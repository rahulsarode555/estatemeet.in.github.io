<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="Rent_Client_Followup.aspx.cs" Inherits="Rent_Client_Followup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .leftDiv {
            padding: 15px;
            border: 1px solid grey;
            /*box-sizing :border-box;*/
        }

        .rightDiv {
            padding: 15px;
            border: 1px solid gray;
        }

        .container2 {
            display: grid;
            grid-gap: 10px;
            grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
            /*grid-template-rows: repeat(2, 100px);*/
            font-size: 13px;
            font-family: 'Bookman Old Style';
        }
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />

    <div class="container2">        

        <div class="leftDiv">
            <br />
            <table style="width: 100%;">
                <tr class="tr_Height">
                    <td> Enter Property Status* </td>
                    <td>
                        <select id="lst_Status" runat="server" class="input_Size">
                            <option>Closed </option>
                            <option>Pending </option>
                            <option>Canceled </option>
                        </select>
                    </td>
                </tr>

                <tr class="tr_Height">
                    <td> Description </td>
                    <td> <textarea id="txt_Desc" rows="5" cols="20" runat="server"> </textarea> </td>
                </tr>

                <tr class="tr_Height">
                    <td>  </td>

                    <td> 
                        <br />
                        <asp:Button ID="btn_Submit" runat="server" Text="Submit Feedback"  OnClick="btn_Submit_Click" />

                    </td>
                </tr>

            </table>   
                        <center>
                            <br /><br />
            <asp:Label ID="lbl_Status_Msg" runat="server" Text="" Font-Size="Large"></asp:Label>
                            </center>
        </div>

        <div class="rightDiv">
            <%=html %>
        </div>
    </div>


</asp:Content>

