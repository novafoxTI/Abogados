﻿var currentUpdateEvent;
var addStartDate;
var addEndDate;
var globalAllDay;

function updateEvent(event, element) {
   

    if ($(this).data("qtip")) $(this).qtip("destroy");

    currentUpdateEvent = event;

    $('#updatedialog').dialog('open');
    $("#eventName").val(event.title);
    $("#eventDesc").val(event.description);
    $("#eventLugar").val(event.lugar);
    $("#eventId").val(event.id);
    $("#eventStart").text("" + event.start.toLocaleString());
    if (event.end === null) {
        $("#eventEnd").text("");
    }
    else {
        $("#eventEnd").text("" + event.end.toLocaleString());
    }

}

function updateSuccess(updateResult) {
    alert(updateResult);
}

function deleteSuccess(deleteResult) {
    //alert(deleteResult);
}

function addSuccess(addResult) {
// if addresult is -1, means event was not added
//    alert("added key: " + addResult);

    if (addResult != -1) {
        $('#calendar').fullCalendar('renderEvent',
						{
						    title: $("#addEventName").val(),
						    start: addStartDate,
						    end: addEndDate,
						    id: addResult,
                            description: $("#addEventDesc").val(),
                            lugar: $("#addEventLugar").val(),
						    allDay: globalAllDay
						},
						true // make the event "stick"
					);


        $('#calendar').fullCalendar('unselect');
    }

}

function UpdateTimeSuccess(updateResult) {
    //alert(updateResult);
}

function selectDate(start, end, allDay) {

    $('#addDialog').dialog('open');


    $("#addEventStartDate").text("" + start.toLocaleString());
    $("#addEventEndDate").text("" + end.toLocaleString());


    addStartDate = start;
    addEndDate = end;
    globalAllDay = allDay;
    //alert(allDay);

}

function updateEventOnDropResize(event, allDay) {

    //alert("allday: " + allDay);
    var eventToUpdate = {
        id: event.id,
        start: event.start

    };

    if (allDay) {
        eventToUpdate.start.setHours(0, 0, 0);

    }

    if (event.end === null) {
        eventToUpdate.end = eventToUpdate.start;

    }
    else {
        eventToUpdate.end = event.end;
        if (allDay) {
            eventToUpdate.end.setHours(0, 0, 0);
        }
    }

    eventToUpdate.start = eventToUpdate.start.format("yyyy-MM-dd'T'HH:mm");
    eventToUpdate.end = eventToUpdate.end.format("yyyy-MM-dd'T'HH:mm");

    PageMethods.UpdateEventTime(eventToUpdate, UpdateTimeSuccess);

}

function eventDropped(event, dayDelta, minuteDelta, allDay, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event, allDay);



}

function eventResized(event, dayDelta, minuteDelta, revertFunc) {

    if ($(this).data("qtip")) $(this).qtip("destroy");

    updateEventOnDropResize(event);

}

function checkForSpecialChars(stringToCheck) {
    var pattern = /[^A-Za-z0-9 ]/;
    return pattern.test(stringToCheck); 
}

$(document).ready(function() {

    // update Dialog
    $('#updatedialog').dialog({
        autoOpen: false,
        width: 470,
        buttons: {
            "Editar": function() {
                alert(currentUpdateEvent.title);
                var eventToUpdate = {
                    id: currentUpdateEvent.id,
                    title: $("#eventName").val(),
                    description: $("#eventDesc").val(),
                    lugar: $("#eventLugar").val()
                };

                if (checkForSpecialChars(eventToUpdate.title) || checkForSpecialChars(eventToUpdate.description)) {
                    alert("por favor introduzca caracteres: A - Z, a - z, 0 - 9, o espacios");
                }
                else {
                    PageMethods.UpdateEvent(eventToUpdate, updateSuccess);
                    $(this).dialog("close");

                    currentUpdateEvent.title = $("#eventName").val();
                    currentUpdateEvent.description = $("#eventDesc").val();
                    currentUpdateEvent.lugar = $("#eventLugar").val();
                    $('#calendar').fullCalendar('updateEvent', currentUpdateEvent);
                }

            },
            "Eliminar": function() {

                if (confirm("Deseas Eliminar el Evento?")) {

                    PageMethods.deleteEvent($("#eventId").val(), deleteSuccess);
                    $(this).dialog("close");
                    $('#calendar').fullCalendar('removeEvents', $("#eventId").val());
                }

            }

        }
    });

    //add dialog
    $('#addDialog').dialog({
        autoOpen: false,
        width: 700,
        buttons: {
            "Agregar": function() {

                //alert("sent:" + addStartDate.format("dd-MM-yyyy hh:mm:ss tt") + "==" + addStartDate.toLocaleString());
                var eventToAdd = {
                    title: $("#addEventName").val(),
                    description: $("#addEventDesc").val(),
                    lugar: $("#addEventLugar").val(),
                    start: $("#addEventStartDate").val(),
                    end: $("#addEventEndDate").val()      
                };
                console.log(eventToAdd);
             
                if (checkForSpecialChars(eventToAdd.title) || checkForSpecialChars(eventToAdd.description)) {
                    alert("Por favor introduzca caracteres como: A - Z, a - z, 0 - 9, o espacios");
                }
                else {
                    //alert("sending " + eventToAdd.title);

                    PageMethods.addEvent(eventToAdd, addSuccess);
                    $(this).dialog("close");
                }

            }

        }
    });

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var calendar = $('#calendar').fullCalendar({
        theme: true,
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        eventClick: updateEvent,
        selectable: true,
        selectHelper: true,
        select: selectDate,
        editable: true,
        events: "JsonResponse.ashx",
        eventDrop: eventDropped,
        eventResize: eventResized,
        eventRender: function(event, element) {
            //alert(event.title);
            element.qtip({
                content: event.description,
                position: { corner: { tooltip: 'bottomLeft', target: 'topRight'} },
                style: {
                    border: {
                        width: 1,
                        radius: 3,
                        color: '#6B7073'

                    },
                    padding: 10,
                    textAlign: 'center',
                    tip: true, // Give it a speech bubble tip with automatic corner detection
                    name: 'cream' // Style it according to the preset 'cream' style
                }

            });
        }

    });

});

