function solve(numbers) {

    const result = [];

    while (numbers.length > 0) {
        
        result.push(Math.min(...numbers));

        if (numbers.length == 1) break;

        result.push(Math.max(...numbers));

        let smallestIndex = numbers.indexOf(Math.min(...numbers));
        numbers.splice(smallestIndex, 1);
        let biggestIndex = numbers.indexOf(Math.max(...numbers));
        numbers.splice(biggestIndex, 1);
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
console.log(solve([-1,-2,-3,-53,-12,-213,-123]));

