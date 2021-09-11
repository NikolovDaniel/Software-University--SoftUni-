function PrintTicketPrice(input) {

    let price = 0;

    switch (input) {
        case "Monday":
        case "Tuesday":
        case "Friday":
            price = 12;
            break;
        case "Wednesday":
        case "Thursday":
           price = 14;
            break;
        case "Saturday":
        case "Sunday":
            price = 16;
            break;
    }
    console.log(price);
}

PrintTicketPrice("Sunday");