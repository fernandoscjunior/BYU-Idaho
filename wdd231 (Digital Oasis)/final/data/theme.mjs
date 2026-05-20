//Save preferences with localStorage
export function applyTheme(theme) {
  document.body.className = theme;
  localStorage.setItem('theme', theme);
}

//Load preferences from localStorage
export function loadTheme() {
  const savedTheme = localStorage.getItem('theme') || 'light';
  applyTheme(savedTheme);
}

//Change between themes
export function toggleTheme() {
  const currentTheme = document.body.className;
  const newTheme = currentTheme === 'light' ? 'dark' : 'light';
  applyTheme(newTheme);
}