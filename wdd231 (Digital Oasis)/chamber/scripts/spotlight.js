const cards = document.querySelector('#spotlight');

async function getSpotlightData() {
    const response = await fetch('data/members.json');
    const data = await response.json();
    const filteredCompanies = filter(data.companies);
    const result = chooseThreeRandomly(filteredCompanies);
    displaySpotlight(result);
    
}

const displaySpotlight = (companies) => {
    companies.forEach((company) => {
        let card = document.createElement('section');
        let portrait = document.createElement('img');
        let adress = document.createElement('p');
        let phone = document.createElement('p');
        let url = document.createElement('a')

        adress.textContent = `${company.adress}`;
        phone.textContent = `${company.phoneNumber}`;
        url.textContent = `${company.url}`;
        url.setAttribute("href", company.url)
        portrait.setAttribute('src', company.image);
        portrait.setAttribute('alt', `${company.name} logo's`);
        portrait.setAttribute('loading', 'lazy');
        portrait.setAttribute('width', '340');
        portrait.setAttribute('height', '440');
        card.appendChild(portrait);
        card.appendChild(adress);
        card.appendChild(phone);
        card.appendChild(url);
        cards.appendChild(card);
    
    });
}

function filter(companies) {
    filteredCompanies = [];
    companies.forEach((company) => {
        if (company.membership < 2){
        
        } else {
            filteredCompanies.push(company);
        }
    });
    return filteredCompanies;
}

function chooseThreeRandomly(filteredCompanies) {
  const chosen = [];
  while (chosen.length < 3) {
    const item = Math.floor(Math.random() * filteredCompanies.length);
    if (!chosen.includes(item)) {
      chosen.push(item);
    }
  }
  const chosenItems = chosen.map(i => filteredCompanies[i]);
  return chosenItems;
}

getSpotlightData();