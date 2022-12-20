import * as SearchForm from './searchForm.js';

export const loadDepartmentTable = (query, insertElement, updateElement, take = 10, skip = 0) => {
    SearchForm.loadTable("Department", "GetPaginatedData", take, skip, query).then(data => {
        const headers = ["Id", "Name"];
        const table = SearchForm.getTable(headers);
        const tbodyElement = document.createElement("tbody");
        for (let response of data.responses) {
            const tbodyRowElement = document.createElement("tr");
            const idData = document.createElement("td");
            const nameData = document.createElement("td");
            idData.appendChild(document.createTextNode(response.id));
            const nameLink = document.createElement("a");
            nameLink.setAttribute("href", "/Department/Get/" + response.id);
            nameLink.setAttribute("target", "_blank");
            nameLink.appendChild(document.createTextNode(response.name));
            nameData.appendChild(nameLink);

            tbodyRowElement.appendChild(idData);
            tbodyRowElement.appendChild(nameData);
            if (updateElement === undefined) {
                const del = {
                    link: `/Department/Delete/${response.id}`,
                    id: response.id,
                    name: response.name
                };
                tbodyRowElement.appendChild(SearchForm.getButtonCell(`/Department/Update/${response.id}`, del));
            } else {
                const rowBtnContainer = document.createElement("td");
                // row select button
                const selectBtn = document.createElement("button");
                selectBtn.setAttribute("type", "button");
                selectBtn.appendChild(document.createTextNode("Select"));
                selectBtn.classList.add("btn")
                selectBtn.classList.add("btn-primary");
                selectBtn.setAttribute("data-bs-dismiss", "modal");
                selectBtn.onclick = (event) => {
                    updateElement[0].value = response.id;
                    updateElement[1].value = response.name;
                };

                rowBtnContainer.appendChild(selectBtn);
                tbodyRowElement.appendChild(rowBtnContainer);
            }
            tbodyElement.appendChild(tbodyRowElement);
        }
        table.appendChild(tbodyElement);
        SearchForm.refreshDetailsTable(data.skip, data.take, data.total, table, insertElement,
            function () {
                loadDepartmentTable(query, insertElement, updateElement, take, skip - take);
            },
            function () {

                loadDepartmentTable(query, insertElement, updateElement, take, take + skip);
            });
    });
}
