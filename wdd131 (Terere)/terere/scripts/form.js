// Listen for form submission
document.getElementById('myForm').addEventListener('submit', function(e) {
  e.preventDefault();

  // Retrieve existing submissions from localStorage, or initialize an empty array
  let submissions = JSON.parse(localStorage.getItem('submissions')) || [];

  // Extract form data:
  const response = document.querySelector('input[name="response"]:checked').value;
  const name = document.getElementById('name').value;
  const comment = document.getElementById('comment').value;
  // Create a new object with the submitted values and include a timestamp.
  const submission = {
    response,
    name,
    comment,
    time: new Date().toLocaleString()
  };

  // Add the new object to the array
  submissions.push(submission);

  // Save the updated array back to localStorage
  localStorage.setItem('submissions', JSON.stringify(submissions));

  // Render the updated submissions in the page
  displaySubmissions(submissions);

});
// Function to display submissions using template literals and array.map()
function displaySubmissions(submissions) {
  const submissionsDiv = document.getElementById('submissionsDisplay');
  submissionsDiv.innerHTML = submissions.map((sub, index) => {
    return `
      <div style="border: 1px solid #999; padding: 10px; margin-bottom: 10px;">
        <h3>Submission ${index + 1}</h3>
        <p><strong>Response:</strong> ${sub.response}</p>
        <p><strong>Name:</strong> ${sub.name}</p>
        <p><strong>Comment:</strong> ${sub.comment}</p>
        <p><em>Submitted at: ${sub.time}</em></p>
      </div>`;
  }).join('');
}
// When the page loads, display any submissions already saved locally.
window.addEventListener('load', () => {
  const savedSubmissions = JSON.parse(localStorage.getItem('submissions'));
  if (savedSubmissions && savedSubmissions.length > 0) {
    displaySubmissions(savedSubmissions);
  }
});
