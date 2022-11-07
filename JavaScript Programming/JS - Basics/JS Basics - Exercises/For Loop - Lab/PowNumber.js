function PrintPowedNumber(n) {

    let num = 1;

    for (let i = 1; i <= n; i += 2) {

        console.log(num);
        num = num * 2 * 2;

    }
}

PrintPowedNumber(10);