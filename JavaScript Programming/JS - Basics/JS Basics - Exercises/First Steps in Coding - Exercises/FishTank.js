function CalculateLitresWater(input) {

    let lengthCm = Number(input[0]);
    let widthCm = Number(input[1]);
    let heightCm = Number(input[2]);
    let percent = Number(input[3]);

    let capacity = lengthCm * widthCm * heightCm;
    capacity *= 0.001;
    capacity -= capacity * (percent / 100);

    console.log(capacity);



}

CalculateLitresWater((["85", "75", "47", "17"]));
