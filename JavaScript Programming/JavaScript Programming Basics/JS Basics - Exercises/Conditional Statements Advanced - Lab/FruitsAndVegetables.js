function InputChecker(input) {

    let product = '';

    switch (input) {
        case "banana":
        case "apple":
        case "kiwi":
        case "cherry":
        case "lemon":
        case "grapes":
            product = 'fruit';
            break;
        case 'tomato':
        case 'cucumber':
        case 'pepper':
        case 'carrot':
            product = 'vegetable';
            break;
        default:
            product = 'unknown';
            break;
    }
    console.log(product);
}

InputChecker("banana");