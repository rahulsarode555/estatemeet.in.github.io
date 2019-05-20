<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_Contact_No.aspx.cs" Inherits="View_Contact_No" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="functions.js"  lang="javascript" type="text/javascript" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <center>
        <div style="margin:10px;border:1px solid gray;padding:10px;" id="demo" runat="server">
            <table>               
                <tr class="tr_Height">
                    <td>Name* 
                    </td>

                    <td>
                        <input id="txt_Cust_Name" maxlength="50" runat="server" type="text" tabindex="1" />
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Mobile No*</td>

                    <td>
                        <input id="txt_Mobile" maxlength="10" runat="server" type="text" tabindex="1" onkeypress="return IsNumeric(event,'error_Mobile');" ondrop="return false;" onpaste="return false;" />
                        <br />
                        <span id="error_Mobile" style="color: Red; display: none">* Input digits only (0 - 9)</span>
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td>Email ID* </td>

                    <td>
                        <input id="txt_Email" maxlength="30" runat="server" type="text" tabindex="1" />                     
                    </td>
                </tr>
                 <tr class="tr_Height">
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="chk_TermsNCond" type="checkbox" runat="server" />*
                    </td>

                    <td>
                        <label id="lbl_TermsNCond" style="" runat="server">I accept the <a href="terms_conditions.aspx">Terms & Conditions </a></label>
                        <br />
                        And also the Brokrage Charges
                    </td>
                </tr>
                <tr class="tr_Height">
                    <td></td>

                    <td>                        
                        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btn_Verify_Email" ToolTip="Send OTP on this Mail ID" runat="server" Text="Send OTP" OnClick="btn_Verify_Email_Click" />
                             <img src="Site_Images/tick.jpg" id="tick_Image" runat="server" visible="false" alt="" style="height:15px" />
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr id="trOTP" style="" runat="server" class="tr_Height">
                    <td>Enter OTP* </td>

                    <td>
                        <input id="txtOTP" type="text" maxlength="10" runat="server" />
                    </td>
                </tr>
                 
                 <tr class="tr_Height">
                    <td></td>

                    <td>
                        <asp:Button ID="btn_Post_Property" runat="server" Text="View Contact" OnClick="btn_View_Contact_Click" />
                        <br /> <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
<%--                        <input id="Button1" type="button" value="ok"  onclick="basicPopup();" />--%>
                    </td>
                </tr>
            </table>
        </div>

        <div style="margin:10px;border:1px solid gray;padding:10px;font-size:30px;visibility:hidden;position:absolute;top:30px; left:30px;" id="div_Contact" runat="server">
            <table>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;<img src="Site_Images/contact.png" img" style="width:40px" />
                    </td>
                    <td>
                        : 9112073377
                    </td>
                </tr>
                <tr>
                    <td>
                        Timming
                    </td>
                    <td>
                        : 9 AM To 6 PM
                    </td>
                </tr>
            </table>
            
            


        </div>
        </center>
    </div>
    </form>
</body>
</html>
