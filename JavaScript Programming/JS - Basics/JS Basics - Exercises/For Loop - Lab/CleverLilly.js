function PrintBirthdaySum(input) {

    let age = Number(input.shift());
    let machinePrice = Number(input.shift());
    let priceToy = Number(input.shift());

    let evenSum = 10;
    let toys = 0;
    let totalSum = 0;
    for (let i = 1; i <= age; i++) {

        if (i % 2 == 0) {
            totalSum += evenSum - 1;
            evenSum += 10;
        } else if (i % 2 == 1) {
            toys++;
        }
    }

    toys *= priceToy;

    totalSum += toys;

    if (totalSum >= machinePrice) {
        console.log(`Yes! ${(totalSum - machinePrice).toFixed(2)}`);
    } else {
        console.log(`No! ${(machinePrice - totalSum).toFixed(2)}`);
    }
}

PrintBirthdaySum((["21", "1570.98", "3"]));