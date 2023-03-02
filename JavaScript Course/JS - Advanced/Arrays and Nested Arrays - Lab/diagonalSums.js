function solve(matrix) {

    let leftSum = 0;
    let rightSum = 0;

    for (let i = 0; i < matrix.length; i++) {
        leftSum += matrix[i][i];
        rightSum += matrix[i][(matrix.length - 1) - i];
    }

    console.log(leftSum, rightSum);
}

solve([[20, 40],
       [10, 60]]);

solve([[3, 5, 17],
       [-1, 7, 14],
       [1, -8, 89]]);