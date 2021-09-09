function BudgetCalculator(input) {

    let cakePrice = Number(input) * 0.20;
    let drinks = cakePrice * 0.55;
    let animator = Number(input) / 3;
    
    let sum = cakePrice + drinks + animator + Number(input);
    
    console.log(sum);
    
}

BudgetCalculator((["225"]));