function solve(input) {

    console.log(input.sort((a, b) => a.localeCompare(b))
    .sort((a, b) => a.length - b.length)
    .join('\n'));
}

solve(['test', 
'Deny', 
'omen', 
'Default']
);