function ExamPreparation(input) {

    let badGrades = Number(input.shift());
    let countBadGrades = 0;
    let countGrades = 0;
    let currProblem = input.shift();
    let currGrade = Number(input.shift());
    let average = 0;
    let lastProblem = "";
    while (currProblem != "Enough") {

        if (currGrade <= 4) {
            countBadGrades++;

            if (countBadGrades == badGrades) {
                console.log(`You need a break, ${badGrades} poor grades.`);
                return;
            }
        }

        countGrades++;
        average += currGrade;

        currProblem = input.shift();
        currGrade = Number(input.shift());
        if (currProblem != "Enough") {
            lastProblem = currProblem;
        }

    }

    console.log(`Average score: ${(average / countGrades).toFixed(2)}`);
    console.log(`Number of problems: ${countGrades}`);
    console.log(`Last problem: ${lastProblem}`);
}

ExamPreparation((["4",
"Money",
"5",
"Story",
"5",
"Spring Time",
"3",
"Enough"])
);