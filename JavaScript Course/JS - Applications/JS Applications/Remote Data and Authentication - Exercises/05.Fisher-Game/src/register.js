window.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', onRegister);
});

async function onRegister(event) {
    event.preventDefault();

    const formData = new FormData(event.target);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();
    const rePass = formData.get('rePass').trim();

    if (password != rePass) {
        alert('Password must match!');
        return;
    }

    try {
        const res = await fetch('http://localhost:3030/users/register', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ email, password })
        });

        if (res.ok != true) {
            const error = await res.json();
            throw new Error(error.message);
        }

        const data = await res.json();
        const userData = {
            email: data.email,
            id: data._id,
            token: data.accessToken
        };

        localStorage.setItem('userData', JSON.stringify(userData));
        window.location = '/index.html';

    } catch (err) {
        alert(err);
    }
}