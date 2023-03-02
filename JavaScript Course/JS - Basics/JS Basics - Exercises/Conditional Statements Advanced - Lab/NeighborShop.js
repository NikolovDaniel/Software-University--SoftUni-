function CalculateProductPrice(input) {

    let product = 0;

    if (input[0] == "coffee") {
        switch (input[1]) {
            case "Sofia":
                product = 0.50;
                break;
            case "Plovdiv":
                product = 0.40;
                break;
            case "Varna":
                product = 0.45;
                break;
        }
    } else if (input[0] == "water") {
        switch (input[1]) {
            case "Sofia":
                product = 0.80;
                break;
            case "Plovdiv":
                product = 0.70;
                break;
            case "Varna":
                product = 0.70;
                break;
        }
    } else if (input[0] == "beer") {
        switch (input[1]) {
            case "Sofia":
                product = 1.20;
                break;
            case "Plovdiv":
                product = 1.15;
                break;
            case "Varna":
                product = 1.10;
                break;
        }
    } else if (input[0] == "sweets") {
        switch (input[1]) {
            case "Sofia":
                product = 1.45;
                break;
            case "Plovdiv":
                product = 1.30;
                break;
            case "Varna":
                product = 1.35;
                break;
        }
    } else if (input[0] == "peanuts") {
        switch (input[1]) {
            case "Sofia":
                product = 1.60;
                break;
            case "Plovdiv":
                product = 1.50;
                break;
            case "Varna":
                product = 1.55;
                break;
        }
    }

    console.log(product * input[2]);
}

CalculateProductPrice(["coffee", "Varna", "2"]);