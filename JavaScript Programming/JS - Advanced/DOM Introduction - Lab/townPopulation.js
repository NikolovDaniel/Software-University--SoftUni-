function solve(input) {

    const result = {};

    for (let i = 0; i < input.length; i++) {

        const town = input[i].split(' <-> ')[0];
        const population = input[i].split(' <-> ')[1];

        if (result[town] == undefined) {
            result[town] = population;
        } else {
            result[town] += population;
        }
    }
    
    console.log(Object.entries(result).forEach(x => console.log(x.join(' : '))));
}

solve(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']	
);