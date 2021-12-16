function CalculateBudget(input) {

    let budget = Number(input.shift());
    let season = input.shift();
    let fishermen = Number(input.shift());

    let boatPrice = 0;

    if (season == "Spring") {
        boatPrice = 3000;
    } else if (season == "Summer" || season == "Autumn") {
        boatPrice = 4200;
    } else if (season == "Winter") {
        boatPrice = 2600;
    }

        if (fishermen >= 0 && fishermen <= 6) boatPrice -= boatPrice * 0.10;
    else if (fishermen > 6 && fishermen <= 11) boatPrice -= boatPrice * 0.15;
    else if (fishermen > 11) boatPrice -= boatPrice * 0.25;

    if (fishermen % 2 == 0 && season != "Autumn") {
        boatPrice -= boatPrice * 0.05;
    }

    if (budget >= boatPrice) {
        console.log(`Yes! You have ${(budget - boatPrice).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money! You need ${(boatPrice - budget).toFixed(2)} leva.`);
    }
}

CalculateBudget((["3000",
"Summer",
"11"])
);