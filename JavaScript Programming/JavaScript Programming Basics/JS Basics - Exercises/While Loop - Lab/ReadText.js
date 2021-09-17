function ReadWords(input) {

    let word = input.shift();

    while (word != "Stop") {
        console.log(word);
        word = input.shift();
    }
}


ReadWords((["Nakov",
"SoftUni",
"Sofia",
"Bulgaria",
"SomeText",
"Stop",
"AfterStop",
"Europe",
"HelloWorld"])
);
