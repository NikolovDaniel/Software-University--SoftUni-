function subtract() {

    const firstNum = Number(document.getElementById("firstNumber").value);
    const secondNum = Number(document.getElementById("secondNumber").value);

    const resultText = document.getElementById("result");

    resultText.textContent = firstNum - secondNum;
}