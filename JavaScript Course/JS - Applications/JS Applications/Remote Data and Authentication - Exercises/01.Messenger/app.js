async function attachEvents() {
    document.getElementById('refresh').addEventListener('click', loadMessages);
    document.getElementById('submit').addEventListener('click', createMessage);
}

loadMessages();

async function createMessage() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const author = document.querySelector('[name=author]').value;
    const content = document.querySelector('[name=content]').value;

    await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ author, content })
    });

    document.querySelector('[name=content]').value = '';
    loadMessages();
}

async function loadMessages() {
    const url = 'http://localhost:3030/jsonstore/messenger';

    const res = await fetch(url);
    const data = await res.json();

    const textarea = document.getElementById('messages');

    textarea.textContent = '';

    Object.values(data).forEach(x => {
        textarea.textContent += `${x.author}: ${x.content}\n`;
    });
}

attachEvents();