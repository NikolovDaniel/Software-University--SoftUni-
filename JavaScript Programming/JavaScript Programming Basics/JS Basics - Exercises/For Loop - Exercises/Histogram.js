function Histogram(input) {

    let n = Number(input.shift());

    var p1 = 0.0;
    var p2 = 0.0;
    var p3 = 0.0;
    var p4 = 0.0;
    var p5 = 0.0;

    var total = input.length;

    for (let i = 0; i < n; i++) {

        let num = Number(input[i]);

        if (num < 200) {
            p1++;
        } else if (num >= 200 && num <= 399) {
            p2++;
        } else if (num >= 400 && num <= 599) {
            p3++;
        } else if (num >= 600 && num <= 799) {
            p4++;
        } else if (num >= 800) {
            p5++;
        }
    }

    p1 = (p1 / total) * 100;
    p2 = (p2 / total) * 100;
    p3 = (p3 / total) * 100;
    p4 = (p4 / total) * 100;
    p5 = (p5 / total) * 100;

    console.log(`${p1.toFixed(2)}%`);
    console.log(`${p2.toFixed(2)}%`);
    console.log(`${p3.toFixed(2)}%`);
    console.log(`${p4.toFixed(2)}%`);
    console.log(`${p5.toFixed(2)}%`);
}

Histogram((["14",
"53",
"7",
"56",
"180",
"450",
"920",
"12",
"7",
"150",
"250",
"680",
"2",
"600",
"200"])

);