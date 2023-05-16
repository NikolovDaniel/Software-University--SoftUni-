window.addEventListener('load', async () => {
    const form = document.querySelector('form');
    form.addEventListener('submit', onCreate);
});

async function onCreate(event) {

    event.preventDefault();

    const form = event.target;
    const formData = new FormData(form);

    const name = formData.get('name').trim();
    const img = formData.get('img').trim();
    const ingredients = formData.get('ingredients').trim().split('\n');
    const steps = formData.get('steps').trim().split('\n');


    try {
        const url = 'http://localhost:3030/data/recipes';
        const token = localStorage.getItem('token');

        if (token == null) {
            return;
        }

        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify({ name, img, ingredients, steps })
        });

        if (response.ok != true) {
            const error = await response.json();
            throw new Error(error.message);
        }

        window.location = '/index.html';

    } catch (error) {
        alert(error);
    }
}
