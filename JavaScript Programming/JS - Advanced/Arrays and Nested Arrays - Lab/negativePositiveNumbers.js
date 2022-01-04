function solve(myArr) {

    let result = [];

    myArr.map(x => {
        if (x < 0) {
            result.unshift(x);
        } else {
            result.push(x);
        }
    });

    // for (let i = 0; i < myArr.length; i++) {
    //     if (myArr[i] < 0) {
    //         result.unshift(myArr[i]);
    //     } else {
    //         result.push(myArr[i]);
    //     }
    // }

    result.forEach(x => console.log(x));
}

solve([7, -2, 8, 9]);
solve([3, -2, 0, - 1]);