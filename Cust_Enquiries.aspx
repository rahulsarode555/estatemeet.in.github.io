<%@ Page Title="estatemeet.com | Find Property in Pimpri Chinchwad" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cust_Enquiries.aspx.cs" Inherits="Cust_Enquiries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="background-image:url('Site_Images/bk.jpg');">   
    <asp:Label ID="lbl_Message" runat="server" ></asp:Label>

     <div class="searchTab" style="visibility:hidden" >
         <br /><br />
        
        Property Type :

        <asp:DropDownList ID="lst_Properyt_Type" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem  Value ="all"> All </asp:ListItem>
            <asp:ListItem> Flat </asp:ListItem>
            <asp:ListItem> Independant Villa </asp:ListItem>
            <asp:ListItem> Row House </asp:ListItem>
            <asp:ListItem> Independant Building </asp:ListItem>
            <asp:ListItem> Office </asp:ListItem>
            <asp:ListItem> Shop </asp:ListItem>
            <asp:ListItem> Restaurent </asp:ListItem>
            <asp:ListItem> Pre-School </asp:ListItem>
            <asp:ListItem> Space for Bank </asp:ListItem>
            <asp:ListItem> Space for Bank ATM </asp:ListItem>
        </asp:DropDownList>        

        <br /><br />

        
        Location :  &nbsp;&nbsp;&nbsp;

        <asp:DropDownList ID="list_Location" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem Value="all"> All </asp:ListItem>
            <asp:ListItem> Akurdi </asp:ListItem>
            <asp:ListItem> Bhosari </asp:ListItem>
            <asp:ListItem> Chikhali </asp:ListItem>
            <asp:ListItem> Chinchwad </asp:ListItem>
            <asp:ListItem> Hinjewadi </asp:ListItem>
            <asp:ListItem> Jagtap-Dairy </asp:ListItem>
            <asp:ListItem> Kalewadi </asp:ListItem>
            <asp:ListItem> Moshi </asp:ListItem>
            <asp:ListItem> Nigdi </asp:ListItem>
            <asp:ListItem> Pimple-Gurav </asp:ListItem>
            <asp:ListItem> Pimple-Nilakh </asp:ListItem>
            <asp:ListItem> Pimple-Saudagar </asp:ListItem>
            <asp:ListItem> Pimpri </asp:ListItem>
            <asp:ListItem> Pradhikaran </asp:ListItem>
            <asp:ListItem> Punawale </asp:ListItem>
            <asp:ListItem> Ravet </asp:ListItem>
            <asp:ListItem> Sangavi </asp:ListItem>
            <asp:ListItem> Tathawade </asp:ListItem>
            <asp:ListItem> Thergaon </asp:ListItem>
            <asp:ListItem> Wakad </asp:ListItem>
        </asp:DropDownList>        
        

        <br /><br />
        Availability :  

        <asp:DropDownList ID="lst_Construction_Status" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem Value="all"> All </asp:ListItem>
            <asp:ListItem> Ready To Move </asp:ListItem>
            <asp:ListItem> Under Construction </asp:ListItem>
            <asp:ListItem> Pre Launching </asp:ListItem>
        </asp:DropDownList>    
        
        
        <br /><br />
        
        Budget :

        <asp:DropDownList ID="lst_Budget_Min" runat="server"   AutoPostBack="True"  OnSelectedIndexChanged="change_Budget" DataSourceID="SqlDataSource1" DataTextField="Value" DataValueField="ID" >
            
        </asp:DropDownList>    
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Sell_Budget_Min]"></asp:SqlDataSource>
            
        &nbsp;&nbsp;

        <asp:DropDownList ID="lst_Budget_Max" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" DataSourceID="SqlDataSource2" DataTextField="Value" DataValueField="ID" >
            
        </asp:DropDownList>   
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Sell_Budget_Max]"></asp:SqlDataSource>


        <br /><br />
                       
        Sale Type :

        <asp:DropDownList ID="lst_Sale_Type" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem Value="all"> All </asp:ListItem>
            <asp:ListItem> New Booking </asp:ListItem>
            <asp:ListItem> Resale </asp:ListItem>
        </asp:DropDownList>
    </div>

    <div>  
        <%=html%>
    </div>

    </div>

     <div id="resize_div_Desktop">
        <img src="Site_Images/close.gif" alt="Close" id="CloseImage" onclick="makePopUpHidden('_Desktop')"/>
        <br />
        <center>
            <div id="demo" runat="server">
                <table>
                    <tr class="tr_Height">
                        <td>Name <span style="color: red">*</span>
                        </td>

                        <td>
                            <input id="txt_Cust_Name" maxlength="50" class="txt_Format" runat="server" type="text" tabindex="1" />
                        </td>
                    </tr>
                    <tr class="tr_Height">
                        <td>Mobile No <span style="color: red">*</span></td>

                        <td>
                            <input id="txt_Mobile" maxlength="10" class="txt_Format" runat="server" type="text" tabindex="2" onkeypress="return IsNumeric(event,'error_Mobile');" ondrop="return false;" onpaste="return false;" />
                            <br />
                            <span id="error_Mobile" style="color: Red; display: none">* Input digits only (0 - 9)</span>
                        </td>
                    </tr>
                    <tr class="tr_Height">
                        <td>Email ID <span style="color: red">*</span> </td>

                        <td>
                            <input id="txt_Email" maxlength="30" class="txt_Format" runat="server" type="text" tabindex="3" />
                        </td>
                    </tr>
                    <tr class="tr_Height">
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="chk_TermsNCond" type="checkbox" runat="server" tabindex="4" />
                            <span style="color: red">*</span>
                        </td>

                        <td>
                             <div id="tr_TermsNCond" runat="server" class="div_Terms_Cond">
                                    <label id="lbl_TermsNCond" runat="server">
                                        I accept <a href="terms_conditions.aspx">Terms & Conditions </a>
                                        &nbsp;and also Brokerage Charges
                                    </label>
                                </div>
                        </td>
                    </tr>
                    <tr class="tr_Height">
                        <td></td>

                        <td>
                            <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btn_Verify_Email" ToolTip="Send OTP on Mobile" tabindex="5" runat="server" Text="Send OTP" OnClick="btn_Verify_Email_Click" />
                                    <img src="Site_Images/tick.jpg" id="tick_Image" runat="server" visible="false" alt="" style="height: 15px" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr id="trOTP" style="" runat="server" class="tr_Height">
                        <td>Enter OTP <span style="color: red">*</span> </td>

                        <td>
                            <input id="txtOTP" type="text"  class="txt_Format" maxlength="5" runat="server" tabindex="6" />
                        </td>
                    </tr>

                    <tr class="tr_Height">

                        <td colspan="2">
                            <center>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Button ID="btn_Post_Property" runat="server" Text="View Contact" OnClick="btn_View_Contact_Click" tabindex="7"/>
                                    <br />
                                    <asp:Label ID="lblMessage" ForeColor="Red" runat="server" Text=""></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            </center>
                        </td>
                    </tr>                    
                </table>
            </div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
                <div visible="false"   style="margin: 10px;border: 1px solid gray; padding: 10px; font-size: 20px;" id="div_Contact" runat="server">
            
                <table>
                    <tr>
                        <td>
                             <a href="tel:+91-9112073377">
                                <img alt="" src="Site_Images/contact.png" style="width: 30px" />
                            </a>
                        </td>
                        <td>: 9112073377
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img alt="" src="Site_Images/Time.png" style="width: 30px" />
                        </td>
                        <td>: 9 am To 6 pm
                        </td>
                    </tr>
                </table>

                </div>
            </ContentTemplate>
            </asp:UpdatePanel>

        </center>
    </div>

</asp:Content>

