function GreetingsByNameAndSex(input) {
    let age = input[0];
    let sex = input[1];

    if (sex == 'm') {
        if (age >= 16) {
            console.log('Mr.');
        } else {
            console.log('Master');
        }
    }
    else if (sex == 'f') {
        if (age >= 16) {
            console.log('Ms.');
        } else {
            console.log('Miss');
        }
    }
}

GreetingsByNameAndSex(['16', 'f']);