function solve(matrix) {

    let biggest = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < matrix.length; i++) {
        if (Math.max(...matrix[i]) > biggest) {
            biggest = Math.max(...matrix[i]);
        }
    }
    
    return biggest;
}

console.log(solve([[20, 50, 10],
[8, 33, 145]]));

console.log(solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]));

console.log(solve([[-1, -2, -3, -4, -5]]));
