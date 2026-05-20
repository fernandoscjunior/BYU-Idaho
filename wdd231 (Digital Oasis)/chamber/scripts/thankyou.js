//Getting parameters from URL
const params = new URLSearchParams(window.location.search);
const firstName = params.get('firstName');
const lastName = params.get('lastName');
const organizationName = params.get('organizationName');
const email = params.get('email');
const phone = params.get('phone');
const timestamp = params.get('timestamp');

//Entering info into HTML div
const div = document.querySelector('#form-data');
div.innerHTML = `
  <p><strong>First Name:</strong> ${firstName}</p>
  <p><strong>Last Name:</strong> ${lastName}</p>
  <p><strong>Organization Name:</strong> ${organizationName}</p>
  <p><strong>E-mail:</strong> ${email}</p>
  <p><strong>Phone:</strong> ${phone}</p>
  <p>${timestamp}</p>

`;
