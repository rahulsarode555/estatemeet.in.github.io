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
using System.Globalization;

public partial class Buy_Property_Mobile : System.Web.UI.Page
{
    protected static string html = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            html = "";
            refresh_Page(sender, e);
        }
    }

    protected void change_Budget(object sender, EventArgs e)
    {
        SqlDataSource2.SelectCommand = "SELECT * FROM [Sell_Budget_Max] WHERE [ID] > " + lst_Budget_Min.SelectedValue;
        refresh_Page(sender, e);
    }

    protected void refresh_Page(object sender, EventArgs e)
    {
        html = "";
        int i = 0;


        var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string str_Command = "SELECT * FROM [Sell_Basic_Info], [Sell_Other_Desc] where";

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

            //Availibility
            if (lst_Construction_Status.Text == "all")
                str_Command += "";
            else
                str_Command += " [Construction_Status] = '" + lst_Construction_Status.Text.TrimEnd().TrimStart() + "' and";

            //Budget Check
            if (lst_Budget_Min.SelectedValue == "1" || lst_Budget_Min.SelectedValue == "")
                str_Command += "";
            else
                str_Command += " [Expected_Price] >= " + lst_Budget_Min.SelectedValue + " and";

            if (lst_Budget_Max.SelectedValue == "2" || lst_Budget_Max.SelectedValue == "")
                str_Command += "";
            else
                str_Command += " [Expected_Price] <= " + lst_Budget_Max.SelectedValue + " and";

            //Posted By Check
            if (lst_Posted_By.Text == "all")
                str_Command += "";
            else
                str_Command += " [C_Type] = '" + lst_Posted_By.Text + "' and";

            //Sale Type Cheack  
            if (lst_Sale_Type.Text == "all")
                str_Command += "";
            else
                str_Command += " [Sale_Type] = '" + lst_Sale_Type.Text + "' and";


            str_Command += " [Sell_Basic_Info].Record_No = [Sell_Other_Desc].Record_No order by [Posted_Date] DESC";
            
            
            cmd.CommandText = str_Command;

            reader = cmd.ExecuteReader();

           
            if (reader.HasRows)
            {


                i = 1;
                while (reader.Read())
                {
                    html += "</br>";
                    html += "<div class='div_Search_Result' style='background-color:rgb(226, 229, 233)' >";

                    
                    //html += "<div class='div_Price'> Price : " + (string)reader["Expected_Price"] + " </div>";

                    html += "<label class='lbl_Header_Mobile'>" + (string)reader["Property_Type"] + " Property in " + (string)reader["Location"] + "</label>";
                                       
                  //  if ((string)reader["Image_Path"] != "")
                    {
                        html += "</br><center><img style='max-width:100%;max-height:200px;padding:10px 0px 10px 0px' src='" + (string)reader["Image_Path"] + "' alt = 'Image' onerror='this.src = \"Site_Images/DummyImage.jpg\"' /></center>";
                    }
                    html += "<center> <table> ";

                    html += "<tr> <td> Property </td> <td>: " + (string)reader["Property_SubType"] + "</td> </tr>";
                    html += "<tr> <td> Construction Status </td> <td>: " + (string)reader["Construction_Status"] + "</td> </tr>";
                    if ((string)reader["Property_Type"] == "Residential")
                    {
                        html += "<tr> <td> Details </td> <td>: " + (string)reader["Bedrooms"] + "</td> </tr>";
                    }
                    html += "<tr> <td> Area </td> <td>: " + (string)reader["Built_Up_Area"] + "Sq. Ft.</td> </tr>";
                    html += "<tr> <td> Floor </td> <td>: " + (string)reader["Property_on_Floor"] + "Out of " + (string)reader["Total_Floors"] + "</td> </tr>";

                    string str_Price = (string)reader["Expected_Price"];
                    string str_Formated_Price = "";
                    try
                    {
                        decimal parsed = decimal.Parse(str_Price, CultureInfo.InvariantCulture);
                        CultureInfo hindi = new CultureInfo("hi-IN");
                        str_Formated_Price = string.Format(hindi, "{0:c}", parsed);
                        str_Formated_Price = str_Formated_Price.Remove(str_Formated_Price.Length - 3, 3);
                    }
                    catch (Exception exFor)
                    {
                        str_Formated_Price = str_Price;
                    }

                    html += "<tr> <td> Expected Price </td> <td>: " + str_Formated_Price + "</td> </tr>";

                    html += "</table> </center>";

                    html += "<div style='height:30px;margin:10px'> <center> ";
                    html += "<input id='Button1' type='button' value='Contact Us/Show Interest'  onclick=\"makePopUpVisible('_Mobile');\" /> &nbsp;&nbsp;<a href='View_Sell_Full_details.aspx?prn=" + reader["Record_No"] + "'> Full Details</a>";
                    html += "</center> </div>";
                    html += "</div> ";
                    i++;

                }
                html += "</br>";

            }
            else
            {
                html += "</br> <div class='div_Search_Result lbl_Header_Mobile' style='font-size:large;background-color:rgb(226, 229, 233)'>";
                html += "<center> </br> </br>";
                html += "No Property available.</br></br> Please Modify your Search!";
                html += "</center> </br> </br>";
                html += "</div>";
            }

        }
        catch (Exception ex)
        {
            lbl_Message.Text = "Something went wrong !";
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
                    //lbl_Status_Msg_Mobile.Text = result;

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");

                    mail.From = new MailAddress("admin@estatemeet.in");
                    mail.To.Add(new MailAddress("admin@estatemeet.in"));

                    mail.Subject = "Property viewed to Buy";

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
