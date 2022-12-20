import { ModalButton } from "./modalButton.js";
const btnContainer = document.getElementById("btnContainer");
const modelInfo = document.getElementById("modelInfo");
const isViewMode = modelInfo.dataset.isviewmode !== undefined ? true : false;

const btnOperation = isViewMode ? "delete" : "update";
const btnName = btnOperation[0].toUpperCase() + btnOperation.substring(1);
const viewModeFunc = () => {
    location.href = modelInfo.dataset.operationurl;
    return false;
}

const btnFunc = isViewMode ? viewModeFunc : null;
const btn = ModalButton(btnOperation, btnName,
    `Are you sure you want to ${btnOperation}
<strong>${modelInfo.dataset.name}</strong>`,
    "btn-danger",
    btnFunc,
    !isViewMode
);

btnContainer.appendChild(btn.button);
btnContainer.appendChild(btn.modal);