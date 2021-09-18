function PrintBiggestNum(input) {

    let biggestNum = Number.MIN_SAFE_INTEGER;

    let cmd = input.shift();

    while (cmd !== "Stop") {

        if (Number(cmd) > biggestNum) {
            biggestNum = Number(cmd);
        }

        cmd = input.shift();
    }

    console.log(biggestNum);
}

PrintBiggestNum((["100",
"99",
"80",
"70",
"Stop"])
);