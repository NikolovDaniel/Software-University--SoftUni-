function CalculateCommission(input) {

    let commision = 0;
    if (input[1] < 0) {
        return console.log('error');
    } else if (input[0] == "Sofia") {
        if (input[1] <= 500) {
            commision = 0.05;
        } else if (input[1] > 500 && input[1] <= 1000) {
            commision = 0.07;
        } else if (input[1] > 1000 && input[1] <= 10000) {
            commision = 0.08;
        } else if (input[1] > 10000) {
            commision = 0.12;
        }
    } else if (input[0] == "Varna") {
        if (input[1] <= 500) {
            commision = 0.045;
        } else if (input[1] > 500 && input[1] <= 1000) {
            commision = 0.075;
        } else if (input[1] > 1000 && input[1] <= 10000) {
            commision = 0.1;
        } else if (input[1] > 10000) {
            commision = 0.13;
        }
    } else if (input[0] == "Plovdiv") {
        if (input[1] <= 500) {
            commision = 0.055;
        } else if (input[1] > 500 && input[1] <= 1000) {
            commision = 0.08;
        } else if (input[1] > 1000 && input[1] <= 10000) {
            commision = 0.12;
        } else if (input[1] > 10000) {
            commision = 0.145;
        }
    } else {
        return console.log('error');
    }
console.log((input[1] * commision).toFixed(2));
}

CalculateCommission(["Varna", "15000"]);