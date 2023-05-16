function loadCommits() {
    const username = document.getElementById('username').value;
    const repo = document.getElementById('repo').value;
    const ulElement = document.getElementById('commits');
    const url = `https://api.github.com/repos/${username}/${repo}/commits`;

    async function getCommits() {

        try {

            const response = await fetch(url);

            if (response.ok == false) {
                throw new Error(`Error: ${response.status} (Not Found)`);
            }

            ulElement.replaceChildren();
            const data = await response.json();

            for (let el of data) {
                const liElement = document.createElement('li');
                liElement.textContent = `${el.commit.author.name}: ${el.commit.message} `;
                console.log(el);
                ulElement.appendChild(liElement);
            }


        } catch (error) {
        ulElement.replaceChildren();
        ulElement.textContent = `${error.message}`;
        }
    }

    getCommits();
}