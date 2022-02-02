function solve(width, height, color) {

    let upperCaseColor = color[0].toUpperCase();

    for (let i = 1; i < color.length; i++) {
        upperCaseColor += color[i];
    }

    const rectangle = {
        width: width,
        height: height,
        color: upperCaseColor,
        calcArea() {
            return width * height;
        }
    }

    return rectangle;
}

let rect = solve(4, 5, 'red');
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
