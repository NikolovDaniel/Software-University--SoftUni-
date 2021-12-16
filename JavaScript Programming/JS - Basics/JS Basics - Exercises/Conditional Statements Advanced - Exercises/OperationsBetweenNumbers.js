function OperationsNumbers(input) {

    let numOne = Number(input.shift());
    let numTwo = Number(input.shift());
    let operator = input.shift();

    let result = 0;

    if (operator == '+' || operator == '-' || operator == '*') {
        if (operator == '+') {
            result = numOne + numTwo;
        } else if (operator == '-') {
            result = numOne - numTwo;
        } else if (operator == '*') {
            result = numOne * numTwo;
        }

        let evenOrOdd = '';

        if (result % 2 == 0) {
            evenOrOdd = 'even';
        } else {
            evenOrOdd = 'odd';
        }

        console.log(`${numOne} ${operator} ${numTwo} = ${result} - ${evenOrOdd}`);

    }
    else if (operator == "%") {
        if (numTwo == 0) {
            console.log(`Cannot divide ${numOne} by zero`);
        } else {
            console.log(`${numOne} ${operator} ${numTwo} = ${numOne % numTwo}`);
        }
    } else if (operator == "/") {
        if (numTwo == 0) {
            console.log(`Cannot divide ${numOne} by zero`);
        } else {
            console.log(`${numOne} ${operator} ${numTwo} = ${(numOne / numTwo).toFixed(2)}`);
        }
    }
}

OperationsNumbers((["-50",
    "-12",
    "+"])
);






