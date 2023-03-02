function solve(heroes) {

    const characters = [];

    for (let i = 0; i < heroes.length; i++) {
        let characterDetails = heroes[i].split(' / ');

        let name = characterDetails[0];
        let level = Number(characterDetails[1]);
        let items = [];

        if (characterDetails[2] != undefined) {
            items = characterDetails[2].split(', ');
        }

        let character = {
            name: name,
            level: level,
            items: items
        }

        characters.push(character);
    }

    console.log(JSON.stringify(characters));
}

solve(['Isacc / 25 ',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);