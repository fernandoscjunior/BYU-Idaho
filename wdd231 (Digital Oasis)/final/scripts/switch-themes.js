import { loadTheme, toggleTheme } from '../data/theme.mjs';

loadTheme(); // Apply saved theme on page load

//Logic to change icon when clicked
const themeIcon = document.getElementById('theme-button');
let isDarkMode = false;

// Switch theme on button click
document.getElementById('toggle-theme').addEventListener('click', () => {
  isDarkMode = !isDarkMode;
  toggleTheme();
  themeIcon.src = isDarkMode ? 'images/dark-mode.svg' : 'images/light-mode.svg';
});