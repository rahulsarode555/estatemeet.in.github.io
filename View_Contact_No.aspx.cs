using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Configuration;


public partial class View_Contact_No : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
            string strName = txt_Cust_Name.Value;
            string To_Email = txt_Email.Value.Trim();
            string strPassword = "";
            string str_OTP = "";
            Random r = new Random();
            strPassword = r.Next().ToString();//Generate randdom Password
            //strPassword = "123";
            str_OTP = (strPassword.Length > 3) ? strPassword.Substring(strPassword.Length - 4, 4) : strPassword;
            Session.Add("SessionOTP", str_OTP);
            Session.Timeout = 10;

            Mail_Password(To_Email, str_OTP, strName);
            tick_Image.Visible = true;
        }
    }

    void Mail_Password(string To_Email, string strPassword, string UserName)
    {
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.googlemail.com");

            mail.From = new MailAddress("brokerpluss.services@gmail.com");
            mail.To.Add(new MailAddress(To_Email));
            mail.Subject = "OTP for Email Varification";
            mail.Body = "       Dear " + UserName + "\n\n Welcome to Brokerpluss.com \n\n Your OTP is '"
                        + strPassword + "'  & is valid for 10 minutes.";

            SmtpServer.Port = 25;
            SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
            SmtpServer.Credentials = new System.Net.NetworkCredential("brokerpluss.services@gmail.com", "admin$$$");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            tick_Image.Visible = true;


        }
        catch (Exception ex)
        {
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + ex + "')", true);
        }
    }


    protected void btn_View_Contact_Click(object sender, EventArgs e)
    {
         string strOTP = txtOTP.Value;

         if (Session["SessionOTP"] != null)
         {
            if (Session["SessionOTP"].ToString() == strOTP)
            {
                 demo.Style.Add("Visibility", "Hidden");
                 div_Contact.Style.Add("Visibility", "Visible");
            }
            else
            {
                lblMessage.Text = "Incorrect OTP";
            }            
        }
        else
        {
            lblMessage.Text = "Plese send OTP on your Email Id";
        }            
    }
}