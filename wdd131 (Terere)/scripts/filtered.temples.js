//getting date and last modified for footer
const currentYear = document.querySelector("#currentyear");
const today = new Date();
currentYear.innerHTML = `<span class="highlight">${today.getFullYear()}</span>`;
document.getElementById("lastModified").textContent = document.lastModified;

//making hamburguer menu
const mainnav = document.querySelector('.navigation')
const hambutton = document.querySelector('#menu');

hambutton.addEventListener('click', () => {
    mainnav.classList.toggle('show');
    hambutton.classList.toggle('show');
});


const temples = [
  {
    templeName: "Aba Nigeria",
    location: "Aba, Nigeria",
    dedicated: "2005, August, 7",
    dedicatedYear: 2005,
    area: 11500,
    imageUrl:
    "https://content.churchofjesuschrist.org/templesldsorg/bc/Temples/photo-galleries/aba-nigeria/400x250/aba-nigeria-temple-lds-273999-wallpaper.jpg"
  },
  {
    templeName: "Manti Utah",
    location: "Manti, Utah, United States",
    dedicated: "1888, May, 21",
    dedicatedYear: 1888,
    area: 74792,
    imageUrl:
    "https://content.churchofjesuschrist.org/templesldsorg/bc/Temples/photo-galleries/manti-utah/400x250/manti-temple-768192-wallpaper.jpg"
  },
  {
    templeName: "Payson Utah",
    location: "Payson, Utah, United States",
    dedicated: "2015, June, 7",
    dedicatedYear: 2015,
    area: 96630,
    imageUrl:
    "https://content.churchofjesuschrist.org/templesldsorg/bc/Temples/photo-galleries/payson-utah/400x225/payson-utah-temple-exterior-1416671-wallpaper.jpg"
  },
  {
    templeName: "Yigo Guam",
    location: "Yigo, Guam",
    dedicated: "2020, May, 2",
    dedicatedYear: 2020,
    area: 6861,
    imageUrl:
    "https://content.churchofjesuschrist.org/templesldsorg/bc/Temples/photo-galleries/yigo-guam/400x250/yigo_guam_temple_2.jpg"
  },
  {
    templeName: "Washington D.C.",
    location: "Kensington, Maryland, United States",
    dedicated: "1974, November, 19",
    dedicatedYear: 1974,
    area: 156558,
    imageUrl:
    "https://content.churchofjesuschrist.org/templesldsorg/bc/Temples/photo-galleries/washington-dc/400x250/washington_dc_temple-exterior-2.jpeg"
  },
  {
    templeName: "Lima Perú",
    location: "Lima, Perú",
    dedicated: "1986, January, 10",
    dedicatedYear: 1986,
    area: 9600,
    imageUrl:
    "https://content.churchofjesuschrist.org/templesldsorg/bc/Temples/photo-galleries/lima-peru/400x250/lima-peru-temple-evening-1075606-wallpaper.jpg"
  },
  {
    templeName: "Mexico City Mexico",
    location: "Mexico City, Mexico",
    dedicated: "1983, December, 2",
    dedicatedYear: 1983,
    area: 116642,
    imageUrl:
    "https://content.churchofjesuschrist.org/templesldsorg/bc/Temples/photo-galleries/mexico-city-mexico/400x250/mexico-city-temple-exterior-1518361-wallpaper.jpg"
  },
  {
    templeName: "São Paulo Brazil",
    location: "São Paulo, Brazil",
    dedicated: "1978, November, 2",
    dedicatedYear: 1978,
    area: 59246,
    imageUrl:
    "https://churchofjesuschristtemples.org/assets/img/temples/_temp/017-S%C3%A3o-Paulo-Brazil-Temple.jpg"
  },
  {
   templeName: "Curitiba Brazil",
   location: "Curitiba, Brazil",
   dedicated: "2008, June, 1",
   dedicatedYear: 2008,
   area: 27850,
   imageUrl:
   "https://churchofjesuschristtemples.org/assets/img/temples/curitiba-brazil-temple/curitiba-brazil-temple-13592.jpg"
  },
  {
    templeName: "Bountiful Utah",
    location: "Utah, USA",
    dedicated: "1995, January, 14",
    dedicatedYear: 1995,
    area: 104000,
    imageUrl:
    "https://churchofjesuschristtemples.org/assets/img/temples/bountiful-utah-temple/bountiful-utah-temple-58567.jpg"
  }
];

function createCards(filteredTemples) {
  cleanScreen();
    const container = document.getElementById("card-container");
    filteredTemples.forEach(item => {
        const card = document.createElement("div");
        card.className = "card";

        const title = document.createElement("h1");
        title.textContent = item.templeName;

        const image = document.createElement("img");
        image.className = "lazy";
        image.dataset.src = item.imageUrl;
        image.alt = item.templeName;

        const dedicated = document.createElement("p");
        dedicated.textContent = "Dedicated: " + item.dedicated;

        const location = document.createElement("p");
        location.textContent = "Location: " + item.location;

        const area = document.createElement("p");
        area.textContent = "Area: " + item.area;

        card.appendChild(title);
        card.appendChild(location);
        card.appendChild(dedicated);
        card.appendChild(area);
        card.appendChild(image);
        container.appendChild(card);
    });

    // Lazy loading configuration using Intersection Observer
    const lazyImages = document.querySelectorAll(".lazy");
    const observer = new IntersectionObserver(entries => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const img = entry.target;
                img.src = img.dataset.src;
                img.classList.remove("lazy");
                observer.unobserve(img);
            }
        });
    });

    lazyImages.forEach(img => observer.observe(img));
}

createCards(temples);

const all = document.querySelector("#all");
const old = document.querySelector("#old");
const newTemple = document.querySelector("#new");
const large = document.querySelector("#large");
const small = document.querySelector("#small");

all.addEventListener("click", () =>{
    createCards(temples)
});

old.addEventListener("click", () => {
    createCards(temples.filter(temple => temple.dedicatedYear < 1900));
});

newTemple.addEventListener("click", () => {
    createCards(temples.filter(temple => temple.dedicatedYear > 2000));
});

large.addEventListener("click", () => {
    createCards(temples.filter(temple => temple.area > 90000)); 
});

small.addEventListener("click", () => {
    createCards(temples.filter(temple => temple.area < 10000));
});

function cleanScreen() {
    const main = document.getElementById('card-container'); // Certifique-se de ter um ID correto
    main.innerHTML = ''; // Limpa o conteúdo antes de adicionar os novos itens

}
