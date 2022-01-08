function solve(input) {
    let copiedArrOne = [...input];
    let copiedArrTwo = [...input];

    return Number(copiedArrOne.shift()) + Number(copiedArrTwo.pop());
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));