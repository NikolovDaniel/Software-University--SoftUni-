import { logout } from './api/data.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { createPage } from './views/create.js';
import { dashboardPage } from './views/dashboard.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import * as api from './api/api.js';

window.api = api;

const root = document.getElementById('content');
document.getElementById('logoutNav').addEventListener('click', ongLogout);

page(decorator);
page('/', homePage);
page('/dashboard', dashboardPage);
page('/create', createPage);
page('/login', loginPage);
page('/register', registerPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);

updateUserNav();
page.start();

function decorator(ctx, next) {

    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;
    next();
}

function updateUserNav() {
    const userData = getUserData();

    if (userData) {
        document.getElementById('loginNav').style.display = 'none';
        document.getElementById('registerNav').style.display = 'none';
        document.getElementById('createNav').style.display = 'inline-block';
        document.getElementById('logoutNav').style.display = 'inline-block';
    } else {
        document.getElementById('loginNav').style.display = 'inline-block';
        document.getElementById('registerNav').style.display = 'inline-block';
        document.getElementById('createNav').style.display = 'none';
        document.getElementById('logoutNav').style.display = 'none';
    }
}

function ongLogout() {
    logout();
    updateUserNav();
    page.redirect('/');
}
