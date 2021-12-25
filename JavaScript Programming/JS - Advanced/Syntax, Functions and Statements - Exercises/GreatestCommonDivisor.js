function gcd_two_numbers(x, y) {
    
    x = Math.abs(x);
    y = Math.abs(y);

    while (y) {
        let t = y;
        y = x % y;
        x = t;
    }

    return x;
}

console.log(gcd_two_numbers(15, 5));
console.log(gcd_two_numbers(51312, 3));