function fruit(type, grams, pricePerKg) {

    let gramsToKg = grams / 1000;
    let totalPrice = gramsToKg * pricePerKg;

    console.log(`I need $${totalPrice.toFixed(2)} to buy ${gramsToKg.toFixed(2)} kilograms ${type}.`);
}

fruit('apple', 1563, 2.35);