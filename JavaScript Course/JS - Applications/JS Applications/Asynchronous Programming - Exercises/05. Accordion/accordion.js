async function solve() {
    const url = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const main = document.getElementById('main');

    const response = await fetch(url);
    const data = await response.json();

    for (article of data) {
        main.append(await creator(article));
    }

    async function creator(article) {

        const id = article._id;
        const url = 'http://localhost:3030/jsonstore/advanced/articles/details/' + id;
        const title = article.title;

        const response = await fetch(url);
        const data = await response.json();

        const divAccordion = document.createElement('div');
        divAccordion.classList.add('accordion');
        const divHead = document.createElement('div');
        divHead.classList.add('head');
        const divExtra = document.createElement('div');
        divExtra.classList.add('extra');
        

        const span = document.createElement('span');
        span.textContent = title;
        const button = document.createElement('button');
        button.classList.add('button');
        button.textContent = 'More';
        button[id] = id;
        button.addEventListener('click', onClick);
        const p = document.createElement('p');
        p.textContent = data.content;

        divExtra.append(p);
        divHead.append(span, button);

        divAccordion.append(divHead, divExtra);

        function onClick(ev) {
            if (ev.target.textContent == 'More') {
                divExtra.style.display = 'block';
                ev.target.textContent = 'Less';
            } else {
                divExtra.style.display = 'none';
                ev.target.textContent = 'More';
            }
        }

        return divAccordion;
    }
}

solve();