//Getting parameters from URL
const params = new URLSearchParams(window.location.search);
const firstName = params.get('fullname');
const email = params.get('email');
const timestamp = params.get('timestamp');

//Entering info into HTML div
const div = document.querySelector('#form-data');
div.innerHTML = `
  <p><strong>First Name:</strong> ${firstName}</p>
  <p><strong>E-mail:</strong> ${email}</p>
  <p>${timestamp}</p>

`;