import {places} from '../data/places.mjs';

// Create cards looping through places json

const cards = document.querySelector('#cards');

const displayPlaces = (places) => {
    places.forEach((place) => {
        let card = document.createElement('section');
        let photo = document.createElement('img');
        let title = document.createElement('h2');
        let address = document.createElement('address');
        let description = document.createElement('p');
        let button = document.createElement('button');
        
        title.textContent = `${place.name}`;
        address.textContent = `${place.address}`;
        description.textContent = `${place.description}`;

        photo.setAttribute('src', '../chamber/images/'+place.photo_url);
        photo.setAttribute('alt', `${place.name} photo`);
        photo.setAttribute('loading', 'eager');
        //button.setAttribute('');
        button.innerHTML = "learn more";

        card.appendChild(photo);
        card.appendChild(title);
        card.appendChild(description);
        card.appendChild(address);
        card.appendChild(button);
        cards.appendChild(card);
    }); 
}

displayPlaces(places);

//Using localStorage to track user

const lastVisit = localStorage.getItem('visitDate');
const now = new Date();
const lastTime = document.getElementById('last-visit');

if (lastVisit) {
  const last = new Date(lastVisit);
  const diffMs = now - last;
  const diffDays = Math.floor(diffMs / (1000 * 60 * 60 * 24));
  if (diffDays < 1) {
    lastTime.innerText = "Back so soon! Awesome!";

  } else {
    lastTime.innerText = `Welcome back! It's been ${diffDays} day(s) since your last visit.`;
  }

} else {
  lastTime.innerText = 'Welcome! Let us know if you have any questions..';
}

const formattedDate = new Date();
localStorage.setItem('visitDate', formattedDate);