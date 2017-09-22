var table;
$(document).ready(function () {
    $("#thumbnailgroupauto").hide();
    //call api to add item
    //$("form").submit(function (e) {
    //    e.preventDefault();
    //$.ajax({
    //    url: "http://localhost:5000/api/Books",
    //    contentType: "application/json",
    //    method: "POST",
    //    dataType:"json",
    //    data: JSON.stringify({
    //    Title: this.elements["Title"].value,
    //    Autor: this.elements["Autor"].value,
    //    Typebook: this.elements["Type"].value
    //}),
    //success: function(data) {
    //   // alert(data.title);
    //    addTableRow(data);
    //}
    //})
    //});
    // init autocomplate to search item
    $('#searchItem').bootcomplete({
        url: "http://localhost:5000/api/Books/search",
        minLength: 1
    });
    //init easy table 
    table = $("table").easyTable({
        hover: 'btn-primary',
        buttons: true,
        select: true,
        sortable: true,
        scroll: { active: false, height: '650px' }
    });

    $('[data-tooltip="tooltip"]').tooltip();
    $("#findbutton").on("click", function () {
        event.preventDefault();
        $("div.loader").show();
        $.ajax({
            url: "/Home/CallInvokeImportItem",
            method: "POST",
            data: { nameofbook: $("#findinput").val() },
            success: function (data) {
                //alert(data);
                $("#showmybook").empty();
                $("#showmybook").append(data);
                $("#thumbnailgroupauto").show();

            }
        });

    });
    //click button view block
    $("#viewblock").on("click", function () {
        event.preventDefault();
        $.ajax({
            url: "/Home/ChangeViewValToTh",
            method: "POST",
            data: { displayitem: "th" },
            success: function (data) {
                $(".DeleteButton").css("display", "none");
                $(".ReadButton").css("display", "none");
                $(".NoteButton").css("display", "none");
                $("#listitem").empty();
                $("#listitem").append(data);
            }
        });

    });
    //click button view list
    $("#viewlist").on("click", function () {
        event.preventDefault();
        $.ajax({
            url: "/Home/ChangeViewValToTh",
            method: "POST",
            data: { displayitem: "th-list" },
            success: function (data) {
                $(".DeleteButton").css("display", "none");
                $(".ReadButton").css("display", "none");
                $(".NoteButton").css("display", "none");
                $("#listitem").empty();
                $("#listitem").append(data);


            }
        });

    });
    // call delete controller to call service delete 
    $("#deletebutton").on("click", function () {
        event.preventDefault();
        console.log($("#rowsitems div.thumbnailselected").data("key"));
        if ($("table").length) {
            $.ajax({
                url: "/Home/CallInvokeDeleteItem",
                method: "Post",
                data: { itemskey: table.getSelected(0) },
                success: function (data) {
                    $("#alert").append(data);
                    $("tr.btn-primary").remove();
                    setTimeout(function () { $(".alert").alert('close') }, 3000);
                    $(".DeleteButton").css("display", "none");
                }
            });
        } else {
            $.ajax({
                url: "/Home/CallInvokeDeleteItem",
                method: "Post",
                data: { itemskey: $("#rowsitems div.thumbnailselected").data("key") },
                success: function (data) {
                    $("#alert").append(data);

                    setTimeout(function () { $(".alert").alert('close') }, 3000);
                    $("#viewblock").trigger("click");
                    //$(".DeleteButton").css("display", "none");
                }
            });
        }


    });
    // call modify controller to put isread value 
    $("#readbutton").on("click", function () {
        event.preventDefault();
        console.log(table.getSelected(6));
        if ($("table").length) {
            $.ajax({
                url: "/Home/CallInvokeIsReadItem",
                method: "Post",
                data: { key: table.getSelected(0), isread: table.getSelected(6) },
                success: function (data) {
                    // $("#alert").append(data);
                    $("tr.btn-primary td:last-child").text("Lu");
                    //$("tr.btn-primary").remove();
                    //setTimeout(function () { $(".alert").alert('close') }, 3000);
                    $(".ReadButton").css("display", "none");
                }
            });
        } else {
            $.ajax({
                url: "/Home/CallInvokeIsReadItem",
                method: "Post",
                data: { key: $("#rowsitems div.thumbnailselected").data("key"), isread: $("span.isread").text() },
                success: function (data) {
                    $("#rowsitems div.thumbnailselected span.isread").replaceWith("<span class='isread label label-info'>Lu</span>");
                    $(".ReadButton").css("display", "none");
                }
            });
        }


    });
    // call GetNote controller to call service GetNote 
    $("#Notebutton").on("click", function () {
        event.preventDefault();
        $.ajax({
            url: "/Home/CallGetNote",
            method: "Post",
            data: { key: table.getSelected(0)},
            success: function (data) {
             //Open Modal to set note
            }
        });

    });
    /* call action Calladditem in homecontroller to add an item */
    $("#btnaddauto").on("click", function () {
        event.preventDefault();
        $.ajax({
            url: "/Home/CallInvokeSaveItem",
            method: "POST",
            data: {
                //sam attribute imperatifly equals sam attribute in controler 
                booktypes: $("#booktypes").val(), format: $("#bookformat").val(), title: $("div .showimportitem.thumbnail h4").data("title"),
                author: $("div.showimportitem span.spanauthor ").data("author"), date: $("div.showimportitem span.spandate").data("date"), src: $("div.showimportitem.thumbnail img").data("img")
            },
            success: function (data) {
                $(".alert-info").show(1000);
                $(".alert-info").hide(3000);
                //setTimeout(function () { $(".alert").hide(( }, 3000);
                if ($('table').length) {
                    // iif table exists
                    $("tbody").append(data);
                } else {
                    //$("#rowsitems div.thumbnail").trigger("click");
                    if ($("#rowsitems  div.row:last > div ").length <= 5) {
                        // alert("----" + $("#rowsitems  div.row:last > div ").length);
                        $("#rowsitems .row:last").append(data);
                    } else {
                        // alert("++++" + $("#rowsitems  div.row:last > div ").length);
                        $("#rowsitems").append("<div class ='row'>" + data + "</div>");
                    }


                }



            }
        });

    });

    $("#myModal").on("hide.bs.modal", function () {

        $("#showmybook").empty();
        $("#showmybook").append("<div class='loader'></div>");
        $("#thumbnailgroupauto").hide();
        $("#findinput").val(" ").focus();

    });

});
var addTableRow = function (data) {
    $("table tbody").append("<tr><td>"
        + data.key + "</td><td>"
        + data.title + "</td><td>"
        + data.autor + "</td><td>"
        + data.type + "</td></tr>");
}
