import { getAllPostsByUser } from '../api/data.js';
import {getUserData} from '../util.js';
import { html } from '../lib.js';

const postTemplate = (post) => html`
<div class="post">
    <h2 class="post-title">${post.title}</h2>
    <img class="post-image" src=${post.imageUrl} alt="Material Image">
    <div class="btn-wrapper">
        <a href="/details/${post._id}" class="details-btn btn">Details</a>
    </div>
</div>`;

const myPostTemplate = (post) => html`
<section id="my-posts-page">
            <h1 class="title">My Posts</h1>
            ${post.length != 0 
            ? html` <div class="my-posts">${post.map(postTemplate)}</div>`
            : html`<h1 class="title no-posts-title">You have no posts yet!</h1>`}
        </section>`;

export async function myPostsPage(ctx) {
    const userData = getUserData();
    const post = await getAllPostsByUser(userData.id);
    ctx.render(myPostTemplate(post));
}