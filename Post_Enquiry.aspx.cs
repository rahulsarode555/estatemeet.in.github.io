using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;//Remove later
using System.Net;//Remove later
using System.Net.Mail;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Collections.Specialized;

public partial class Post_Enquiry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    bool validate_Input()
    {
        string str_Cust_Name = txt_Name.Value.Trim();
        string str_Mobile_No = txt_Mobile.Value.Trim();

        string str_Enquiry_For = Page.Request.Form["lst_Enquiry_For"];
        string str_Property_Type = Page.Request.Form["lst_Property_Type"];
        string str_Property_Sub_Type = "";
        string str_Sale_Type = Page.Request.Form["lst_Sale_Type"];
        string str_Construction_Status = Page.Request.Form["lst_Construction_Status"];
        string str_Bed_Rooms = Page.Request.Form["lst_Bed_Rooms"];
        string str_Location = list_Location.Text;
        string str_Carpet_Area_Min = txt_Area_Min.Value.Trim();
        string str_Carpet_Area_Max = txt_Area_Max.Value.Trim();
        string str_Carpet_Area_Unit = lst_Built_Up_Area_Unit.Value;
        string str_Budget_Min = "";// lst_Budget_Min.Text.Trim();
        string str_Budget_Max = "";// lst_Budget_Max.Text.Trim();
        string str_Deal_Closing = lst_Deal_Closing.Value;
        bool validate_Input = true;

        if (str_Property_Type == "Residential")
        {
            str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Residential"].ToString();
        }
        else
        {
            str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Commercial"].ToString();
        }

        if (str_Enquiry_For == "On Rent")
        {
            str_Budget_Min = Page.Request.Form["lst_Budget_Min_Rent"].Trim();
            str_Budget_Max = Page.Request.Form["lst_Budget_Max_Rent"].Trim();
        }
        else
        {
            str_Budget_Min = Page.Request.Form["lst_Budget_Min"].Trim();
            str_Budget_Max = Page.Request.Form["lst_Budget_Max"].Trim();
        }




        if (str_Enquiry_For == "Select" || str_Property_Type == "Select" || str_Property_Sub_Type == "Select" || str_Location == "Select" ||
           str_Budget_Min == "Min" || str_Budget_Max == "Max" || lst_Deal_Closing.Value == "Select" ||
           str_Cust_Name == "" || str_Mobile_No == "")
        {
            validate_Input = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter all Compulsary fields !')", true);
        }    
        //else if (str_Enquiry_For == "To Buy" && (str_Sale_Type == "Select" || str_Construction_Status == "Select"))
        else if (str_Enquiry_For == "To Buy" && str_Sale_Type == "Select")
        {
            validate_Input = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Sale Type !')", true);
        }
        else if (chk_TermsNCond.Checked == false)
        {
            validate_Input = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Accept Terms & Conditions !')", true);
        }

        //if (str_Property_Type == "Residential" && str_Bed_Rooms == "Select")
        //{
        //    validate_Input = false;
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Bedrooms')", true);
        //}

        return validate_Input;
    }


    protected void btn_Verify_Email_Click(object sender, EventArgs e)
    {
        bool input_Valid = validate_Input();

        if (input_Valid)
        {
            string str_Mobile_No = "91" + txt_Mobile.Value.Trim();
            string strPassword = "";
            string str_OTP = "";
            Random r = new Random();
            strPassword = r.Next().ToString();//Generate randdom Password

            str_OTP = (strPassword.Length > 3) ? strPassword.Substring(strPassword.Length - 4, 4) : strPassword;
            Session.Add("SessionOTP", str_OTP);

            try
            {
                string Message = "Your Estate Meet OTP is " + str_OTP + ".%n %n www.estatemeet.in";

                using (var wb = new WebClient())
                {
                    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                        {
                        {"apikey" , "iFq1vr78uEY-JqbC4hDfsMIEcazkB8n4960dzSXDpk"},
                        {"numbers" , str_Mobile_No},
                        {"message" , Message},
                        {"sender" , "EsMEET"}
                        });
                    string result = System.Text.Encoding.UTF8.GetString(response);

                    tick_Image.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('OTP sent Sucessfully !')", true);
                    //lbl_Status_Msg_Mobile.Text = result;
                }
            }
            catch (Exception ex)
            {
                //lbl_Status_Msg_Mobile.Text = ex.ToString();
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + ex + "')", true);
                ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Opps! Problem in sending OTP. Please check Internet Connection ! or Contact Admin')", true);
            }
        }
    }

    protected void btn_Submit_Form_Click(object sender, EventArgs e)
    {
        string strOTP = txtOTP.Value;

        long Record_No = 1;
        string str_Cust_Name = txt_Name.Value;
        string str_Mail_ID = txt_Email.Value;
        string str_Mobile_No = txt_Mobile.Value;
        string str_Address = "";// txt_Address.Value;
        string str_Enquiry_For = Page.Request.Form["lst_Enquiry_For"];
        string str_Property_Type = Page.Request.Form["lst_Property_Type"];
        string str_Property_Sub_Type = "";
        string str_Sale_Type = Page.Request.Form["lst_Sale_Type"];
        string str_Construction_Status = Page.Request.Form["lst_Construction_Status"];
        string str_Bed_Rooms = Page.Request.Form["lst_Bed_Rooms"];
        string str_Location = ""; // list_Location.Text;
        string str_Specific_Location = "";
        string str_Carpet_Area_Min = txt_Area_Min.Value;
        string str_Carpet_Area_Max = txt_Area_Max.Value;
        string str_Carpet_Area_Unit = lst_Built_Up_Area_Unit.Value;
        string str_Budget_Min = "";
        string str_Budget_Max = "";
        string str_Deal_Closing = lst_Deal_Closing.Value;
        string str_Other_Desc = txt_Desc.Value.Trim();
        DateTime dt_Posted_Date = DateTime.Now;

        


        if ((Page.Request.Form["chk_Location"] == null))
        {
            foreach (ListItem item in list_Location.Items)
            {
                if (item.Selected)
                {
                    str_Location += item.Value.Trim() + ", ";
                }
            }
            
            str_Location = str_Location.Substring(0, str_Location.Length - 2);
        }
        else
            str_Location = Page.Request.Form["txt_Location"].Trim();

        

        if (str_Property_Type == "Residential")
        {
            str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Residential"].ToString();
        }
        else
        {
            str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Commercial"].ToString();
        }

        if (str_Enquiry_For == "On Rent")
        {
            str_Budget_Min = Page.Request.Form["lst_Budget_Min_Rent"].Trim();
            str_Budget_Max = Page.Request.Form["lst_Budget_Max_Rent"].Trim();
        }
        else
        {
            str_Budget_Min = Page.Request.Form["lst_Budget_Min"].Trim();
            str_Budget_Max = Page.Request.Form["lst_Budget_Max"].Trim();
        }

        if (str_Deal_Closing == "Select")
            str_Deal_Closing = "-";

        if (Session["SessionOTP"] != null && validate_Input())
        {
            if (Session["SessionOTP"].ToString() == strOTP)
            {
                string sqlCommand = "";
                var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();

                try
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    //Open Conncetion   
                    conn.Open();

                    cmd.CommandText = "SELECT max (Record_No) FROM [Buy_Rent_Enquiry]";

                    if (cmd.ExecuteScalar() != DBNull.Value)//check for empty Database
                    {
                        Record_No = Convert.ToInt64(cmd.ExecuteScalar()) + 1;
                    }
                    else
                        Record_No = 1;

                    sqlCommand = "INSERT INTO [Client_Info]([Record_No], [Record_Type], [Cust_Name], [Mail_ID], [Mobile_No]) " +
                                            "VALUES(" + Record_No + ",'" + "Enquiry" + "','" + str_Cust_Name + "','" + str_Mail_ID + "','" + str_Mobile_No + "')";

                    cmd.CommandText = sqlCommand;

                    cmd.ExecuteNonQuery();


                    sqlCommand = "INSERT INTO [Buy_Rent_Enquiry]([Record_No], [Email_ID], [Enquiry_For], [Property_Type], [Property_Sub_Type], " +
                                "[Sale_Type], [Construction_Status], [Bed_Rooms], [Location], [Specific_Location], [Carpet_Area_Min], [Carpet_Area_Max], " +
                                "[Carpet_Area_Unit], [Budget_Min], [Budget_Max], [Deal_Closing], [Othre_Desc], [Posted_Date]) " +
                                "VALUES(" + Record_No + ",'" + str_Mail_ID + "','" + str_Enquiry_For + "','" + str_Property_Type + "','" + str_Property_Sub_Type +
                                "','" + str_Sale_Type + "','" + str_Construction_Status + "','" + str_Bed_Rooms + "','" + str_Location + "','" + str_Specific_Location +
                                    "','" + str_Carpet_Area_Min + "','" + str_Carpet_Area_Max + "','" + str_Carpet_Area_Unit + "','" + str_Budget_Min + "','" + str_Budget_Max +
                                    "','" + str_Deal_Closing + "','" + str_Other_Desc + "','" + dt_Posted_Date + "')";

                    cmd.CommandText = sqlCommand;

                    cmd.ExecuteNonQuery();

                    lbl_Status_Msg.Text = "Enquiry posted successfully!";
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Enquiry posted successfully!')", true);
                    tick_Image.Visible = false;

                    list_Location.SelectedIndex = 0;                   

                    lst_Deal_Closing.SelectedIndex = 0;
                    chk_TermsNCond.Checked = false;
                    txt_Name.Value = "";
                    txt_Mobile.Value = "";
                    txt_Email.Value = "";
                    txtOTP.Value = "";

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");

                    mail.From = new MailAddress("admin@estatemeet.in");
                    mail.To.Add(new MailAddress("admin@estatemeet.in"));
                    mail.Subject = "New Enquiry posted";//change the subject later
                    mail.Body = "       Dear " + "Kalpesh Sir" + "\n\n Mr. " + str_Cust_Name + " has posted new Enquiry on BrokerPluss.com";
                    mail.Body += "\n\n Mobile No :- " + str_Mobile_No;
                    mail.Body += "\n\n Address :- " + str_Location;

                    SmtpServer.Port = 25;
                    //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("admin@estatemeet.in", "Admin123$$$");
                    //SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);


                }
                catch (Exception ex)
                {
                    lbl_Status_Msg.Text = "Opps! Something has gone wrong!" + ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
                lbl_Status_Msg.Text = "Incorrect OTP";
        }
        else
        {
            lbl_Status_Msg.Text = "Plese send OTP on your Email Id";
        }

    }//Submit end
}