function PrintRightClothes(input) {

    let degrees = Number(input.shift());
    let dayType = input.shift();

    let outfit = '';
    let shoes = '';

    if (dayType == "Morning") {

        if (degrees >= 10 && degrees <= 18) {
            outfit = 'Sweatshirt';
            shoes = 'Sneakers';
        } else if (18 < degrees && degrees <= 24) {
            outfit = 'Shirt';
            shoes = 'Moccasins';
        } else if (degrees >= 25) {
            outfit = 'T-Shirt';
            shoes = 'Sandals';
        }

    } else if (dayType == "Afternoon") {

        if (degrees >= 10 && degrees <= 18) {
            outfit = 'Shirt';
            shoes = 'Moccasins';
        } else if (18 < degrees && degrees <= 24) {
            outfit = 'T-Shirt';
            shoes = 'Sandals';
        } else if (degrees >= 25) {
            outfit = 'Swim Suit';
            shoes = 'Barefoot';
        }

    } else if (dayType == "Evening") {

        if (degrees >= 10 && degrees <= 18) {
            outfit = 'Shirt';
            shoes = 'Moccasins';
        } else if (18 < degrees && degrees <= 24) {
            outfit = 'Shirt';
            shoes = 'Moccasins';
        } else if (degrees >= 25) {
            outfit = 'Shirt';
            shoes = 'Moccasins';
        }
    }

    console.log(`It's ${degrees} degrees, get your ${outfit} and ${shoes}.`)
}

PrintRightClothes((["16",
"Morning"])
);