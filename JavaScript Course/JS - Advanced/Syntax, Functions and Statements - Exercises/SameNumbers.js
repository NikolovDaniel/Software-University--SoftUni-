function sameNumbers(input) {

    let falseOrTrue = 'true';
    let sum = 0;
    let inputToString = input.toString();

    for (let i = 0; i < inputToString.length; i++) {

        if (i + 1 < inputToString.length) {
            if (inputToString[i] != inputToString[i + 1]) {
                falseOrTrue = 'false';
            } else {
                falseOrTrue = 'true';
            }
        }

        sum += Number(inputToString[i]);
    }

    console.log(falseOrTrue);
    console.log(sum);
}

sameNumbers(1);