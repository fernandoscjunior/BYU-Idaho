//Get the current year and last modified date
const currentYear = document.querySelector("#currentyear");
const today = new Date();
currentYear.innerHTML = `<span class="highlight">${today.getFullYear()}</span>`;
document.getElementById("lastModified").textContent = document.lastModified;

// Function to calculate wind chill based on temperature, wind speed, and unit
function calculateWindChill(temp, speed, unit) {
    return (unit === "C") 
        ? (13.12 + 0.6215 * temp - 11.37 * Math.pow(speed, 0.16) + 0.3965 * temp * Math.pow(speed, 0.16)).toFixed(2)
        : (35.74 + 0.6215 * temp - 35.75 * Math.pow(speed, 0.16) + 0.4275 * temp * Math.pow(speed, 0.16)).toFixed(2);
}

function getWindChill(temp, speed, unit) {
    const tempThreshold = (unit === "C") ? 10 : 50;
    const speedThreshold = (unit === "C") ? 4.8 : 3;

    return (temp <= tempThreshold && speed > speedThreshold) 
        ? calculateWindChill(temp, speed, unit) 
        : "N/A";
}

document.addEventListener("DOMContentLoaded", function () {
    const temperature = 5; 
    const windSpeed = 10; 
    const unit = "C";       

    document.getElementById("windChill").textContent = `Wind Chill: ${getWindChill(temperature, windSpeed, unit)}°${unit}`;
});
