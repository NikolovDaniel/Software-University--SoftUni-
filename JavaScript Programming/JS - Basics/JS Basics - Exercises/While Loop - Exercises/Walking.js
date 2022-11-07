function CalculateSteps(input) {

    let currSteps = 0;

    while (currSteps < 10000) {

        let command = input.shift();

        if (command == "Going home") {
            let steps = Number(input.shift());
            currSteps += steps;

            if (currSteps < 10000) {
                console.log(`${10000 - currSteps} more steps to reach goal.`);
                return;
            }
        }
        else {
            currSteps += Number(command);
        }
    }

    console.log(`Goal reached! Good job!`);
    console.log(`${currSteps - 10000} steps over the goal!`);
}

CalculateSteps((["1500",
    "3000",
    "250",
    "1548",
    "2000",
    "Going home",
    "2000"])
);