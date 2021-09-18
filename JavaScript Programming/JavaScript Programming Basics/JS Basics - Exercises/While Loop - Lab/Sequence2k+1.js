function PrintNumber(input) {

    let sum = 1;

    while (sum <= Number(input)) {
     console.log(sum);
     sum = (sum * 2) + 1;
    }
}

PrintNumber("17");