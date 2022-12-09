function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

function confirmDelete(uniqueId, isTrue) {

    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isTrue) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}


document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');

    var calendar = new FullCalendar.Calendar(calendarEl, {
        initialView: 'dayGridMonth',
        
        headerToolbar: {
           
           
           
        },
        events: [] ,
           /* $.getJSON('https://localhost:7210/Zdarzenias/EventsJson',),*/
       
        selectable: true,
        selectHelper: true,
        //select: function (start, end, allDays) {
        //    $.get("/zdarzenias/create")
        //},
        
        selectHelper: true,
        edittable: true,
        eventLimit: true,
        //eventSource: [
        //    {
        //        url: '/Zdarzenias/EventsJson',
        //        color: 'yellow',
        //        textColor:'black'
        //    }]
       
        

           
        
    });
     calendar.FullCalendar('addEventSource', '/zdarzenias/EventsJson');
    calendar.getEvents('https://localhost:7210/Zdarzenias/EventsJson');
    calendar.render();
});


$(function () {
    

    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
           
        })
    })
})





     
