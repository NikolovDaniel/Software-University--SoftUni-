function MoneyNeeded(input) {

let priceStrawb = Number(input[0]);
let quantityBananas = Number(input[1]);
let quantityOranges = Number(input[2]);
let quantityRasp = Number(input[3]);
let quantityStrawb = Number(input[4]);

let priceRasp = priceStrawb / 2;
let priceOranges = priceRasp * 0.60;
let priceBananas = priceRasp * 0.20;

priceStrawb *= quantityStrawb;
priceRasp *= quantityRasp;
priceOranges *= quantityOranges;
priceBananas *= quantityBananas;

let totalSum = priceStrawb + priceRasp + priceOranges + priceBananas;

console.log(totalSum);

}

MoneyNeeded((["63.5",
"3.57",
"6.35",
"8.15",
"2.5"]));
