function colorize() {
    const rows = Array.from(document.querySelectorAll('table tr:nth-child(even)'));

    for (let i = 0; i < rows.length; i++) {
        rows[i].style.background = 'teal';
    }
}