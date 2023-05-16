async function getInfo() {
    const busId = document.getElementById('stopId').value;
    const url = 'http://localhost:3030/jsonstore/bus/businfo/' + busId;

    const ulElement = document.getElementById('buses');

    try {
        const response = await fetch(url);
        const data = await response.json();

        document.getElementById('stopName').textContent = data.name;
        ulElement.replaceChildren();

        Object.entries(data.buses).forEach(x => {
            const liElement = document.createElement('li');

            liElement.textContent = `Bus ${x[0]} arrives in ${x[1]} minutes`;

            ulElement.appendChild(liElement);
        });
    } catch (error) {
        document.getElementById('stopName').textContent = 'Error';
        ulElement.replaceChildren();
    }
}