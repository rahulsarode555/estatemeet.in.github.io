using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Cust_Enquiry_Details : System.Web.UI.Page
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
            string str_Record_No = Request.QueryString.Get("prn").Trim();
            var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);


            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            string str_Command = "SELECT * FROM [Buy_Rent_Enquiry] WHERE [Record_No] = " + str_Record_No;

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

                    reader.Read();

                    //html += "</br>";
                    html += "<center> <div class='div_Search_Result' style='background-image:url(\"Site_Images/bk.jpg\");'>";
                    html += "<table border='0' style='font-family:Arial'>";

                    html += "<tr style='height:50px' >";
                    html += "<td colspan=3 style='font-size:25px;position:relative'>";
                    html += "Property Required " + (string)reader["Enquiry_For"];

                    //string str_Prop_Img = "";

                    //if (reader["Property_Sub_Type"].ToString().Trim() == "Flat")
                    //{
                    //    str_Prop_Img = "Site_Images/Sub_Type/flat.png";
                    //}
                    //else if (reader["Property_Sub_Type"].ToString().Trim() == "Office")
                    //{
                    //    str_Prop_Img = "Site_Images/Sub_Type/Office.png";
                    //}
                    //else if (reader["Property_Sub_Type"].ToString().Trim() == "Shop")
                    //{
                    //    str_Prop_Img = "Site_Images/Sub_Type/Shop.png";
                    //}
                    //else if (reader["Property_Sub_Type"].ToString().Trim() == "Independant Villa")
                    //{
                    //    str_Prop_Img = "Site_Images/Sub_Type/villa.png";
                    //}
                    //else if (reader["Property_Sub_Type"].ToString().Trim() == "Space for Bank")
                    //{
                    //    str_Prop_Img = "Site_Images/Sub_Type/Bank.png";
                    //}
                    //else if (reader["Property_Sub_Type"].ToString().Trim() == "Restaurent")
                    //{
                    //    str_Prop_Img = "Site_Images/Sub_Type/restaurant.png";
                    //}
                    //else if (reader["Property_Sub_Type"].ToString().Trim() == "Independant Building")
                    //{
                    //    str_Prop_Img = "Site_Images/Sub_Type/Building.png";
                    //}

                    //html += "<img src='" + str_Prop_Img + "' alt='' style='width:120px;position:absolute;top:50px;Right:0px;'>";


                    html += "</td>";
                    html += "</tr >";


                    html += "<tr class='tr_Height' >";
                    
                    html += "<td>";
                    html += "Location ";
                    html += "</td>";

                    html += "<td>:</td>";

                    html += "<td>";
                    html += (string)reader["Location"];
                    html += "</td>";
                    
                    html += "</tr >";


                    html += "<tr class='tr_Height' >";

                    html += "<td>";
                    html += "Requirement ";
                    html += "</td>";

                    html += "<td>:</td>";

                    html += "<td>";
                    html += (string)reader["Property_Sub_Type"];
                    html += "</td>";

                    html += "</tr >";

                    if (reader["Enquiry_For"].ToString().Trim() == "To Buy")
                    {
                        html += "<tr class='tr_Height' >";

                        html += "<td>";
                        html += "Sale Type ";
                        html += "</td>";

                        html += "<td>:</td>";

                        html += "<td>";
                        html += (string)reader["Sale_Type"];
                        html += "</td>";

                        html += "</tr >";


                        html += "<tr class='tr_Height' >";

                        html += "<td>";
                        html += "Availability ";
                        html += "</td>";

                        html += "<td>:</td>";

                        html += "<td>";
                        html += (string)reader["Construction_Status"];
                        html += "</td>";

                        html += "</tr >";
                    }

                    html += "<tr class='tr_Height' >";

                    html += "<td>";
                    html += "Specific Location ";
                    html += "</td>";

                    html += "<td>:</td>";

                    html += "<td>";
                    html += (string)reader["Specific_Location"];
                    html += "</td>";

                    html += "</tr >";

                    if (reader["Bed_Rooms"].ToString().Trim() != "")
                    {
                        html += "<tr class='tr_Height' >";

                        html += "<td>";
                        html += "Bed Rooms ";
                        html += "</td>";

                        html += "<td>:</td>";

                        html += "<td>";
                        html += (string)reader["Bed_Rooms"];
                        html += "</td>";

                        html += "</tr >";
                    }

                    
                    string str_lbl1 = "";
                    string str_lbl2 = "";
                    if (reader["Carpet_Area_Min"].ToString().Trim() == "1")
                    {
                        str_lbl1 = "Not Specified";
                    }
                    else
                        str_lbl1 = (string)reader["Carpet_Area_Min"];

                    if (reader["Carpet_Area_Max"].ToString().Trim() == "2")
                    {
                        str_lbl2 = "Not Specified";
                    }
                    else
                        str_lbl2 = (string)reader["Carpet_Area_Max"];

                    html += "<tr class='tr_Height' >";

                    html += "<td>";
                    html += "Carpet Area ";
                    html += "</td>";

                    html += "<td>:</td>";

                    html += "<td>";
                    html += "Min " + str_lbl1 + "&nbsp;&nbsp;&nbsp;Max " + str_lbl2 + "&nbsp";
                    html += (string)reader["Carpet_Area_Unit"] + "</td>";

                    html += "</tr >";

                   
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
                    
                    html += "<tr class='tr_Height' >";

                    html += "<td>";
                    html += "Budget ";
                    html += "</td>";

                    html += "<td>:</td>";

                    html += "<td>";
                    html += "Min - " + str_lbl1 + "&nbsp;&nbsp;&nbsp;Max - " + str_lbl2;
                    html += "</td>";

                    html += "</tr >";


                    html += "<tr class='tr_Height' >";

                    html += "<td>";
                    html += "Deal Closing ";
                    html += "</td>";

                    html += "<td>:</td>";

                    html += "<td>";
                    html += (string)reader["Deal_Closing"];
                    html += "</td>";

                    html += "</tr >";

                    html += "<tr class='tr_Height' >";

                    html += "<td>";
                    html += "Particular Requirement";
                    html += "</td>";

                    html += "<td>:</td>";

                    html += "<td>";
                    if (reader["Othre_Desc"].ToString().Trim() != "")
                    {
                        html += (string)reader["Othre_Desc"];
                    }
                    html += "</td>";

                    html += "</tr >";

                    html += "</table>";
                    html += "</div> </center>";
                    i++;
                    
                    //html += "</br>";
                    
                        
                    

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
                lbl_Message.InnerText = "Something went wrong ! <br/>" + ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}