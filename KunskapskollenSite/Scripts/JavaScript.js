$("#showAdressField").click(function () {
    $(".txt").val('');
    var form = $("#formCreate");
    var btn = $('#showAdressField');

    if (form.hasClass('hidden')) {
        form.removeClass("hidden ");
        btn.html('Hide');
    }
    else {
        form.addClass("hidden");
        btn.html('Add new adress');
    }
});

$("#AddAdress").click(function () {
    $('#showAdressField').html('Add new adress');
    $("#formCreate").addClass("hidden");

});