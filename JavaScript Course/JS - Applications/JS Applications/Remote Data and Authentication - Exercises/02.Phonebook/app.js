function attachEvents() {
    document.getElementById('btnLoad').addEventListener('click', loadContacts);
    document.getElementById('btnCreate').addEventListener('click', createContact);
    document.getElementById('phonebook').addEventListener('click', deleteContanct);
}

loadContacts();

async function deleteContanct(event) {
    if (event.target.dataset.id) {
        const url = 'http://localhost:3030/jsonstore/phonebook/' + event.target.dataset.id;

        await fetch(url, {
            method: 'delete'
        });

        event.target.parentNode.remove();
    }
}

async function createContact() {
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const person = document.getElementById('person').value;
    const phone = document.getElementById('phone').value;

    await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ person, phone })
    });

    document.getElementById('person').value = '';
    document.getElementById('phone').value = '';

    loadContacts();
}

async function loadContacts() {
    const url = 'http://localhost:3030/jsonstore/phonebook';

    const res = await fetch(url);
    const data = await res.json();

    const phonebook = document.getElementById('phonebook');

    phonebook.replaceChildren();

    Object.values(data).forEach(x => {
        const liElement = document.createElement('li');
        liElement.innerHTML = `${x.person}: ${x.phone}
                               <button data-id=${x._id}> Delete </button>`;

        phonebook.appendChild(liElement);
    });
}

attachEvents();