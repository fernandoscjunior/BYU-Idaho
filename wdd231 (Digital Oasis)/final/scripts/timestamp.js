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