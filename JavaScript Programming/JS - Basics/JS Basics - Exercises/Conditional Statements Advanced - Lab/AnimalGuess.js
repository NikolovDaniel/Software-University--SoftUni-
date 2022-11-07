function PrintAnimal(input) {
    switch (input) {
        case 'dog':
            console.log('mammal');
            break;
        case 'crocodile':
        case 'tortoise':
        case 'snake':
            console.log('reptile');
            break;
        default:
            console.log('unknown');
            break;
    }
}

prin