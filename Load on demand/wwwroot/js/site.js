

/*-----------------------------------pagination-----------------------------*/

//method for creating Pagination in tables it takes 2 params table and nav ID and creates pagination for sent table data
function createPagination(tableID, navID) {
    $('#' + tableID).after('<div id=' + navID + '></div>');
    var rowsShown = 10;
    var rowsTotal = $('#' + tableID + ' tbody tr').length;
    var numPages = rowsTotal / rowsShown;
    for (i = 0; i < numPages; i++) {
        var pageNum = i + 1;
        $('#' + navID).append('<a class="navNumb" href="#" rel="' + i + '">' + pageNum + '</a> ');
    }
    $('#' + tableID + ' tbody tr').hide();
    $('#' + tableID + ' tbody tr').slice(0, rowsShown).show();
    $('#' + navID + ' a:first').addClass('active');
    $('#' + navID + ' a').bind('click', function () {

        $('#' + navID + ' a').removeClass('active');
        $(this).addClass('active');
        var currPage = $(this).attr('rel');
        var startItem = currPage * rowsShown;
        var endItem = startItem + rowsShown;
        $('#' + tableID + ' tbody tr').css('opacity', '0.0').hide().slice(startItem, endItem).
            css('display', 'table-row').animate({
                opacity: 1
            }, 300);
    });
}

/*--------------------------------popup dodaj novi-------------------------------------*/
function popup() {

    document.getElementById("Država").value = "";
    document.getElementById("PoštanskiBroj").value = "";
    document.getElementById("NazivDržave").value = "";
    // Get the modal
    var modal = document.getElementById("myModal");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks the button, open the modal
    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}
/*----------------------------Popup edit------------------------------------*/
function popupEdit(ID) {
    var drzava = document.getElementById("Država " + ID).innerHTML;
    var postanski = document.getElementById("Poštanski " + ID).innerHTML;
    var naziv = document.getElementById("Naziv " + ID).innerHTML;


    document.getElementById("Država").value = drzava;
    document.getElementById("PoštanskiBroj").value = postanski;
    document.getElementById("NazivDržave").value = naziv;
    document.getElementById("IDnaselja").value = ID;

    // Get the modal
    var modal = document.getElementById("myModal");

    // Get the <span> element that closes the modal
    var span = document.getElementsByClassName("close")[0];

    // When the user clicks the button, open the modal
    modal.style.display = "block";

    // When the user clicks on <span> (x), close the modal
    span.onclick = function () {
        modal.style.display = "none";
    }

    // When the user clicks anywhere outside of the modal, close it
    window.onclick = function (event) {
        if (event.target == modal) {
            modal.style.display = "none";
        }
    }
}

/*------------------------------Stvaranje popup forme-------------------------*/

function loadForm() {
    var div = document.createElement("div");
    div.innerHTML = document.getElementById("dodaj/edit").innerHTML;
    document.getElementById("mod-content").appendChild(div);
}

/*------------------------------Load on demand--------------------------------*/

