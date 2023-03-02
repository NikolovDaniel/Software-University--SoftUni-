function solve(car) {

    const result = {
        model: null,
        engine: { power: null, volume: null },
        carriage: { type: null, color: null },
        wheels: null
    };

    const carObjects = Object.entries(car);

    const modelName = carObjects[0][1];

    result.model = modelName;

    for (let i = 0; i < carObjects.length; i++) {
        let component = carObjects[i][0];
        let componentName = carObjects[i][1];

        if (component == 'power') {

            result.engine.power = Number(componentName)
            let enginePower = 0;

            if (result.engine.power <= 90) {
                enginePower = 90;
                result.engine.volume = 1800;
            } else if (result.engine.power <= 120) {
                enginePower = 120;
                result.engine.volume = 2400;
            } else {
                enginePower = 200;
                result.engine.volume = 3500;
            }

            result.engine.power = enginePower;

        } else if (component == 'color') {
            result.carriage.color = componentName;
        } else if (component == 'carriage') {
            result.carriage.type = componentName;
        } else if (component == 'wheelsize') {

            let size = Number(componentName);
            if (size % 2 == 0) {
                size -= 1;
            }

            let wheels = [0, 0, 0, 0];

            result.wheels = wheels.fill(size, 0, 4);
        }
    }

    return result;
}

console.log(solve({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14
}));

console.log(solve({
    model: 'Opel Vectra',
    power: 110,
    color: 'grey',
    carriage: 'coupe',
    wheelsize: 17
}));