<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Test_SMS.aspx.cs" Inherits="Test_SMS" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <br />
        <br />
        <br />

        <asp:Label ID="lbl1" runat="server"></asp:Label> <br />
        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
        <br />
        <input type="button" value="Send OTP" onclick="send_SMS();" />

        <br />
        <br />
    </center>
</asp:Content>
