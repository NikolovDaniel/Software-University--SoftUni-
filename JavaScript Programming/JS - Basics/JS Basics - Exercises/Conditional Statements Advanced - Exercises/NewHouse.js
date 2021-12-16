function PrintBudget(input) {

    let flower = input.shift();
    let flowerCount = Number(input.shift());
    let budget = Number(input.shift());

    let flowerPrice = 0;
    let totalSum = 0;
    switch (flower) {

        case "Roses":
            flowerPrice = 5;
            totalSum = flowerPrice * flowerCount;
            if (flowerCount > 80) totalSum -= totalSum * 0.10;
            break;
        case "Dahlias":
            flowerPrice = 3.80;
            totalSum = flowerPrice * flowerCount;
            if (flowerCount > 90) totalSum -= totalSum * 0.15;
            break;
        case "Tulips":
            flowerPrice = 2.80;
            totalSum = flowerPrice * flowerCount;
            if (flowerCount > 80) totalSum -= totalSum * 0.15;
            break;
        case "Narcissus":
            flowerPrice = 3;
            totalSum = flowerPrice * flowerCount;
            if (flowerCount < 120) totalSum += totalSum * 0.15;
            break;
        case "Gladiolus":
            flowerPrice = 2.50;
            totalSum = flowerPrice * flowerCount;
            if (flowerCount < 80) totalSum += totalSum * 0.20;
            break;
    }

    if (totalSum <= budget) {
        console.log(`Hey, you have a great garden with ${flowerCount} ${flower} and ${(budget - totalSum).toFixed(2)} leva left.`);
    } else {
        console.log(`Not enough money, you need ${(totalSum - budget).toFixed(2)} leva more.`);
    }
}

PrintBudget(["Gladiolus", "64", "160"]);