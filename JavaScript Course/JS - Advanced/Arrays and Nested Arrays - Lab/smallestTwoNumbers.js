function solve(myArr) {

    myArr.sort((a, b) => a - b);

    return [myArr[0], myArr[1]];
}

console.log(solve([30, 15, 50, 5]).join(' '));
console.log(solve([3, 0, 10, 4, 7, 3]).join(' '));