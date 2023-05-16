window.addEventListener('load', async () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', onRegister);
});

async function onRegister(event) {

    event.preventDefault();

    const form = event.target;
    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    if (password != rePass) {
        return alert('Passwords don\'t match');
    }

    try {

        const url = 'http://localhost:3030/users/register';

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

        window.location = '/index.html';

    } catch (error) {
        alert(error);
    }
}