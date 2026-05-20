const currentTemp = document.querySelector('#current-temp');
const weatherIcon = document.querySelector('#weather-icon');
const captionDesc = document.querySelector('figcaption');
const forecast = document.querySelector('#forecast');
const forecast2 = document.querySelector('#forecast2');
const forecast3 = document.querySelector('#forecast3');
const weatherIcon1 = document.querySelector('#weather-icon1');
const weatherIcon2 = document.querySelector('#weather-icon2');
const weatherIcon3 = document.querySelector('#weather-icon3');

const url = 'https://api.openweathermap.org/data/2.5/weather?lat=-27.596803269853925&lon=-48.546556446437464&appid=6d6a389f142aae34730ed2a7c959a9c7&units=metric';

const urlDays = 'https://api.openweathermap.org/data/2.5/forecast?lat=-27.596803269853925&lon=-48.546556446437464&appid=6d6a389f142aae34730ed2a7c959a9c7&units=metric';

async function apiFetch() {
    try {
        const response = await fetch(url);
        if (response.ok) {
            const data = await response.json();
            console.log(data);
            displayResults(data);
        } else {
            throw Error(await response.text());
        }
    } catch (error) {
        console.log(error);
    }
}

async function apiFetchDays() {
    try {
        const response = await fetch(urlDays);
        if (response.ok) {
            const data = await response.json();
            console.log(data);
            displayForecast(data);

        } else {
            throw Error(await response.text());
        }
    } catch (error) {
        console.log(error);
    }
}

function displayResults(data) {
    currentTemp.innerHTML = `${data.main.temp}&deg;C`;
    const iconsrc = `https://openweathermap.org/img/wn/${data.weather[0].icon}@2x.png`;
    let desc = data.weather[0].description;
    weatherIcon.setAttribute('src', iconsrc );
    weatherIcon.setAttribute('alt', desc);
    captionDesc.innerHTML = desc;
}

function displayForecast(data) {
    forecast.innerHTML = `${data.list[6].main.temp}&deg;C`;
    forecast2.innerHTML = `${data.list[14].main.temp}&deg;C`;
    forecast3.innerHTML = `${data.list[22].main.temp}&deg;C`;

    const iconsrc1 = `https://openweathermap.org/img/wn/${data.list[6].weather[0].icon}.png`;
    let desc1 = data.list[6].weather[0].description;
    weatherIcon1.setAttribute('src', iconsrc1 );
    weatherIcon1.setAttribute('alt', desc1);

    const iconsrc2 = `https://openweathermap.org/img/wn/${data.list[14].weather[0].icon}.png`;
    let desc2 = data.list[14].weather[0].description;
    weatherIcon2.setAttribute('src', iconsrc2 );
    weatherIcon2.setAttribute('alt', desc2);
    
    const iconsrc3 = `https://openweathermap.org/img/wn/${data.list[22].weather[0].icon}.png`;
    let desc3 = data.list[22].weather[0].description;
    weatherIcon3.setAttribute('src', iconsrc3 );
    weatherIcon3.setAttribute('alt', desc3);
}

//Getting dynamically the next three days dates
const day1 = document.querySelector('#tomorrow');
const day2 = document.querySelector('#after-tomorrow');
const day3 = document.querySelector('#after-after-tomorrow');

const today2 = new Date();

const tomorrow = new Date(today);
tomorrow.setDate(today2.getDate() + 1);

const afterTomorrow = new Date(tomorrow);
afterTomorrow.setDate(tomorrow.getDate() + 1);

const afterAfterTomorrow = new Date(afterTomorrow);
afterAfterTomorrow.setDate(afterAfterTomorrow.getDate() + 1);

function setDays(tomorrow, afterTomorrow, afterAfterTomorrow) {
    day1.innerHTML = tomorrow.getMonth() + "/" + tomorrow.getDate();
    day2.innerHTML = afterTomorrow.getMonth() + "/" + afterTomorrow.getDate();
    day3.innerHTML = afterAfterTomorrow.getMonth() + "/" + afterAfterTomorrow.getDate();
    
}

apiFetch();
apiFetchDays();
setDays(tomorrow, afterTomorrow, afterAfterTomorrow);