function MultiplicationTable(input) {

    for (let i = 1; i <= 10; i++) {

        console.log(`${i} * ${input} = ${i * Number(input)}`);

    }
}

MultiplicationTable("5");