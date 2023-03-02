function CalculateTimeOutside(input) {
let pages = Number(input[0]);
let pagesPerHour = Number(input[1]);
let days = Number(input[2]);

pages /= pagesPerHour;
pages /= days;

console.log(pages);
}

CalculateTimeOutside((["212","20","2"]));