import { logout } from './api/api.js';
import { render, page } from './lib.js';
import { getUserData } from './util.js';
import { createPage } from './views/create.js';
import { dashboardPage } from './views/dashboard.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { loginPage } from './views/login.js';
import { myBooksPage } from './views/myBooks.js';
import { registerPage } from './views/register.js';

const root = document.getElementById('site-content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorator);
page('/login', loginPage);
page('/register', registerPage);
page('/', dashboardPage);
page('/addbook', createPage);
page('/details/:id', detailsPage);
page('/mybooks', myBooksPage);
page('/edit/:id', editPage);

updateUserNav();
page.start();

function decorator(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;
    next();
}

export function updateUserNav() {
    const userData = getUserData();

    if (userData) {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('user').style.display = 'inline-block';
        document.querySelector('#user span').textContent = `Welcome, ${userData.email}`;
    } else {
        document.getElementById('guest').style.display = 'inline-block';
        document.getElementById('user').style.display = 'none';
    }
}

async function onLogout() {
    logout();
    updateUserNav();
    page.redirect('/');
}