using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Configuration;
using System.Collections.Generic;
using System.Collections.Specialized;

public partial class Properties_For_Rent : System.Web.UI.Page
{
    protected static string html = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            html = "";
            if (Utils.fBrowserIsMobile())
            {
                // go to mobile pages
                Server.Transfer("Properties_For_Rent_Mobile.aspx");
                
            }
            else
                refresh_Page(sender, e);
            
        }
    }

    protected void change_Budget(object sender, EventArgs e)
    {
        //SqlDataSource2.SelectCommand = "SELECT * FROM [Sell_Budget_Max] WHERE [ID] > " + lst_Budget_Min.SelectedValue;
        refresh_Page(sender, e);
    }

    protected void refresh_Page(object sender, EventArgs e)
    {
        html = "";
        int i = 0;

        string str_Admin_Rights = "";
        bool bool_DNS_Rec = false;
        bool bool_Show_Image = true;
        
        //string str_Final = "";
        
        //str_Final = str_Demo.Replace("5Y","5N");


        var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string str_Command = "SELECT * FROM [Rent_Basic_Info], [Rent_Other_Desc] where";

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();

            //Property_Type check
            if (lst_Properyt_Type.Text == "all")
                str_Command += "";
            else
                str_Command += " [Property_SubType] = '" + lst_Properyt_Type.Text.Trim() + "' and";

            //Location check
            if (list_Location.Text == "all")
                str_Command += "";
            else
                str_Command += " [Location] = '" + list_Location.Text + "' and";           
           
            //Posted By Check
            if (lst_Posted_By.Text == "all")
                str_Command += "";
            else
                str_Command += " [C_Type] = '" + lst_Posted_By.Text + "' and";

           
            str_Command += " [Rent_Basic_Info].Record_No = [Rent_Other_Desc].Record_No order by [Posted_Date] DESC";
            
            
            cmd.CommandText = str_Command;

            reader = cmd.ExecuteReader();

           
            if (reader.HasRows)
            {                
                i = 1;
                while (reader.Read())
                {
                    bool_DNS_Rec = false;
                    if (reader["Admin_Rights"] != DBNull.Value)
                    {
                        str_Admin_Rights = (string)reader["Admin_Rights"];
                        bool_DNS_Rec = str_Admin_Rights.Contains("DNS");

                        if (str_Admin_Rights.Contains("7N"))
                            bool_Show_Image = false;
                    }

                    if (!bool_DNS_Rec)
                    {
                        html += "</br>";
                        html += "<div style='position:relative;left:350px;width:700px;Border:solid 1px grey;background-color:rgb(226, 229, 233)'>";
                        html += "<table border='0' style='margin-left:15px;font-family:Bookman Old Style'>";
                        html += "<div class='div_Rent'> Rent : " + (string)reader["Rent_Per_Month"] + "/ Month </div>";

                        html += "<tr style='height:40px' >";
                        html += "<td colspan='2' style='font-size:24px;'>";
                        html += (string)reader["Property_Type"] + " Property in " + (string)reader["Location"] + "on Rent";
                        html += "</td>";
                        html += "</tr >";


                        html += "<tr >";
                        html += "<td style='width:300px'>";
                       // if ((string)reader["Image_Path"] != "" && bool_Show_Image)
                        {
                            html += "&nbsp;&nbsp; <img style='max-width:250px;max-height:150px' src='" + (string)reader["Image_Path"] + "' alt = 'Image'  onerror='this.src = \"Site_Images/DummyImage.jpg\"' />";
                        }
                        html += "</td>";

                        html += "<td style='width:250px'>";

                        html += "Property : " + (string)reader["Property_SubType"];

                        if ((string)reader["Property_Type"] == "Residential")
                        {
                            html += "</br> Details : " + (string)reader["Bedrooms"];
                        }

                        html += "</br> Area : " + (string)reader["Carpet_Area"] + "Sq. Ft.";
                        html += "</br> Floor : " + (string)reader["Property_on_Floor"] + "Out of " + (string)reader["Total_Floors"];

                        html += "</td>";

                        html += "</tr>";

                        html += "<tr style='height:40px'>";
                        html += "<td colspan='2' style='font-size:20px'> <center>";
                        html += "<input id='Button1' type='button' value='Contact Us/Show Interest'  onclick=\"makePopUpVisible('_Desktop');\" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href='View_Rent_Prop.aspx?prn=" + reader["Record_No"] + "'> Full Details </a>";
                        //html += "<asdsasp:Button ID=\"Button1\" runat=\"server\" Text=\"Button\" />";
                        html += "</center> </td>";
                        html += "</tr>";

                        html += "</table>";
                        html += "</div> ";
                        i++;
                    }
                }//close while
                html += "</br>";

            }
            else
            {
                html += "</br> <div style='position:relative;left:350px;height:250px;width:600px;border:solid 1px gray;font-family:Bookman Old Style;font-size:large'>";
                html += "<center> </br> </br>";
                html += "No Property available. Please Modify your Search!";
                html += "</center>";
                html += "</div> </br>";
            }

        }
        catch (Exception ex)
        {
            lbl_Message.Text = "Something went wrong !" + ex;
        }
        finally
        {
            conn.Close();
        }
    }

    bool validate_Input()
    {
        string str_Cust_Name = txt_Cust_Name.Value.Trim();
        string str_Mail_ID = txt_Email.Value.Trim();
        string str_Mobile_No = txt_Mobile.Value.Trim();
        //string strOTP = txtOTP.Value.Trim();

        bool validate_Input = true;

        if (str_Cust_Name == "" || str_Mobile_No == "" || str_Mail_ID == "")
        {
            validate_Input = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter all Compulsary fields !')", true);
        }
        else if (chk_TermsNCond.Checked == false)
        {
            validate_Input = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Accept Terms & Conditions !')", true);
        }
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
                   
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");

                    mail.From = new MailAddress("admin@estatemeet.in");
                    mail.To.Add(new MailAddress("admin@estatemeet.in"));

                    mail.Subject = "Property viewed for Rent";

                    mail.Body = "       Dear " + "Kalpesh Sir" + "\n\n Mr. " + txt_Cust_Name.Value + " has viewed Property on estatemeet.in";
                    mail.Body += "\n\n Mobile No :- " + str_Mobile_No;
                    //mail.Body += "\n\n Address :- " + str_Location;

                    SmtpServer.Port = 25;
                    //SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("admin@estatemeet.in", "Admin123$$$");
                    //SmtpServer.EnableSsl = true;

                    SmtpServer.Send(mail);
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

    protected void btn_View_Contact_Click(object sender, EventArgs e)
    {
        //Session.Add("SessionOTP", "123");
        string strOTP = txtOTP.Value;

        if (Session["SessionOTP"] != null)
        {
            if (Session["SessionOTP"].ToString() == strOTP)
            {

                div_Contact.Visible = true;
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Please enter correct OTP";
            }
        }
        else
        {
            lblMessage.Text = "Plese send OTP on your Mobile";
        }
    }
}