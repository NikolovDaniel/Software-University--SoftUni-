function PrintLeapYears(input) {

    let leapYear = Number(input.shift());
    let totalYears = Number(input.shift());

    for (let i = leapYear; i <= totalYears; i += 4) {

        console.log(i);

    }
}

PrintLeapYears(["2020", "2032"]);