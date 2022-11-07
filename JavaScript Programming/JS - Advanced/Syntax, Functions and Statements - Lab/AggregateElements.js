function aggregateElements(input) {

    let array = input;
    let sum = 0;
    let sumInverse = 0;
    let concatenated = '';

    for (let i = 0; i < array.length; i++) {
        sum += Number(input[i]);
        sumInverse += 1 / Number(input[i]);
        concatenated += input[i];
    }

    console.log(sum);
    console.log(sumInverse);
    console.log(concatenated);
}

aggregateElements([2, 4, 8, 16]);