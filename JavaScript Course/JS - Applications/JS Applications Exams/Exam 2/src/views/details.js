import { deletePostById, getPostById, hasDonated, getDonationCount, donate} from "../api/data.js";
import { html } from "../lib.js";
import { getUserData } from "../util.js";

const editDeleteButtons = (post, isOwner, onDelete) => {
if(isOwner) {
    return html`
        <a href="/edit/${post._id}" class="edit-btn btn">Edit</a>
        <a @click=${onDelete} href="javascript:void(0)" class="delete-btn btn">Delete</a>`;
} 

return null;
};

const donateButton = (isOwner, hasDonate, onClick, user) => {
    if (isOwner || hasDonate || user == null) return null;
    else return html`<a @click=${onClick} href="javascript:void(0)" class="donate-btn btn">Donate</a>`;
};

const detailsTemplate = (count, hasDonate, user, isOwner, post, onDelete, onClick) => html`
 <section id="details-page">
            <h1 class="title">Post Details</h1>
            <div id="container">
                <div id="details">
                    <div class="image-wrapper">
                        <img src=${post.imageUrl} alt="Material Image" class="post-image">
                    </div>
                    <div class="info">
                        <h2 class="title post-title">${post.title}</h2>
                        <p class="post-description">Description: ${post.description}</p>
                        <p class="post-address">Address: ${post.address}</p>
                        <p class="post-number">Phone number: ${post.phone}</p>
                        <p class="donate-Item">Donate Materials: ${count * 100}</p>

                        <div class="btns">
                           ${editDeleteButtons(post, isOwner, onDelete)}
                           ${donateButton(isOwner, hasDonate, onClick, user)}
                        </div>
                    </div>
                </div>
            </div>
        </section>`;

export async function detailsPage(ctx) {
    const userData = getUserData();
    const post = await getPostById(ctx.params.id);
    const isOwner = userData && userData.id == post._ownerId;

    let isDonated = false;

    if (userData) {
         isDonated = await hasDonated(ctx.params.id, userData.id);
    }
    
    const count = await getDonationCount(ctx.params.id);

    ctx.render(detailsTemplate(count, isDonated, userData, isOwner, post, onDelete, onClick));

    async function onDelete() {
        if (confirm('Do you want to delete this post?')) {
            await deletePostById(ctx.params.id);
            ctx.page.redirect('/');
        }
    }

    async function onClick() {
        await donate(ctx.params.id);
        ctx.page.redirect('/details/' + post._id);
    }
}

