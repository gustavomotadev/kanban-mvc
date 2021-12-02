function hideElements() {

    let elements = document.querySelectorAll(".is-hidden");

    elements.forEach(function (element) {
        element.style.display = "none";
    });
}

function editBoard() {

    let boardName = document.querySelector(".board-name-h");

    let elements = boardName.querySelectorAll(".is-hidden, .is-visible");

    let currentTitle = boardName.querySelector("h2");
    let input = boardName.querySelector("input");

    elements.forEach(function (element) {
        if (element.style.display === "none") element.style.display = "inline-block";
        else element.style.display = "none";
    });

    input.value = currentTitle.innerText;
}

function submitFormBoard() {

    let form = document.querySelector(".board-name-h form");
    let input = form.querySelector("input");

    if (input.value === "") editBoard();
    else form.submit();
}

function editNewBoard() {

    let boardsHeader = document.querySelector(".boards-header");

    let elements = boardsHeader.querySelectorAll(".is-hidden, .is-visible");

    elements.forEach(function (element) {
        if (element.style.display === "none") element.style.display = "inline-block";
        else element.style.display = "none";
    });
}

function submitFormNewBoard() {

    let form = document.querySelector(".boards-header form");
    let input = form.querySelector("input");

    if (input.value === "") editNewBoard();
    else form.submit();
}

function divNewColumn() {

    let div = document.querySelector(".new-column");

    if (div.style.display === "none") div.style.display = "flex";
    else div.style.display = "none";
}

function submitFormNewColumn() {

    let form = document.querySelector(".new-column form");
    let input = form.querySelector("input");

    if (input.value === "") divNewColumn();
    else form.submit();
}

function editColumn(columnId) {

    let column = document.querySelector(".column-" + columnId);
    let columnName = column.querySelector(".column-name")

    let elements = columnName.querySelectorAll(".is-hidden, .is-visible");

    let currentTitle = columnName.querySelector("h3");
    let input = columnName.querySelector("input");

    elements.forEach(function (element) {
        if (element.style.display === "none") element.style.display = "inline-block";
        else element.style.display = "none";
    });

    input.value = currentTitle.innerText;
}

function formNewNote(columnId) {

    let column = document.querySelector(".column-" + columnId);
    let form = column.querySelector(".new-note-form");

    if (form.style.display === "none") { form.style.display = "block"; }
    else {form.style.display = "none";}
}

function submitFormNewNote(columnId) {

    let column = document.querySelector(".column-" + columnId);
    let form = column.querySelector(".new-note-form");
    let input = form.querySelector("input");
    let textarea = form.querySelector("textarea");


    if (input.value === "" && textarea.value === "") formNewNote(columnId);
    else if (input.value !== "" && textarea.value !== "") form.submit();
}

function submitFormColumn(columnId) {

    let column = document.querySelector(".column-" + columnId);
    let form = column.querySelector(".column-name form");
    let input = form.querySelector("input");

    if (input.value === "") editColumn(columnId);
    else form.submit();
}

function editNote(noteId) {

    let note = document.querySelector(".note-" + noteId);

    let elements = note.querySelectorAll(".is-hidden, .is-visible");

    let currentTitle = note.querySelector("h4");
    let currentText = note.querySelector("p");

    let input = note.querySelector("input");
    let textarea = note.querySelector("textarea");

    elements.forEach(function (element) {
        if (element.style.display === "none") element.style.display = "inline-block";
        else element.style.display = "none";
    });

    input.value = currentTitle.innerText;
    textarea.value = currentText.innerText;
}

function submitFormNote(noteId) {

    let note = document.querySelector(".note-" + noteId);
    let form = note.querySelector("form");
    let input = form.querySelector("input");
    let textarea = form.querySelector("textarea");


    if (input.value === "" && textarea.value === "") editNote(noteId);
    else if (input.value !== "" && textarea.value !== "") form.submit();
}

function onLoadFunc() {
    hideElements();
}
window.onload = onLoadFunc();