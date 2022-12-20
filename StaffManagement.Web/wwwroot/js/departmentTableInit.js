import { loadDepartmentTable } from "./departmentTable.js";

const searchForm = document.getElementById("searchForm");
const clearBtn = document.getElementById("clearBtn");
const queryText = document.getElementById("queryText");
const detailsTable = document.getElementById("detailsTable");

searchForm.onsubmit = (event) => {
    event.preventDefault();
    loadDepartmentTable(queryText.value, detailsTable);
};

clearBtn.onclick = (event) => {
    loadDepartmentTable("", detailsTable);
    queryText.value = "";
}

loadDepartmentTable("", detailsTable);