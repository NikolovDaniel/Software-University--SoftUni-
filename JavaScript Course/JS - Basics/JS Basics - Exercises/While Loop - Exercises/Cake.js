function CalculatePieces(input) {

    let width = Number(input.shift());
    let length = Number(input.shift());

    let cakeSize = width * length;
    let currPieces = 0;
    while (cakeSize > currPieces) {

        let command = input.shift();

        if (command == "STOP") {
            break;
        }
        
        currPieces += Number(command);
    }

    if (cakeSize - currPieces > 0) {
        console.log(`${cakeSize - currPieces} pieces are left.`);
    }
    else {
        console.log(`No more cake left! You need ${currPieces - cakeSize} pieces more.`);
    }
}

CalculatePieces((["10",
"2",
"2",
"4",
"6",
"STOP"])
);