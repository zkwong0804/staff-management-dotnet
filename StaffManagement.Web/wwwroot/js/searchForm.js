import { ModalButton } from './modalButton.js';

export const refreshDetailsTable = (skip, take, total, table, insertElement, prevBtnAction, nextBtnAction) => {
    insertElement.innerHTML = "";
    insertElement.appendChild(table);
    insertElement.appendChild(createPaginateBtnContainer(skip, take, total, prevBtnAction, nextBtnAction));
}

export const loadTable = async (controller, action, take, skip, query) => {
    const url = `/${controller}/${action}?take=${take}&skip=${skip}&query=${query}`;
    const data = await fetch(url);
    const jsonResult = await data.json();
    return jsonResult;
}

export const getTable = (headers) => {
    const tableElement = document.createElement("table");
    tableElement.classList.add("table");
    tableElement.classList.add("table-striped");
    const theadElement = document.createElement("thead");
    const theadRowElement = document.createElement("tr");
    headers.push(""); // append empty cell for buttons

    for (let header of headers) {
        const headerElement = document.createElement("th");
        headerElement.appendChild(document.createTextNode(header));
        theadRowElement.appendChild(headerElement);
    }
    theadElement.appendChild(theadRowElement);
    tableElement.appendChild(theadElement);
    return tableElement;
}

export const getButtonCell = (updateLink, del) => {
    if (!updateLink || !del) {
        console.error("updateLink, deleteLink and deleteId must have value!");
        return;
    }

    const buttonCell = document.createElement("td");
    const updateButton = document.createElement("button");

    // update button
    updateButton.classList.add("btn");
    updateButton.classList.add("btn-warning");
    updateButton.appendChild(document.createTextNode("Update"));
    updateButton.setAttribute("type", "button");
    updateButton.onclick = () => {
        location.href = updateLink;
        return false;
    }

    const bodyText = `Are you sure you want to delete <strong>${del.name}</strong>?`;
    const deleteBtn = ModalButton(del.id, "Delete", bodyText, "btn-danger", function () {
        location.href = del.link;
        return false;
    });


    // append all button to td
    buttonCell.appendChild(updateButton);
    buttonCell.appendChild(document.createTextNode(" "));
    buttonCell.appendChild(deleteBtn.button);
    buttonCell.appendChild(deleteBtn.modal);
    return buttonCell;
}

function createPaginateBtnContainer(skip, take, total, prevClick, nextClick) {
    const paginateBtnContainer = document.createElement("div");

    paginateBtnContainer.appendChild(createPaginateButton("<", (skip - take) < 0, prevClick));
    paginateBtnContainer.appendChild(document.createTextNode(" ")); // make space between buttons
    paginateBtnContainer.appendChild(createPaginateButton(">", (skip + take) > total, nextClick));

    return paginateBtnContainer;
}

function createPaginateButton(btnText, isDisabled, onclick) {
    const btn = document.createElement("button");
    btn.setAttribute("type", "button");
    btn.classList.add("col-sm-1");
    btn.classList.add("btn");
    btn.classList.add("btn-outline-secondary");
    if (isDisabled) {
        btn.setAttribute("disabled", "");
    }
    btn.appendChild(document.createTextNode(btnText));
    btn.onclick = onclick;

    return btn;

}