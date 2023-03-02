function CalculateSeconds(input) {
    let totalSeconds = Number(input[0]) + Number(input[1]) + Number(input[2]);

    let minutes = Math.floor(totalSeconds / 60).toFixed(0);

    totalSeconds %= 60;

    if (totalSeconds >= 10) {
        console.log(`${minutes}:${totalSeconds}`);
    } else {
        console.log(`${minutes}:0${totalSeconds}`);
    }
}

CalculateSeconds((["50", "50", "50"]));