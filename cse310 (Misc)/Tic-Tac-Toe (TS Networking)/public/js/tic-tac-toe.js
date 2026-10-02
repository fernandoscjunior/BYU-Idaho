let boxes = [...document.querySelectorAll(".box")]
let newGameBtn = document.querySelector("#new-btn")
let msgContainer = document.querySelector(".msg-div")
let msg = document.querySelector("#msg")
let statusMsg = document.querySelector(".net-stat")
const socket = io()

// Adds event listener to all boxes (where player can click) and sends a socket
boxes.forEach((box) => {
  box.addEventListener("click", () => {
    let boxId = box.id
    socket.emit("boxClick", boxId)
  })
})

// Once gameOver is received by the server, calls showWinner
socket.on("gameOver", (Winner) => {
  showWinner(Winner)
})

// Once draw is received and all boxes were clicked, game ends as draw
socket.on("draw", () => {
  msgContainer.classList.remove("hide")
  msg.innerText = "Match Drawn"
})

// If server returns that the click was valid, change the box to show "O" or "X"
socket.on("validClick", (boxId, mark) => {
  let theBox = boxes[boxId - 1]
  theBox.innerHTML = mark
  console.log(theBox)
})

// Resets game when server asks to
socket.on("clearAll", () => {
  resetGame()
})

/* -------------------------
-----Auxiliar Functions-----
----------------------------*/

// When called shows what player won
const showWinner = (Winner) => {
  msg.innerText = `Winner is ${Winner}`
  msgContainer.classList.remove("hide")
  disableBoxes()
}

// When called makes so you cannot click on the boxes
const disableBoxes = () => {
  for (let box of boxes) {
    box.disabled = true
  }
}

// When called starts a fresh new game
const resetGame = () => {
  for (let box of boxes) {
    box.disabled = false
    box.innerText = ""
  }
  msgContainer.classList.add("hide")
}

// If user click on New Game after a game is over, sends a message to server that returns for every client to clean their boxes
newGameBtn.addEventListener("click", (e) => {
  resetGame()
  socket.emit("clear")
})
