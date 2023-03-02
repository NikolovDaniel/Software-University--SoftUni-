function CalculateSum(input) {

    let totalSum = input * 7.61;
    let discount = totalSum * 0.18;
    totalSum -= discount;

    console.log(`The final price is: ${totalSum.toFixed(2)} lv.`)
    console.log(`The discount is: ${discount.toFixed(2)} lv.`)
}

CalculateSum("550");