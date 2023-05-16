let userData = null;

window.addEventListener('DOMContentLoaded', () => {
    userData = JSON.parse(localStorage.getItem('userData'));

    if (userData != null) {
        document.getElementById('guest').style.display = 'none';
        document.querySelector('#addForm .add').disabled = false;
        document.querySelector('p').innerHTML = `Welcome, <span>${userData.email}</span>`;
    } else {
        document.getElementById('user').style.display = 'none';
    }

    document.querySelector('.load').addEventListener('click', loadData);
    document.getElementById('logout').addEventListener('click', onLogout);
    document.getElementById('addForm').addEventListener('submit', onCreateSubmit);
    document.getElementById('catches').addEventListener('click', onClick);
});

async function onClick(event) {
    if (event.target.className == 'delete') {
        onDelete(event.target.dataset.id);
    } else if (event.target.className == 'update') {
        onUpdate(event.target);
    }
}

async function onUpdate(button) {
    const fields = [...button.parentNode.querySelectorAll('input')];
    const angler = fields[0].value;
    const weight = fields[1].value;
    const species = fields[2].value;
    const location = fields[3].value;
    const bait = fields[4].value;
    const captureTime = fields[5].value;
    const id = button.dataset.id;

    await fetch('http://localhost:3030/data/catches/' + id, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': userData.token
        },
        body: JSON.stringify({ angler, weight, species, location, bait, captureTime })
    });

    loadData();
}

async function onDelete(id) {
    await fetch('http://localhost:3030/data/catches/' + id, {
        method: 'delete',
        headers: {
            'X-Authorization': userData.token
        }
    });

    loadData();
}

async function onCreateSubmit(event) {
    event.preventDefault();

    if (!userData) {
        window.location = '/login.html';
        return;
    }

    const formData = new FormData(event.target);

    const data = [...formData.entries()].reduce((a, [k, v]) => Object.assign(a, { [k]: v }), {});

    try {
        if (Object.values(data).some(x => x == '')) {
            throw new Error('All fields are required!');
        }
        const res = await fetch('http://localhost:3030/data/catches', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userData.token
            },
            body: JSON.stringify(data)
        });

        if (res.ok != true) {
            const error = await res.json();
            throw new Error(error.message);
        }

        loadData();
        event.target.reset();

    } catch (err) {
        alert(err);
    }
}

async function loadData() {

    const res = await fetch('http://localhost:3030/data/catches');
    const data = await res.json();

    document.getElementById('catches').replaceChildren(...data.map(createPreview));
}

function createPreview(item) {
    const isOwner = userData && item._ownerId == userData.id;

    const element = document.createElement('div');
    element.className = 'catch';
    element.innerHTML = ` 
    <label>Angler</label>
    <input type="text" class="angler" value="${item.angler}" ${!isOwner ? "disabled" : ''}>
    <label>Weight</label>
    <input type="text" class="weight" value="${item.weight}" ${!isOwner ? "disabled" : ''}>
    <label>Species</label>
    <input type="text" class="species" value="${item.species}" ${!isOwner ? "disabled" : ''}>
    <label>Location</label>
    <input type="text" class="location" value="${item.location}" ${!isOwner ? "disabled" : ''}>
    <label>Bait</label>
    <input type="text" class="bait" value="${item.bait}" ${!isOwner ? "disabled" : ''}>
    <label>Capture Time</label>
    <input type="number" class="captureTime" value="${item.captureTime}" ${!isOwner ? "disabled" : ''}>
    <button class="update" data-id="${item._id}" ${!isOwner ? "disabled" : ''}>Update</button>
    <button class="delete" data-id="${item._id}" ${!isOwner ? "disabled" : ''}>Delete</button>`;

    return element;
}

async function onLogout() {
    const url = 'http://localhost:3030/users/logout';
    const userData = localStorage.getItem('userData');

    if (userData == null) {
        return;
    }

    await fetch(url, {
        method: 'get',
        headers: {
            'X-Authorization': userData.token
        },
    });

    localStorage.removeItem('userData');
    window.location = '/index.html';
}