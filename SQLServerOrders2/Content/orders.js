$(document).ready(function () {

    blinkLights();



    var availableTags = [
        "ActionScript",
        "AppleScript",
        "Asp",
        "BASIC",
        "C",
        "C++",
        "Clojure",
        "COBOL",
        "ColdFusion",
        "Erlang",
        "Fortran",
        "Groovy",
        "Haskell",
        "Java",
        "JavaScript",
        "Lisp",
        "Perl",
        "PHP",
        "Python",
        "Ruby",
        "Scala",
        "Scheme"
    ];

    $("#tags").autocomplete({
        source: availableTags
    });





    var searchArray = [];

    var getDescriptions =




        $.ajax({

            url: '../api/RESTOrders/',
            type: 'GET',
            async: false,
            success: function (ContactsArray) {



                $.each(ContactsArray, function (index, ordersArray) {
                    console.log(ordersArray.orderDescription);
                     searchArray.push(ordersArray.orderDescription);

                     




                });
            },


            error: function () {
                alert('fail');
            }
        });

  
 


    console.log(searchArray);

    $("#search-order").autocomplete({
        source: searchArray
        // minLength: 2

    });
});





function createOrder() {
    blinkLights();
    $("#orders-table").toggle();
    $("#create-order-div").toggle();


    $.ajax({
        type: 'GET',
        url: '../api/RESTContacts/',

        success: function (contactArray) {

            $.each(contactArray, function (index, item) {


                $("#contact-drop-down").append("<option value=" + item.contactId + ">" + item.fullName + "</option>")
            });


        },



        error: function () {
            alert('fail');
        }
    });

}


function submitOrder() {

    $.ajax({
        type: 'POST',
        url: '../api/RESTOrders/',
        data: JSON.stringify({
            contactId: $('#contact-drop-down').val(),
            orderDate: $('#add-order-date').val(),
            orderDescription: $('#add-order-description').val(),
            orderAmount: $('#add-order-amount').val()

        }),
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'

        },
        'dataType': 'json',

        success: function () {
            $('#ajaxError').empty();
        },
        error: function () {

            $('#ajaxError').append('<h3 style="color: red; margin: auto;">Error from ajax call </h3>');
        }


    });
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






            }
        },








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
        $('#light5').delay(100).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
        $('#light6').delay(50).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
        $('#light7').delay(100).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
        $('#light8').delay(150).fadeOut(500).fadeIn(500).fadeOut(500).fadeIn(500);
    }

}