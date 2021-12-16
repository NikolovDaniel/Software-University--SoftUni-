function CalculateArea(input) {

    switch (input[0]) {
        case "rectangle":
            console.log((input[1] * input[2]).toFixed(3));
            break;
        case "square":
            console.log((input[1] * input[1]).toFixed(3));
            break;
        case "circle":
            console.log(((input[1] * input[1]) * Math.PI).toFixed(3));
            break;
        case "triangle":
            console.log(((input[1] * input[2]) / 2).toFixed(3));
            break;
    }
}

CalculateArea(["circle", "6"]);