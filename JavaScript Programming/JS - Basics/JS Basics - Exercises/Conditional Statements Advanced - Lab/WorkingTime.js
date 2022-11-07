function CheckWorkingTime(input) {
    if (input[0] < 10 || input[0] > 18 || input[1] == "Sunday") {
        console.log('closed');
    } else {
        console.log('open');
    }
}

CheckWorkingTime(["11", "Sunday"]);