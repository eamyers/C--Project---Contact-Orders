$(document).ready(function () {

     

    blinkLights();


    $('#add-contact-button').click(function () {

        blinkLights();


        $.ajax({
            type: 'POST',
            url: '../api/RESTContacts',
            data: JSON.stringify({
                firstName: $('#add-first-name').val(),
                lastName: $('#add-last-name').val(),
                dateOfBirth: $('#add-dob').val(),
                AllowContactByPhone: $('#add-phone').val(),
                Role: $('#add-role').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },

            'dataType': 'json',
            success: function () {
                $('#add-first-name').val('');
                $('#add-last-name').val('');
                $('#add-dob').val('');
                $('#add-phone').val('');
                $('#add-role').val('');

                $("#contacts-table").toggle();
                $("#create-contact-div").toggle();
                
                window.location.reload(true);
            },
            error: function () {
                //add error her
            }
        });

        })
  }); 


function createContact() {
    blinkLights();
    $("#contacts-table").toggle();
    $("#create-contact-div").toggle();

}







function showDetails(id) {
    blinkLights();

    $("#contacts-table").toggle();
    $("#contact-details-div").toggle();
    $("#contact-details-col-1").empty();
    $("#contact-details-col-2").empty();

    $.ajax({
        type: 'GET',
        url: '../api/RESTContacts/' + id,

        success: function (contact) {
            var detailsDiv = $("#contact-details-col-1");

            var dob = new Date(contact.dateOfBirth),

                dobM = dob.getMonth(),
                dobD = dob.getDate(),
                dobY = dob.getFullYear();


            var created = new Date(contact.createdDate),
                creM = created.getMonth(),
                creD = created.getDate(),
                creY = created.getYear();


            var details = "<h2>";
            details += contact.fullName + "</h2>";
            details += "<p>Dob:" + dobM + "/" + dobD + "/" + dobY + "</p>";
            details += "<p>Role:" + contact.role + "</p>";
            details += "<p>Created:" + creM + "/" + creD + "/" + creY + "</p>";
            detailsDiv.append(details);



            var details2Div = $("#contact-details-col-2");

            var ordersTable = " <table class='table-bordered' style='margin - bottom: 24px; '>< tr ><th>Order No. </th><th>Date</th><th>Description</th><th></th> </tr >";

            var orders = contact.orders;

            var order1 = orders[0];
            var more = order1.orderId;

            if (orders[0] != null) {
                for (i = 0; i < orders.length; i++) {
                    ordersTable += "< tr >";
                    ordersTable += "<td width='200'>" + orders[i].orderId + "</td>";
                    ordersTable += " <td width='200'>" + orders[i].orderDate + "</td>";
                    ordersTable += " <td width='200'><span style='color: orchid'> " + orders[i].orderDescription + " </span></td>";
                   // ordersTable += " <td> @Html.ActionLink('Edit', 'Edit', 'Orders', new { id = " + orders[i].orderId + "}, null) | ";
                    ordersTable += "</td></tr>";

                  
                }
                ordersTable += "</table>";
                details2Div.append(ordersTable);




                //     @Html.ActionLink("Details", "Details", "Orders", new {id = item.OrderId}, null) |
                //  @Html.ActionLink("Delete", "Delete", "Orders", new {id = item.OrderId}, null)
                //    </td>
                //   </tr >




            }
        },


          //  }



        

        error: function () {
            alert('fail');
        }
    });
}


function showTable() {
    blinkLights();
    $("#contacts-table").toggle("blind");
    $("#contact-details-div").toggle("blind");

}



function blinkLights() {

    for (var i = 0; i < 50; i++) {
        $('#light1').delay(100).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
        $('#light2').delay(50).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
        $('#light3').delay(100).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
        $('#light4').delay(150).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
    }
   
  //  $('#light3').delay(25).(100).fadeIn(100).fadeOut(100).fadeIn(100);
   // $('#light4').delay(40).(100).fadeIn(100).fadeOut(100).fadeIn(100);
}