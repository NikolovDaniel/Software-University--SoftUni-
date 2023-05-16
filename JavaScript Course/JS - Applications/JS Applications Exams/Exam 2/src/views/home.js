import { getAllPosts } from '../api/data.js';
import { html } from '../lib.js';


const postTemplate = (post) => html`
<div class="post">
    <h2 class="post-title">${post.title}</h2>
    <img class="post-image" src=${post.imageUrl} alt="Material Image">
    <div class="btn-wrapper">
        <a href="/details/${post._id}" class="details-btn btn">Details</a>
    </div>
</div>`;

const homeTemplate = (post) => html`
<section id="dashboard-page">
    <h1 class="title">All Posts</h1>
    ${post.length != 0
        ? html` <div class="all-posts">${post.map(postTemplate)}</div>`
        : html`<h1 class="title no-posts=title"> No posts yet!</h1>`}
</section>`;

export async function homePage(ctx) {
    const post = await getAllPosts();
    ctx.render(homeTemplate(post));
}