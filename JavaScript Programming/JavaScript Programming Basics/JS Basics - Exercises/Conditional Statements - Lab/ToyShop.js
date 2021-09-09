function ExcursionMoney(input) {

    let priceExcursion = Number(input[0]);
    let puzzleQuantity = Number(input[1]);
    let dollsQuantity = Number(input[2]);
    let bearsQuantity = Number(input[3]);
    let minionsQuantity = Number(input[4]);
    let trucksQuantity = Number(input[5]);

    let totalQuantity = puzzleQuantity + dollsQuantity + bearsQuantity + minionsQuantity + trucksQuantity;

    let puzzlePrice = 2.60;
    let dollsPrice = 3;
    let bearsPrice = 4.10;
    let minionsPrice = 8.20;
    let trucksPrice = 2;

    let totalSum = (puzzlePrice * puzzleQuantity)
        + (dollsPrice * dollsQuantity) + (bearsPrice * bearsQuantity)
        + (minionsPrice * minionsQuantity) + (trucksPrice * trucksQuantity);

    if (totalQuantity >= 50) {
        totalSum -= totalSum * 0.25;
    }

    totalSum -= totalSum * 0.10;

    if (totalSum >= priceExcursion) {
        console.log(`Yes! ${(totalSum -= priceExcursion).toFixed(2)} lv left.`)
    } else {
        console.log(`Not enough money! ${(priceExcursion -= totalSum).toFixed(2)} lv needed.`);
    }
}

ExcursionMoney((["320", "8", "2", "5", "5", "1"]));