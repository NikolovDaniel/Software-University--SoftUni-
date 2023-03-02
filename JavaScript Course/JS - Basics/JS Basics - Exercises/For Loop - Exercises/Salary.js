function PrintSalary(input) {

    let n = Number(input.shift());
    let salary = Number(input.shift());

    for (let i = 0; i < n; i++) {

        let website = input.shift();

        if (website == "Facebook") {
            salary -= 150;
        } else if (website == "Instagram") {
            salary -= 100;
        } else if (website == "Reddit") {
            salary -= 50;
        }

        if (salary <= 0) {
            console.log("You have lost your salary.");
            return;
        }
    }

    console.log(salary);
}

PrintSalary((["3",
"500",
"Facebook",
"Stackoverflow.com",
"softuni.bg"]
));
