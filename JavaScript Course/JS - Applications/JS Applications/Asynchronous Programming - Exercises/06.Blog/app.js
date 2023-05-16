async function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', getAllPosts);
    document.getElementById('btnViewPost').addEventListener('click', displayPosts);
}

attachEvents();

async function displayPosts() {

    const selectedPost = document.getElementById('posts').value;

    const post = await getPostById(selectedPost);
    const comments = await getCommentsById(selectedPost);
    
    document.getElementById("post-title").textContent = post.title;
    document.getElementById("post-body").textContent = post.body;

    const ulElement = document.getElementById("post-comments");

    ulElement.replaceChildren();

    comments.forEach(x => {
    const liElement = document.createElement('li');

    liElement.textContent = x.text;
    ulElement.appendChild(liElement);
    });
}

async function getAllPosts() {
    document.getElementById('btnLoadPosts').disabled = true;

    const url = 'http://localhost:3030/jsonstore/blog/posts';

    const response = await fetch(url);
    const data = await response.json();

    const selectElement = document.getElementById('posts');

    Object.values(data).forEach(p => {
        const optionElement = document.createElement('option');
        optionElement.textContent = p.title;
        optionElement.value = p.id;

        selectElement.appendChild(optionElement);
    });
}

async function getPostById(postId) {
    const url = 'http://localhost:3030/jsonstore/blog/posts/' + postId;

    const response = await fetch(url);

    return await response.json();
}

async function getCommentsById(postId) {
    const url = 'http://localhost:3030/jsonstore/blog/comments';

    const response = await fetch(url);
    const data = await response.json();

    return Object.values(data).filter(x => x.postId == postId);
}