function editElement(element, match, replacer) {

    const text = element.textContent;
    element.textContent = text.replace(match, replacer);
}