using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class View_Sell_Full_Details : System.Web.UI.Page
{
    protected static string image_html = "";
    protected string btn_Html = "";
    protected string main_Html = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            refresh_Page(sender, e);
        }
    }

    protected void refresh_Page(object sender, EventArgs e)
    {
        image_html = "";
        btn_Html = "";
        main_Html = "";

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

                str_Command = "SELECT * FROM [Sell_Basic_Info], [Sell_Other_Desc] where [Sell_Basic_Info].[Record_No] = [Sell_Other_Desc].[Record_No] and [Sell_Basic_Info].[Record_No] = " + str_Record_No;
                cmd.CommandText = str_Command;

                conn.Open();
                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {                   
                    while (reader.Read())
                    {
                        if ((string)reader["Image_Path"] != "")
                        {
                            i = 1;
                            image_html += "<img class='mySlides' src='" + (string)reader["Image_Path"] + "' alt = 'Image' style='width:100%' />";
                            btn_Html += "<button class='w3-button demo' onclick='currentDiv(1)'><img src='" + (string)reader["Image_Path"] + "' alt = 'Image' style='height:40px' /></button> ";
                        }

                        main_Html += "<center> <div>";
                        main_Html += "<table border='0' style='font-family:Arial'>";

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Property Type </td>";
                        main_Html += "<td style='width:30px'>:</td>";
                        main_Html += "<td>" +  (string)reader["Bedrooms"] + " " + (string)reader["Property_Type"] + "</td>";
                        main_Html += "</tr>";
                       
                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Location </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Location"] + "</td>";
                        main_Html += "</tr>";

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Price</td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Expected_Price"] + "</td>";
                        main_Html += "</tr>";

                        //str_Built_Up_Area = reader["Built_Up_Area"].ToString().Trim();

                        //if (str_Built_Up_Area == "")
                        //    str_Built_Up_Area = "-";
                        //else
                        //    str_Built_Up_Area += " Sq.Ft";//later check for Sq.Mtr.

                        //str_Carpet_Area = reader["Carpet_Area"].ToString().Trim();

                        //if (str_Carpet_Area == "")
                        //    str_Carpet_Area = "-";
                        //else
                        //    str_Carpet_Area += " Sq.Ft";//later check for Sq.Mtr.

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Built Up Area </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Built_Up_Area"] + " " + (string)reader["Area_Unit"] + "</td>";
                        main_Html += "</tr>";

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Carpet Area </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Carpet_Area"] + " " + (string)reader["Area_Unit"] + "</td>";
                        main_Html += "</tr>";

                      
                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Booking Type </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Sale_Type"] + "</td>";
                        main_Html += "</tr>";

                       
                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Construction Status &nbsp;</td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Construction_Status"] + "</td>";
                        main_Html += "</tr>";

                        
                        main_Html += "<tr class='tr_Height'>";

                        if ((string)reader["Construction_Status"].ToString().Trim() == "Under Construction")
                            main_Html += "<td class='td_Padding'>Possession In </td>";
                        else
                            main_Html += "<td class='td_Padding'>Age Of Property </td>";

                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Possession_Or_Age"] + "</td>";
                        main_Html += "</tr>";

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Property on Floor </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Property_on_Floor"] + " Out of" + (string)reader["Total_Floors"] +"</td>";
                        main_Html += "</tr>";

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Furnished Status </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" +  (string)reader["Furnished_Status"] + "</td>";
                        main_Html += "</tr>";

                       
                        //main_Html += "<tr class='tr_Height'>";
                        //main_Html += "<td class='td_Padding'>Reserved Parking </td>";
                        //main_Html += "<td>:</td>";
                        //main_Html += "<td>" +  (string)reader["Reserved_Parking"] + "</td>";
                        //main_Html += "</tr>";

                      
                        string str_Amenities = (string)reader["Amenities"];

                        str_Amenities = str_Amenities.Replace("1", "checked='checked'");
                        str_Amenities = str_Amenities.Replace("0", " ");

                        string []array_Amenities = str_Amenities.Split('_');     


                        //chk_Amenities_Garden.Disabled = true;

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Amenities </td>";
                        main_Html += "<td>:</td> <td>";
                        main_Html += " <table> <tr>" +
                                     " <td> <input id='chk_Amenities_Lift' runat='server'" + array_Amenities[0] + " disabled='disabled' type='checkbox' /> Lift </td> " +
                                     " <td> <input id='chk_Amenities_Security' runat='server'" + array_Amenities[1] + " disabled='disabled' type='checkbox' /> Security 24x7 </td>" +
                                     " </tr> <tr> " +
                                      " <td> <input id='chk_Amenities_Garden' runat='server'" + array_Amenities[2] + " disabled='disabled' type='checkbox' /> Garden </td> " +
                                     " <td> <input id='chk_Amenities_PowerBK' runat='server'" + array_Amenities[3] + " disabled='disabled' type='checkbox' /> Power Backup </td>" +
                                     " </tr> <tr> " +
                                      " <td> <input id='chk_Amenities_Piped_Gas' runat='server'" + array_Amenities[4] + " disabled='disabled' type='checkbox' /> Piped Gas </td> " +
                                     " <td> <input id='chk_Amenities_Solar_System' runat='server'" + array_Amenities[5] + " disabled='disabled' type='checkbox' /> Solar System </td>" +
                                     " </tr> <tr> " +
                                      " <td> <input id='chk_Amenities_Water' runat='server'" + array_Amenities[6] + " disabled='disabled' type='checkbox' /> Water 24x7 </td> " +
                                     " <td> <input id='chk_Amenities_Swimming' runat='server'" + array_Amenities[7] + " disabled='disabled' type='checkbox' /> Swimming Pool 24x7 </td>" +
                                     " </tr> </table>";                               
                           
                        main_Html += "</td> </tr>";


                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Description </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" + (string)reader["Other_desc"] + "</td>";//verify for -
                        main_Html += "</tr>";

                      
                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>Posted By </td>";
                        main_Html += "<td>:</td>";
                        main_Html += "<td>" + (string)reader["C_Type"] + "</td>";
                        main_Html += "</tr>";

                        main_Html += "<tr class='tr_Height'>";
                        main_Html += "<td class='td_Padding'>RERA No </td>";
                        main_Html += "<td>:</td>";

                        if((string)reader["RERA_Registration_Status"].ToString().Trim() == "")
                            main_Html += "<td>" + " - </td>";
                        else
                            main_Html += "<td>" + (string)reader["RERA_Registration_Status"] + "</td>";

                        main_Html += "</tr>";
                                              
                        main_Html += "</table>";
                        main_Html += "</div>";
                    }
                }

                conn.Close();

                conn.Open();


                cmd.CommandText = "SELECT * FROM [Sell_Photos] where [Record_No] = " + str_Record_No;

                reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        i++;
                        if ((string)reader["Image_Path"] != "")
                        {
                            image_html += "<img class='mySlides' src='" + (string)reader["Image_Path"] + "' alt = 'Image' style='width:100%' />";
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