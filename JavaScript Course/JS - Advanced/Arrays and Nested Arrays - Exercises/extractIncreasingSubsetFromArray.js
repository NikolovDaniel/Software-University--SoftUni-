function solve(arr) {

    let biggest = Number.MIN_SAFE_INTEGER;

    // const result = [];

    // arr.forEach(x => {
    //     if (x >= biggest) {
    //         biggest = x;
    //         result.push(x);
    //     }
    // });

    // return result;

    return arr.filter(x => {
        if (x >= biggest) {
            biggest = x;
            return true;
        }

        return false;
    });
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));