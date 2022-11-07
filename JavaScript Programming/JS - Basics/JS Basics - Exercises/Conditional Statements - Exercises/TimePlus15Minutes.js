function CalculateTimePlus15Minute(input) {

    let hours = Number(input.shift());
    let minutes = Number(input.shift()) + 15;

    if (minutes < 60) {
        if (minutes < 10) {
            console.log(`${hours}:0${minutes}`);
        } else {
            console.log(`${hours}:${minutes}`);
        }
    } else {
        hours++;

        if (hours == 24) {
            hours = 0;
        }
        minutes %= 60;
        if (minutes < 10) {
            console.log(`${hours}:0${minutes}`);
        } else {
            console.log(`${hours}:${minutes}`);

        }
    }
}

CalculateTimePlus15Minute(["0", "01"]);