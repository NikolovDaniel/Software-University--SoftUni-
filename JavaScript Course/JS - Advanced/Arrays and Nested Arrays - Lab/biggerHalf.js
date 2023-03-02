function solve(myArr) {

    myArr.sort((a, b) => a - b);

    let middle = Math.floor(myArr.length / 2);
    let result = [];

    for (let i = middle; i < myArr.length; i++) {
        result.unshift(myArr[i]);
    }

    return result.reverse();
}

console.log(solve([4, 7, 2, 5]));
console.log(solve([3, 19, 14, 7, 2, 19, 6]));