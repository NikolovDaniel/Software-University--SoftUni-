function PrintPassword(input) {

    let username = input.shift();
    let password = input.shift();

    let currPass = "10101";
    let isTrue = false;
    while (currPass !== password) {
        currPass = input.shift();

        if (currPass == password) {
            isTrue = true;
            break;
        }
    }

    if (isTrue) {
        console.log(`Welcome ${username}!`);
    }
}


PrintPassword((["Gosho",
    "secret",
    "secret"]));
