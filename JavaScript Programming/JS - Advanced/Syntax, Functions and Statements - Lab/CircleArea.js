function circleArea(input) {
    
    let area;

    if (typeof(input) == 'number') {
        area = Math.pow(input, 2) * Math.PI;
    }
    else {
        return console.log(`We can not calculate the circle area, because we receive a ${typeof(input)}.`);
    }

    console.log(area.toFixed(2));
}

circleArea(5);