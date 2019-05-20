<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View_Sell_Full_Details.aspx.cs" Inherits="View_Sell_Full_Details" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css"/>

    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script src="functions.js" language="javascript" type="text/javascript" ></script>

    <style type="text/css">

        .container_Master2 {
            display: grid;
            grid-gap: 10px;
            grid-template-columns: repeat(auto-fit, minmax(80px, 1fr));
            /*grid-template-rows: repeat(auto-fit, 100px);*/
            
            font-size: 15px;
            font-family: 'Bookman Old Style';
            padding:20px 10px;        
            background-color: rgb(128, 49, 160);
        }

    </style>

</head>
    
<body>
    <%--<form id="form1" runat="server" style="">--%>
    <center>

        <div class="container_Master2">            
            
            <a href="Default.aspx" class="clslink">     HOME        </a> &nbsp;&nbsp;&nbsp;
            <a href="Buy_Property.aspx" class="clslink_Alter">  BUY </a> &nbsp;&nbsp;&nbsp;
            <a href="Sell_Property.aspx" class="clslink">  SELL </a> &nbsp;&nbsp;&nbsp;
            <a href="Properties_For_Rent.aspx" class="clslink_Alter">  ON RENT </a> &nbsp;&nbsp;&nbsp;
            <a href="Rent_Your_Property.aspx" class="clslink">  LEASE OUT </a> &nbsp;&nbsp;&nbsp;
            <a href="Cust_Enquiries.aspx" class="clslink_Alter">  ENQUIRIES </a> &nbsp;&nbsp;&nbsp;
            <a href="About_Us.aspx" class="clslink">  ABOUT US </a> 

        </div>
   
    <div style="border:solid 1px grey;margin:10px;background-image:url('Site_Images/bk.jpg');">            
            
        <h2 class="w3-center">Property Details</h2>

        <div class="w3-content" style="max-width:500px;">
            <%=image_html%>
  
        </div>

        <div class="w3-center">
                <%--<div class="w3-section">
                <button class="w3-button w3-light-grey" onclick="plusDivs(-1)">❮ Prev</button>
                <button class="w3-button w3-light-grey" onclick="plusDivs(1)">Next ❯</button>
                </div>--%>
                <%=btn_Html%>
        </div>

         <script>
             var slideIndex = 1;
             showDivs(slideIndex);

             function plusDivs(n) {
                 showDivs(slideIndex += n);
             }

             function currentDiv(n) {
                 showDivs(slideIndex = n);
             }

             function showDivs(n) {
                 var i;
                 var x = document.getElementsByClassName("mySlides");
                 var dots = document.getElementsByClassName("demo");
                 if (n > x.length) { slideIndex = 1 }
                 if (n < 1) { slideIndex = x.length }
                 for (i = 0; i < x.length; i++) {
                     x[i].style.display = "none";
                 }
                 for (i = 0; i < dots.length; i++) {
                     dots[i].className = dots[i].className.replace(" w3-red", "");
                 }
                 x[slideIndex - 1].style.display = "block";
                 dots[slideIndex - 1].className += " w3-red";
             }

        </script>

        <%=main_Html %>
       
    </div>

    </center>
       
</body>
</html>