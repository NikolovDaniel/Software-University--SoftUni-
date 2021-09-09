function CalculateNeededHours(input) {

    let nameArchitect = input[0];
    let projectsCount = input[1];

    let hours = projectsCount * 3;

    console.log(`The architect ${nameArchitect} will need ${hours} hours to complete ${projectsCount} projects.`)
}

CalculateNeededHours((["George","4"]))