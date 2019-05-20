using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class Login_Page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["Email"] != null)// Logged IN
            {
                Server.Transfer("admin_control.aspx");
            }
        }

    }
    protected void Submit_Click(object sender, EventArgs e)
    {

        string emailID = txtMailID.Value.Trim();
        string passWord = txtPassword.Value.Trim();

        if (emailID == "" || passWord == "")
        {
            labelErrorMsg.Text = "Hello ! ID or Password should not be blank";
        }
        else
        {
            //Create Connection obj
            var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            bool clientIDExists = false;
            bool exceptionExists = false;
            try
            {

                cmd.CommandText = "SELECT [Password] FROM [Admin_Member_Info] WHERE [Member_ID] = '" + emailID + "'";//use where later
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                //Open Conncetion   
                conn.Open();
                Object obj = cmd.ExecuteScalar();
                if (obj != DBNull.Value && obj != null)//check for empty Database
                {
                    if (passWord == obj.ToString().Trim())
                    {
                        clientIDExists = true;
                    }

                }

            }
            catch (Exception ex)
            {
                exceptionExists = true;
            }
            finally
            {
                conn.Close();

                if (exceptionExists)
                {
                    labelErrorMsg.Text = "Opps ! Something has gone wrong! Please try again!";
                }
                else if (clientIDExists)
                {
                    labelErrorMsg.Text = "Login Successful";
                    Session.Add("Email", emailID);
                    Session.Timeout = 30;//check on google for setting. Do some R n D on session

                    Server.Transfer("admin_control.aspx");
                }
                else
                {
                    labelErrorMsg.Text = "Enter correct Id or password";
                }
            }
        }//else closed
    }

}