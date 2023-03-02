function PrintSumOfNumbera(input) {

    let n = Number(input.shift());
    let sum = 0;

    while (input.length > 0) {
        sum += Number(input.shift());

        if (sum >= n) {
            console.log(sum);
            return;
        }
    }
}

PrintSumOfNumbera((["20",
"1",
"2",
"3",
"4",
"5",
"6"])
);