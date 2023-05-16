import { editBook, getBookById } from '../api/data.js';
import { html } from '../lib.js';


function selectedOption(book) {
    const type = book.type;

    switch (type) {
        case 'Fiction': return html`
        <select id="type" name="type" value="Fiction">
            <option value="Fiction" selected>Fiction</option>
            <option value="Romance">Romance</option>
            <option value="Mistery">Mistery</option>
            <option value="Classic">Clasic</option>
            <option value="Other">Other</option>
        </select>`;
        case 'Romance': return html`
        <select id="type" name="type" value="Fiction">
            <option value="Fiction">Fiction</option>
            <option value="Romance" selected>Romance</option>
            <option value="Mistery">Mistery</option>
            <option value="Classic">Clasic</option>
            <option value="Other">Other</option>
        </select>`;
        case 'Mistery': return html`
        <select id="type" name="type" value="Fiction">
            <option value="Fiction">Fiction</option>
            <option value="Romance">Romance</option>
            <option value="Mistery" selected>Mistery</option>
            <option value="Classic">Clasic</option>
            <option value="Other">Other</option>
        </select>`;
        case 'Clasic': return html`
        <select id="type" name="type" value="Fiction">
            <option value="Fiction">Fiction</option>
            <option value="Romance">Romance</option>
            <option value="Mistery">Mistery</option>
            <option value="Classic" selected>Clasic</option>
            <option value="Other">Other</option>
        </select>`;
        case 'Other': return html`
        <select id="type" name="type" value="Fiction">
            <option value="Fiction">Fiction</option>
            <option value="Romance">Romance</option>
            <option value="Mistery">Mistery</option>
            <option value="Classic">Clasic</option>
            <option value="Other" selected>Other</option>
        </select>`;
    }


}
const editTemplate = (book, onSubmit) => html`
        <section id="edit-page" class="edit">
            <form @submit=${onSubmit} id="edit-form" action="#" method="">
                <fieldset>
                    <legend>Edit my Book</legend>
                    <p class="field">
                        <label for="title">Title</label>
                        <span class="input">
                            <input type="text" name="title" id="title" value=${book.title}>
                        </span>
                    </p>
                    <p class="field">
                        <label for="description">Description</label>
                        <span class="input">
                            <textarea name="description" id="description">${book.description}</textarea>
                        </span>
                    </p>
                    <p class="field">
                        <label for="image">Image</label>
                        <span class="input">
                            <input type="text" name="imageUrl" id="image" value=${book.imageUrl}>
                        </span>
                    </p>
                    <p class="field">
                        <label for="type">Type</label>
                        <span class="input">
                            ${selectedOption(book)}
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Save">
                </fieldset>
            </form>
        </section>`;

export async function editPage(ctx) {
    const book = await getBookById(ctx.params.id);
    ctx.render(editTemplate(book, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();

        const form = new FormData(event.target);

        const title = form.get('title').trim();
        const description = form.get('description').trim();
        const imageUrl = form.get('imageUrl').trim();
        const type = document.getElementById('type').value;

        if (title == '' || description == '' || imageUrl == '' || type == '') {
            return alert('All fields must be filled!');
        }

        const book = {
            title,
            description,
            imageUrl,
            type
        };

        editBook(book, ctx.params.id);
        ctx.page.redirect('/details/' + ctx.params.id);
    }
}