// Open modal when link is clicked
  document.querySelectorAll('[data-dialog]').forEach(link => {
    link.addEventListener('click', e => {
      e.preventDefault();
      const dialogId = link.getAttribute('data-dialog');
      const dialog = document.getElementById(dialogId);
      if (dialog) dialog.showModal();
    });
  });

  // Close modal when close button is clicked
  document.querySelectorAll('.close-btn').forEach(btn => {
    btn.addEventListener('click', () => {
      const dialog = btn.closest('dialog');
      if (dialog) dialog.close();
    });
  });

  // Close modal on Escape key
  document.querySelectorAll('dialog').forEach(dialog => {
    dialog.addEventListener('keydown', e => {
      if (e.key === 'Escape') dialog.close();
    });
  });

// Populate hidden timestamp with ISO string when the page loads
//I made this a function to gurantee it doens't try to give value to timestamp before it exists
function populateTimestamp(){
  const time = new Date().toISOString();
  const timestamp = document.getElementById('timestamp')

  if (timestamp != null){
    timestamp.value = time;
  }
}

populateTimestamp();