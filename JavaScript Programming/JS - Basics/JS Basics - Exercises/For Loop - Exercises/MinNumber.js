function PrintMinNumber(input) {

    let n = Number(input.shift());
    let minNum = Number.MAX_SAFE_INTEGER;

    for (let i = 0; i < n; i++) {
        if (Number(input[i]) < minNum) {
            minNum = Number(input[i]);
        }
    }

    console.log(minNum);
}

PrintMinNumber((["4",
"45",
"-20",
"7",
"99"])
);