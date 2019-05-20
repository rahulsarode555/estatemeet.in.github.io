<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register_Member.aspx.cs" Inherits="Register_Member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="height:500px; border:0px solid red; overflow:auto;">
    <center>
        
        <br />

        Enter your Business / Personal details below <br /><br />
        <table style="font-family:'Bookman Old Style';">
            <tr style="height:30px">
                <td>
                    Name* 
                </td>
                <td>
                    <input id="txt_Member_Name" maxlength="50" runat="server" type="text" tabindex="1"/>
                </td>
            </tr>
            <tr>
                <td>Mobile No*</td>
                <td>
                    <input id="txt_Mobile_NO" maxlength="10" runat="server" type="text" tabindex="1"/>
                </td>
            </tr>
            <tr>
                <td>Email ID*</td>
                <td>
                    <input id="txt_Email_ID" maxlength="30" runat="server" type="text" tabindex="1"/>
                </td>
            </tr>
            <tr>
                <td>Password*</td>
                <td>
                    <input id="txt_Pwd" maxlength="30" runat="server" type="password" tabindex="1"/>
                </td>
            </tr>
            <tr>
                <td>Repeat Password*</td>
                <td>
                    <input id="txt_Repeat_Pwd" maxlength="30" runat="server" type="password" tabindex="1"/>
                </td>


            </tr>
        </table>

         <br /><br />
        <asp:Label ID="labelStatusMsg" runat="server" Text="" ForeColor= "">
        </asp:Label>

        <br /><br />

        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"  TabIndex="7"/>
        <br /><br />
    </center>
    </div>      
</asp:Content>

