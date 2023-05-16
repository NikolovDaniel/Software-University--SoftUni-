import { del } from "../api/api.js";
import { getPetById, addDonation, checkDonate, countDonation } from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const detailsTemplate = (userData, pet, onDelete) => html`
<section id="detailsPage">
    <div class="details">
        <div class="animalPic">
            <img src=${pet.image}>
        </div>
        <div>
            <div class="animalInfo">
                <h1>Name: ${pet.name}</h1>
                <h3>Breed: ${pet.breed}</h3>
                <h4>Age: ${pet.age}</h4>
                <h4>Weight: ${pet.weight}</h4>
                <h4 class="donation">Donation: 0</h4>
            </div>
            ${userData 
            ? html`
            <div class="actionBtn">
                ${pet._ownerId == userData.id 
                ? html`
                <a href="/edit/${pet._id}" class="edit">Edit</a>
                <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>`
                : html`${0 == 1 
                    ? html`<a href="javascript:void(0)" class="donate">Donate</a>`
                    : null }`}
            </div>`
            : null}
        </div>
    </div>
</section>`;

export async function detailsPage(ctx) {
    const userData = getUserData();
    const pet = await getPetById(ctx.params.id);

    ctx.render(detailsTemplate(userData, pet, onDelete));

    async function onDelete() {
       await del('/data/pets/' + pet._id);
        ctx.page.redirect('/');
    }
}

