function solve(n, k) {

    let result = [1];

     for (let i = 0; i < n - 1; i++) {

         let currSum = 0;

        for (let j = 0; j < k; j++) {
            if (i - j < 0) break;
            currSum += result[i - j];
        }

        result.push(currSum);
     }

    return result;
}

console.log(solve(6, 3));
console.log(solve(8, 2));