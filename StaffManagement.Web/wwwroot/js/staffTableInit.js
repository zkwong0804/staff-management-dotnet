import { loadStaffTable } from "./staffTable.js";

const searchForm = document.getElementById("searchForm");
const clearBtn = document.getElementById("clearBtn");
const queryText = document.getElementById("queryText");
const detailsTable = document.getElementById("detailsTable");

searchForm.onsubmit = (event) => {
    event.preventDefault();
    loadStaffTable(queryText.value, detailsTable);
};

clearBtn.onclick = (event) => {
    loadStaffTable("", detailsTable);
    queryText.value = "";
}

loadStaffTable("", detailsTable);