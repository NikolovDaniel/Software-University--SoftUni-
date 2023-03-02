function CalculateBudget(input) {

    let neededMoney = Number(input.shift());
    let currentMoney = Number(input.shift());

    let days = 0;
    let daysSpend = 0;

    while (currentMoney < neededMoney) {

        days++;
        let cmd = input.shift();
        let money = Number(input.shift());

        if (cmd == "spend") {

            daysSpend++;

            if (currentMoney - money < 0) {
                currentMoney = 0;
            }
            else {
                currentMoney -= money;
            }
        }
        else if (cmd == "save") {
            daysSpend = 0;

            currentMoney += money;
        }

        if (currentMoney >= neededMoney) {
            console.log(`You saved the money for ${days} days.`);
        }

        if (daysSpend == 5) {
            console.log(`You can't save the money.`);
            console.log(`${days}`);
            return;
        }
    }
}

CalculateBudget((["110",
    "60",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10",
    "spend",
    "10"])

);
