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
using System.Collections.Specialized;

public partial class Rent_Your_Property : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        string str_Rent_Per_Month = txt_Rent_Per_Month.Value;
        string str_Deposit = txt_Deposit.Value;
        //string str_Balconies = lst_Balconies.Value;
        string str_Total_Floors = lst_Total_Floors.Value.Trim();
        string str_Property_on_Floor = lst_Property_On_Floor.Value.Trim();
        string str_Reserved_Parking = ""; //lst_Reserverd_Parking.Value;
        string str_Agr_Duration = Page.Request.Form["lst_Agr_Duration"];

        string str_Avai_From = Page.Request.Form["Avi_Date"] + " " + Page.Request.Form["Avi_Month"] + " " + Page.Request.Form["Avi_Year"];

        if (str_Avai_From.Contains("Date") || str_Avai_From.Contains("Months") || str_Avai_From.Contains("Year"))
            str_Avai_From = "NA";


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


        if (str_Cust_Type == "Select" || str_Property_Type == "Select" || str_Property_Sub_Type == "Select" || str_Furnished_Status == "Select" ||
            str_Bathrooms_Or_Washroom == "Select" || str_Location == "Select" || str_Project_Name == "" ||
            str_Rent_Per_Month == "" || str_Deposit == "" || str_Property_on_Floor == "Select" || str_Total_Floors == "Select" ||
            str_Agr_Duration == "Select" || str_Avai_From == "NA" || str_Cust_Name == "" || str_Mobile_No == "")
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
                string str_Property_Type = Page.Request.Form["lst_Property_Type"].ToString();
                string str_Property_Sub_Type = "";
                string str_Furnished_Status =  txt_Furnished_Status.Value;
                string str_Bedrooms = Page.Request.Form["lst_Bed_Rooms"];
                string str_Bathrooms_Or_Washroom = "";
                string str_Location = "";// lst_Location.Text;
                string str_Unit_No = txt_Unit_No.Value.Trim();
                string str_Wing_Name = txt_Wing_Name.Value.Trim();
                string str_Project_Name = txt_Project_Name.Value.Trim();
                string str_Street_Name = txt_Street_Name.Value.Trim();
                string str_Landmark = txt_Landmark.Value.Trim();
                string str_Pincode = "";// txt_Pincode.Value.Trim();
                string str_Location_Remark = "";// txt_Location_Remark.Value.Trim();
                string str_Salable_Area = txt_Built_Up_Area.Value;
                string str_Carpet_Area = txt_Carpet_Area.Value;
                string str_Rent_Per_Month = txt_Rent_Per_Month.Value;
                string str_Deposit = txt_Deposit.Value;
                //string str_Balconies = lst_Balconies.Value;
                string str_Total_Floors = lst_Total_Floors.Value;
                string str_Property_on_Floor = lst_Property_On_Floor.Value;
                string str_Reserved_Parking = ""; //lst_Reserverd_Parking.Value;
                string str_Image_Path = "";
                string str_Other_Desc = Page.Request.Form["txt_Desc"].Trim();

                if ((Page.Request.Form["chk_Location"] == null))
                    str_Location = lst_Location.Text;
                else
                    str_Location = Page.Request.Form["txt_Location"].Trim();

                string str_Agr_Duration = Page.Request.Form["lst_Agr_Duration"];
                string str_Avai_From = Page.Request.Form["Avi_Date"] + " " + Page.Request.Form["Avi_Month"] + " " + Page.Request.Form["Avi_Year"];

                string str_Rent_Out_To = "";

                if (Page.Request.Form["chk_Family"] != null)
                    str_Rent_Out_To += Page.Request.Form["chk_Family"] + " / ";

                if (Page.Request.Form["chk_Bachelor"] != null)
                    str_Rent_Out_To += Page.Request.Form["chk_Bachelor"] + " / ";

                if (Page.Request.Form["chk_Anyone"] != null)
                    str_Rent_Out_To += Page.Request.Form["chk_Anyone"] + " / ";

                if(str_Rent_Out_To.Length > 5)
                    str_Rent_Out_To = str_Rent_Out_To.Substring(0, str_Rent_Out_To.Length - 3);
                else
                    str_Rent_Out_To = "-";

                string dummy = "N/A";
                string sqlCommand = "";
                long Record_No = 1;
                string str_Cust_Name = txt_Cust_Name.Value;
                string str_Mail_ID = txt_Email.Value;
                string str_Mobile_No = txt_Mobile.Value;       

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

                    cmd.CommandText = "SELECT max (Record_No) FROM Rent_Basic_Info";

                    if (cmd.ExecuteScalar() != DBNull.Value)//check for empty Database
                    {
                        Record_No = Convert.ToInt64(cmd.ExecuteScalar()) + 1;
                    }
                    else
                        Record_No = 1;

                    if (str_Image_Path2 != "")
                    {
                        sqlCommand = "INSERT INTO [Rent_Photos]([Record_No], [Image_Path], [Tag_Photo], [Cover_Photo]) " +
                                        "VALUES(" + Record_No + ",'" + str_Image_Path2 + "','" + dummy + "','" + dummy + "')";

                        cmd.CommandText = sqlCommand;
                        cmd.ExecuteNonQuery();
                    }

                    if (str_Image_Path3 != "")
                    {
                        sqlCommand = "INSERT INTO [Rent_Photos]([Record_No], [Image_Path], [Tag_Photo], [Cover_Photo]) " +
                                        "VALUES(" + Record_No + ",'" + str_Image_Path3 + "','" + dummy + "','" + dummy + "')";

                        cmd.CommandText = sqlCommand;
                        cmd.ExecuteNonQuery();
                    }

                    sqlCommand = "INSERT INTO [Rent_Basic_Info](Record_No, [C_Type], [Property_Type], [Property_SubType], [Project_Name], [Unit_No], [Wing], " +
                                   "[Colony_Name], [Street_Name], [Land_Mark], [Pincode], [Location], [City], [Specific_Location], [Image_Path], [Posted_Date], [Admin_Rights]) " +
                                   "VALUES(" + Record_No + ",'" + str_Cust_Type + "','" + str_Property_Type + "','" + str_Property_Sub_Type + "','" + str_Project_Name + "','" + str_Unit_No + "','" + str_Wing_Name +
                                   "','" + dummy + "','" + str_Street_Name + "','" + str_Landmark + "','" + str_Pincode + "','" + str_Location + "','" + dummy + "','" + str_Location_Remark + 
                                   "','" + str_Image_Path + "','" + DateTime.Now + "','" + dummy + "')";

                    cmd.CommandText = sqlCommand;
                    cmd.ExecuteNonQuery();

                    sqlCommand = "INSERT INTO [Rent_Other_Desc]([Record_No], [Built_Up_Area],[Carpet_Area],[Bedrooms], [Bathrooms_Or_Washroom], " +
                                "[Total_Floors], [Property_on_Floor], [Reserved_Parking], [RERA_Registration_Status], [Rent_Per_Month],  [Deposit], " +
                                "[Amenities], [Furnished_Status], [Other_Desc], [Agreement_Duration], [Available_From], [Rent_Out_To]) VALUES(" + 
                                Record_No + ",'" + str_Salable_Area + "','" + str_Carpet_Area + "','" + str_Bedrooms + "','" + str_Bathrooms_Or_Washroom +
                                "','" + str_Total_Floors + "','" + str_Property_on_Floor + "','" + dummy + "','" + dummy + "','" + str_Rent_Per_Month + "','" + str_Deposit +
                                 "','" + dummy + "','" + str_Furnished_Status + "','" + str_Other_Desc + "','" + str_Agr_Duration + "','" + str_Avai_From + "','" + str_Rent_Out_To + "')";

                    cmd.CommandText = sqlCommand;
                    cmd.ExecuteNonQuery();

                    sqlCommand = "INSERT INTO [Client_Info]([Record_No], [Record_Type], [Cust_Name], [Mail_ID], [Mobile_No]) " +
                                            "VALUES(" + Record_No + ",'" + "On Rent" + "','" + str_Cust_Name + "','" + str_Mail_ID + "','" + str_Mobile_No + "')";

                    cmd.CommandText = sqlCommand;
                    cmd.ExecuteNonQuery();
                    
                    lblMessage.Text = "Property Posted Succesfully";
                    ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('Property posted successfully!')", true);
                    tick_Image.Visible = false;

                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient("relay-hosting.secureserver.net");

                    mail.From = new MailAddress("admin@estatemeet.in");
                    mail.To.Add(new MailAddress("admin@estatemeet.in"));
                    mail.Subject = "New Property added for Rent";//change the subject later
                    mail.Body = "Dear " + "Kalpesh Sir" + "\n\n Mr. " + str_Cust_Name + " has posted new Property on BrokerPluss.com";
                    mail.Body += "\n\n Mobile No :- " + str_Mobile_No;
                    mail.Body += "\n\n Address :- \n\n Location - " + str_Location;
                    
                    if(str_Unit_No.Length > 0)
                        mail.Body += "\n\n Unit No - " + str_Unit_No + ", Wing - " + str_Wing_Name;
                    
                    mail.Body += "\n\n Project/Building Name - " + str_Project_Name;

                    if(str_Street_Name.Length > 0)
                        mail.Body += "\n\n Street Name - " + str_Street_Name;

                    if (str_Landmark.Length > 0)
                        mail.Body += "\n\n Landmark - " + str_Landmark;                  
                   

                    SmtpServer.Port = 25;                    
                    SmtpServer.Credentials = new System.Net.NetworkCredential("admin@estatemeet.in", "Admin123$$$");                  
                    SmtpServer.Send(mail);

                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Opps! Something has gone wrong<br/>" +ex;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                lblMessage.Text = "Incorrect OTP";
            }            
        }
        else
        {
            lblMessage.Text = "Plese send OTP on Mobile";
        }


    }//btn_Post_Property_Click closed

}