function extractText() {
    const elements = Array.from(document.querySelectorAll('ul li')).map(x => x.textContent);

    const result = elements.join('\n');

    document.getElementById('result').textContent = result;
}