<%@ Page Title="Real Estate Consultant and Agent /Channel Partner in PCMC / pune - Home" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Copy (2) of Default.aspx.cs"
    Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
    <meta name="google-site-verification" content="WixJgM_uDgTkIwnGPlwoJ5YXIUXgJqED08Ru1Tl0axU" />

    <style type="text/css">
        .leftDiv {
            padding: 0px;
            border: 1px solid white;
            margin-bottom: 10px;
            width:90%;
        }

        .rightDiv {
            padding: 0px;
            border: 1px solid white;
            margin-bottom: 10px;
            width:90%;
        }

        .container1 {
            display: grid;
            grid-gap: 50px;
            grid-template-columns: repeat(auto-fit, minmax(340px, 1fr));
            /*grid-template-rows: repeat(2, 100px);*/
            font-size: 13px;
            font-family: 'Bookman Old Style';
            width: 80%;
        }

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

        .container_Contact_Us {
            display: grid;
            grid-gap: 10px;
            grid-template-columns: repeat(auto-fit, minmax(280px, 1fr));
            font-size: 15px;
            border: solid 0px;
            width: 90%;           
        }

        #slideshow { 
            margin: 50px auto; 
            position: relative; 
            width: 80%; 
            height: 240px; 
            padding: 10px; 
            box-shadow: 0 0 20px rgba(0,0,0,0.4); 
        }

        #slideshow > div { 
            position: absolute; 
            top: 10px; 
            left: 10px; 
            right: 10px; 
            bottom: 10px; 
        }
        
    </style>

    <script type="text/javascript" >     

        $("#slideshow > div:gt(0)").hide();

        setInterval(function () {
            $('#slideshow > div:first')
              .fadeOut(1000)
              .next()
              .fadeIn(1000)
              .end()
              .appendTo('#slideshow');
        }, 3000);

    </script>


</asp:Content>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content" runat="server">
    <div style="background-color:#b1edc8">
     <%--<div style="background-color:rgb(216, 213, 212)">--%>
    <center>
        <%--<img src="Site_Images/homeSemi.jpg" alt="" style="width: 100%;" />--%>
        <br /><br />
        <div class="container1" style="border: 0px solid red; margin-top: 0px;">

            <div class="leftDiv zoom">
                <a href="Buy_Property.aspx" class="tablink sub_Div_Link">BUY PROPERTIES
                    <br />
                    <label style="font-size:15px;color:red">(Click Here)</label>
                </a>

                <a href="Buy_Property.aspx">
                    <img alt="" src="Site_Images/Buy.jpg" style="width: 100%;" />
                </a>
            </div>

            <div class="rightDiv zoom">
                <a href="Sell_Property.aspx" class="tablink sub_Div_Link">SELL PROPERTIES
                     <br />
                    <label style="font-size:15px;">[Click Here]</label>
                </a>

                <a href="Sell_Property.aspx">
                    <img alt="" src="Site_Images/For_Sale.jpg" style="width: 100%" />
                </a>
            </div>

            <div class="leftDiv zoom">
                <a href="Properties_For_Rent.aspx" class="tablink sub_Div_Link"> <blink>  PROPERTIES ON RENT </blink>
                     <br />
                     <label style="font-size:15px;">[Click Here]</label>
                </a>

                <a href="Properties_For_Rent.aspx">
                    <img alt="" src="Site_Images/On_Rent.jpg" style="width: 100%" />
                </a>
            </div>

            <div class="rightDiv zoom">
                <a href="Rent_Your_Property.aspx" class="tablink sub_Div_Link">LEASE OUT PROPERTIES
                </a>
                <a href="Rent_Your_Property.aspx">
                    <img alt="" src="Site_Images/Lease_Out.jpg" style="width: 100%" />
                </a>
            </div>

        </div>

      <%--    <div id="slideshow">
               <div>
                 <img src="Site_Images/img_mountains.jpg" alt="" style="width:100%;height:100%" />
               </div>

               <div>
                 <img src="Site_Images/img_snowtops.jpg"alt="" style="width:100%;height:100%" />
               </div>

              <div>
                 <img src="Site_Images/img_forest.jpg" alt="" style="width:100%;height:100%" />
               </div>

               <div>
                 <img src="Site_Images/img_lights.jpg"alt="" style="width:100%;height:100%" />
               </div>


               <%--<div>
                 Pretty cool eh? This slide is proof the content can be anything.
               </div>
        </div>--%>

        

       

        <br />
        <br />

        <div class="container_Contact_Us" style="text-align: left">

            <div>

                <table>
                    <tr>
                        <td>
                            <img alt="" src="Site_Images/address.png" style="width: 60px" />
                        </td>
                        <td>Khinavsara Trade Centre,<br />
                            Datta Mandir Road,
                            <br />
                            Dange Chowk,Thergaon,<br />
                            Pune -  411033 

                        </td>
                    </tr>

                </table>

            </div>

            <div>
                <table>
                    <tr>
                        <td>
                            <img alt="" src="Site_Images/mail.png" style="width: 60px" />
                        </td>

                        <td>estatemeet.services@gmail.com
                        </td>
                    </tr>
                </table>

            </div>


            <div>
                <table>
                    <tr>
                        <td>
                            <a href="tel:+91-9112073377">
                                <img alt="" src="Site_Images/contact.png" style="width: 60px" />
                            </a>
                        </td>

                        <td>
                            <label style="font-size: 30px">
                                <a href="tel:+91-9112073377">9112073377</a>
                            </label>
                        </td>
                    </tr>
                </table>

            </div>
             <div>
                <table>
                    <tr>
                        <td>
                            <a href="https://www.facebook.com/Estate-meet-355560571653974" target="_blank">
                                <img alt="" src="Site_Images/fb.png" style="width: 70px" />
                            </a>
                        </td>                        
                        <td style="width:10px"> </td>
                        <td>
                            <a href=".">
                                <img alt="" src="Site_Images/twit.png" style="width: 70px" />
                            </a>
                        </td>                        
                        <td style="width:10px"> </td>
                        <td>
                            <a href=".">
                                <img alt="" src="Site_Images/inst.png" style="width: 70px" />
                            </a>
                        </td>                        
                    </tr>
                </table>

            </div>

        </div>

    </center>

    </div>
</asp:Content>