function solve() {

  function setCharAt(str, index, chr) {
    if (index > str.length - 1) return str;
    return str.substring(0, index) + chr + str.substring(index + 1);
  }

  const text = document.getElementById("text").value;
  const parser = document.getElementById("naming-convention").value;
  const wordsToParse = text.split();



}