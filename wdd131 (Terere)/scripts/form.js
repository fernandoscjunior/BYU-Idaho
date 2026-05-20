//Getting datetime for footer
const currentYear = document.querySelector("#currentyear");
const today = new Date();
currentYear.innerHTML = `<span class="highlight">${today.getFullYear()}</span>`;
document.getElementById("lastModified").textContent = document.lastModified;

//Dynamically adding products
document.addEventListener('DOMContentLoaded', function() {
    const products = [
  {
    id: "fc-1888",
    name: "flux capacitor",
    averagerating: 4.5
  },
  {
    id: "fc-2050",
    name: "power laces",
    averagerating: 4.7
  },
  {
    id: "fs-1987",
    name: "time circuits",
    averagerating: 3.5
  },
  {
    id: "ac-2000",
    name: "low voltage reactor",
    averagerating: 3.9
  },
  {
    id: "jj-1969",
    name: "warp equalizer",
    averagerating: 5.0
  }
];

const productSelect = document.getElementById('product-name');
  products.forEach(product => {
    const option = document.createElement('option');
    option.value = product.name;
    option.textContent = product.name;
    productSelect.appendChild(option);
    });
});

 document.addEventListener('DOMContentLoaded', function() {
      // Retrieve the current counter from localStorage or initialize it at 0
      let reviewCounter = localStorage.getItem('reviewCounter');
      if (!reviewCounter) {
        reviewCounter = 0;
      } else {
        reviewCounter = parseInt(reviewCounter, 10);
      }

      // Increase the counter by one for this completed review
      reviewCounter++;
      localStorage.setItem('reviewCounter', reviewCounter);

      // Display the updated counter on the page
      const counterDisplay = document.getElementById('review-counter');
      counterDisplay.textContent = "Number of reviews submitted: " + reviewCounter;
    });