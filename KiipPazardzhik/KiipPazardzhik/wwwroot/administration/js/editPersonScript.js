function selectedName(person) {
    let personId = person.value;

    $.ajax({
        type: "GET",
        url: `/Administration/EditPerson/GetPersonData`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {
            'personId': personId
        },
        headers: {
            RequestVerificationToken:
                $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        success: function (data) {
            document.getElementById("editPersonInputForm").style.display = "block";
            $("#registerNumber").val(data.registerNumber);
            $("#firstName").val(data.firstName);
            $("#middleName").val(data.middleName);
            $("#lastName").val(data.lastName);
            $("#section").val(data.section);
            $("#legalCapacity").val(data.legalCapacity);
            $("#phone").val(data.phone);
            $("#email").val(data.email);
            $("#position").val(data.position);
            $("#technicalControl").val(data.technicalControl);
            $("#technologistKind").val(data.technologistKind);
        },
        error: function (msg) {
            console.error(msg);
        }
    })
}