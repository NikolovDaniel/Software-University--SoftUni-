function solve(name, population, treasury) {

    const result = {
        name: name,
        population: population,
        treasury: treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += Math.floor(this.population * this.taxRate);
        },
        applyGrowth(percentage) {
            this.population += Math.floor(this.population * (percentage / 100));
        },
        applyRecession(percentage) {
            this.population -= Math.ceil(this.population * (percentage / 100));
        }
    };

    return result;
}

const city = 
  solve('Tortuga',
  7000,
  15000);
console.log(city);
