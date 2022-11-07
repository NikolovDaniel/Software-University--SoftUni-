function SumNumberInString(input) {

    let totalSum = 0;

    for (let index = 0; index < input.length; index++) {

        if (Number(input[index])) {
            totalSum += Number(input[index]);
        }
    }

    console.log(`The sum of the digits is:${totalSum}`);
}

SumNumberInString("Da213niel23");