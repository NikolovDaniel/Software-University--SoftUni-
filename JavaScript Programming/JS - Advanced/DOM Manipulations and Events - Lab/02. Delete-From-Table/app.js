function deleteByEmail() {
    // get the input
    const input = document.getElementsByName('email')[0].value;

    // iterate the table to find the email and print the result
    const result = document.getElementById('result');

    const tableElements = [...document.querySelectorAll('#customers tbody tr')];

    for (let child of tableElements) {
        if (child.children[1].textContent == input) {
            child.remove();
            result.textContent = 'Deleted.';
            return;
        }
    }

    result.textContent = 'Not found.';
}