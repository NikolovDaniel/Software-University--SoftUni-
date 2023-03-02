function CalculateNeededSum(input) {
    let budget = Number(input.shift());
    let decor = budget * 0.10;;
    let statisticians = Number(input.shift());
    let priceDress = Number(input.shift());

    priceDress = statisticians * priceDress;

    if (statisticians > 150) priceDress -= priceDress * 0.10;

    let totalSum = decor + priceDress;

    if (totalSum <= budget) {
        console.log('Action!');
        console.log(`Wingard starts filming with ${(budget - totalSum).toFixed(2)} leva left.`);
    } else {
        console.log('Not enough money!');
        console.log(`Wingard needs ${(totalSum - budget).toFixed(2)} leva more.`);
    }
}

CalculateNeededSum((["20000",
"120",
"55.5"])
);