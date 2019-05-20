
//Stop Form Submission of Enter Key Press
function stopRKey(evt) {
    var evt = (evt) ? evt : ((event) ? event : null);
    var node = (evt.target) ? evt.target : ((evt.srcElement) ? evt.srcElement : null);
    if ((evt.keyCode == 13) && (node.type == "text")) { return false; }
}
document.onkeypress = stopRKey;

function show_Contact(){
    alert("For Website, Contact on 7741001258");
}


function disable_Location() {

    lbl_Location
    var var_chk_Location = document.getElementById('chk_Location');
    var var_txt_Location = document.getElementById('txt_Location');
    var var_lbl_Location = document.getElementById('lbl_Location');

    //alert(var_chk_Location.value);

    if (var_chk_Location.checked == true) {
        var_txt_Location.disabled = false;
        var_lbl_Location.style.color = 'black';
        var_txt_Location.focus();
    }
    else {
        var_txt_Location.disabled = true;
        var_lbl_Location.style.color = 'gray';
    }
}


function basicPopup() 
{
    popupWindow = window.open("View_Contact_No.aspx", 'popUpWindow', 'height=350,width=400,left=100,top=30,resizable=No,scrollbars=No,toolbar=no,menubar=no,location=no,directories=no, status=No');
}

function change_Sale_Type(){
    //alert('here');
    var z = document.getElementById('lst_Cust_Type').value;
    var x = document.getElementById('lst_Sale_Type');

    var var_lbl_RERA = document.getElementById('lbl_RERA');
    var var_txt_RERA = document.getElementById('txt_RERA');
   
    if (z == 'Owner') {        
        x.options[1].disabled = true;
        x.options[3].disabled = true;
        var_lbl_RERA.style.color = "grey";
        var_txt_RERA.disabled = true;
    }
    else {
        //var option = document.createElement("option");
        //option.text = "New Booking";
        //x.add(option);
        x.options[1].disabled = false;
        x.options[3].disabled = false;
        var_lbl_RERA.style.color = "black";
        var_txt_RERA.disabled = false;

    }
}

function change_Const_Stat() {
    //alert('here');
    var z = document.getElementById('lst_Sale_Type').value;
    var x = document.getElementById('lst_Const_Status');

    if (z == 'Resale') {
        x.options[2].disabled = true;
    }
    else {
        //var option = document.createElement("option");
        //option.text = "New Booking";
        //x.add(option);
        x.options[2].disabled = false;

    }
}

function change_Furnish_Stat() {
    alert('here1');
    var z = document.getElementById('lst_Const_Status').value;
    var x = document.getElementById('tr_Furnish_Status');

    if (z == 'Under Construction' || z == 'Pre Launching') {
        alert('here');
        x.disabled = true;
    }
    else {
        //var option = document.createElement("option");
        //option.text = "New Booking";
        //x.add(option);
        x.disabled = false;

    }
}


function format_Number(x) {
    //alert('demo');
    x = x.value.toString();
    
    var lastThree = x.substring(x.length - 3);
    var otherNumbers = x.substring(0, x.length - 3);
    if (otherNumbers != '')
        lastThree = ',' + lastThree;
    var res = otherNumbers.replace(/\B(?=(\d{2})+(?!\d))/g, ",") + lastThree;
    document.getElementById('price').textContent = 'Rs. ' + res;
    //alert(res);
}

    var specialKeys = new Array();
    specialKeys.push(8); //Backspace
    function IsNumeric(e) {
        //alert(error_Obj);
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        //document.getElementById(error_Obj).style.display = ret ? "none" : "inline";
        return ret;
    }

    function IsNumericOther(e) {
        //alert(error_Obj);
        var keyCode = e.which ? e.which : e.keyCode
        var ret = ((keyCode >= 48 && keyCode <= 57) || specialKeys.indexOf(keyCode) != -1);
        //document.getElementById(error_Obj).style.display = ret ? "none" : "inline";
        return ret;
    }

    function make_Age_Or_Pos_Visible() {
       // alert('here');
       // change_Furnish_Stat();
        var z = document.getElementById('lst_Const_Status').value;
        var x = document.getElementById('lbl_Age_Of_Prop');
        var y = document.getElementById('lbl_Possession_In');
    
        if (z == 'Ready To Move') {

            div_Age.style.visibility = "visible";
            x.style.visibility = "visible";
            y.style.visibility = "hidden";
            div_Possession.style.visibility = "hidden";
        }
        else {
            div_Age.style.visibility = "hidden";
            x.style.visibility = "hidden";
            y.style.visibility = "visible";

            div_Possession.style.visibility = "visible";
        }

    }

    function make_No_Of_Parking_Visible() {

        var var_Radio_parking_1 = document.getElementById('Radio_parking_1');
        var var_Radio_parking_2 = document.getElementById('Radio_parking_2');
    
        var var_Reserverd_Parking = document.getElementById('lst_Reserverd_Parking');
        var var_lst_No_Of_Parking = document.getElementById('lst_No_Of_Parking');
        var var_Reserverd_Parking2 = document.getElementById('lst_Reserverd_Parking2');
        var var_lst_No_Of_Parking2 = document.getElementById('lst_No_Of_Parking2');
                
        if (var_Radio_parking_1.checked) { 
            var_Reserverd_Parking.disabled = false;
            var_lst_No_Of_Parking.disabled = false;
            var_Reserverd_Parking2.disabled = false;
            var_lst_No_Of_Parking2.disabled = false;
        }
        else {
            var_Reserverd_Parking.disabled = true;
            var_lst_No_Of_Parking.disabled = true;
            var_Reserverd_Parking2.disabled = true;
            var_lst_No_Of_Parking2.disabled = true;
        }
    }
    

    function disable_Acc_Ind_Build(prop_Sub) {

        //alert(prop_Sub);
        var var_Prop_Sub = document.getElementById(prop_Sub).value;
        //alert(var_Prop_Sub);

        var var_lst_Property_On_Floor = document.getElementById('lst_Property_On_Floor');
        var var_lbl_Property_On_Floor = document.getElementById('lbl_Property_On_Floor');

        var var_lst_Bed_Rooms = document.getElementById('lst_Bed_Rooms');
        var var_lbl_Bed_Room = document.getElementById('lbl_Bed_Room');

        var var_lst_Property_On_Floor = document.getElementById('lst_Property_On_Floor');
        var var_lbl_Property_On_Floor = document.getElementById('lbl_Property_On_Floor');


        if (var_Prop_Sub == 'Independant Building') {

            var_lbl_Property_On_Floor.style.color = "gray";
            var_lst_Property_On_Floor.disabled = true;
        }
        else {
            var_lbl_Property_On_Floor.style.color = "black";
            var_lst_Property_On_Floor.disabled = false;
        }
    }
    
    function disable_Unit_Wing(prop_Sub) {

       // alert(prop_Sub);
        var var_Prop_Sub = document.getElementById(prop_Sub).value;
        //var var_txt_Unit_No = document.getElementById('txt_Unit_No');
        //var var_lbl_Unit_No = document.getElementById('lbl_Unit_No');
        //var var_lbl_Wing_Name = document.getElementById('lbl_Wing_Name');
        //var var_txt_Wing_Name = document.getElementById('txt_Wing_Name');

        //alert(var_Prop_Sub);
        //if (var_Prop_Sub == 'Flat' || var_Prop_Sub == 'Office' || var_Prop_Sub == 'Shop') {

        //    var_lbl_Unit_No.style.color = "black";
        //    var_lbl_Wing_Name.style.color = "black";
        //    var_txt_Unit_No.disabled = false;
        //    var_txt_Wing_Name.disabled = false;
        //}
        //else {
        //    var_lbl_Unit_No.style.color = "gray";
        //    var_lbl_Wing_Name.style.color = "gray";
        //    var_txt_Unit_No.disabled = true;        
        //    var_txt_Wing_Name.disabled = true;
        //}
    
        //Section 2
        var var_lst_Property_On_Floor = document.getElementById('lst_Property_On_Floor');
        var var_lbl_Property_On_Floor = document.getElementById('lbl_Property_On_Floor');

        if (var_Prop_Sub == 'Independant Building') {

            var_lbl_Property_On_Floor.style.color = "gray";
            var_lst_Property_On_Floor.disabled = true;
        }
        else {
            var_lbl_Property_On_Floor.style.color = "black";
            var_lst_Property_On_Floor.disabled = false;
        }


    }

    function disable_Enable_Avai() {
       
        var y = document.getElementById('lst_Construction_Status');

        var var_lbl_Avai = document.getElementById('lbl_Avai');

        var z = document.getElementById('lst_Sale_Type').value;
        // alert('!' + z + '!' + x.value + '!' + y.value);
        //alert(x.value);
        if (z == 'Pre Launching') {
          
            y.disabled = true;
            var_lbl_Avai.style.color = "grey";
        }
        else {
            y.disabled = false;
            var_lbl_Avai.style.color = "black";
        }
    }
    function change_Rent_Sale()
    {
        //alert('here');
        var x = document.getElementById('lst_Sale_Type');
        var y = document.getElementById('lst_Construction_Status');

        var z = document.getElementById('lst_Enquiry_For').value;

        var var_lbl_SaleType = document.getElementById('lbl_SaleType');
        var var_lbl_Avai = document.getElementById('lbl_Avai');
       // alert('!' + z + '!' + x.value + '!' + y.value);
       
        var var_div_Rent = document.getElementById('div_Rent');
        var var_div_Sale = document.getElementById('div_Sale');
        
        //alert(y.value);
        if (z == 'On Rent') {
            x.disabled = true;
            y.disabled = true;
            var_lbl_SaleType.style.color = "grey";
            var_lbl_Avai.style.color = "grey";

            var_div_Rent.style.visibility = "visible";
            var_div_Sale.style.visibility = "hidden";

        }
        else {
            x.disabled = false;
            y.disabled = false;
            var_lbl_SaleType.style.color = "black";
            var_lbl_Avai.style.color = "black";

            var_div_Rent.style.visibility = "hidden";
            var_div_Sale.style.visibility = "visible";
        }

    }

    function disable_BedRoom() {

        var x = document.getElementById('lst_Sub_Property_Com');
        var y = document.getElementById('lst_Sub_Property_Res');

        var z = document.getElementById('lst_Property_Type').value;
       
        var var_lbl_Bed_Room = document.getElementById('lbl_Bed_Room');
        var var_lst_Bed_Rooms = document.getElementById('lst_Bed_Rooms');

        var var_lst_Sub_Property_Res = document.getElementById('lst_Sub_Property_Res').value;

        if (z == 'Commercial') {
            x.style.visibility = "visible";
            y.style.visibility = "hidden";

            var_lbl_Bed_Room.style.color = "gray";
            var_lst_Bed_Rooms.disabled = true;
        }
        else {

            x.style.visibility = "hidden";
            y.style.visibility = "visible";

            var_lbl_Bed_Room.style.color = "black";
            var_lst_Bed_Rooms.disabled = false;

            if (var_lst_Sub_Property_Res == 'Independant Building') {
                var_lbl_Bed_Room.style.color = "gray";
                var_lst_Bed_Rooms.disabled = true;
            }
        }
    }

    function disable_BedRoom2() {
        var var_lst_Sub_Property_Res = document.getElementById('lst_Sub_Property_Res').value;
        var var_lbl_Bed_Room = document.getElementById('lbl_Bed_Room');
        var var_lst_Bed_Rooms = document.getElementById('lst_Bed_Rooms');

        if (var_lst_Sub_Property_Res == 'Independant Building') {
            var_lbl_Bed_Room.style.color = "gray";
            var_lst_Bed_Rooms.disabled = true;
        }
        else {
            var_lbl_Bed_Room.style.color = "black";
            var_lst_Bed_Rooms.disabled = false;
        }

    }
    
    function make_PR_Type_Visible() {
    
        var x = document.getElementById('lst_Sub_Property_Com');
        var y = document.getElementById('lst_Sub_Property_Res');

        var z = document.getElementById('lst_Property_Type').value;
               
        var var_lbl_Bath_Room = document.getElementById('lbl_Bath_Room');
        var var_lbl_Wash_Room = document.getElementById('lbl_Wash_Room');
        var b_r = document.getElementById('lbl_Bed_Room');
        var l_b_r = document.getElementById('lst_Bed_Rooms');

        var var_lbl_Willing_To_Rent1 = document.getElementById('lbl_Willing_To_Rent1');
        var var_lbl_Willing_To_Rent2 = document.getElementById('lbl_Willing_To_Rent2');
        var var_lbl_Family = document.getElementById('lbl_Family');
        var var_lbl_Bachelor = document.getElementById('lbl_Bachelor');
        var var_lbl_Anyone = document.getElementById('lbl_Anyone');
        var var_Checkbox1 = document.getElementById('Checkbox1');
        var var_Checkbox2 = document.getElementById('Checkbox2');
        var var_Checkbox5 = document.getElementById('Checkbox5');

        if (z == 'Commercial') {
            x.style.visibility = "visible";
            y.style.visibility = "hidden";
          
            b_r.style.color = "gray";
            l_b_r.disabled = true;

            var_lbl_Bath_Room.style.visibility = "hidden";
            div_Bathroom.style.visibility = "hidden";
            var_lbl_Wash_Room.style.visibility = "visible";
            div_Wash_Room.style.visibility = "visible";
       
            var_lbl_Willing_To_Rent1.style.color = "gray";
            var_lbl_Willing_To_Rent2.style.color = "gray";
            var_lbl_Family.style.color = "gray";
            var_lbl_Bachelor.style.color = "gray";
            var_lbl_Anyone.style.color = "gray";

            var_Checkbox1.disabled = true;
            var_Checkbox2.disabled = true;
            var_Checkbox5.disabled = true;

            disable_Unit_Wing('lst_Sub_Property_Com');
        }
        else {
            x.style.visibility = "hidden";
            y.style.visibility = "visible";
            b_r.style.color = "black";
            l_b_r.disabled = false;

            var_lbl_Bath_Room.style.visibility = "visible";
            div_Bathroom.style.visibility = "visible";
            var_lbl_Wash_Room.style.visibility = "hidden";
            div_Wash_Room.style.visibility = "hidden";

            var_lbl_Willing_To_Rent1.style.color = "black";
            var_lbl_Willing_To_Rent2.style.color = "black";
            var_lbl_Family.style.color = "black";
            var_lbl_Bachelor.style.color = "black";
            var_lbl_Anyone.style.color = "black";

            var_Checkbox1.disabled = false;
            var_Checkbox2.disabled = false;
            var_Checkbox5.disabled = false;

            disable_Unit_Wing('lst_Sub_Property_Res');
        }
    }

        function make_P_Type_Visible() {
    
            var x = document.getElementById('lst_Sub_Property_Com');
            var y = document.getElementById('lst_Sub_Property_Res');

            var z = document.getElementById('lst_Property_Type').value;
    
            var tr_Comj = document.getElementById('tr_Comm');
            var tr_Resj = document.getElementById('tr_Res');

   
            //alert(tr_Comj);
            if (z == 'Commercial') {
                x.style.visibility = "visible";        
                y.style.visibility = "hidden";
                tr_Comj.style.visibility = "visible";
                tr_Resj.style.visibility = "hidden";
       

            }
            else {
                x.style.visibility = "hidden";
                y.style.visibility = "visible";
                tr_Comj.style.visibility = "hidden";
                tr_Resj.style.visibility = "visible";
            }
        }

        //Zoom image of final result
        function makePopUpVisible(i) {

            var w = $(window).width();            
            var h = $(window).height();
            var d = document.getElementById('resize_div'+ i);
            var divW = $(d).width();
            var divH = $(d).height();
            
            if(i=='_Desktop')
                d.style.top = (h / 2) - (divH / 2) - 80 + "px";
            else
                d.style.top = (h / 2) - (divH / 2) - 50 + "px";

            d.style.left = (w / 2) - (divW / 2) + "px";           
            d.style.visibility = "visible";         
        }

        function makePopUpHidden(i) {
            var x = document.getElementById('resize_div' + i);
            x.style.visibility = "hidden";
        }


        //Scroll Home Image 
        function StartMove() {
            var cssBGImage = new Image();
            cssBGImage.src = "Site_Images/Home_Scroll.jpg";

            window.cssMaxWidth = cssBGImage.width;
            window.cssXPos = 0;
            setInterval("MoveBackGround()", 10); //change speed
        }

        function MoveBackGround() {
            window.cssXPos = window.cssXPos - 1; // changed direction
            if (window.cssXPos >= window.cssMaxWidth) {
                window.cssXPos = 0;
            }
            toMove = document.getElementById("scroller");
            toMove.style.backgroundPosition = window.cssXPos + "px 0px";

        }