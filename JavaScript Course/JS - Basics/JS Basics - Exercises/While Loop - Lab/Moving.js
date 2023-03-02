function PrintIfPossibleToMove(input) {

    let width = Number(input.shift());
    let length = Number(input.shift());
    let height = Number(input.shift());

    let totalSpace = width * length * height;

    while (input.length > 0) {
        let box = input.shift();
        if (box == "Done") break;
        if (totalSpace - box < 0) {
            console.log(`No more free space! You need ${Math.abs(totalSpace - box)} Cubic meters more.`);
            return;
        } else {
            totalSpace -= box;
        }
    }

    console.log(`${totalSpace} Cubic meters left.`);

}

PrintIfPossibleToMove((["10",
    "1",
    "2",
    "4",
    "6",
    "Done"])
);