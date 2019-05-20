using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class View_Rent_Prop : System.Web.UI.Page
{
    protected static string html = "";
    protected string btn_Html = "";
    protected string str_Posted_By;
    protected string str_Property_Type;
    protected string str_Property_Sub_Type;
    protected string str_Furnised_Status;
    protected string str_Location;
    protected string str_Address;
    protected string str_Built_Up_Area;
        protected string str_Carpet_Area;
        protected string str_Rent_Per_Month;
        protected string str_Deposit;
        protected string str_Bedrooms;
        protected string str_Bathrooms_Or_Washroom = "";
        //string str_Balconies = lst_Balconies.Value;
        protected string str_Total_Floors;
        protected string str_Property_on_Floor;
        protected string str_Reserved_Parking;

        protected string str_Rent_Out_To;
        protected string str_Agr_Duration;
        protected string str_Avai_From;
        protected string str_Desc;

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
            string str_Record_No = Request.QueryString.Get("prn").Trim();

            var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

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
                        str_Posted_By = (string)reader["C_Type"];
                        str_Property_Type = (string)reader["Bedrooms"] + " " + (string)reader["Property_Type"];
                        str_Property_Sub_Type = (string)reader["Property_SubType"];
                        str_Furnised_Status = (string)reader["Furnished_Status"];

                        str_Location = (string)reader["Location"];

                        str_Built_Up_Area = reader["Built_Up_Area"].ToString().Trim();

                        if (str_Built_Up_Area == "")
                            str_Built_Up_Area = "-";
                        else
                            str_Built_Up_Area += " Sq.Ft";//later check for Sq.Mtr.

                        str_Carpet_Area = reader["Carpet_Area"].ToString().Trim();

                        if (str_Carpet_Area == "")
                            str_Carpet_Area = "-";
                        else
                            str_Carpet_Area += " Sq.Ft";//later check for Sq.Mtr.

                        str_Rent_Per_Month = (string)reader["Rent_Per_Month"];
                        str_Deposit = (string)reader["Deposit"];
                        str_Property_on_Floor = (string)reader["Property_on_Floor"];
                        str_Total_Floors = (string)reader["Total_Floors"];
                        str_Reserved_Parking = (string)reader["Reserved_Parking"];
                        str_Bedrooms = (string)reader["Bedrooms"];
                        str_Bathrooms_Or_Washroom = (string)reader["Bathrooms_Or_Washroom"];
                        str_Rent_Out_To = (string)reader["Rent_Out_To"];
                        str_Agr_Duration = (string)reader["Agreement_Duration"];
                        str_Avai_From = (string)reader["Available_From"];

                        str_Desc = reader["Other_Desc"].ToString().Trim();                        
                        if (str_Desc == "")
                            str_Desc = "-";

                        if ((string)reader["Image_Path"] != "")
                        {
                            i = 1;
                            html += "<img class='mySlides' src='" + (string)reader["Image_Path"].ToString().Trim() + "' alt = 'Image' style='width:100%' />";
                            btn_Html += "<button class='w3-button demo' onclick='currentDiv(1)'><img src='" + (string)reader["Image_Path"] + "' alt = 'Image' style='height:40px' /></button> ";
                        }
                    }
                }

                conn.Close();

                conn.Open();


                cmd.CommandText = "SELECT * FROM [Rent_Photos] where [Record_No] = " + str_Record_No;

                reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    
                    while (reader.Read()) 
                    {
                        i++;
                        if ((string)reader["Image_Path"] != "")
                        {
                            html += "<img class='mySlides' src='" + (string)reader["Image_Path"].ToString().Trim() + "' alt = 'Image' style='width:100%' />";
                            btn_Html += "<button class='w3-button demo' onclick='currentDiv(" + i + ")'><img src='" + (string)reader["Image_Path"] + "' alt = 'Image' style='height:40px' /></button> ";
                        }
                       
                    }
                }
                
            }
            catch (Exception ex)
            {
                //lbl_Message.Text = "Something went wrong !";
            }
            finally
            {
                conn.Close();
            }

        }//if end

    }//refresh end

}