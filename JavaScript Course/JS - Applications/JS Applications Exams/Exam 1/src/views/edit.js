import { put } from "../api/api.js";
import { getPetById } from "../api/data.js";
import { html } from "../lib.js";

const editTemplate = (onSubmit, pet) => html`
<section id="editPage">
    <form @submit=${onSubmit} class="editForm">
        <img src=${pet.image}>
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" value=${pet.name}>
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" value=${pet.breed}>
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" value=${pet.age}>
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" value=${pet.weight}>
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" value=${pet.image}>
            </div>
            <button class="btn" type="submit">Edit Pet</button>
        </div>
    </form>
</section>`;

export async function editPage(ctx) {
    const pet = await getPetById(ctx.params.id);
    ctx.render(editTemplate(onSubmit, pet));

    async function onSubmit(event) {
        event.preventDefault();

        const form = new FormData(event.target);

        const name = form.get('name');
        const breed = form.get('breed');
        const age = form.get('age');
        const weight = form.get('weight');
        const image = form.get('image');

        if (name == '' || breed == '' || age == '' || weight == '' || image == '') {
            return alert('All fields must be filled!');
        }

        const petEdit = {
            name,
            breed,
            age,
            weight,
            image
        };

        put('/data/pets/' + pet._id, petEdit);
        ctx.page.redirect('/details/' + pet._id);
    }
}

