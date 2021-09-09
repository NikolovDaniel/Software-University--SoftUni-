function Print100To200(input) {

    let currNum = Number(input);

    if (currNum < 100) {
        console.log("Less than 100");
    } else if (currNum >= 100 && currNum <= 200) {
        console.log("Between 100 and 200");
    } else {
        console.log("Greater than 200");
    }
}

Print100To200("201");