function DivideWithourRemainder(input) {

    let nums = Number(input.shift());

    let p1 = 0;
    let p2 = 0;
    let p3 = 0;

    for (let i = 0; i < nums; i++) {

        if (Number(input[i]) % 2 == 0) {
            p1++;
        } 
        if (Number(input[i]) % 3 == 0) {
            p2++;
        }
        if (Number(input[i]) % 4 == 0) {
            p3++;
        }
    }

    p1 = p1 / nums * 100;
    p2 = p2 / nums * 100;
    p3 = p3 / nums * 100;

    console.log(`${p1.toFixed(2)}%`);
    console.log(`${p2.toFixed(2)}%`);
    console.log(`${p3.toFixed(2)}%`);
}

DivideWithourRemainder((["3",
"3",
"6",
"9"])
);