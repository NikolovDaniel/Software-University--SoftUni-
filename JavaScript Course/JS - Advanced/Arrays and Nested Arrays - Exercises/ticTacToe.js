function solve(moves) {

    const matrix = [
        ['false', 'false', 'false'],
        ['false', 'false', 'false'],
        ['false', 'false', 'false']
    ];

    let counter = 0;

    function noMoreSpaces(board) {

        for (let i = 0; i < board.length; i++) {
            for (let j = 0; j < board[i].length; j++) {
                if (board[i][j] == 'false') return false;
            }
        }

        return true;
    }

    while (moves.length > 0) {

        if (counter % 2 == 0) {
            let rowCol = moves.shift().split(' ');

            let row = Number(rowCol[0]);
            let col = Number(rowCol[1]);

            if (matrix[row][col] == 'O' || matrix[row][col] == 'X') {
                console.log('This place is already taken. Please choose another!');

                while (true) {
                    rowCol = moves.shift().split(' ');
                    row = Number(rowCol[0]);
                    col = Number(rowCol[1]);

                    if (matrix[row][col] != 'X' || matrix[row][col] != 'O') {
                        matrix[row][col] = 'X';
                        break;
                    }

                    console.log('This place is already taken. Please choose another!');
                }
            } else {
                matrix[row][col] = 'X';
            }
        } else {
            let rowCol = moves.shift().split(' ');

            let row = Number(rowCol[0]);
            let col = Number(rowCol[1]);

            if (matrix[row][col] == 'O' || matrix[row][col] == 'X') {
                console.log('This place is already taken. Please choose another!');

                while (true) {
                    rowCol = moves.shift().split(' ');
                    row = Number(rowCol[0]);
                    col = Number(rowCol[1]);

                    if (matrix[row][col] != 'X' || matrix[row][col] != 'O') {
                        matrix[row][col] = 'O';
                        break;
                    }

                    console.log('This place is already taken. Please choose another!');
                }
            } else {
                matrix[row][col] = 'O';
            }
        }

        let winnerX = false;
        let winnerO = false;

        for (let a = 0; a < matrix.length; a++) {
            let first = matrix[a][0];
            let second = matrix[a][1];
            let third = matrix[a][2];

            if (first == 'X' && second == 'X' && third == 'X') winnerX = true;
            if (first == 'O' && second == 'O' && third == 'O') winnerO = true;
        }

        for (let a = 0; a < matrix.length; a++) {

            let first = matrix[0][a];
            let second = matrix[1][a];
            let third = matrix[2][a];

            if (first == 'X' && second == 'X' && third == 'X') winnerX = true;
            if (first == 'O' && second == 'O' && third == 'O') winnerO = true;

        }

        let firstLeft = matrix[0][0];
        let secondLeft = matrix[1][1];
        let thirdLeft = matrix[2][2];
        let firstRight = matrix[0][2];
        let secondRight = matrix[1][1];
        let thirdRight = matrix[2][0];

        if (firstLeft == 'X' && secondLeft == 'X' && thirdLeft == 'X') winnerX = true;
        if (firstLeft == 'O' && secondLeft == 'O' && thirdLeft == 'O') winnerO = true;
        if (firstRight == 'X' && secondRight == 'X' && thirdRight == 'X') winnerX = true;
        if (firstRight == 'O' && secondRight == 'O' && thirdRight == 'O') winnerO = true;

        if (winnerX || winnerO) {
            console.log(`Player ${winnerX ? 'X' : 'O'} wins!`);

            for (let row of matrix) {
                console.log(row.join('\t'));
            }

            return;
        }

        if (noMoreSpaces(matrix)) {
            break;
        }

        counter++;
    }

    console.log('The game ended! Nobody wins :(');

    for (let row of matrix) {
        console.log(row.join('\t'));
    }
}

solve([
    "0 0",
    "0 0",
    "1 0",
    "1 0",
    "2 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
);

// solve([
//     "0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 1",
//     "1 2",
//     "2 2",
//     "2 1",
//     "0 0"]
// );

// solve([
//     "0 0",
//     "0 0",
//     "1 1",
//     "0 1",
//     "1 2",
//     "0 2",
//     "2 2",
//     "1 2",
//     "2 2",
//     "2 1"
// ]);

// solve([
//     "0 1",
//     "0 0",
//     "0 2",
//     "2 0",
//     "1 0",
//     "1 2",
//     "1 1",
//     "2 1",
//     "2 2",
//     "0 0"
// ]);

