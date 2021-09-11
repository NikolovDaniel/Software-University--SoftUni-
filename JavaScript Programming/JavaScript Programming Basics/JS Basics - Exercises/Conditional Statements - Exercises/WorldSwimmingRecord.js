function CalculateWorldRecord(input) {

    let record = Number(input.shift());
    let lengthMeters = Number(input.shift());
    let secondsPerMeter = Number(input.shift());

    let slowDown = Math.floor(lengthMeters / 15) * 12.5;

    let swimmingTime = ((lengthMeters * secondsPerMeter) + slowDown).toFixed(2);

    if (swimmingTime < record) {
        console.log(`Yes, he succeeded! The new world record is ${swimmingTime} seconds.`);
    } else {
        console.log(`No, he failed! He was ${(swimmingTime - record).toFixed(2)} seconds slower.`);
    }
}

CalculateWorldRecord((["55555.67",
"3017",
"5.03"])
);