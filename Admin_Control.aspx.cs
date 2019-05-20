using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Admin_Control : System.Web.UI.Page
{
    protected static string html = "";
    static long i;
    static long j;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            html = "";
            if (Session["Email"] == null)// not Logged IN
            {
                Server.Transfer("Login_Page.aspx");
            }          
        }
    }

    protected void btn_LOG_OUT_Click(object sender, EventArgs e)
    {
        //if (Session["Email"] != null)
        {
            Session.Remove("Email");//clear session
            //Session.Abandon();//Abandon session check
            Server.Transfer("Login_Page.aspx");
        }
    }

    protected void makeChoice(object sender, EventArgs e)
    {
        if (Session["Email"] == null)// not Logged IN
        {
            Server.Transfer("Login_Page.aspx");
        }
        else
        {
            if (lst_Rent_Sale.Text.Trim() == "Sell")
                Sell_Page();
            else if (lst_Rent_Sale.Text.Trim() == "Rent")
                Rent_Page();
            else if (lst_Rent_Sale.Text.Trim() == "Enquiry")
                Enquiry_Page();
        }
    }

    protected void Delete_From_Database(object sender, EventArgs e)
    {
        if (Session["Email"] == null)// not Logged IN
        {
            Server.Transfer("Login_Page.aspx");
        }
        else
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            bool Rec_Deleled = false;
            bool exceptionExists = false;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();


                long counter;
                long Record_No;
                string Temp_Image_Path = "";

                for (counter = 1; counter < i; counter++)
                {
                    if (Page.Request.Form["Checkbox_" + counter] != null)
                    {
                        Record_No = Convert.ToInt64(Page.Request.Form["Checkbox_" + counter]);

                        //phycially delete image file form server folder
                        //cmd.CommandText = "select [Image_Path] from [Client_Data] where Record_No = " + Record_No;
                        //if (cmd.ExecuteScalar() != DBNull.Value && cmd.ExecuteScalar().ToString() != "")//check for empty Database
                        //{
                        //    Temp_Image_Path = cmd.ExecuteScalar().ToString();

                        //    System.IO.File.Delete(Server.MapPath(Temp_Image_Path));
                        //}

                        //delete code goes here
                        if (lst_Rent_Sale.Text.Trim() == "Sell")
                        {
                            cmd.CommandText = "delete from [Sell_Basic_Info] where Record_No = " + Record_No;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from [Sell_Other_Desc] where Record_No = " + Record_No;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from [Client_Info] where Record_No = " + Record_No + " and [Record_Type] = 'For Sale' ";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from [Sell_Photos] where Record_No = " + Record_No;
                            cmd.ExecuteNonQuery();

                        }
                        else if (lst_Rent_Sale.Text.Trim() == "Rent")
                        {
                            cmd.CommandText = "delete from [Rent_Basic_Info] where Record_No = " + Record_No;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from [Rent_Other_Desc] where Record_No = " + Record_No;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from [Client_Info] where Record_No = " + Record_No + " and [Record_Type] = 'On Rent' ";
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from [Rent_Photos] where Record_No = " + Record_No;
                            cmd.ExecuteNonQuery();
                        }
                        else if (lst_Rent_Sale.Text.Trim() == "Enquiry")
                        {
                            cmd.CommandText = "delete from [Buy_Rent_Enquiry] where Record_No = " + Record_No;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "delete from [Client_Info] where Record_No = " + Record_No + " and [Record_Type] = 'Enquiry' ";
                            cmd.ExecuteNonQuery();
                        }

                        Rec_Deleled = true;
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

                if (Rec_Deleled && !exceptionExists)
                {
                    lbl_Message.Text = "Property deleted Successfully !";

                    if (lst_Rent_Sale.Text.Trim() == "Sell")
                        Sell_Page();
                    else if (lst_Rent_Sale.Text.Trim() == "Rent")
                        Rent_Page();
                    else if (lst_Rent_Sale.Text.Trim() == "Enquiry")
                        Enquiry_Page();
                }
                else if (exceptionExists)
                    lbl_Message.Text = "Something went wrong !";
                else
                    lbl_Message.Text = "No Property selected !";
            }
        }
       
    }

    protected void Sell_Page()
    {
        html = "";


        var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string str_Command = "SELECT * FROM [Sell_Basic_Info], [Sell_Other_Desc] where";

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();        

            str_Command += " [Sell_Basic_Info].Record_No = [Sell_Other_Desc].Record_No order by [Posted_Date] DESC";


            cmd.CommandText = str_Command;

            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {


                i = 1;
                while (reader.Read())
                {
                    html += "</br>";
                    html += "<div style='position:relative;left:350px;width:600px;Border:solid 1px grey;'>";
                    html += "<table border='0' style='margin-left:15px;font-family:Bookman Old Style'>";
                    html += "<div class='div_Price'> Price : " + (string)reader["Expected_Price"] + " </div>";

                    html += "<tr style='height:40px' >";
                    html += "<td colspan='2' style='font-size:25px'>";
                    html += (string)reader["Property_Type"] + " Property in " + (string)reader["Location"];
                    html += "</td>";
                    html += "</tr >";


                    html += "<tr >";
                    html += "<td style='width:300px'>";
                    //  if ((string)reader["Image_Path"] != "")
                    {
                        html += "&nbsp;&nbsp; <img style='max-width:250px;max-height:150px' src='" + (string)reader["Image_Path"] + "' alt = 'Image' onerror='this.src = \"Site_Images/DummyImage.jpg\"' />";
                    }
                    html += "</td>";

                    html += "<td style='width:250px'>";

                    html += "Property : " + (string)reader["Property_SubType"];
                    html += "</br> Sale Type : " + (string)reader["Sale_Type"];
                    html += "</br> Status : " + (string)reader["Construction_Status"];

                    if ((string)reader["Property_Type"] == "Residential")
                        html += "</br> Details : " + (string)reader["Bedrooms"];

                    html += "</br> Area : " + (string)reader["Carpet_Area"] + (string)reader["Area_Unit"];
                    html += "</br> Floor :" + (string)reader["Property_on_Floor"] + "Out of " + (string)reader["Total_Floors"];

                    html += "</td>";

                    html += "</tr>";

                    html += "<tr style='height:40px'>";
                    html += "<td style='width:40px;padding-left:20px'>";
                    html += "<input name='Checkbox_" + i + "' value='" + reader["Record_No"].ToString() + "' type='checkbox' runat='server' />";
                    html += "&nbsp;&nbsp;Delete Record";
                    html += "</td>";
                    html += "<td style='font-size:20px'> <center>";
                    html += "<a href='View_Sell_Full_Details.aspx?prn=" + reader["Record_No"] + "'> See Full Details </a>";
                    html += "</center> </td>";
                    html += "</tr>";
                   

                    html += "</table>";
                    html += "</div> ";
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
    
    protected void Rent_Page()
    {
        html = "";

        var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        string str_Command = "SELECT * FROM [Rent_Basic_Info], [Rent_Other_Desc] where";

        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();         


            str_Command += " [Rent_Basic_Info].Record_No = [Rent_Other_Desc].Record_No order by [Posted_Date] DESC";


            cmd.CommandText = str_Command;

            reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {


                i = 1;
                while (reader.Read())
                {
                    html += "</br>";
                    html += "<div style='position:relative;left:350px;height:250px;width:700px;Border:solid 1px grey;'>";
                    html += "<table border='0' style='margin-left:15px;font-family:Bookman Old Style'>";
                    html += "<div class='div_Rent'> Rent : " + (string)reader["Rent_Per_Month"] + "/ Month </div>";

                    html += "<tr style='height:40px' >";
                    html += "<td colspan='2' style='font-size:24px;'>";
                    html += (string)reader["Property_Type"] + " Property in " + (string)reader["Location"] + "on Rent";
                    html += "</td>";
                    html += "</tr >";


                    html += "<tr >";
                    html += "<td style='width:300px'>";
                    {
                        html += "&nbsp;&nbsp; <img style='max-width:250px;max-height:150px' src='" + (string)reader["Image_Path"] + "' alt = 'Image' onerror='this.src = \"Site_Images/DummyImage.jpg\"' />";
                    }
                    html += "</td>";

                    html += "<td style='width:250px'>";

                    html += "Property : " + (string)reader["Property_SubType"];
                    html += "</br> Location : " + (string)reader["Location"];
                    if ((string)reader["Property_Type"] == "Residential")
                    {
                        html += "</br> Details : " + (string)reader["Bedrooms"] + "BHK";
                    }
                    html += "</br> Area : " + (string)reader["Built_Up_Area"] + "Sq. Ft.";
                    html += "</br> Floor :" + (string)reader["Property_on_Floor"] + "Out of " + (string)reader["Total_Floors"];

                    html += "</td>";

                    html += "</tr>";

                    html += "<tr style='height:40px'>";
                    html += "<td style='width:40px;padding-left:20px'>";
                    html += "<input name='Checkbox_" + i + "' value='" + reader["Record_No"].ToString() + "' type='checkbox' runat='server' />";
                    html += "&nbsp;&nbsp;Delete Rocord";
                    html += "</td>";
                    html += "<td style='font-size:20px'> <center>";
                    html += "<a href='View_Rent_Prop.aspx?prn=" + reader["Record_No"] + "'> See Full Details </a>";
                    html += "</center> </td>";
                    html += "</tr>";

                    html += "</table>";
                    html += "</div> ";
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

    protected void Enquiry_Page()
    {
        html = "";

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
                    html += "<center> <div style='height:250px;width:600px;Border:solid 1px grey;'>";
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

                    html += "<td style='' colspan='2'> <center>";
                    html += "<input name='Checkbox_" + i + "' value='" + reader["Record_No"].ToString() + "' type='checkbox' runat='server' />";
                    html += "&nbsp;&nbsp;Delete Record";
                    html += "</center> </td>";

                    html += "<td style='font-size:20px'> <center>";
                    html += "&nbsp;&nbsp;&nbsp;&nbsp;<a href='Cust_Enquiry_Details.aspx?prn=" + reader["Record_No"] + "'> Full Details </a>";
                    html += "</center> </td>";

                    //html += "<td style='font-size:20px'> <center>";
                    ////html += "<a href=''> Call Us </a>";
                    //html += "</center> </td>";

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


    protected void btn_Hide_Click(object sender, EventArgs e)
    {
        //if (Session["Email"] != null)
        //{
            //string dbEmail = Session["Email"].ToString();

        var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            bool Rec_Deleled = false;
            bool exceptionExists = false;
            try
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();


                long counter;
                long Record_No;

                for (counter = 1; counter < i; counter++)
                {
                    if (Page.Request.Form["Checkbox_" + counter] != null)
                    {
                        Record_No = Convert.ToInt64(Page.Request.Form["Checkbox_" + counter]);

                        //phycially delete image file form server folder
                        //cmd.CommandText = "select [Image_Path] from [Client_Data] where Record_No = " + Record_No;
                        //if (cmd.ExecuteScalar() != DBNull.Value && cmd.ExecuteScalar().ToString() != "")//check for empty Database
                        //{
                        //    Temp_Image_Path = cmd.ExecuteScalar().ToString();

                        //    System.IO.File.Delete(Server.MapPath(Temp_Image_Path));
                        //}

                        //delete code goes here
                        cmd.CommandText = "UPDATE [dbo].[Rent_Basic_Info] SET [Admin_Rights] = 'DNS' WHERE [Record_No] = " + Record_No;
                        cmd.ExecuteNonQuery();                       

                        Rec_Deleled = true;
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

                if (Rec_Deleled && !exceptionExists)
                {
                    lbl_Message.Text = "Property Hided Successfully !";
                }
                else if (exceptionExists)
                    lbl_Message.Text = "Something went wrong !";
                else
                    lbl_Message.Text = "No Property selected !";
            }
    }

    protected void btn_Show_Click(object sender, EventArgs e)
    {
        //if (Session["Email"] != null)
        //{
        //string dbEmail = Session["Email"].ToString();

        var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection(connectionString);

        SqlCommand cmd = new SqlCommand();
        bool Rec_Deleled = false;
        bool exceptionExists = false;
        try
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            conn.Open();


            long counter;
            long Record_No;

            for (counter = 1; counter < i; counter++)
            {
                if (Page.Request.Form["Checkbox_" + counter] != null)
                {
                    Record_No = Convert.ToInt64(Page.Request.Form["Checkbox_" + counter]);

                    //phycially delete image file form server folder
                    //cmd.CommandText = "select [Image_Path] from [Client_Data] where Record_No = " + Record_No;
                    //if (cmd.ExecuteScalar() != DBNull.Value && cmd.ExecuteScalar().ToString() != "")//check for empty Database
                    //{
                    //    Temp_Image_Path = cmd.ExecuteScalar().ToString();

                    //    System.IO.File.Delete(Server.MapPath(Temp_Image_Path));
                    //}

                    //delete code goes here
                    cmd.CommandText = "UPDATE [dbo].[Rent_Basic_Info] SET [Admin_Rights] = '' WHERE [Record_No] = " + Record_No;
                    cmd.ExecuteNonQuery();

                    Rec_Deleled = true;
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

            if (Rec_Deleled && !exceptionExists)
            {
                lbl_Message.Text = "Property can be seen now !";
            }
            else if (exceptionExists)
                lbl_Message.Text = "Something went wrong !";
            else
                lbl_Message.Text = "No Property selected !";
        }
    }
}