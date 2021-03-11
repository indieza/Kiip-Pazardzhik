function changeVisibility(filterValue, buttonElement) {
    if ([...buttonElement.classList].includes("freeFilterSpan")) {
        buttonElement.classList.remove("freeFilterSpan");

        let oldButtons = document.querySelectorAll(".filterSpan");

        for (var button of oldButtons) {
            button.classList.remove("filterSpan");
            button.classList.add("freeFilterSpan");
        }

        buttonElement.classList.add("filterSpan");
    }

    if (filterValue == "Всички") {
        let rows = document.querySelectorAll("tbody>tr");

        for (let row of rows) {
            row.style.display = "";
        }
    }
    else {
        let rows = document.querySelectorAll(`.${filterValue}`);
        let allRows = document.querySelectorAll("tbody>tr");

        for (let row of allRows) {
            row.style.display = "none";
        }

        for (let row of rows) {
            row.parentElement.style.display = "";
        }
    }
}