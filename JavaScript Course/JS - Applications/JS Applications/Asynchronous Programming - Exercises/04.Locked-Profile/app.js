async function lockedProfile() {

    const main = document.getElementById('main');

    const data = await getProfiles();

    data.forEach(x => {
        main.appendChild(createUser(x));
    });

    Array.from(document.getElementsByTagName('button')).forEach(x => {
        x.addEventListener('click', onClick);
    });
}

function onClick(ev) {
    const isChecked = ev.target.parentNode.querySelector('input').checked;

    if (isChecked) {
        return;
    }

    console.log(isChecked);

    if (ev.target.textContent == 'Show more') {
        ev.target.textContent = 'Hide it';
        Array.from(ev.target.parentNode.querySelector('div').querySelectorAll('label')).forEach(x => x.style.display = 'inline-block');
        Array.from(ev.target.parentNode.querySelector('div').querySelectorAll('input')).forEach(x => x.style.display = 'inline-block');
    } else {
        ev.target.textContent = 'Show more';
        Array.from(ev.target.parentNode.querySelector('div').querySelectorAll('label')).forEach(x => x.style.display = 'none');
        Array.from(ev.target.parentNode.querySelector('div').querySelectorAll('input')).forEach(x => x.style.display = 'none');
    }
}

function createUser(user) {
    const age = user[1].age;
    const email = user[1].email;
    const username = user[1].username;

    const div = document.createElement('div');
    div.classList.add('profile');

    div.innerHTML = `
    <img src="./iconProfile2.png" class="userIcon" />
    <label>Lock</label>
    <input type="radio" name="user1Locked" value="lock" checked>
    <label>Unlock</label>
    <input type="radio" name="user1Locked" value="unlock"><br>
    <hr>
    <label>Username</label>
    <input type="text" name="user1Username" value=${username} disabled readonly />
    <div class="hiddenInfo">
        <hr>
        <label>Email:</label>
        <input type="email" name="user1Email" value=${email} disabled readonly />
        <label>Age:</label>
        <input type="email" name="user1Age" value=${age} disabled readonly />
    </div>
    <button>Show more</button>`;

    return div;
}

async function getProfiles() {
    const url = 'http://localhost:3030/jsonstore/advanced/profiles';

    const response = await fetch(url);

    return Object.entries(await response.json());
}
