import { ModalButton } from "./modalButton.js";
import { loadDepartmentTable } from "./departmentTable.js"

const departmentId = document.getElementById("departmentId");
const departmentName = document.getElementById("departmentName");
const formInput = [departmentId, departmentName];

// **define table components
const departmentSelector = document.getElementById("departmentSelector");
// table container and overall container
const selectDepartmentContainer = document.createElement("div");
const tableContainer = document.createElement("div");
tableContainer.id = "tableContainer";
//search bar
const searchBar = document.createElement("input");
searchBar.setAttribute("type", "input");
searchBar.setAttribute("id", "query");
searchBar.onkeydown = (event) => {
    if (event.key === 'Enter') {
        loadDepartmentTable(searchBar.value, tableContainer, formInput);
        return false;
    }
}
//append component to container
selectDepartmentContainer.appendChild(searchBar);
selectDepartmentContainer.appendChild(tableContainer);

// get update button and modal
const modalBtn = ModalButton("selectDepartment",
    "Select department", selectDepartmentContainer, "btn-primary",
    function () {
        alert("confirm click");
    });

// append component to overall container
departmentSelector.appendChild(modalBtn.button);
departmentSelector.appendChild(modalBtn.modal);
loadDepartmentTable(searchBar.value, tableContainer, formInput);
