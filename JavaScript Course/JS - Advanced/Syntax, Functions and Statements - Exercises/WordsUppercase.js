function wordsUppercase(text) {

    let result = text.toUpperCase()
      .split(/[\W]+/)
      .filter(w => w.length > 0)
      .join(", ");
  
    console.log(result);
  }
  

wordsUppercase('Functions in JS can be nested, i.e. hold other functions');
wordsUppercase('Hi, how are you?');