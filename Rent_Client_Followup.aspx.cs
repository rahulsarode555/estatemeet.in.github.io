using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Rent_Client_Followup : System.Web.UI.Page
{
    protected static string html = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            refresh_Page(sender, e);
        }
    }

    protected void refresh_Page(object sender, EventArgs e)
    {
        html = "";
        int i = 0;

        if (Request.QueryString.Get("prn") != null)
        {
            string str_Record_No = Request.QueryString.Get("prn").Trim(); ;

            SqlConnection conn = new SqlConnection
            ("Server=(localdb)\\COMPinst; Database = Broker_Plus;Trusted_Connection=true;");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            string str_Command;

            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                str_Command = "SELECT * FROM [Rent_Basic_Info], [Rent_Other_Desc] where [Rent_Basic_Info].[Record_No] = Rent_Other_Desc.[Record_No] and [Rent_Basic_Info].[Record_No] = " + str_Record_No;
                cmd.CommandText = str_Command;

                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                     //   str_Posted_By = (string)reader["C_Type"];
                     //   str_Property_Type = (string)reader["Property_Type"];
                        if ((string)reader["Image_Path"] != "")
                        {
                            i = 1;
                            html += "<img src='" + (string)reader["Image_Path"] + "' alt = 'Image' style='width:100%' />";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbl_Status_Msg.Text = "Something went wrong !";
            }
            finally
            {
                conn.Close();
            }

        }

    }//refresh Closed

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        lbl_Status_Msg.Text = "Thank you for your valuable feedback";
    }
}