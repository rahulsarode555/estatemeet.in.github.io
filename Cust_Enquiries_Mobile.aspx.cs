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
public partial class Cust_Enquiries_Mobile : System.Web.UI.Page
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
        

    protected void refresh_Page(object sender, EventArgs e)
    {
        html = "";
        int i = 0;


        var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string str_Command = "SELECT * FROM [Buy_Rent_Enquiry] where";

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();

            //Property_Type check
            if (lst_Properyt_Type.Text == "all")
                str_Command += "";
            else
                str_Command += " [Property_Sub_Type] = '" + lst_Properyt_Type.Text.Trim() + "' and";

            //Location check
            if (list_Location.Text.Trim() == "all" || list_Location.Text == "")
                str_Command += "";
            else
                str_Command += " [Location] = '" + list_Location.Text + "' and";

            //Posted By Check
            //if (lst_Posted_By.Text == "all")
            //    str_Command += "";
            //else
            //    str_Command += " [C_Type] = '" + lst_Posted_By.Text + "' and";
            

            str_Command += " Record_No > 0  order by [Posted_Date] DESC";
            
            
            cmd.CommandText = str_Command;

            reader = cmd.ExecuteReader();

           
            if (reader.HasRows)
            {


                i = 1;
                while (reader.Read())
                {
                    html += "</br>";
                    html += "<div class='div_Search_Result' style='background-color:rgb(226, 229, 233)' >";

                    html += "<label class='lbl_Header_Mobile'>Required " + (string)reader["Property_Type"] + " Property " + (string)reader["Enquiry_For"] + "</label>";

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
                    
                    if (str_Prop_Img != "")
                    {
                        html += "</br><center><img style='max-width:100%;max-height:200px;padding:10px 0px 10px 0px' src='" + str_Prop_Img + "' alt = 'Image' /></center>";
                    }

                    html += "<center> <table> ";

                    html += "<tr> <td> Location </td> <td>: " + (string)reader["Location"] + "</td> </tr>";
                    html += "<tr> <td> Requirement </td> <td>: " + (string)reader["Property_Sub_Type"] + "</td> </tr>";
                    
                    if ((string)reader["Property_Type"].ToString().Trim() == "Residential")
                    {
                        html += "<tr> <td> Details </td> <td>: " + (string)reader["Bed_Rooms"] + "</td> </tr>";
                    }

                    html += "<tr> <td> Budget </td> <td>: Min - " + (string)reader["Budget_Min"] + "&nbsp;&nbsp;&nbsp;&nbsp;Max - " + (string)reader["Budget_Max"] + "</td></tr>";

                    html += "</table> </center>";

                    html += "<div style='height:30px;margin:10px'> <center> ";
                    html += "<input id='Button1' type='button' value='Contact Us/Show Interest'  onclick=\"makePopUpVisible('_Mobile');\" /> &nbsp; <a href='Cust_Enquiry_Details.aspx?prn=" + reader["Record_No"] + "'> Full Details</a>";
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
                html += "</div> <br/>";
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