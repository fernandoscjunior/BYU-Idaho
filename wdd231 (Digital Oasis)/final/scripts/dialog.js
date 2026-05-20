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
document.querySelectorAll('.close-button').forEach(btn => {
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


//Giving functionallity to continue button on modal
document.getElementById('continue-button').addEventListener('click', () => {
    window.location.href = "attribuitions.html";
})