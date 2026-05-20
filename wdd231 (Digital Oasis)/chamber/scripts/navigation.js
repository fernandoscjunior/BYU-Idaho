//Getting hamburger button on header
const navButton = document.querySelector('#ham-btn');

//Adding event listener on hambuger button
navButton.addEventListener('click', () => {
    navButton.classList.toggle('show');
    navBar.classList.toggle('show');
});

//getting navigation menu
const navBar = document.querySelector('#nav-bar');


document.addEventListener("DOMContentLoaded", () => {
  const links = document.querySelectorAll("#list-nav a");
  // Obtém o nome da página atual (sem extensão)
  const currentPage = window.location.pathname.split("/").pop().split(".")[0];
    
  links.forEach(link => {
    const page = link.getAttribute("data-page");
    if (page === currentPage) {
      link.classList.add("active");
    }
  });
});