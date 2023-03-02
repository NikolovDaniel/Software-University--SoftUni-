function OldBooks(input) {

    let isFound = false;
    let desiredBook = input.shift();
    let currBook = input.shift();
    let count = 0;
    while (currBook != "No More Books") {

        if (currBook == desiredBook) {           
            console.log(`You checked ${count} books and found it.`);
            return;
        }

        count++;

        currBook = input.shift();
    }

    console.log("The book you search is not here!");
    console.log(`You checked ${count} books.`);
}

OldBooks((["The Spot",
"Hunger Games",
"Harry Potter",
"Torronto",
"Spotify",
"No More Books"]));

