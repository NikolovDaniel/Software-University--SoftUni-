function addItem() {
    const liElement = document.createElement('li');
    const text = document.getElementById('newItemText').value;
    liElement.textContent = text;

    document.getElementById('items').appendChild(liElement);
    document.getElementById('newItemText').value = '';
}