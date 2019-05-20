using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;


public partial class Test_SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }    

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
        // String message = HttpUtility.UrlEncode("This is your message");
            String message = "OTP is 1290";
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    {
                    {"apikey" , "iFq1vr78uEY-JqbC4hDfsMIEcazkB8n4960dzSXDpk"},
                    {"numbers" , "919112073377"},
                    {"message" , message},
                    {"sender" , "TXTLCL"}
                    });
                string result = System.Text.Encoding.UTF8.GetString(response);
                lbl1.Text = result;
            }
       
        }
        catch (Exception ex)
            {
                lbl1.Text = ex.ToString();
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('" + ex + "')", true);
                //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Opps! Problem in sending OTP. Please check Internet Connection ! or Contact Admin')", true);
            }
        }
    }
