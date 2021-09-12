function CalculateHotelStay(input) {

    let month = input.shift();
    let nights = Number(input.shift());

    let studioPrice = 0;
    let apartmentPrice = 0;

    if (month == "May" || month == "October") {
        studioPrice = nights * 50;
        apartmentPrice = nights * 65;
        if (nights > 7 && nights <= 14) {
            studioPrice -= studioPrice * 0.05;
        } else if (nights > 14) {
            studioPrice -= studioPrice * 0.3;
        }
    } else if (month == "June" || month == "September") {
        studioPrice = 75.20 * nights;
        apartmentPrice = 68.70 * nights;
        if (nights > 14) {
            studioPrice -= studioPrice * 0.2;
        }
    } else if (month == "July" || month == "August") {
        studioPrice = 76 * nights;
        apartmentPrice = 77 * nights;
    }

    if (nights > 14) {
        apartmentPrice -= apartmentPrice * 0.10;
    }

    console.log(`Apartment: ${apartmentPrice.toFixed(2)} lv.`);
    console.log(`Studio: ${studioPrice.toFixed(2)} lv.`);
}

CalculateHotelStay((["May",
"15"])
);