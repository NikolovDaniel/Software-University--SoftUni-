function sumTable() {
    const rows = document.querySelectorAll('table tbody tr');
    let sum = 0;

    for (let i = 1; i < rows.length - 1; i++) {
        sum += Number(rows[i].children[1].textContent);
    }

   const sumElement = document.getElementById('sum');
   sumElement.textContent = sum;
}