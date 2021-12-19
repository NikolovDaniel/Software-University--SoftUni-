function largestNumber(numOne, numTwo, numThree) {

    let biggestNum = 0;

    if (numOne > numTwo && numOne > numThree) {
        biggestNum = numOne;
    } else if (numTwo > numOne && numTwo > numThree) {
        biggestNum = numTwo;
    } else if (numThree > numOne && numThree > numTwo) {
        biggestNum = numThree;
    }

    console.log(`The largest number is ${biggestNum}.`);
}

largestNumber(5, -3, 16);
largestNumber(-3, -5, -22.5);

