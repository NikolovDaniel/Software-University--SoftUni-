function solve(numbersOperands) {

    const numbers = [];
    const operands = [];
    function arithmeticOperations(a, b, operator) {
        if (operator == '+') {
            return a + b;
        } else if (operator == '-') {
            return a - b;
        } else if (operator == '*') {
            return a * b;
        } else if (operator == '/') {
            return a / b;
        }
    }

    for (let i = 0; i < numbersOperands.length; i++) {
        if (typeof (numbersOperands[i]) == 'string') {
            operands.push(numbersOperands[i]);
        } else {
            numbers.push(Number(numbersOperands[i]));
        }
    }

    while (true) {

        if (numbers.length == 1 && operands.length == 0) {
            console.log(numbers[0]);
            break;
        } else if (numbers.length > 1 && operands.length == 0) {
            console.log('Error: too many operands!');
            break;
        } else if (numbers.length <= 1 && operands.length != 0) {
            console.log('Error: not enough operands!');
            break;
        }

        let firstNum = numbers.pop();
        let secondNum = numbers.pop();
        let operand = operands.shift();

        numbers.unshift(Math.ceil(arithmeticOperations(firstNum, secondNum, operand)));
    }
}

solve([3, 4, '+']);
solve([5, 3, 4, '*', '-']);
solve([7, 33, 8, '-']);
solve([15, '/']);
solve([31, 2, '+', 11, '/']);-1
solve([-1, 1, '+', 101, '*', 18, '+', 3, '/']);