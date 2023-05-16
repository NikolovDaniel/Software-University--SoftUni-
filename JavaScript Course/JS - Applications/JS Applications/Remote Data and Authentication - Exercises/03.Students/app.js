document.getElementById('submit').addEventListener('click', createStudent);

loadStudents();

async function loadStudents() {
    const url = 'http://localhost:3030/jsonstore/collections/students';

    const res = await fetch(url);
    const data = await res.json();

    const tbody = document.querySelector('#results tbody');

    tbody.replaceChildren();

    Object.values(data).forEach(x => {
        const trElement = document.createElement('tr');
        trElement.innerHTML = `
        <th>${x.firstName}</th>
        <th>${x.lastName}</th>
        <th>${x.facultyNumber}</th>
        <th>${x.grade}</th>
        `;

        tbody.appendChild(trElement);
    });
}

async function createStudent(event) {

    event.preventDefault();

    const url = 'http://localhost:3030/jsonstore/collections/students';

    const firstName = document.querySelector('[name=firstName]').value;
    const lastName = document.querySelector('[name=lastName]').value;
    const facultyNumber = document.querySelector('[name=facultyNumber]').value;
    const grade = document.querySelector('[name=grade]').value;

    await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ firstName, lastName, facultyNumber, grade })
    });

    loadStudents();
}