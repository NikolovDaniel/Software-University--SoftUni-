async function attachEvents() {

    const symbols = {
        "Sunny": '&#x2600',
        "Partly sunny": '&#x26C5',
        "Overcast": '&#x2601',
        "Rain": '&#x2614'
    };

    const input = document.getElementById('location').value;
    const divForecast = document.getElementById('current');
    const divUpcoming = document.getElementById('upcoming');

    try {

        document.querySelector('#current .label').textContent = 'Loading...';

        const locations = await getLocations();

        const currLocation = locations.find(x => x.name == input);

        if (currLocation == undefined) {
            throw new Error();
        }

        document.querySelector('#current .label').textContent = 'Current conditions';

        displayTodayConditions();
        displayForecast();

        async function displayForecast() {

            const forecast = await getForecast(currLocation.code);
            const divElement = document.createElement('div');

            if (document.querySelector('#upcoming .forecast-info') != undefined) {
                document.querySelector('#upcoming .forecast-info').remove();
            }


            divElement.innerHTML = `<div class="forecast-info"> 
                ${forecast.forecast.map(x => {
                return `<span class="upcoming">
                   <span class="symbol">${symbols[x.condition]}</span>
                   <span class="forecast-data">${x.low}${'&#176'}/${x.high}${'&#176'}</span>
                   <span class="forecast-data">${x.condition}</span>
                </span>`;
            }).join(' ')} 
                </div> `;

            document.querySelector('#upcoming').style.display = 'block';
            divUpcoming.appendChild(divElement);
        }

        async function displayTodayConditions() {
            const todayConditions = await getCurrentConditions(currLocation.code);
            const divElement = document.createElement('div');

            if (document.querySelector('#current .forecasts') != undefined) {
                document.querySelector('#current .forecasts').remove();
            }

            divElement.innerHTML = `
            <div class="forecasts">
            <span class="condition symbol">${symbols[todayConditions.forecast.condition]}</span>
            <span class="condition">
        <span class="forecast-data">${todayConditions.name}</span>
        <span class="forecast-data">${todayConditions.forecast.low}${'&#176'}/${todayConditions.forecast.high}${'&#176'}</span>
        <span class="forecast-data">${todayConditions.forecast.condition}</span>
            </span>
            </div>
            `;

            divForecast.appendChild(divElement);
            document.getElementById('forecast').style.display = 'block';
        }

    } catch (error) {
        document.querySelector('#current .label').textContent = 'Error';
        document.querySelector('#current .forecasts').remove();
        document.querySelector('#upcoming .forecast-info').remove();
        document.querySelector('#upcoming').style.display = 'none';
    }
}

async function getLocations() {
    const url = 'http://localhost:3030/jsonstore/forecaster/locations';

    const response = await fetch(url);

    if (response.status != 200) {
        throw new Error();
    }

    return await response.json();
}

async function getCurrentConditions(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/today/' + code;

    const response = await fetch(url);

    if (response.status != 200) {
        throw new Error();
    }

    return await response.json();
}

async function getForecast(code) {
    const url = 'http://localhost:3030/jsonstore/forecaster/upcoming/' + code;

    const response = await fetch(url);

    if (response.status != 200) {
        throw new Error();
    }

    return await response.json();
}
