function loadRepos() {
	const username = document.getElementById('username').value;
	const url = `https://api.github.com/users/${username}/repos`;
	const ulElement = document.getElementById('repos');

	async function getRepository() {

		try {

			const response = await fetch(url);

			if (response.ok == false) {
				throw new Error(`${response.status}`);
			}

			ulElement.innerHTML = '';
			const data = await response.json();

			for (let el of data) {
				const liElement = document.createElement('li');
				liElement.innerHTML = `<a href=${el.html_url}>${el.full_name}</a>`;
				ulElement.appendChild(liElement);
			}


		} catch (error) {
			ulElement.innerHTML = '';
			ulElement.textContent = `Error: ${error.message}`;
		}
	}

	getRepository();
}