function CalculateCharitySum(input) {

    let priceCake = 45;
    let priceWaffle = 5.80;
    let pricePancake = 3.20;

    let days = Number(input[0]);
    let chefs = Number(input[1]);
    let cakes = Number(input[2]);
    let waffles = Number(input[3]);
    let pancakes = Number(input[4]);

    priceCake = cakes * priceCake;
    priceWaffle = waffles * priceWaffle;
    pricePancake = pancakes * pricePancake;

    let totalSum = (chefs * days) * (priceCake + pricePancake + priceWaffle);
    totalSum -= totalSum / 8;
    console.log(totalSum);

}

CalculateCharitySum((["131", "5", "9", "33", "46"]));