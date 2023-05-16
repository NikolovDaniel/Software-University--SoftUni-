window.addEventListener('load', () => {
    const registerForm = document.getElementById('register');
    // registerForm.addEventListener('submit');
    const loginForm = document.getElementById('register');
    loginForm.addEventListener('submit', onLogin);
});

async function onLogin(event) {
    event.preventDefault();

    const form = event.target.parentNode;
    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    try {
        const url = 'http://localhost:3030/users/login';
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }

        const data = await response.json();
        const token = data.accessToken;

        localStorage.setItem('token', token);

        window.location = '/homeLogged.html';

    } catch (error) {
        alert(error.message);
    }
}