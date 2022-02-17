function extract(content) {
    const text = document.getElementById("content");
    let result = [];

    for (let i = 0; i < text.textContent.length; i++) {

        if (text.textContent[i] == '(') {
            let index = i + 1;
            let currWord = '';

            while (text.textContent[index] != ')') {
                currWord += text.textContent[index];
                index++;
            }

            result.push(currWord);
        }
    }

    return result.join('; ');
}