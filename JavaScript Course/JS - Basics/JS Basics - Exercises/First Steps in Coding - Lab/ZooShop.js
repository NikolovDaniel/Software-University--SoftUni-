function NeededSum(input) {

    let dogCount = input[0];
    let otherAnimalsCount = input[1];

    let totalSum = (dogCount * 2.50) + (otherAnimalsCount * 4);

    console.log(`${totalSum} lv.`)
}

NeededSum(["13", "9"]);