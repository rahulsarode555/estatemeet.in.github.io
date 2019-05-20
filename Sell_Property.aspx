<%@ Page Title="estatemeet.in | Sell Property in Pimpri Chinchwad" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Sell_Property.aspx.cs" Inherits="Sell_Property" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .leftDiv {
            padding: 10px;
            /*margin: 10px;
            margin-top:20px;*/
            border: 1px solid rgb(128, 49, 160);
            /*background-color:rgb(228, 227, 227);*/
            /*background-image:url("Site_Images/bk.jpg");*/
            /*border-style: outset;*/
        }

        .rightDiv {
            padding: 10px;
            /*margin: 10px;
            margin-top:20px;*/
            border: 1px solid rgb(128, 49, 160);
            /*background-color:rgb(228, 227, 227);*/
             /*background-image:url("Site_Images/bk.jpg");*/
            /*border-style: outset;*/
        }

        .container {
            display: grid;
            grid-gap: 0px;
            grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
            font-size: 14px;
            /*font-weight: bold;*/
            font-family:sans-serif;
            color:black;
            background-image:url("Site_Images/bk.jpg");
           
        }
    </style>
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
    
    <div class="container">

        <div class="leftDiv" runat="server" id="div_Left">
            <center>
            <table border="0">
                <tr class="tr_Height">
                    <td style="">You are<span style="color:red" >*</span></td>

                    <td>
                        <select id="lst_Cust_Type" name="lst_Cust_Type" class="select_Format input_Size" onchange="change_Sale_Type()">
                            <option>Select </option>
                            <option>Owner </option>
                            <option>Broker </option>
                            <option>Builder </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td style="">
                        <label id="lbl_RERA">RERA Reg.No.</label>

                    </td>

                    <td>
                        <input id="txt_RERA" runat="server" maxlength="12" type="text" class="input_Size" />
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Sale Type<span style="color:red" >*</span></td>
                    <td>
                        <select id="lst_Sale_Type"  name="lst_Sale_Type" class="select_Format input_Size">
                            <option>Select </option>
                            <option>New Booking </option>
                            <option>Resale </option> 
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Construction Status<span style="color:red" >*</span>
                    </td>
                    <td>
                        <select id="lst_Const_Status" class="select_Format input_Size" name="lst_Const_Status" onchange="make_Age_Or_Pos_Visible()">
                            <option> Select </option>
                            <option> Ready To Move </option>
                            <option> Under Construction </option>
                        </select>

                    </td>
                </tr>

                <tr class="tr_Height">

                    <td style="position: relative">
                        <label id="lbl_Age_Of_Prop">Age of Property<span style="color:red" >*</span> </label>
                        <label id="lbl_Possession_In" style="position: absolute; top: 12px; left: 0px; visibility: hidden">Possession in<span style="color:red" >*</span> </label>

                    </td>
                    <td style="position: relative">
                        <div id="div_Age">

                            <select id="lst_Age_Of_property" class="select_Format input_Size" name="lst_Age_Of_property">
                                <option>Select </option>
                                <option>1 Year </option>
                                <option>2 Years </option>
                                <option>3 Years </option>
                                <option>4 Years </option>
                                <option>4+ Years </option>
                            </select>

                        </div>

                        <div style="position: absolute; top: 4px; left: 0px; visibility: hidden" id="div_Possession">
                            
                            <select id="lst_Possession_In_Month" class="select_Format" name="lst_Possession_In_Month">
                                <option>Month </option>
                                <option>Jan </option>
                                <option>Feb </option>
                                <option>Mar </option>
                                <option>April </option>
                                <option>May </option>
                                <option>Jun </option>
                                <option>July </option>
                                <option>Aug </option>
                                <option>Sep </option>
                                <option>Oct </option>
                                <option>Nov </option>
                                <option>Dec </option>
                            </select>

                            &nbsp;&nbsp;                        
                            <select id="lst_Possession_In" class="select_Format" name="lst_Possession_In">
                                <option> Year </option>
                                <option> 2018 </option>
                                <option> 2019 </option>
                                <option> 2020 </option>
                                <option> 2021 </option>
                                <option> 2022 </option>
                                <option> 2023 </option>
                                <option> 2024 </option>
                                <option> 2025 </option>
                            </select>



                        </div>

                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Property Type<span style="color:red" >*</span></td>

                    <td>
                        <select id="lst_Property_Type" name="lst_Property_Type" class="select_Format input_Size" onchange="make_PR_Type_Visible()">
                            <option>Select </option>
                            <option>Residential </option>
                            <option>Commercial </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Property Sub-Type<span style="color:red" >*</span></td>

                    <td style="position: relative">
                        <select id="lst_Sub_Property_Res" onchange="disable_Acc_Ind_Build('lst_Sub_Property_Res')" name="lst_Property_Sub_Residential" style="" class="select_Format input_Size">
                            <option> Select </option>
                            <option> Flat </option>
                            <option> Independant Villa </option>
                            <option> Row House </option>
                            <option> Independant Building </option>
                        </select>

                        <select id="lst_Sub_Property_Com" onchange="disable_Acc_Ind_Build('lst_Sub_Property_Com')" name="lst_Property_Sub_Commercial" style="position: absolute; top: 10px; left: 1px; visibility: hidden" class="select_Format input_Size">
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

                <tr class="tr_Height" id="tr_Furnish_Status">
                    <td>Furnished Status<span style="color:red" >*</span></td>

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
                        <label id="lbl_Wash_Room" style="position: absolute; top: 12px; left: 0px; visibility: hidden">Wash Room<span style="color:red" >*</span> </label>
                    </td>

                    <td style="position:relative">
                        <div id="div_Bathroom">
                            <select id="lst_Bathrooms" class="select_Format input_Size" runat="server">
                                <option> Select </option>
                                <option> 0 </option>
                                <option> 1 </option>
                                <option> 2 </option>
                                <option> 3 </option>
                                <option> 4 </option>
                            </select>

                        </div>
                        <div id="div_Wash_Room" style="position: absolute; top: 12px; left: 0px; visibility: hidden">
                            <select id="lst_Washrooms" class="select_Format input_Size" runat="server">
                                <option> Select </option>
                                <option> Attached </option>
                                <option> Common </option>
                                <option> None </option>
                            </select>
                        </div>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td><label id="lbl_Property_On_Floor"> Property on Floor </label> <span style="color:red" >*</span></td>
                    <td>
                        <select id="lst_Property_On_Floor" name="lst_Property_On_Floor" class="select_Format input_Size">
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
                    <td> Total Floors<span style="color:red" >*</span> </td>
                    <td> 
                        <select id="lst_Total_Floors" name="lst_Total_Floors" class="select_Format input_Size" >                           
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
                        <input id="txt_Unit_No" style="width: 30px" maxlength="15" runat="server" type="text" tabindex="1" onkeypress="return IsNumericOther(event);" ondrop="return false;" onpaste="return false;" />&nbsp;
                    <asp:Label ID="lbl_Wing_Name" runat="server" Text="Label">Wing</asp:Label>
                        <input id="txt_Wing_Name" class="input_Small_Size" maxlength="15" runat="server" type="text" tabindex="1" />
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>
                        Building Name<span style="color:red" >*</span>
                    </td>

                    <td>
                        <input id="txt_Project_Name" maxlength="30" runat="server" type="text" tabindex="1" />
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>
                        Street Name
                    </td>

                    <td>
                        <input id="txt_Street_Name" maxlength="30" runat="server" type="text" tabindex="1" />&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Landmark
                    </td>

                    <td>
                        <input id="txt_Landmark" maxlength="30" runat="server" type="text" tabindex="1" />&nbsp;&nbsp;
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Location<span style="color:red" >*</span></td>

                    <td>
                        <asp:DropDownList ID="lst_Location" runat="server" DataSourceID="SqlDataSource1" DataTextField="Location" DataValueField="Location" CssClass="input_Size select_Format">
                        </asp:DropDownList>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Location_Area] ORDER BY [Location]"></asp:SqlDataSource>
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>If Location not found</td>
                    <td>        
                        <input id="chk_Location" name="chk_Location" type="checkbox" onclick ="disable_Location()"/> 
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td><label id="lbl_Location" style="color:gray" >Location</label></td>
                    <td>       
                        <input id="txt_Location" name="txt_Location" disabled="disabled" maxlength="49" type="text" tabindex="1"/>
                    </td>
                </tr>

            </table>
            </center>
        </div>

        <center>
        <div class="rightDiv">
            <table>

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
                    <td>Price<span style="color:red" >*</span></td>

                    <td>
                        <input id="txt_Expected_Price" maxlength="11" class="input_Small_Size" type="text" runat="server" onkeypress="return IsNumericOther(event);" ondrop="return false;" onpaste="return false;" onkeyup="return format_Number(this)" />
                        <label id="price"></label>
                    </td>
                </tr>

                <tr class="tr_Height" style="height:50px">
                    <td><br />Add Image 1</td>

                    <td>                        
                       <%-- <span id="Span2" style="color: Red;"> Only JPG Upto 5 MB </span><br />--%>
                        <asp:FileUpload ID="browseImage" runat="server" ToolTip="Please select JPEG format only" />                        
                        <br /><asp:Label ID="lblStatusMsg" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Add Image 2</td>

                    <td>
                        <asp:FileUpload ID="browseImage2" runat="server" ToolTip="Please select JPEG format only" />
                         <br /><asp:Label ID="lblStatusMsg2" runat="server" Text=""></asp:Label>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>Add Image 3</td>

                    <td>
                        <asp:FileUpload ID="browseImage3" runat="server" ToolTip="Please select JPEG format only" />
                        <br /><asp:Label ID="lblStatusMsg3" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
               
                <tr class="tr_Height">
                    <td>Parking<span style="color:red" >*</span><br /><br /><br /><br />&nbsp; </td>
                    <td style="position: relative">
                        Yes <input id="Radio_parking_1" name="Parking_type" checked="checked" type="radio" onchange="make_No_Of_Parking_Visible()" /> &nbsp;&nbsp; 
                        No <input id="Radio_parking_2"  name="Parking_type" type="radio" onchange="make_No_Of_Parking_Visible()" />
                        <br /><br />
                        <select id="lst_Reserverd_Parking" class="input_Small_Size">
                            <option> Select </option>
                            <option>Open </option>
                            <option>Covered </option>
                        </select>

                        <select id="lst_No_Of_Parking" style="width:40px">
                            <option>0 </option>
                            <option>1 </option>
                            <option>2 </option>
                            <option>3 </option>
                        </select>
                        <br /><br />
                        <select id="lst_Reserverd_Parking2" class="input_Small_Size" >
                            <option> Select </option>
                            <option>Open </option>
                            <option>Covered </option>
                        </select>

                        <select id="lst_No_Of_Parking2" style="width:40px">
                            <option>0 </option>
                            <option>1 </option>
                            <option>2 </option>
                            <option>3 </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Amenities">
                    <td>Amenities </td>

                    <td>
                        <table>
                            <tr>
                                <td>
                                    <input name="chk_Amenities_Lift" id="chk_Amenities_Lift" runat="server" type="checkbox" />
                                    Lift </td>
                                <td>
                                    <input name="chk_Amenities_Security" id="chk_Amenities_Security" runat="server" type="checkbox" />
                                    Security 24x7 </td>
                            </tr>
                            <tr>
                                <td>
                                    <input name="chk_Amenities_Garden" id="chk_Amenities_Garden" runat="server"  type="checkbox" />
                                    Garden  </td>
                                <td>
                                    <input name="chk_Amenities_PowerBK" id="chk_Amenities_PowerBK" runat="server"  type="checkbox" />
                                    Power Backup </td>
                            </tr>
                            <tr>
                                <td>
                                    <input name="chk_Amenities_Piped_Gas" id="chk_Amenities_Piped_Gas"  runat="server" type="checkbox" />
                                    Piped Gas </td>
                                <td>
                                    <input name="chk_Amenities_Solar_System" id="chk_Amenities_Solar_System" runat="server" type="checkbox" />
                                    Solar System </td>
                            </tr>
                            <tr>
                                <td>
                                    <input name="chk_Amenities_Water" id="chk_Amenities_Water" runat="server" type="checkbox" />
                                    Water 24x7 </td>
                                <td>
                                    <input name="chk_Amenities_Swimming" id="chk_Amenities_Swimming" runat="server"  type="checkbox" />
                                    Swimming Pool</td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td>Description </td>

                    <td>
                        <textarea id="txt_Desc" maxlength="999" placeholder="                     Write few words about your property." runat="server" rows="5" cols="21"></textarea>
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
                    <td>Your Name<span style="color:red" >*</span> 
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
                        <input id="txt_Mobile" maxlength="10" runat="server" type="text" tabindex="1" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                        
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td>
                    </td>
                    <td>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btn_Verify_Email" ToolTip="Send OTP on Mobile No" CssClass="btn" runat="server" Text="Send OTP" OnClick="btn_Verify_Email_Click" />
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
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                            <asp:Button ID="btn_Post_Property" runat="server" CssClass="btn" Text="Post Property" OnClick="btn_Post_Property_Click" />
                            <br /><br /> <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                        <%--</ContentTemplate>
                        </asp:UpdatePanel>--%>
                    </td>
                </tr>

            </table>
        </div>
        </center>
    </div>


</asp:Content>
