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
using System.Collections.Generic;
using System.Collections.Specialized;


public partial class Sell_Property : System.Web.UI.Page
{
    string imagePath = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Utils1.fBrowserIsMobile())
        //    div_Left.Style.Add("font-size", "13px");
        //else
        //    div_Left.Style.Add("font-size", "18px");
    }

    private void Upload(FileUpload fileUpload)
    {
        string uri = "ftp://" + "107.180.46.208" + "/httpdocs/Images/" + fileUpload.FileName;

        int buffLength = 512000; // The buffer size is set to 512kb

        FtpWebRequest reqFTP;

        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(uri));// Create FtpWebRequest object from the Uri provided

        reqFTP.Credentials = new NetworkCredential("ph17518320251", "Aakash123$");

        reqFTP.KeepAlive = false;

        reqFTP.Method = WebRequestMethods.Ftp.UploadFile; // Specify the command to be executed.

        reqFTP.UseBinary = true; // Specify the data transfer type.

        reqFTP.ContentLength = fileUpload.PostedFile.InputStream.Length;

        byte[] buff = new byte[buffLength];

        int contentLen;

        try
        {
            Stream strm = reqFTP.GetRequestStream();  // Stream to which the file to be upload is written

            contentLen = fileUpload.PostedFile.InputStream.Read(buff, 0, buffLength);

            while (contentLen != 0)
            {
                strm.Write(buff, 0, contentLen);

                contentLen = fileUpload.PostedFile.InputStream.Read(buff, 0, buffLength);
            }

            strm.Close();

            fileUpload.PostedFile.InputStream.Close();
        }

        catch (Exception ex)
        {
            throw (ex);
        }

    }    

    bool validate_Input()
    {
        string str_Cust_Name = txt_Cust_Name.Value.Trim();
        string str_Mail_ID = txt_Email.Value.Trim();
        string str_Mobile_No = txt_Mobile.Value.Trim();

        string str_Cust_Type = Page.Request.Form["lst_Cust_Type"];
        string str_Sale_Type = Page.Request.Form["lst_Sale_Type"];
        string str_Construction_Status = Page.Request.Form["lst_Const_Status"].ToString();
        string str_Possession_Or_Age = "";
        string str_Property_Type = Page.Request.Form["lst_Property_Type"].ToString();
        string str_Property_Sub_Type = "";
        string str_Furnished_Status = txt_Furnished_Status.Value;
        string str_Bedrooms = Page.Request.Form["lst_Bed_Rooms"];
        string str_Bathrooms_Or_Washroom = "";
        string str_Location = lst_Location.Text;
        string str_Unit_No = txt_Unit_No.Value;
        string str_Wing_Name = txt_Wing_Name.Value;
        string str_Project_Name = txt_Project_Name.Value.Trim();
        string str_Street_Name = txt_Street_Name.Value.Trim();
        string str_Landmark = txt_Landmark.Value.Trim();
        string str_Pincode = "";// txt_Pincode.Value.Trim();
        string str_Carpet_Area = txt_Carpet_Area.Value;
        string str_Expected_Price = txt_Expected_Price.Value;
        //string str_Balconies = lst_Balconies.Value;
        string str_Total_Floors = Page.Request.Form["lst_Total_Floors"];
        string str_Property_on_Floor = Page.Request.Form["lst_Property_On_Floor"]; ;
        string str_Reserved_Parking = ""; //lst_Reserverd_Parking.Value;
        //DateTime date = Calendar1.SelectedDate;


        bool validate_Input = true;

        if (str_Property_Type == "Residential")
        {
            str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Residential"].ToString();
            str_Bathrooms_Or_Washroom = Page.Request.Form["lst_Bathrooms"];
        }
        else
        {
            str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Commercial"].ToString();
            str_Bathrooms_Or_Washroom = Page.Request.Form["lst_Washrooms"];
        }

        if (str_Construction_Status == "Ready To Move")
            str_Possession_Or_Age = Page.Request.Form["lst_Age_Of_property"].ToString();
        else
            str_Possession_Or_Age = Page.Request.Form["lst_Possession_In_Month"] + " " + Page.Request.Form["lst_Possession_In"];

        //validation For Parking is remained & month
        if (str_Cust_Type == "Select" || str_Sale_Type == "Select" || str_Construction_Status == "Select" ||
            str_Property_Type == "Select" || str_Property_Sub_Type == "Select" || str_Furnished_Status == "Select" || 
            str_Bathrooms_Or_Washroom == "Select" || str_Location == "Select" || str_Project_Name == "" || str_Property_on_Floor == "Select" || 
            str_Total_Floors == "Select" || str_Expected_Price == "" || str_Cust_Name == "" || str_Mobile_No == "")
        {
            validate_Input = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please enter all Compulsary fields !')", true);
        }
        else if (chk_TermsNCond.Checked == false)
        {
            validate_Input = false;
            ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Accept Terms & Conditions !')", true);
        }

        //if (str_Property_Type == "Residential" && str_Bed_Rooms == "Select")
        //{
        //    validate_Input = false;
        //    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Please Select Bedrooms')", true);
        //}

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
                        //{"numbers" , '0'+ str_Mobile_No},
                        {"numbers" , str_Mobile_No},
                        {"message" , Message},
                        {"sender" , "EsMEET"}
                        });
                    string result = System.Text.Encoding.UTF8.GetString(response);

                    tick_Image.Visible = true;
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('OTP sent Sucessfully !')", true);
                    //lbl_Status_Msg_Mobile.Text = result;
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
   
    protected void btn_Post_Property_Click(object sender, EventArgs e)
    {
        string strOTP = txtOTP.Value;

        if (Session["SessionOTP"] != null && validate_Input())
        {
            if (Session["SessionOTP"].ToString() == strOTP)
            {                
                string str_Cust_Type = Page.Request.Form["lst_Cust_Type"];
                string str_RERA_No = txt_RERA.Value.Trim();
                string str_Sale_Type = Page.Request.Form["lst_Sale_Type"];
                string str_Property_Type = Page.Request.Form["lst_Property_Type"];
                string str_Property_Sub_Type;
                string str_Furnished_Status = txt_Furnished_Status.Value;
                string str_Location = ""; 
                string str_Unit_No = txt_Unit_No.Value.Trim();
                string str_Wing_Name = txt_Wing_Name.Value.Trim();
                string str_Project_Name = txt_Project_Name.Value.Trim();
                string str_Street_Name = txt_Street_Name.Value.Trim();
                string str_Landmark = txt_Landmark.Value.Trim();
                string str_Pincode = "";// txt_Pincode.Value.Trim();

                string str_Location_Remark = "";

                string str_Built_Up_Area = txt_Built_Up_Area.Value;
                string str_Carpet_Area = txt_Carpet_Area.Value;
                string str_Expected_Price = txt_Expected_Price.Value;
                string str_Area_Unit = lst_Carpet_Area_Unit.Value;
                string str_Bedrooms = Page.Request.Form["lst_Bed_Rooms"];
                string str_Bathrooms_Or_Washroom = "";
                string str_Total_Floors = Page.Request.Form["lst_Total_Floors"];
                string str_Property_on_Floor = Page.Request.Form["lst_Property_On_Floor"];
                string str_Reserved_Parking = Page.Request.Form["lst_Reserverd_Parking"];

                if ((Page.Request.Form["chk_Location"] == null))
                    str_Location = lst_Location.Text; 
                else
                    str_Location = Page.Request.Form["txt_Location"].Trim();

                bool bool_Amenities_Lift = chk_Amenities_Lift.Checked;              
                bool bool_Amenities_Security = chk_Amenities_Security.Checked;
                bool bool_Amenities_Garden = chk_Amenities_Garden.Checked;
                bool bool_Amenities_PowerBK = chk_Amenities_PowerBK.Checked;

                bool bool_Amenities_Piped_Gas = chk_Amenities_Piped_Gas.Checked;
                bool bool_Amenities_Solar_System = chk_Amenities_Solar_System.Checked;
                bool bool_Amenities_Water = chk_Amenities_Water.Checked;
                bool bool_Amenities_Swimming = chk_Amenities_Swimming.Checked;

                string str_Amenities = bool_Amenities_Lift.ToString() + "_" + bool_Amenities_Security.ToString() + "_" +
                                       bool_Amenities_Garden.ToString() + "_" + bool_Amenities_PowerBK.ToString() + "_" +
                                       bool_Amenities_Piped_Gas.ToString() + "_" + bool_Amenities_Solar_System.ToString() + "_" +
                                       bool_Amenities_Water.ToString() + "_" + bool_Amenities_Swimming.ToString();

                str_Amenities = str_Amenities.Replace("True", "1");
                str_Amenities = str_Amenities.Replace("False", "0");
                
                string str_Image_Path = "";
                string str_Construction_Status = Page.Request.Form["lst_Const_Status"];
                string str_Possession_Or_Age = "";
                string dummy = "N/A";
                string str_Desc = txt_Desc.Value;
                string sqlCommand = "";
                long Record_No = 1;
                string str_Cust_Name = txt_Cust_Name.Value;
                string str_Mail_ID = txt_Email.Value;
                string str_Mobile_No = txt_Mobile.Value;

                if (str_Property_Type == "Residential")
                {
                    str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Residential"];
                    str_Bedrooms = Page.Request.Form["lst_Bed_Rooms"];
                }
                else
                {
                    str_Property_Sub_Type = Page.Request.Form["lst_Property_Sub_Commercial"];
                    str_Bedrooms = Page.Request.Form["lst_Washrooms"];
                }

                if (str_Construction_Status == "Ready To Move")
                    str_Possession_Or_Age = Page.Request.Form["lst_Age_Of_property"].ToString();
                else
                    str_Possession_Or_Age = Page.Request.Form["lst_Possession_In_Month"] + " " + Page.Request.Form["lst_Possession_In"];


                if (browseImage.HasFile)
                {
                    try
                    {
                        if (browseImage.PostedFile.ContentType == "image/jpeg")
                        {
                            Upload(browseImage);
                            str_Image_Path = "Images/" + browseImage.FileName;
                        }
                        else
                            lblStatusMsg.Text = "Only JPEG files are accepted <br />";
                    }
                    catch (Exception ex)
                    {
                        lblStatusMsg.Text = "An error occured while uploading Image !";
                    }
                }

                string str_Image_Path2 = "";
                if (browseImage2.HasFile)
                {
                    try
                    {
                        if (browseImage2.PostedFile.ContentType == "image/jpeg")
                        {

                            Upload(browseImage2);

                            str_Image_Path2 = "Images/" + browseImage2.FileName;
                        }
                        else
                            lblStatusMsg2.Text = "Only JPEG files are accepted <br />";
                    }
                    catch (Exception ex)
                    {
                        lblStatusMsg2.Text = "An error occured while uploading Image !";
                    }
                }

                string str_Image_Path3 = "";
                if (browseImage3.HasFile)
                {
                    try
                    {
                        if (browseImage3.PostedFile.ContentType == "image/jpeg")
                        {

                            Upload(browseImage3);

                            str_Image_Path3 = "Images/" + browseImage3.FileName;
                        }
                        else
                            lblStatusMsg3.Text = "Only JPEG files are accepted <br />";
                    }
                    catch (Exception ex)
                    {
                        lblStatusMsg3.Text = "An error occured while uploading Image !";
                    }
                }

                var connectionString = ConfigurationManager.ConnectionStrings["Broker_PlusConnectionString"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();

                try
                {

                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conn;

                    //Open Conncetion   
                    conn.Open();

                    cmd.CommandText = "SELECT max (Record_No) FROM Sell_Basic_Info";

                    if (cmd.ExecuteScalar() != DBNull.Value)//check for empty Database
                    {
                        Record_No = Convert.ToInt64(cmd.ExecuteScalar()) + 1;
                    }
                    else
                        Record_No = 1;

                    if (str_Image_Path2 != "")
                    {
                        sqlCommand = "INSERT INTO [Sell_Photos]([Record_No], [Image_Path], [Tag_Photo], [Cover_Photo]) " +
                                        "VALUES(" + Record_No + ",'" + str_Image_Path2 + "','" + dummy + "','" + dummy + "')";

                        cmd.CommandText = sqlCommand;
                        cmd.ExecuteNonQuery();
                    }

                    if (str_Image_Path3 != "")
                    {
                        sqlCommand = "INSERT INTO [Sell_Photos]([Record_No], [Image_Path], [Tag_Photo], [Cover_Photo]) " +
                                        "VALUES(" + Record_No + ",'" + str_Image_Path3 + "','" + dummy + "','" + dummy + "')";

                        cmd.CommandText = sqlCommand;
                        cmd.ExecuteNonQuery();
                    }

                    sqlCommand = "INSERT INTO [Sell_Basic_Info]([Record_No],[C_Type],[Sale_Type],[Property_Type],[Property_SubType],[Project_Name],[Unit_No],[Wing],"+
                                "[Colony_Name],[Street_Name],[Land_Mark],[Pincode],[Location],[City],[Specific_Location],[Image_Path],[Posted_Date],[Admin_Rights])" +
                                "VALUES(" + Record_No + ",'" + str_Cust_Type + "','" + str_Sale_Type + "','" + str_Property_Type + "','" + str_Property_Sub_Type + "','" + str_Project_Name + "','" + str_Unit_No + "','" + str_Wing_Name +
                                "','" + dummy + "','" + str_Street_Name + "','" + str_Landmark + "','" + str_Pincode + "','" + str_Location + "','" + dummy + "','" + str_Location_Remark  + "','" + str_Image_Path + "','" + DateTime.Now + "','" + dummy + "')";

                    cmd.CommandText = sqlCommand;
                    cmd.ExecuteNonQuery();

                    sqlCommand = "INSERT INTO [Sell_Other_Desc]([Record_No],[Built_Up_Area],[Carpet_Area],[Area_Unit],[Bedrooms],[Bathrooms_Or_Washroom]," +
                         "[Total_Floors],[Property_on_Floor],[Reserved_Parking],[RERA_Registration_Status],[Construction_Status],[Possession_Or_Age],[Expected_Price],[Amenities]," +
                        "[Furnished_Status], [Other_desc]) " +
                        "VALUES(" + Record_No + ",'" + str_Built_Up_Area + "','" + str_Carpet_Area + "','" + str_Area_Unit + "','" + str_Bedrooms +
                        "','" + str_Bathrooms_Or_Washroom + "','" + str_Total_Floors + "','" + str_Property_on_Floor + "','" + str_Reserved_Parking + "','" + str_RERA_No + "','" +
                        str_Construction_Status + "','" + str_Possession_Or_Age + "','" + str_Expected_Price + "','" + str_Amenities + "','" + str_Furnished_Status + "','" + str_Desc + "')";

                    cmd.CommandText = sqlCommand;
                    cmd.ExecuteNonQuery();

                    sqlCommand = "INSERT INTO [Client_Info]([Record_No], [Record_Type], [Cust_Name], [Mail_ID], [Mobile_No]) " +
                                            "VALUES(" + Record_No + ",'" + "For Sale" + "','" + str_Cust_Name + "','" + str_Mail_ID + "','" + str_Mobile_No + "')";

                    cmd.CommandText = sqlCommand;

                    cmd.ExecuteNonQuery();

                    lblMessage.Text = "Property Posted Succesfully";
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Property posted successfully!')", true);
                    tick_Image.Visible = false;


                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");

                    mail.From = new MailAddress("admin@estatemeet.in");
                    mail.To.Add(new MailAddress("admin@estatemeet.in"));
                    mail.Subject = "New Property added for Sale";
                    mail.Body = "       Dear " + "Kalpesh Sir" + "\n\n Mr. " + str_Cust_Name + " has posted new Property on BrokerPluss.com";
                    mail.Body += "\n\n Mobile No :- " + str_Mobile_No;
                    mail.Body += "\n\n Address :- " + str_Location;

                    if (str_Unit_No.Length > 0)
                        mail.Body += "\n\n Unit No - " + str_Unit_No + ", Wing - " + str_Wing_Name;

                    mail.Body += "\n\n Project/Building Name - " + str_Project_Name;

                    if (str_Street_Name.Length > 0)
                        mail.Body += "\n\n Street Name - " + str_Street_Name;

                    if (str_Landmark.Length > 0)
                        mail.Body += "\n\n Landmark - " + str_Landmark;      

                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("admin@estatemeet.in", "Admin123$$$");
                    SmtpServer.Timeout = 900000;
                    SmtpServer.Send(mail);

                    

                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Opps! Something has gone wrong" + ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                lblMessage.Text = "Incorrect OTP. <br/> Please provide correct OTP.";
            }
        }
        else
            lblMessage.Text = "Please enter all compulsary fields & Send OTP. ";


    }//btn_Post_Property_Click closed
}