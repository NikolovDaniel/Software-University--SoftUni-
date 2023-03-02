function daysInAMonth(month, year) {
    return new Date(year, month, 0).getDate();
}

console.log(daysInAMonth(2, 2021));