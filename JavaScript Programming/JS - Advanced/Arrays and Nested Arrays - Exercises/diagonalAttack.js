function solve(input) {

    const matrix = [];

    for (let i = 0; i < input.length; i++) {
        matrix.push(input[i].split(' '));
    }

    let leftDiagonal = 0;
    let rightDiagonal = 0;

    for (let i = 0; i < matrix.length; i++) {
        leftDiagonal += Number(matrix[i][i]);
    }

    for (let i = matrix.length - 1; i >= 0; i--) {
        rightDiagonal += Number(matrix[matrix.length - 1 - i][i]);
    }

    if (leftDiagonal != rightDiagonal) {
        for (let row of matrix) {
            console.log(row.join(' '));
        }

        return;
    }

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            if (j == i) continue;
            if (j == (matrix.length - 1) - i) continue;

            matrix[i][j] = rightDiagonal;
        }
    }

    for (let row of matrix) {
        console.log(row.join(' '));
    }
}


solve([
    '1 1 1',
    '1 1 1',
    '1 1 0'
]);

solve([
    '5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1'
]);