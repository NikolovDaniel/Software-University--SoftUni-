function solve(arrNames) {

    arrNames.sort((a, b) => a.localeCompare(b));

    for (let i = 1; i <= arrNames.length; i++) {

        console.log(`${i}.${arrNames[i - 1]}`);
    }
}

solve(["John", "Bob", "Christina", "Ema"]);