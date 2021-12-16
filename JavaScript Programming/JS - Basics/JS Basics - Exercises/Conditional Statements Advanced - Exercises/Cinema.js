function CalculateIncome(input) {

    let priceTicket = 0;

    if (input[0] == "Normal") {
        priceTicket = 7.50;
    } else if (input[0] == "Premiere") {
        priceTicket = 12;
    } else if (input[0] == "Discount") {
        priceTicket = 5;
    }

    let hallSize = Number(input[1]) * Number(input[2]);

    let totalSum = priceTicket * hallSize;

    console.log(`${totalSum.toFixed(2)} leva.`)
}

CalculateIncome((["Normal",
"21",
"13"])
);