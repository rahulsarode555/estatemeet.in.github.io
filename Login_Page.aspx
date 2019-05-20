<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login_Page.aspx.cs" Inherits="Login_Page" %>

<asp:Content ID="content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height:450px; border:0px solid red; overflow:auto;">
    <center>
        
        <br />

        
        Enter your Login details below <br /><br />

        <table>
            <tr>
                <td>
                    Email ID :
                </td>
                <td>
                    <input id="txtMailID" maxlength="30" runat= "server" type="text" />
                </td>
            </tr>
            <tr>
                <td>
                    Password :
                </td>
                <td>
                    <input id="txtPassword" maxlength="20" runat= "server" type="password" />
                </td>
            </tr>

        </table>

        <br />

        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" /> <br /><br />

         <asp:Label ID="labelErrorMsg" runat="server">
            
        </asp:Label>

    </center>        
    </div>
       



</asp:Content>