function PrintFactorial(input) {

    let sum = 1;

    for (let i = 1; i <= Number(input); i++) {

        sum *= i;
    }

    console.log(sum);

}

PrintFactorial("8");