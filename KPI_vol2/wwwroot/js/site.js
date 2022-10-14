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


function daysInMonth (month, year) {
                return new Date(year, month, 0).getDate();
            }
              


function changeStyle() {

    var year = Date.year();
    var month = Date.month();

    var day = Date.daysInMonth(month,year);

    for (let i = 1; i <= day.length; i++) {

        var element = document.getElementById(i);
        element.style.backgroundColor = "#f5425a";
    }
    document.getElementById("test").innerHTML = year;
}

function testData() {
    let year = new Date();
    document.getElementById("test").innerHTML = year;
}


