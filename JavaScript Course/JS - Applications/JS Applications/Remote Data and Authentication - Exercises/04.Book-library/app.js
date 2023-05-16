const table = document.querySelector('body table');
const tbody = document.querySelector('tbody');
const createForm = document.getElementById('createBook');
const updateForm = document.getElementById('updateBook');
document.getElementById('loadBooks').addEventListener('click', loadBooks);
createForm.addEventListener('click', createBook);
updateForm.addEventListener('click', updateBook);
table.addEventListener('click', onTableClick);


async function onTableClick(event) {
    const id = event.target.dataset.id;

    if (id && event.target.className == 'delete') {
        deleteBook(id);
    } else if (id && event.target.className == 'edit') {
        onUpdate(id);
    }
}

async function updateBook(event) {
    event.preventDefault();
    if (event.target.tagName != 'BUTTON') {
        return;
    }
    const formData = new FormData(event.target.parentNode);
    const id = formData.get('id');
    const title = formData.get('title');
    const author = formData.get('author');

    const url = 'http://localhost:3030/jsonstore/collections/books/' + id;

    console.log(await fetch(url, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title, author, id })
    }));

    loadBooks();

    createForm.style.display = 'block';
    updateForm.style.display = 'none';
}
async function onUpdate(id) {

    const book = await loadBookById(id);

    createForm.style.display = 'none';
    updateForm.style.display = 'block';

    document.querySelector('#updateBook [name=id]').value = id;
    document.querySelector('#updateBook [name=title]').value = book.title;
    document.querySelector('#updateBook [name=author]').value = book.author;
}

async function deleteBook(id) {
    const url = 'http://localhost:3030/jsonstore/collections/books/' + id;

    await fetch(url, {
        method: 'delete'
    });

    loadBooks();
}

async function loadBookById(id) {
    const url = 'http://localhost:3030/jsonstore/collections/books/' + id;

    const res = await fetch(url);

    return await res.json();
}

async function createBook(event) {
    event.preventDefault();

    if (event.target.tagName != 'BUTTON') {
        return;
    }

    const url = 'http://localhost:3030/jsonstore/collections/books';

    const formData = new FormData(event.target.parentNode);
    const title = formData.get('title');
    const author = formData.get('author');

    await fetch(url, {
        method: 'post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ title, author })
    });

    event.target.parentNode.reset();
    loadBooks();
}

async function loadBooks() {
    const url = 'http://localhost:3030/jsonstore/collections/books';

    const res = await fetch(url);
    const data = await res.json();

    tbody.replaceChildren();

    Object.entries(data).forEach(([id, book]) => {
        const trElement = document.createElement('tr');
        trElement.innerHTML = `
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
        <button class="edit" data-id=${id}>Edit</button>
        <button class="delete" data-id=${id}>Delete</button>
    </td>
    `;

        tbody.appendChild(trElement);
    });
}




