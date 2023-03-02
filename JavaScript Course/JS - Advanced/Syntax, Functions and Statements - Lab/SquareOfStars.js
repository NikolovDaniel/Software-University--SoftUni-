function squareOfStars(n = 5) {

    let result = '';

    for (let i = 0; i < n; i++) {

        result += `${'* '.repeat(n)}\n`;
    }

    console.log(result);
}

squareOfStars(5);