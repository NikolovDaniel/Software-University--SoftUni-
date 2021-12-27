function roadRadar(speed, area) {

    let status = '';

    switch (area) {

        case 'motorway':
            if (speed <= 130) {
                return `Driving ${speed} km/h in a 130 zone`;
            }
            else {
                if (speed - 130 <= 20) status = 'speeding';
                else if (speed - 130 > 20 && speed - 130 <= 40) status = 'excessive speeding';
                else status = 'reckless driving';

                return `The speed is ${speed - 130} km/h faster than the allowed speed of 130 - ${status}`;
            }

        case 'interstate':
            if (speed <= 90) {
                return `Driving ${speed} km/h in a 90 zone`;
            }
            else {
                if (speed - 90 <= 20) status = 'speeding';
                else if (speed - 90 > 20 && speed - 90 <= 40) status = 'excessive speeding';
                else status = 'reckless driving';

                return `The speed is ${speed - 90} km/h faster than the allowed speed of 90 - ${status}`;
            }

        case 'city':
            if (speed <= 50) {
                return `Driving ${speed} km/h in a 50 zone`;
            }
            else {
                if (speed - 50 <= 20) status = 'speeding';
                else if (speed - 50 > 20 && speed - 50 <= 40) status = 'excessive speeding';
                else status = 'reckless driving';

                return `The speed is ${speed - 50} km/h faster than the allowed speed of 50 - ${status}`;
            }

        case 'residential':
            if (speed <= 20) {
                return `Driving ${speed} km/h in a 20 zone`;
            }
            else {
                if (speed - 20 <= 20) status = 'speeding';
                else if (speed - 20 > 20 && speed - 20 <= 40) status = 'excessive speeding';
                else status = 'reckless driving';

                return `The speed is ${speed - 20} km/h faster than the allowed speed of 20 - ${status}`;
            }
    }
}

console.log(roadRadar(40, 'city'));
console.log(roadRadar(21, 'residential'));
console.log(roadRadar(120, 'interstate'));
console.log(roadRadar(200, 'motorway'));
