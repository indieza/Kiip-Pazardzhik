$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: `/Home/GetAllRegionalColleges`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (allRegionalColleges) {
            let list = document.getElementById("allRegionalColleges");
            list.innerHTML = "";
            for (var position of allRegionalColleges) {
                list.innerHTML += `<li><a href="${position.url}" target="blank">${position.name}</a></li>`
            }
        },
        error: function (msg) {
            console.error(msg);
        }
    });
})