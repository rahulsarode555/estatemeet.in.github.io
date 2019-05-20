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

public partial class Cust_Enquiries : System.Web.UI.Page
{
    protected static string html = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Utils.fBrowserIsMobile())
            {
                // go to mobile pages
                Server.Transfer("Cust_Enquiries_Mobile.aspx");

            }
            else
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
            string str_Command = "SELECT * FROM [Buy_Rent_Enquiry] order by [Posted_Date] DESC";

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();

                cmd.CommandText = str_Command;

                reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {


                    i = 1;
                    while (reader.Read())
                    {
                        html += "</br>";
                        html += "<center> <div style='width:600px;Border:solid 1px grey;background-color:rgb(226, 229, 233)'>";
                        html += "<table border='0' style='margin-left:15px;font-family:Arial'>";

                        html += "<tr style='height:40px' >";
                        html += "<td colspan=3 style='font-size:25px'>";
                        html += "Required " + (string)reader["Property_Type"] + " Property " + (string)reader["Enquiry_For"];
                        html += "</td>";
                        html += "</tr >";


                        html += "<tr >";

                        html += "<td style='width:120px'>";

                        html += "</br> Location ";
                        html += "</br> Requirement";

                        if (reader["Bed_Rooms"].ToString().Trim() != "")
                            html += "</br> BHK";

                        html += "</br> Budget <br/><br/>";


                        html += "</td>";

                        html += "<td>";
                        html += "</br> : &nbsp;&nbsp;" + (string)reader["Location"];
                        html += "</br> : &nbsp;&nbsp;" + (string)reader["Property_Sub_Type"];

                        if (reader["Bed_Rooms"].ToString().Trim() != "")
                            html += "</br> : &nbsp;&nbsp;" + (string)reader["Bed_Rooms"];

                        string str_lbl1 = "";
                        string str_lbl2 = "";
                        if (reader["Budget_Min"].ToString().Trim() == "1")
                        {
                            str_lbl1 = "Not Specified";
                        }
                        else
                            str_lbl1 = (string)reader["Budget_Min"];

                        if (reader["Budget_Max"].ToString().Trim() == "2")
                        {
                            str_lbl2 = "Not Specified";
                        }
                        else
                            str_lbl2 = (string)reader["Budget_Max"];

                        html += "</br> : &nbsp;&nbsp;Min - " + str_lbl1 + "&nbsp;&nbsp;&nbsp;&nbsp;Max - " + str_lbl2;

                        html += "<br/><br/>";

                        html += "</td>";

                        html += "<td>";

                        string str_Prop_Img = "";

                        if (reader["Property_Sub_Type"].ToString().Trim() == "Flat")
                        {
                            str_Prop_Img = "Site_Images/Sub_Type/flat.png";
                        }
                        else if (reader["Property_Sub_Type"].ToString().Trim() == "Office")
                        {
                            str_Prop_Img = "Site_Images/Sub_Type/Office.png";
                        }
                        else if (reader["Property_Sub_Type"].ToString().Trim() == "Shop")
                        {
                            str_Prop_Img = "Site_Images/Sub_Type/Shop.png";
                        }
                        else if (reader["Property_Sub_Type"].ToString().Trim() == "Independant Villa")
                        {
                            str_Prop_Img = "Site_Images/Sub_Type/villa.png";
                        }
                        else if (reader["Property_Sub_Type"].ToString().Trim() == "Space for Bank")
                        {
                            str_Prop_Img = "Site_Images/Sub_Type/Bank.png";
                        }
                        else if (reader["Property_Sub_Type"].ToString().Trim() == "Restaurent")
                        {
                            str_Prop_Img = "Site_Images/Sub_Type/restaurant.png";
                        }
                        else if (reader["Property_Sub_Type"].ToString().Trim() == "Independant Building")
                        {
                            str_Prop_Img = "Site_Images/Sub_Type/Building.png";
                        }

                        html += "<img src='" + str_Prop_Img + "' alt='' style='width:150px'";

                        html += "</td>";

                        html += "</tr>";

                        html += "<tr style='height:50px'>";

                        html += "<td style='font-size:20px'> <center>";
                        //html += "<a href=''> I Can Help </a>";
                        html += "</center> </td>";

                        html += "<td style='font-size:20px'> <center>";
                        html += "<input id='Button1' type='button' value='Contact Us/Show Interest'  onclick=\"makePopUpVisible('_Desktop');\" /> &nbsp;&nbsp;&nbsp;&nbsp;<a href='Cust_Enquiry_Details.aspx?prn=" + reader["Record_No"] + "'> Full Details </a>";
                        html += "</center> </td>";

                        html += "<td style='font-size:20px'> <center>";
                        //html += "<a href=''> Call Us </a>";
                        html += "</center> </td>";

                        html += "</tr>";

                        html += "</table>";
                        html += "</div> </center>";
                        i++;
                    }
                    html += "</br>";

                }
                else
                {
                    html += "</br> <div style='position:relative;left:350px;height:250px;width:600px;border:solid 1px gray;font-family:Bookman Old Style;font-size:large'>";
                    html += "<center> </br> </br>";
                    html += "No data available. Please Modify your Search!";
                    html += "</center>";
                    html += "</div> </br>";
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
        demo.Visible = false;
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

                    mail.Subject = "Property viewed for Enquiry";

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