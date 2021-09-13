function SumVowels(input) {

    let totalSum = 0;

    for (let index = 0; index < input.length; index++) {

        if (input[index] == 'a') {
            totalSum += 1;
        } else if (input[index] == 'e') {
            totalSum += 2;
        } else if (input[index] == 'i') {
            totalSum += 3;
        } else if (input[index] == 'o') {
            totalSum += 4;
        } else if (input[index] == 'u') {
            totalSum += 5;
        }
    }
    console.log(totalSum);
}

SumVowels("bamboo");