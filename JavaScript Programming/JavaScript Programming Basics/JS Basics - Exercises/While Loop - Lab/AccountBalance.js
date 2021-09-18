function PrintBalance(input) {

    let cmd = input.shift();
    let totalSum = 0.0;

    while (cmd !== "NoMoreMoney") {


        if (Number(cmd) < 0) {
            console.log("Invalid operation!");
            break;
        } else {
            console.log(`Increase: ${Number(cmd).toFixed(2)}`);
            totalSum += Number(cmd);
        }
        cmd = input.shift();
    }

    console.log(`Total: ${totalSum.toFixed(2)}`);
}

PrintBalance((["120",
"45.55",
"-150"])
);