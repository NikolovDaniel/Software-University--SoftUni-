function CalculateDeposit(input) {

let depositedSum = Number(input[0]);
let depositLength = Number(input[1]);
let interest = Number(input[2]);

interest = depositedSum * (interest / 100);
interest /= 12;

let sum = depositedSum + (depositLength * interest);

console.log(sum);
}

CalculateDeposit((["200","3","5.7"]));