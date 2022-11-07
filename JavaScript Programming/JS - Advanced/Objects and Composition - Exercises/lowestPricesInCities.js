function solve(products) {

    const result = [];

    for (const info of products) {
        let details = info.split(' | ');

        let town = details[0];
        let product = details[1];
        let price = Number(details[2]);

        if (result[product] != undefined) {
            if (result[product].price > price) {
                result[product].price = price;
                result[product].town = town;
            }
        } else {
            result[product] = { price: price, town: town };
        }
    }

    for (const product in result) {
        console.log(product); 
        console.log(`${product} -> ${product.price} (${product.town})`);
    }
}

solve([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);