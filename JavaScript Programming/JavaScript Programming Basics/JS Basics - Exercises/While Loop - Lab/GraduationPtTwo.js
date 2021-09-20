function PrintAverageGrade(input) {

    let name = input.shift();
    let grade = 1;
    let countGr = 0;
    let counter = 0;
    let totalGr = 0;
    while (input.length > 0) {
        let gr = Number(input.shift());

        if (gr >= 4.00) {
            grade++;
            counter++;
            totalGr += gr;
        } else {
            totalGr += gr;
            countGr++;
            counter++;
        }

        if (countGr == 2) {

            console.log(`${name} has been excluded at ${grade} grade`)
            return;
        }
    }

    totalGr /= counter;

    console.log(`${name} graduated. Average grade: ${totalGr.toFixed(2)}`);
}

PrintAverageGrade((["Gosho", 
"5",
"5.5",
"6",
"5.43",
"5.5",
"6",
"5.55",
"5",
"6",
"6",
"5.43",
"5"])
);