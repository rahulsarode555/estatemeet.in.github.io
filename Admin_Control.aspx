<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Control.aspx.cs" Inherits="Admin_Control" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="function.js" lang="javascript" type="text/javascript" ></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <div class="searchTab" >
         <br />
            <asp:Button ID="btn_Log_Out" runat="server" Text="Log Out" OnClick="btn_LOG_OUT_Click" />

         <br /><br />
        
          View Properties : 
        <asp:DropDownList ID="lst_Rent_Sale" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="makeChoice">
            <asp:ListItem> Select </asp:ListItem>
            <asp:ListItem> Sell </asp:ListItem>
            <asp:ListItem> Rent </asp:ListItem>
            <asp:ListItem> Enquiry </asp:ListItem>
        </asp:DropDownList>
        
        <br /><br />
         
        Delete Property &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" Text="DELETE"  OnClick="Delete_From_Database"/>

         <br /><br />

<%--        Hide Property &nbsp;&nbsp;&nbsp;
         <asp:Button ID="btn_Hide" runat="server" Text="Hide" OnClick="btn_Hide_Click" />
        
          <br /><br />

        Show Property &nbsp;&nbsp;&nbsp;
         <asp:Button ID="btn_Show" runat="server" Text="Show" OnClick="btn_Show_Click" />
         <br /><br /><br />
    --%>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbl_Message" runat="server" Text=""></asp:Label>
        
         <%--<br /><br />
        Property Type :

        <asp:DropDownList ID="lst_Properyt_Type" runat="server" AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem  Value ="all"> All </asp:ListItem>
            <asp:ListItem> Flat </asp:ListItem>
            <asp:ListItem> Office </asp:ListItem>
            <asp:ListItem> Shop </asp:ListItem>
        </asp:DropDownList>        

        <br /><br />

        
        Location :  &nbsp;&nbsp;&nbsp;

        <asp:DropDownList ID="list_Location" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem Value="all"> All </asp:ListItem>
            <asp:ListItem> Wakad </asp:ListItem>
            <asp:ListItem> Ravet </asp:ListItem>
            <asp:ListItem> Hinjewadi </asp:ListItem>
        </asp:DropDownList>        
        

      <%--   <br /><br />
        
       Area :  &nbsp;Min
        <asp:DropDownList ID="DropDownList1" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem Value="all"> All </asp:ListItem>
            <asp:ListItem> Wakad </asp:ListItem>
            <asp:ListItem> Ravet </asp:ListItem>
            <asp:ListItem> Hinjewadi </asp:ListItem>
        </asp:DropDownList>        
        
        &nbsp;&nbsp;
        Max 
        <asp:DropDownList ID="DropDownList2" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem Value="all"> All </asp:ListItem>
            <asp:ListItem> Wakad </asp:ListItem>
            <asp:ListItem> Ravet </asp:ListItem>
            <asp:ListItem> Hinjewadi </asp:ListItem>
        </asp:DropDownList>        
        

        <br /><br />--%>
        <%--<br /><br />
        Budget :

        <asp:DropDownList ID="lst_Budget_Min" runat="server"   AutoPostBack="True"  OnSelectedIndexChanged="change_Budget" DataSourceID="SqlDataSource1" DataTextField="Value" DataValueField="ID" >
            
        </asp:DropDownList>    
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Sell_Budget_Min]"></asp:SqlDataSource>
            
        &nbsp;&nbsp;

        <asp:DropDownList ID="lst_Budget_Max" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" DataSourceID="SqlDataSource2" DataTextField="Value" DataValueField="ID" >
            
        </asp:DropDownList>   
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Broker_PlusConnectionString %>" SelectCommand="SELECT * FROM [Sell_Budget_Max]"></asp:SqlDataSource>


        <br /><br />
        
        Posted By :

        <asp:DropDownList ID="lst_Posted_By" runat="server"  AutoPostBack="True"  OnSelectedIndexChanged="refresh_Page" >
            <asp:ListItem Value="all"> All </asp:ListItem>
            <asp:ListItem> Owner </asp:ListItem>
            <asp:ListItem> Builder </asp:ListItem>
            <asp:ListItem> Dealer </asp:ListItem>
        </asp:DropDownList>

         <br /><br />
        --%>
        

    </div>    
 
    <div style="overflow:auto">  
        
        <h2><center>
            Welcome Admin!            
        </h2>       
        
       
        <%=html%>
        </center>
    </div>

    </div>
    </form>
</body>
</html>
