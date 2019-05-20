<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Post_Enquiry.aspx.cs" Inherits="Post_Enquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     
    <style type="text/css">
    
        .container_User_Enquiry {
            display: grid;
            grid-gap: 10px;
            grid-template-columns: repeat(auto-fit, minmax(340px, 1fr));
            font-family: Arial;
            font-size: 14px;
            /*font-weight: bold;*/
            color:black;
            width: 90%; 
             /*background-image:url("Site_Images/bk.png");*/ 

        }

        .left_Div_User_Enquiry {
           padding: 0px; 
           border: 1px solid rgb(128,49,160); 
           margin: 0px
        }

        .right_Div_User_Enquiry {
            padding: 0px;
            border: 1px solid rgb(128,49,160);
            margin-bottom: 0px;
        }

       
        
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="background-image:url('Site_Images/bk.jpg');">
        
    <center>
        <br />
    <h2  >
        <label style="color:rgb(128, 49, 160);">
            Post Your Requirement Here
        </label>
    </h2>

     <div class="container_User_Enquiry">

            <div class="left_Div_User_Enquiry">
                <center>
                    <table>

                       <tr class="tr_Height">
                            <td style="">You are
                                <label style="color: red">*</label>
                            </td>

                            <td>
                                <select id="lst_Cust_Type" name="lst_Cust_Type" class="select_Format input_Size" onchange="change_Sale_Type()">
                                    <option>Select </option>
                                    <option>Customer </option>
                                    <option>Broker </option>
                                </select>
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>I want <span style="color: red">* </span></td>
                            <td>
                                <select id="lst_Enquiry_For" name="lst_Enquiry_For" class="select_Format input_Size" onchange="change_Rent_Sale()">
                                    <option>Select </option>
                                    <option>To Buy </option>
                                    <option>On Rent </option>
                                </select>
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>Property Type
                                <label style="color: red">*</label>
                            </td>

                            <td>
                                <select id="lst_Property_Type" name="lst_Property_Type" class="select_Format input_Size" onchange="disable_BedRoom()">
                                    <option>Select </option>
                                    <option>Residential </option>
                                    <option>Commercial </option>
                                </select>
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>Sub-Type
                                <label style="color: red">*</label>
                            </td>

                            <td style="position: relative">
                                <select id="lst_Sub_Property_Res" name="lst_Property_Sub_Residential" style="" class="select_Format input_Size" onchange="disable_BedRoom2()">
                                    <option>Select </option>
                                    <option>Flat </option>
                                    <option>Row House </option>
                                    <option>Independant Villa </option>
                                    <option>Independant Building </option>
                                </select>

                                <select id="lst_Sub_Property_Com" name="lst_Property_Sub_Commercial" style="position: absolute; top: 10px; left: 1px; visibility: hidden" class="select_Format input_Size">
                                    <option>Select </option>
                                    <option>Office </option>
                                    <option>Shop </option>
                                    <option>Restaurent </option>
                                    <option>Independant Building </option>
                                    <option>Pre-School </option>
                                    <option>Space for Bank </option>
                                    <option>Space for Bank ATM </option>
                                </select>
                            </td>
                        </tr>
                        <tr class="tr_Height">
                            <td>
                                <label id="lbl_SaleType">
                                    Sale Type
                                    <label style="color: red">*</label>
                                </label>
                            </td>
                            <td>
                                <select id="lst_Sale_Type" name="lst_Sale_Type" class="select_Format input_Size" onchange="disable_Enable_Avai()">
                                    <option>Select </option>
                                    <option>New Booking </option>
                                    <option>Resale </option>
                                    <option>Pre Launching </option>
                                </select>
                            </td>
                        </tr>
                        <tr class="tr_Height">
                            <td>
                                <label id="lbl_Avai">
                                    Availability
                                    <label style="color: red">*</label>
                                </label>
                            </td>
                            <td>
                                <select id="lst_Construction_Status" name="lst_Construction_Status" class="select_Format input_Size">
                                    <option>Select </option>
                                    <option>Ready To Move </option>
                                    <option>Under Construction </option>
                                </select>
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>Location
                                <label style="color: red">
                                    <label style="color: red">*</label>
                                </label>
                            </td>
                            <td>

                                <asp:ListBox ID="list_Location" runat="server" SelectionMode="Multiple" class="multi_Select_Format input_Size " DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="Location" ToolTip="Use 'CTR + Mouse left click' to select multiple choices">
                                </asp:ListBox>

                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Location_Area] ORDER BY [Location]"></asp:SqlDataSource>
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>If Location <br />not found</td>
                            <td>
                                <input id="chk_Location" name="chk_Location" type="checkbox" style="height: 18px;width:18px" onclick="disable_Location()" />
                                <%--<asp:CheckBox ID="chk_Location"  onchange="  />--%>   
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>
                                <label id="lbl_Location" style="color: gray">Location</label></td>
                            <td>
                                <input id="txt_Location" name="txt_Location" disabled="disabled" maxlength="30" type="text" class="txt_Format" tabindex="1" />
                            </td>
                        </tr>


                        <tr class="tr_Height">
                            <td style="position: relative">
                                <label id="lbl_Bed_Room">
                                    Bed Rooms
                                    <label style="color: red">*</label>
                                </label>

                            </td>

                            <td style="position: relative">
                                <select id="lst_Bed_Rooms" name="lst_Bed_Rooms" class="select_Format input_Size">
                                    <option>Select </option>
                                    <option>1 RK </option>
                                    <option>1 BHK </option>
                                    <option>1.5 BHK </option>
                                    <option>2 BHK </option>
                                    <option>2.5 BHK </option>
                                    <option>3 BHK </option>
                                    <option>3.5 BHK </option>
                                    <option>4 BHK </option>
                                    <option>4 BHK+ </option>
                                </select>
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>Budget
                                <label style="color: red">*</label>
                            </td>
                            <td style="position: relative">
                                <div id="div_Sale">
                                    <%--<asp:DropDownList ID="lst_Budget_Min" class="input_Min_Max" runat="server" DataSourceID="SqlDataSource2" DataTextField="Value" DataValueField="Value">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Sell_Budget_Min]"></asp:SqlDataSource>--%>

                                    <select id="lst_Budget_Min" name="lst_Budget_Min" class="input_Min_Max select_Format">
                                        <option> Min </option>
                                        <option> 5 Lac </option>
                                        <option> 10 Lac </option>
                                        <option> 15 Lac </option>
                                        <option> 20 Lac </option>
                                        <option> 25 Lac </option>
                                        <option> 30 Lac </option>
                                        <option> 40 Lac </option>
                                        <option> 50 Lac </option>
                                        <option> 60 Lac </option>
                                        <option> 70 Lac </option>
                                        <option> 75 Lac </option>
                                        <option> 90 Lac </option>
                                        <option> 1 Cr </option>
                                        <option> 1.5 Cr </option>
                                        <option> 2 Cr </option>
                                        <option> 3 Cr </option>
                                        <option> 5 Cr </option>
                                    </select>

                                  &nbsp;

                                     <select id="lst_Budget_Max" name="lst_Budget_Max" class="select_Format input_Min_Max">
                                        <option> Max </option>
                                        <option> 5 Lac </option>
                                        <option> 10 Lac </option>
                                        <option> 15 Lac </option>
                                        <option> 20 Lac </option>
                                        <option> 25 Lac </option>
                                        <option> 30 Lac </option>
                                        <option> 40 Lac </option>
                                        <option> 50 Lac </option>
                                        <option> 60 Lac </option>
                                        <option> 70 Lac </option>
                                        <option> 75 Lac </option>
                                        <option> 90 Lac </option>
                                        <option> 1 Cr </option>
                                        <option> 1.5 Cr </option>
                                        <option> 2 Cr </option>
                                        <option> 3 Cr </option>
                                        <option> 5 Cr </option>
                                        <option> 5 Cr+ </option>
                                    </select>

                      <%--  <asp:DropDownList ID="lst_Budget_Max" CssClass="input_Min_Max" runat="server" DataSourceID="SqlDataSource3" DataTextField="Value" DataValueField="Value">
                        </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Sell_Budget_Max]"></asp:SqlDataSource>--%>
                                </div>

                                <div id="div_Rent" style="visibility: hidden; position: absolute; top: 3px; left: 1px">
                                   <%-- <asp:DropDownList ID="lst_Budget_Min_Rent" class="input_Min_Max" runat="server" DataSourceID="SqlDataSource4" DataTextField="Value" DataValueField="Value">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Rent_Budget_Min]"></asp:SqlDataSource>


                                    <asp:DropDownList ID="lst_Budget_Max_Rent" CssClass="input_Min_Max" runat="server" DataSourceID="SqlDataSource5" DataTextField="Value" DataValueField="Value">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Rent_Budget_Max]"></asp:SqlDataSource>--%>
                               
                                    <select id="lst_Budget_Min_Rent" name="lst_Budget_Min_Rent" class="select_Format input_Min_Max">
                                        <option> Min </option>
                                        <option> 5 Th </option>
                                        <option> 10 Th </option>
                                        <option> 15 Th </option>
                                        <option> 20 Th </option>
                                        <option> 25 Th </option>
                                        <option> 30 Th </option>
                                        <option> 40 Th </option>
                                        <option> 50 Th </option>
                                        <option> 45 Th </option>
                                        <option> 60 Th </option>
                                        <option> 75 Th </option>
                                        <option> 90 Th </option>
                                        <option> 1 lac </option>
                                        <option> 1.5 lac </option>
                                        <option> 2 lac </option>
                                        <option> 5 lac </option>
                                    </select>

                                    &nbsp;

                                    <select id="lst_Budget_Max_Rent" name="lst_Budget_Max_Rent" class="select_Format input_Min_Max">
                                        <option> Max </option>
                                       <option> 5 Th </option>
                                        <option> 10 Th </option>
                                        <option> 15 Th </option>
                                        <option> 20 Th </option>
                                        <option> 25 Th </option>
                                        <option> 30 Th </option>
                                        <option> 40 Th </option>
                                        <option> 50 Th </option>
                                        <option> 45 Th </option>
                                        <option> 60 Th </option>
                                        <option> 75 Th </option>
                                        <option> 90 Th </option>
                                        <option> 1 lac </option>
                                        <option> 1.5 lac </option>
                                        <option> 2 lac </option>
                                        <option> 5 lac </option>
                                        <option> 5 lac+ </option>
                                    </select>
                                    
                                </div>

                            </td>
                        </tr>
                       

                    </table>
                </center>
            </div>

            <div class="right_Div_User_Enquiry">
                <center>
                    <table>
                         <tr class="tr_Height">
                            <td>Carpet Area</td>
                            <td>
                                <input id="txt_Area_Min" placeholder="Min" maxlength="5" class="txt_Format input_Min_Max_Txt" runat="server" type="text" tabindex="1" />
                                
                                <input id="txt_Area_Max" placeholder="Max" maxlength="5" class="txt_Format input_Min_Max_Txt" runat="server" type="text" tabindex="1" />

                                <select id="lst_Built_Up_Area_Unit" runat="server" class="select_Format input_Min_Max" >
                                    <option>Sq.Ft.</option>
                                    <option>Sq.Mtr.</option>
                                </select>
                            </td>
                        </tr>           

                         <tr class="tr_Height" id="tr_Furnish_Status">
                            <td>Furnished Status</td>

                            <td>
                                <select class="select_Format input_Size" id="txt_Furnished_Status" runat="server">
                                    <option>Select </option>
                                    <option>Furnished </option>
                                    <option>Semi-Furnished </option>
                                    <option>Unfurnished </option>
                                </select>
                            </td>
                        </tr>
                        <tr class="tr_Height">
                            <td>Deal Closing <label style="color: red">*</label>
                            </td>
                            <td>
                                <select id="lst_Deal_Closing" class="select_Format input_Size" runat="server">
                                    <option>Select </option>
                                    <option>Immediate </option>
                                    <option>In this month </option>
                                    <option>After a month </option>
                                </select>
                            </td>
                        </tr>

                                    
                       
                        <tr>
                            <td>Particular<br />
                                Requirements </td>

                            <td>
                                <textarea id="txt_Desc" maxlength="999" placeholder="                     Write few words about your requirement." class="txt_Area_Format" runat="server" rows="4" cols="15"></textarea>
                            </td>
                        </tr>
                        <tr class="tr_Height">
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="chk_TermsNCond" type="checkbox" runat="server" style="height: 18px;width:18px" />
                                <label style="color: red">*</label>
                            </td>

                            <td>
                                <label id="lbl_TermsNCond" runat="server">
                                    I accept <a href="terms_conditions.aspx">Terms & Conditions </a>.
                                </label>
                            </td>
                        </tr>
                        <tr class="tr_Height">
                            <td>Name
                                <label style="color: red">*</label>
                            </td>
                            <td>
                                <input id="txt_Name" maxlength="50" class="txt_Format" runat="server" type="text" tabindex="1" />
                            </td>
                        </tr>

                         <tr class="tr_Height">
                            <td>
                                Email ID                                
                            </td>
                            <td>
                                <input id="txt_Email" maxlength="40" class="txt_Format" runat="server" type="text" tabindex="1" />
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>Mobile No
                                <label style="color: red">*</label>
                            </td>
                            <td>
                                <input id="txt_Mobile" maxlength="10" class="txt_Format" runat="server" type="text" tabindex="1" />
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td>
                            </td>
                            <td>
                                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                <asp:UpdatePanel ID="up1" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btn_Verify_Email" CssClass="btn" ToolTip="Send OTP on Mobile No" runat="server" Text="Send OTP" OnClick="btn_Verify_Email_Click" />
                                        <img src="Site_Images/tick.jpg" id="tick_Image" runat="server" visible="false" alt="" style="height: 15px" />
                                        <asp:Label ID="lbl_Status_Msg_Mobile" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                       


                        <tr id="trOTP" style="" runat="server" class="tr_Height">
                            <td>Enter OTP
                                <label style="color: red">*</label>
                            </td>

                            <td>
                                <input id="txtOTP" type="text" maxlength="10" class="txt_Format" runat="server" />
                            </td>
                        </tr>

                        <tr class="tr_Height">
                            <td></td>
                            <td>
                                <br />
                                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btn_Submit_Form" runat="server" CssClass="btn" Text="Post Enquiry" OnClick="btn_Submit_Form_Click" />
                                        <br /><br /><asp:Label ID="lbl_Status_Msg" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>

                        </tr>
                    </table>                    
                   
                    <br />
                    <br />
                </center>
            </div>

        </div>
    
    </center>

    </div>

</asp:Content>

