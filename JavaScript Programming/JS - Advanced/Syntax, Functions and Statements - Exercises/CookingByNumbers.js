function cookingByNumbers(num, oprOne, oprTwo, oprThree, oprFour, oprFive,) {

    let operationsArray = [oprOne, oprTwo, oprThree, oprFour, oprFive];

    for (let i = 0; i < operationsArray.length; i++) {

        switch (operationsArray[i]) {
            case 'chop': num /= 2; break;
            case 'dice': num = Math.sqrt(num); break;
            case 'spice': num += 1; break;
            case 'bake': num *= 3; break;
            case 'fillet': num -= num * 0.20; break;
        }

        console.log(num);
    }
}


cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');