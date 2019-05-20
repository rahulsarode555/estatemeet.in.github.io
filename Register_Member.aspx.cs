using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Configuration;

public partial class Register_Member : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        long Member_ID = 1;
        string str_Member_Name = txt_Member_Name.Value;
        string str_Email_ID = txt_Email_ID.Value.Trim();
        string str_Mobile_NO = txt_Mobile_NO.Value;
        string str_Password = txt_Pwd.Value.Trim();
        string str_Repeat_Pwd = txt_Repeat_Pwd.Value.Trim();

        if (str_Member_Name == "" || str_Mobile_NO == "" || str_Email_ID == "" || str_Password == "" || str_Repeat_Pwd == "")
        {
            labelStatusMsg.Text = "Enter All fields";
        }
        else
        {

            var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            bool clientIDExists = false;
            bool exceptionExists = false;

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                conn.Open(); //Open Conncetion   

                //check for Email ID already exists or not
                cmd.CommandText = "SELECT [Member_ID] FROM [Member_Info] WHERE [Email_ID] ='" + str_Email_ID + "'";
                reader = cmd.ExecuteReader();

                if (reader.HasRows) //returns true if Email ID is present
                {
                    clientIDExists = true;
                }
                conn.Close();

                if (clientIDExists == false) //new Email ID 
                {
                    conn.Open();

                    cmd.CommandText = "SELECT max (Member_ID) FROM [Member_Info]";
                    if (cmd.ExecuteScalar() != DBNull.Value)//check for empty Database
                    {
                        Member_ID = Convert.ToInt64(cmd.ExecuteScalar()) + 1;
                    }
                    else
                        Member_ID = 1;


                    string insertCMD = "INSERT INTO [Member_Info](Member_ID, Member_Name, Email_ID, Mobile_No) " +
                                   "VALUES(" + Member_ID + ",'" + str_Member_Name + "','" + str_Email_ID + "','" + str_Mobile_NO + "')";

                    cmd.CommandText = insertCMD;
                    cmd.ExecuteNonQuery();

                    //More code will be inserted here later

                    //Random r = new Random();
                    //strPassword = r.Next().ToString();//Generate randdom Password

                    insertCMD = "INSERT INTO [Admin_Member_Info] ([Member_ID], [Password], [Joinging_Date]) " +
                                "VALUES('" + str_Email_ID + "','" + str_Password + "','" + DateTime.Today + "')";

                    cmd.CommandText = insertCMD;
                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('Something went wrong');</script>");
                exceptionExists = true;
                labelStatusMsg.Text = "Something went wrong !" + ex;
            }
            finally
            {
                conn.Close();

                if (exceptionExists == false && clientIDExists == false)
                {
                    // Mail_Password(Email, strPassword, Name);
                    // Server.Transfer("RegistrationMessage.aspx");
                    labelStatusMsg.Text = "Member created Successfully !";
                }
                else
                {
                    if (clientIDExists == true)
                        labelStatusMsg.Text = "Email-ID already registered, Please use another Email-ID !";
                    else
                        labelStatusMsg.Text = "Something went wrong !";
                }
        
            }//finally Closed
    
        }//else Closed
    
    }//Submit Closed


}