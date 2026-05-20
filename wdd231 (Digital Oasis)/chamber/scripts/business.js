const cards = document.querySelector('#cards');

async function getBusinessData() {
    const response = await fetch('data/members.json');
    const data = await response.json();
    displayBusiness(data.companies);
    
}

const displayBusiness = (companies) => {
    companies.forEach((company) => {
        let card = document.createElement('section');
        let portrait = document.createElement('img');
        let adress = document.createElement('p');
        let phone = document.createElement('p');
        let url = document.createElement('a');
        
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

getBusinessData();