function evenOrOdd(input) {
    let number = Number(input);
    if (number % 2 == 0) {
        let res = number % 2;
        console.log("even");
    } else {
        console.log("odd");
    }
}
evenOrOdd("-2");