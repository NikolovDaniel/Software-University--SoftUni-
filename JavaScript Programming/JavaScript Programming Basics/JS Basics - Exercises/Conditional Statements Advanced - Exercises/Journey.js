function DecideHoliday(input) {

    let budget = Number(input.shift());
    let season = input.shift();

    let spendings = 0;
    let typeHotel = '';
    let country = '';

   

    if (budget <= 100) {
        if (season == "summer") {
            spendings = budget * 0.3;
        } else {
            spendings = budget * 0.7;
        }
        country = 'Bulgaria';
    } else if (budget > 100 && budget <= 1000) {
        if (season == "summer") {
            spendings = budget * 0.4;
        } else {
            spendings = budget * 0.8;
        }
        country = 'Balkans';
    } else if (budget > 1000) {
        spendings = budget * 0.9;
        country = 'Europe';
    }

    if (season == "summer" && country != "Europe") typeHotel = 'Camp';
    else typeHotel = 'Hotel';

console.log(`Somewhere in ${country}`);
console.log(`${typeHotel} - ${spendings.toFixed(2)}`);

}

DecideHoliday((["50", "summer"]));