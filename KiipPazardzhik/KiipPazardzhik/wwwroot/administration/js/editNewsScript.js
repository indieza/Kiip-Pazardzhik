function selectedName(news) {
    let newsId = news.value;

    $.ajax({
        type: "GET",
        url: `/Administration/EditNews/GetNewsData`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            'newsId': newsId
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (data) {
            document.getElementById("editPersonInputForm").style.display = "block";
            $("#title").val(data.title);
            tinyMCE.get("description").setContent(data.description == null ? "" : data.description);
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}