<%@ Page Title="estatemeet.in | Rent Property Flat Office Shop in Pimpri Chinchwad" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Rent_Your_Property.aspx.cs" Inherits="Rent_Your_Property" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .leftDiv {
            padding: 15px;
            border: 1px solid rgb(128, 49, 160);
            margin :0px;
            /*background-image:url("Site_Images/bg.jpg");*/
            /*background-color:gray;*/
        }

        .rightDiv {
            margin :0px;
            padding: 15px;
            border: 1px solid rgb(128, 49, 160);
            /*background-image:url("Site_Images/bg.jpg");*/
            /*background-color:gray;*/
        }

        .container {
            display: grid;
            grid-gap: 0px;
            grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
            /*grid-template-rows: repeat(2, 100px);*/
            font-size: 14px;
            /*font-weight: bold;*/
            font-family:sans-serif;
            /*margin-top:10px;*/ 
            background-image:url("Site_Images/bk.jpg");
        }
    </style>
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
    
    <div class="container">

        <div class="leftDiv">
            <center>
            <table>
                <tr class="tr_Height">
                    <td style="">You are<span style="color:red" >*</span></td>

                    <td>
                        <select id="lst_Cust_Type" name="lst_Cust_Type" class="select_Format input_Size">
                            <option> Select </option>
                            <option> Owner </option>
                            <option> Broker </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Property Type<span style="color:red" >*</span></td>

                    <td>
                        <select id="lst_Property_Type" name="lst_Property_Type" class="select_Format input_Size" onchange="make_PR_Type_Visible()">
                            <option> Select </option>
                            <option> Residential </option>
                            <option> Commercial </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Property Sub-Type<span style="color:red" >*</span></td>

                    <td style="position: relative">
                        <select id="lst_Sub_Property_Res" onchange="disable_Unit_Wing('lst_Sub_Property_Res')" name="lst_Property_Sub_Residential" style="" class="select_Format input_Size">
                            <option> Select </option>
                            <option> Flat </option>
                            <option> Independant Villa </option>
                            <option> Row House </option>
                            <option> Independant Building </option>
                        </select>

                        <select id="lst_Sub_Property_Com" onchange="disable_Unit_Wing('lst_Sub_Property_Com')" name="lst_Property_Sub_Commercial" style="position: absolute; top: 10px; left: 1px; visibility: hidden" class="input_Size">
                            <option> Select </option>
                            <option> Office </option>
                            <option> Shop </option>
                            <option> Restaurent </option>
                            <option> Independant Building </option>
                            <option> Pre-School </option>
                            <option> Space for Bank </option>
                            <option> Space for Bank ATM </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Furnished Status<span style="color:red" >*</span></td>

                    <td>
                        <select class="select_Format input_Size" id="txt_Furnished_Status" runat="server">
                            <option> Select </option>
                            <option> Furnished </option>
                            <option> Semi-Furnished </option>
                            <option> Unfurnished </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                        <td >
                        <label id="lbl_Bed_Room">Bed Rooms<span style="color:red" >*</span> </label>
                    </td>

                    <td>
                            <select id="lst_Bed_Rooms" class="select_Format input_Size" name="lst_Bed_Rooms">
                                <option> Select </option>
                                <option> 1 RK </option>
                                <option> 1 BHK </option>
                                <option> 1.5 BHK </option>
                                <option> 2 BHK </option>
                                <option> 2.5 BHK </option>
                                <option> 3 BHK </option>
                                <option> 3.5 BHK </option>
                                <option> 4 BHK </option>
                                <option> 4 BHK+ </option>
                            </select>
                    </td>                
                </tr>

                <tr class="tr_Height">
                    <td style="position:relative">
                        <label id="lbl_Bath_Room">Bath Rooms<span style="color:red" >*</span> </label>
                        <label id="lbl_Wash_Room" style="position: absolute; top: 10px; left: 0px; visibility: hidden">Wash Room </label>
                    </td>

                    <td style="position:relative">
                        <div id="div_Bathroom">
                            <select id="lst_Bathrooms" name="lst_Bathrooms" class="select_Format input_Size">
                                <option> Select </option>
                                <option> 1 </option>
                                <option> 2 </option>
                                <option> 3 </option>
                                <option> 4 </option>
                            </select>

                        </div>
                        <div id="div_Wash_Room" style="position: absolute; top: 10px; left: 0px; visibility: hidden">
                            <select id="lst_Washrooms" name="lst_Washrooms" class="select_Format input_Size">
                                <option> Select </option>
                                <option> Attached </option>
                                <option> Common </option>
                                <option> None </option>
                            </select>
                        </div>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td> Property on Floor<span style="color:red" ><span style="color:red" >*</span></span></td>
                    <td>
                        <select id="lst_Property_On_Floor" name="lst_Property_On_Floor" class="select_Format input_Size" runat="server">
                            <option> Select </option>
                            <option> Basement </option>
                            <option> Ground </option>
                            <option> 1 </option>
                            <option> 2 </option>
                            <option> 3 </option>
                            <option> 4 </option>
                            <option> 5 </option>
                            <option> 6 </option>
                            <option> 7 </option>
                            <option> 8 </option>
                            <option> 9 </option>
                            <option> 10 </option>
                            <option> 11 </option>
                            <option> 12 </option>
                            <option> 13 </option>
                            <option> 14 </option>
                            <option> 15 </option>
                            <option> 16 </option>
                            <option> 17 </option>
                            <option> 18 </option>
                            <option> 19 </option>
                            <option> 20 </option>
                            <option> 21 </option>
                            <option> 22 </option>
                            <option> 23 </option>
                            <option> 24 </option>
                        </select>                    
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td> Total Floors<span style="color:red" ><span style="color:red" >*</span></span> </td>
                    <td> 
                        <select id="lst_Total_Floors" name="lst_Total_Floors" class="select_Format input_Size" runat="server">                           
                            <option> Select </option>
                            <option> Ground </option>
                            <option> 1 </option>
                            <option> 2 </option>
                            <option> 3 </option>
                            <option> 4 </option>
                            <option> 5 </option>
                            <option> 6 </option>
                            <option> 7 </option>
                            <option> 8 </option>
                            <option> 9 </option>
                            <option> 10 </option>
                            <option> 11 </option>
                            <option> 12 </option>
                            <option> 13 </option>
                            <option> 14 </option>
                            <option> 15 </option>
                            <option> 16 </option>
                            <option> 17 </option>
                            <option> 18 </option>
                            <option> 19 </option>
                            <option> 20 </option>
                            <option> 21 </option>
                            <option> 22 </option>
                            <option> 23 </option>
                            <option> 24 </option>
                        </select>
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td colspan="2">
                        <div style="background-color:rgb(128, 49, 198);color:white">
                           <center>
                                Property Location
                           </center>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbl_Unit_No" runat="server" Text="Label">Unit No</asp:Label>
                    </td>
                    <td>
                        <input id="txt_Unit_No" name="txt_Unit_No" style="width: 30px" maxlength="15" runat="server" type="text" tabindex="1" onkeypress="return IsNumericOther(event);" ondrop="return false;" onpaste="return false;" />&nbsp;
                    <asp:Label ID="lbl_Wing_Name" runat="server" Text="Label">Wing</asp:Label>
                        <input id="txt_Wing_Name" name="txt_Wing_Name" class="input_Small_Size" maxlength="15" runat="server" type="text" tabindex="1" />
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Project / Building Name<span style="color:red" >*</span> 
                    </td>

                    <td>
                        <input id="txt_Project_Name" maxlength="40" runat="server" type="text" tabindex="1" />
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Street Name
                    </td>

                    <td>
                        <input id="txt_Street_Name" maxlength="38" runat="server" type="text" tabindex="1" />&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Landmark
                    </td>

                    <td>
                        <input id="txt_Landmark" maxlength="38" runat="server" type="text" tabindex="1" />&nbsp;&nbsp;
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Location<span style="color:red" >*</span></td>

                    <td>
                        <asp:DropDownList ID="lst_Location" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="Location" CssClass="input_Size select_Format" >
                        </asp:DropDownList>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Location_Area] ORDER BY [Location]"></asp:SqlDataSource>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>If Location not found</td>
                    <td>        
                        <input id="chk_Location" name="chk_Location"  type="checkbox"  onclick ="disable_Location()"/>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td><label id="lbl_Location" style="color:gray" >Location</label></td>
                    <td>       
                        <input id="txt_Location" name="txt_Location" disabled="disabled" maxlength="49" type="text" class="" tabindex="1"/>
                    </td>
                </tr>
           
                                   
                <tr class="tr_Height">
                    <td>Salable Area</td>

                    <td>
                        <input id="txt_Built_Up_Area"  maxlength="5" class="input_Small_Size" type="text" runat="server" onkeypress="return IsNumericOther(event);" ondrop="return false;" onpaste="return false;"/>
                        &nbsp;&nbsp;
                    <select id="lst_Built_Up_Area_Unit">
                        <option>Sq. Ft.</option>
                        <option>Sq. Mtr.</option>
                    </select>

                    </td>
                </tr>
                                
                <tr class="tr_Height">
                    <td>Capet Area</td>

                    <td>
                        <input id="txt_Carpet_Area" maxlength="5" class="input_Small_Size" type="text" runat="server" onkeypress="return IsNumericOther(event);" ondrop="return false;" onpaste="return false;" />
                        &nbsp;&nbsp;
                    <select id="lst_Carpet_Area_Unit" runat="server">
                        <option>Sq. Ft.</option>
                        <option>Sq. Mtr.</option>
                    </select>

                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Rent Per Month<span style="color:red" >*</span></td>

                    <td>
                        <input id="txt_Rent_Per_Month" maxlength="7" class="input_Small_Size" type="text" runat="server" onkeypress="return IsNumericOther(event);" ondrop="return false;" onpaste="return false;" onkeyup="return format_Number(this)" />
                        <label id="price"></label>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Deposit<span style="color:red" >*</span></td>

                    <td>
                        <input id="txt_Deposit" maxlength="8" class="input_Small_Size" type="text" runat="server" onkeypress="return IsNumericOther(event);" ondrop="return false;" onpaste="return false;" onkeyup="return format_Number(this)" />
                        <label id="lbl_Deposit"></label>
                    </td>
                </tr>


            </table>
            </center>
        </div>


        <div class="rightDiv">
            <center>
            <table>                

                <tr class="tr_Height">
                    <td>Add Image 1</td>

                    <td>
                        <asp:FileUpload ID="browseImage" runat="server" ToolTip="Please select JPEG format only" />
                        <%--<br /><img src="Site_Images/tick.jpg" id="Img1" visible="false" alt="" style="height:15px" />--%>
                        <br /><asp:Label ID="lblStatusMsg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Add Image 2</td>

                    <td>
                        <asp:FileUpload ID="browseImage2" runat="server" ToolTip="Please select JPEG format only" />
                        <%--<br /><img src="Site_Images/tick.jpg" id="Img2" alt="" style="height:15px" />--%>
                         <br /><asp:Label ID="lblStatusMsg2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Add Image 3</td>

                    <td>
                        <asp:FileUpload ID="browseImage3" runat="server" ToolTip="Please select JPEG format only" />
                        <%--<br /><img src="Site_Images/tick.jpg" id="Img3" alt="" style="height:15px" />--%>
                        <br /><asp:Label ID="lblStatusMsg3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td><label id="lbl_Willing_To_Rent1">Willing to </label>
                        <br />
                        <label id="lbl_Willing_To_Rent2">Rent out to<span style="color:red" >*</span> </label>
                         </td>

                    <td>
                        <input id="Checkbox1" type="checkbox" name="chk_Family" value="Family" />
                        <label id="lbl_Family">Family</label> &nbsp;&nbsp;

                        <input id="Checkbox2" type="checkbox" name="chk_Bachelor" value="Bachelor" />
                        <label id="lbl_Bachelor">Bachelor</label>
                        
                        <br />
                        <input id="Checkbox5" type="checkbox" name="chk_Anyone" value="Anyone" />
                        <label id="lbl_Anyone">Anyone</label>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Agreement Duration<span style="color:red" >*</span> </td>

                    <td>
                        <select id="lst_Agr_Duration" name="lst_Agr_Duration" class="select_Format input_Size">
                            <option>Select </option>
                            <option>11 Months </option>
                            <option>2 Years </option>
                            <option>5 Years </option>
                            <option>10 Years </option>
                            <option>10+ Years </option>
                            <option>Any </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Available From<span style="color:red" >*</span> </td>

                    <td>
                      <select id="Avi_Date" name="Avi_Date" style="">
                            <option>Date </option>
                            <option>1 </option>
                            <option>2 </option>
                            <option>3 </option>
                            <option>4 </option>
                            <option>5 </option>
                          <option>6 </option>
                            <option>7 </option>
                            <option>8 </option>
                            <option>9 </option>
                            <option>10 </option>
                          <option>11 </option>
                            <option>12 </option>
                            <option>13 </option>
                            <option>14 </option>
                            <option>15 </option>
                          <option>16 </option>
                            <option>17 </option>
                            <option>18 </option>
                            <option>19 </option>
                            <option>20 </option>
                          <option>21 </option>
                            <option>22 </option>
                            <option>23 </option>
                            <option>24 </option>
                            <option>25 </option>
                          <option>26 </option>
                            <option>27 </option>
                            <option>28 </option>
                            <option>29 </option>
                            <option>30 </option>
                          <option>31 </option>
                        </select>

                        <select id="Avi_Month" name="Avi_Month" style="">
                            <option> Months </option>
                            <option> Jan </option>
                            <option> Feb </option>
                            <option> Mar </option>
                            <option> Apr </option>
                            <option> May </option>
                            <option> Jun </option>
                            <option> Jul </option>
                            <option> Aug </option>
                            <option> Sep </option>
                            <option> Oct </option>
                            <option> Nov </option>
                            <option> Dec </option>
                        </select>

                        <select id="Avi_Year" name="Avi_Year" style="">
                            <option>Year </option>
                            <option>2018 </option>
                            <option>2019 </option>
                           
                        </select>
                    
                    </td>
                </tr>

                <tr class="tr_Desc">
                    <td>Description </td>

                    <td>
                        <textarea id="txt_Desc" name="txt_Desc" rows="5" cols="21" maxlength="999" placeholder="                     Write few words about your property."></textarea>
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="chk_TermsNCond" type="checkbox" runat="server" style="height: 18px;width:18px" /><span style="color:red" >*</span>
                    </td>

                    <td>
                        <label id="lbl_TermsNCond" style="" runat="server">I accept the <a href="terms_conditions.aspx">Terms & Conditions </a></label>.
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Name<span style="color:red" >*</span> 
                    </td>

                    <td>
                        <input id="txt_Cust_Name" maxlength="50" runat="server" type="text" tabindex="1" />
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Email ID </td>

                    <td>
                        <input id="txt_Email" maxlength="30" runat="server" type="text" tabindex="1" />
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Mobile No<span style="color:red" >*</span></td>

                    <td>
                        <input id="txt_Mobile" maxlength="10" runat="server" type="text" tabindex="1" onkeypress="return IsNumeric(event,'error_Mobile');" ondrop="return false;" onpaste="return false;" />
                        <br />
                        <span id="error_Mobile" style="color: Red; display: none">* Input digits only (0 - 9)</span>
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td> </td>

                    <td>                        
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btn_Verify_Email" ToolTip="Send OTP on Mobile No" runat="server" Text="Send OTP" OnClick="btn_Verify_Email_Click" />
                             <img src="Site_Images/tick.jpg" id="tick_Image" runat="server" visible="false" alt="" style="height:15px" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trOTP" style="" runat="server" class="tr_Height">
                    <td>Enter OTP<span style="color:red" >*</span> </td>

                    <td>
                        <input id="txtOTP" type="text" maxlength="10" runat="server" />
                    </td>
                </tr>
                 
                 <tr class="tr_Height">
                    <td></td>

                    <td>
                        <asp:Button ID="btn_Post_Property" runat="server" Text="Post Property" OnClick="btn_Post_Property_Click" />
                        <br /> <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
            </center>
        </div>
    </div>


</asp:Content>
