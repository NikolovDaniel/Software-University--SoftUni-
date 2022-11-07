function PrintSmallestNum(input) {

    let smallestNum = Number.MAX_SAFE_INTEGER;

    let cmd = input.shift();

    while (cmd !== "Stop") {

        if (Number(cmd) < smallestNum) {
            smallestNum = Number(cmd);
        }

        cmd = input.shift();
    }

    console.log(smallestNum);
}

PrintSmallestNum((["100",
"99",
"80",
"70",
"Stop"])
);