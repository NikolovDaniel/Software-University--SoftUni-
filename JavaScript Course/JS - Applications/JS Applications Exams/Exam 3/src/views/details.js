import { addLike, delBook, getBookById, getLikes, hasLiked } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

function editDeleteButtons(user, book, onDelete) {

    if (user && user.id == book._ownerId) {
        return html` 
        <a class="button" href="/edit/${book._id}">Edit</a>
        <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>`;
    }

    return null;
}

function likeButton(user, book, onLike, isLiked) {

    if (user && user.id != book._ownerId && isLiked == 0) {
        return html`<a @click=${onLike} class="button" href="javascript:void(0)">Like</a>`;
    }

    return null;
}

async function userHasLiked(book, user) {
    if (book && user) {
        return await hasLiked(book._id, user.id);
    }
}

const detailsTemplate = (user, book, onDelete, onLike, isLiked, count) => html`
    <section id="details-page" class="details">
        <div class="book-information">
            <h3>${book.title}</h3>
            <p class="type">Type: ${book.type}</p>
            <p class="img"><img src=${book.imageUrl}></p>
            <div class="actions">
                ${editDeleteButtons(user, book, onDelete)}
                ${likeButton(user, book, onLike, isLiked)}
                <div class="likes">
                    <img class="hearts" src="/images/heart.png">
                    <span id="total-likes">Likes: ${count}</span>
                </div>
            </div>
        </div>
        <div class="book-description">
            <h3>Description:</h3>
            <p>${book.description}</p>
        </div>
    </section>`;

export async function detailsPage(ctx) {
    const book = await getBookById(ctx.params.id);
    const userData = getUserData();
    const isLiked = await userHasLiked(book, userData);
    const count = await getLikes(book._id);

    ctx.render(detailsTemplate(userData, book, onDelete, onLike, isLiked, count));

    async function onDelete() {
        delBook(book._id);
        ctx.page.redirect('/');
    }

    async function onLike() {
        await addLike(book._id);
        ctx.page.redirect('/details/' + book._id);
    }
}