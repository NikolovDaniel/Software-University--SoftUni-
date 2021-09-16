function PrintMessage(input) {

    let text = input.shift();

    const arr = text.split(' ');

    if (arr.length > 10) {
        console.log(`The message is too long to be send! Has ${arr.length} words.`);
    } else {
        console.log("The message was sent successfully!")
    }
}

PrintMessage((["This message has exactly eleven words. One more as it's allowed!"]));