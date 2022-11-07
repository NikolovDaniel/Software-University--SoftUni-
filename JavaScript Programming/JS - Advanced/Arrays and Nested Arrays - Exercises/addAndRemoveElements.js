function solve(arrSteps) {

    const result = [];
    let counter = 1;

    arrSteps.forEach(x => {
        if (x == 'add') {
            result.push(counter);
        } else {
            result.pop();
        }
        counter++;
    })

    if (result.length == 0) {
        console.log('Empty');
    } else {
        console.log(result.join('\n'));
    }
}

solve(['add', 'add', 'add', 'add']);
solve(['add', 'add', 'remove', 'add', 'add']);
solve(['remove']);