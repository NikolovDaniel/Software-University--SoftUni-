function solve(worker) {

    const result = worker;

    if (result.dizziness) {

        result.dizziness = false;

        let mlWater = 0.1 * result.weight * result.experience;
        result.levelOfHydrated += mlWater;

    }

    return result;
}

console.log(solve(
    {
        weight: 120,
        experience: 20,
        levelOfHydrated: 200,
        dizziness: true
    }));

console.log(solve(
    {
        weight: 95,
        experience: 3,
        levelOfHydrated: 0,
        dizziness: false
    }));