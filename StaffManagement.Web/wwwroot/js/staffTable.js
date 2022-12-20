import * as SearchForm from './searchForm.js';

export const loadStaffTable = (query, insertElement, take = 10, skip = 0) => {
    SearchForm.loadTable("Staff", "GetPaginatedData", take, skip, query).then(data => {
        const headers = ["Id", "Name", "Department"];
        const table = SearchForm.getTable(headers);
        const tbodyElement = document.createElement("tbody");
        for (let response of data.responses) {
            const tbodyRowElement = document.createElement("tr");
            const idData = document.createElement("td");
            const nameData = document.createElement("td");
            const departmentData = document.createElement("td");
            // id cell
            idData.appendChild(document.createTextNode(response.id));
            const nameLink = document.createElement("a");

            // staff name cell
            nameLink.setAttribute("href", "/Staff/Get/" + response.id);
            nameLink.appendChild(document.createTextNode(response.name));
            nameData.appendChild(nameLink);

            // department cell
            const departmentLink = document.createElement("a");
            departmentLink.setAttribute("href", "/Department/Get/" + response.department.id);
            departmentLink.appendChild(document.createTextNode(response.department.name));
            departmentData.appendChild(departmentLink);

            tbodyRowElement.appendChild(idData);
            tbodyRowElement.appendChild(nameData);
            tbodyRowElement.appendChild(departmentData);
            const del = {
                link: `/Staff/Delete/${response.id}`,
                id: response.id,
                name: response.name
            };
            tbodyRowElement.appendChild(SearchForm.getButtonCell(`/Staff/Update/${response.id}`, del))
            tbodyElement.appendChild(tbodyRowElement);
        }
        table.appendChild(tbodyElement);
        SearchForm.refreshDetailsTable(data.skip, data.take, data.total, table, insertElement,
            function () {
                loadStaffTable(query, insertElement, take, skip - take);
            },
            function () {

                loadStaffTable(query, insertElement, take, take + skip);
            });
    });
}
