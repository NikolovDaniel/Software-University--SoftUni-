function PrintNumbers(input) {

    let a = Number(input[0]);
    let b = Number(input[1]);

    let totalSum = 0;

    for (let i = a; i <= b; i++) {

        if (i % 9 == 0) {
            totalSum += i;
        }
    }
    console.log(`The sum: ${totalSum}`);
    for (let i = a; i <= b; i++) {

        if (i % 9 == 0) {
            console.log(i);
        }
    }
}

PrintNumbers(["100", "200"]);