function solve(matrix) {

    const add = function (acc, a) {
        return acc + a;
    }

    let firstRowSum = matrix[0].reduce(add, 0);

    for (let i = 1; i < matrix.length; i++) {

        let currSum = matrix[i].reduce(add, 0);

        if (currSum != firstRowSum) {
            return false;
        }
    }

    for (let i = 0; i < matrix.length; i++) {
        let currSum = 0;

        for (let j = 0; j < matrix.length; j++) {

            currSum += matrix[j][i];

        }

        if (currSum != firstRowSum) {
            return false;
        }
    }

    return true;
}

console.log(solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]
));