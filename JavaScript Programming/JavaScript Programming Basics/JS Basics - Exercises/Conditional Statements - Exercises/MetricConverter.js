function MetricConverter(input) {

    let sum = Number(input[0]);

    if (input[1] == "m") {
        if (input[2] == "mm") {
            sum *= 1000;
        } else if (input[2] == "cm") {
            sum *= 100;
        }
    } else if (input[1] == "cm") {
        if (input[2] == "m") {
            sum /= 100;
        } else if (input[2] == "mm") {
            sum *= 10;
        }
    } else if (input[1] == "mm") {
        if (input[2] == "m") {
            sum /= 1000;
        } else if (input[2] == "cm") {
            sum /= 10;
        }
    }

    console.log(sum.toFixed(3));
}

MetricConverter((["45","cm","mm"]));