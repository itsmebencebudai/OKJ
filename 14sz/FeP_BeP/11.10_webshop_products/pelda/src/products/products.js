// import { getData } from '../script.js';

function updateDOM(data) {

    const list = document.getElementById('dataList');
    data.forEach(item => {
        const listItem = document.createElement('li');
        listItem.textContent = item.name;
        list.appendChild(listItem);
    });
}
document.getElementById('frissit').addEventListener('click', updateDOM);