function solve(input) {

    const result = {};

    for (let i = 0; i < input.length; i += 2) {
        let name = input[i];
        let calories = Number(input[i + 1]);

        result[name] = calories;

    }

    return result;
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));