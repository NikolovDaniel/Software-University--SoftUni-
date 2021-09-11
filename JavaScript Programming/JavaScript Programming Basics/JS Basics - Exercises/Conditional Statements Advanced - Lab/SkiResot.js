function CalculateHotelPrice(input) {
    let stayDays = input[0] - 1;
    let apType = input[1];
    let review = input[2];
    let roomPrice = 0;
    let discount = 0;
    let totalSum = 0;

    if (apType == "room for one person") {
        roomPrice = 18;
    } else if (apType == "apartment") {
        roomPrice = 25;
        if (stayDays < 10) {
            discount = 0.30;
        } else if (stayDays >= 10 && stayDays <= 15) {
            discount = 0.35;
        } else {
            discount = 0.50;
        }
    } else if (apType == "president apartment") {
        roomPrice = 35;
        if (stayDays < 10) {
            discount = 0.1;
        } else if (stayDays >= 10 && stayDays <= 15) {
            discount = 0.15;
        } else {
            discount = 0.20;
        }
    }

    totalSum = roomPrice * stayDays;
    if (apType != "room for one person") {
        totalSum -= totalSum * discount;
    }

    if (review == "positive") {
        totalSum += totalSum * 0.25;
    }
    else {
        totalSum -= totalSum * 0.10;
    }

    console.log(totalSum.toFixed(2));
}

CalculateHotelPrice((["2","apartment","positive"]));