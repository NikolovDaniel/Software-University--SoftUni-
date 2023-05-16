function solve() {

    const obj = {
        id: 'depot',
        name: null
    };

    function depart() {
        document.getElementById('arrive').disabled = false;
        document.getElementById('depart').disabled = true;

        async function getNextStop() {
            const url = 'http://localhost:3030/jsonstore/bus/schedule/' + obj.id;

            const response = await fetch(url);
            const data = await response.json();

            console.log(data);

            obj.id = data.next;
            obj.name = data.name;
            document.getElementById('info').textContent = `Next stop ${data.name}`;
        }

        getNextStop();

    }

    function arrive() {
        document.getElementById('arrive').disabled = true;
        document.getElementById('depart').disabled = false;

        document.getElementById('info').textContent = `Arriving at ${obj.name}`;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();