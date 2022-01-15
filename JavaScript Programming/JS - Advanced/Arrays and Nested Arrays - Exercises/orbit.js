function solve(sizes) {

    const matrix = [];

    let matrixSize = sizes[0];
    let row = sizes[2];
    let col = sizes[3];

    for (let i = 0; i < matrixSize; i++) {

        let newArr = [];

        for (let j = 0; j < matrixSize; j++) {
            newArr.push(0);
        }

        matrix.push(newArr);
    }

    matrix[row][col] = 1;

}

solve([4, 4, 0, 0]);
solve([5, 5, 2, 2]);
solve([3, 3, 2, 2]);