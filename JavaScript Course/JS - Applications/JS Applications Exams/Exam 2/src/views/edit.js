import { put } from "../api/api.js";
import { getPostById } from "../api/data.js";
import { html } from "../lib.js";

const editTemplate = (onSubmit, post) => html`
<section id="edit-page" class="auth">
    <form @submit=${onSubmit} id="edit">
        <h1 class="title">Edit Post</h1>

        <article class="input-group">
            <label for="title">Post Title</label>
            <input type="title" name="title" id="title" value="${post.title}">
        </article>

        <article class="input-group">
            <label for="description">Description of the needs </label>
            <input type="text" name="description" id="description" value="${post.description}">
        </article>

        <article class="input-group">
            <label for="imageUrl"> Needed materials image </label>
            <input type="text" name="imageUrl" id="imageUrl" value="${post.imageUrl}">
        </article>

        <article class="input-group">
            <label for="address">Address of the orphanage</label>
            <input type="text" name="address" id="address" value="${post.address}">
        </article>

        <article class="input-group">
            <label for="phone">Phone number of orphanage employee</label>
            <input type="text" name="phone" id="phone" value="${post.phone}">
        </article>

        <input type="submit" class="btn submit" value="Edit Post">
    </form>
</section>`;

export async function editPage(ctx) {
    const post = await getPostById(ctx.params.id);
    ctx.render(editTemplate(onSubmit, post));

    async function onSubmit(event) {
        event.preventDefault();

        const form = new FormData(event.target);

        const title = form.get('title');
        const description = form.get('description');
        const imageUrl = form.get('imageUrl');
        const address = form.get('address');
        const phone = form.get('phone');

        if (title == '' || description == '' || imageUrl == '' || address == '' || phone == '') {
            return alert('All fields must be filled!');
        }

        const postEdit = {
            title,
            description,
            imageUrl,
            address,
            phone
        };

        put('/data/posts/' + post._id, postEdit);
        ctx.page.redirect('/details/' + post._id);
    }
}

