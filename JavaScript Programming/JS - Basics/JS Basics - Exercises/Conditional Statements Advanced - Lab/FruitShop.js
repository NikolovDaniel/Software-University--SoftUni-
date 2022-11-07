function CalculateSum(input) {

    let product = 0;

    switch (input[1]) {
        case "Monday":
        case "Tuesday":
        case "Wednesday":
        case "Thursday":
        case "Friday":
            switch (input[0]) {
                case "banana":
                    product = 2.50;
                    break;
                case "apple":
                    product = 1.20;
                    break;
                case "orange":
                    product = 0.85;
                    break;
                case "grapefruit":
                    product = 1.45;
                    break;
                case "kiwi":
                    product = 2.70;
                    break;
                case "grapes":
                    product = 3.85;
                    break;
                case "pineapple":
                    product = 5.50;
                    break;
                    default:
                        return console.log("error");
            }
            break;
        case "Saturday":
        case "Sunday":
            switch (input[0]) {
                case "banana":
                    product = 2.50;
                    break;
                case "apple":
                    product = 1.20;
                    break;
                case "orange":
                    product = 0.85;
                    break;
                case "grapefruit":
                    product = 1.45;
                    break;
                case "kiwi":
                    product = 2.70;
                    break;
                case "grapes":
                    product = 3.85;
                    break;
                case "pineapple":
                    product = 5.50;
                    break;
                    default:
                        return console.log("error");
            }
            break;
    }

    console.log((input[2] * product).toFixed(2));
}

CalculateSum(["tomato", "Tuesday", "2"]);