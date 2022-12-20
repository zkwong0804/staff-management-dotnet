// generate button and coresponding confirmation modal
export const ModalButton = (id, btnText, bodyText, btnClass, confirmClick, isSubmit = false) => {
    // button
    const button = document.createElement("button");
    const backddropId = `deleteBackdrop_${id}`;
    const isBodyTextString = typeof bodyText === 'string' || bodyText instanceof String;
    button.classList.add("btn");
    button.classList.add(btnClass);
    button.setAttribute("data-bs-toggle", "modal");
    button.setAttribute("data-bs-target", `#${backddropId}`);
    button.setAttribute("type", "button");
    button.appendChild(document.createTextNode(btnText));

    // modal
    const modalContainer = document.createElement("div");
    const modalDialog = document.createElement("div");
    const modalContent = document.createElement("div");
    const modalHeader = document.createElement("div");
    const modalBody = document.createElement("div");
    const modalFooter = document.createElement("div");
    const header = document.createElement("h5");
    const headerCloseBtn = document.createElement("button");
    const bodyTextParagraph = isBodyTextString ? document.createElement("p")
        : document.createElement("div");
    const cancelButton = document.createElement("button");
    const confirmButton = document.createElement("button");

    header.appendChild(document.createTextNode("Delete"));
    headerCloseBtn.classList.add("btn-close");
    headerCloseBtn.setAttribute("data-bs-dismiss", "modal");
    modalHeader.appendChild(header);
    modalHeader.appendChild(headerCloseBtn);
    modalHeader.classList.add("modal-header");

    if (isBodyTextString) {
        bodyTextParagraph.innerHTML = bodyText;
    } else {
        bodyTextParagraph.appendChild(bodyText);
    }
    modalBody.appendChild(bodyTextParagraph);
    modalBody.classList.add("modal-body");

    cancelButton.classList.add("btn");
    cancelButton.classList.add("btn-secondary");
    cancelButton.classList.add("mr-1");
    cancelButton.setAttribute("data-bs-dismiss", "modal");
    cancelButton.appendChild(document.createTextNode("Cancel"));
    cancelButton.setAttribute("type", "button");
    confirmButton.classList.add("btn");
    confirmButton.classList.add("btn-danger");
    confirmButton.setAttribute("type", isSubmit ? "submit" : "button");
    if (!isSubmit) {
        confirmButton.onclick = confirmClick;
    }
    confirmButton.appendChild(document.createTextNode("Yes"));
    modalFooter.appendChild(cancelButton);
    modalFooter.appendChild(confirmButton);
    modalFooter.classList.add("modal-footer");

    modalContent.classList.add("modal-content");
    modalContent.appendChild(modalHeader);
    modalContent.appendChild(modalBody);
    modalContent.appendChild(modalFooter);
    modalDialog.classList.add("modal-dialog");
    modalDialog.appendChild(modalContent);
    modalContainer.appendChild(modalDialog);
    modalContainer.classList.add("modal");
    modalContainer.classList.add("fade");
    modalContainer.id = backddropId;
    modalContainer.setAttribute("data-bs-backdrop", "static");
    modalContainer.setAttribute("tabindex", "-1");

    return { button: button, modal: modalContainer }
}