import express, { type Express } from "express"
import { Server } from "socket.io"
import http from "http"
import { turn, clearAll, checkWinner } from "./rules.js"

const app: Express = express()
const server = http.createServer(app)
const io = new Server(server)

app.use(express.static("public"))

// Here is where the commuincation happens between server and client through socket
io.on("connection", (socket) => {
  console.log(`A user connected, ID: ${socket.id}`)
  clearAll()

  // When receives a click from a client, valids it and checks for a possible victory
  socket.on("boxClick", (boxId) => {
    console.log(`box clicked, ID:${boxId}`)
    let result: number = turn(boxId)
    if (result == 1) {
      io.emit("validClick", boxId, "O")
    } else if (result == 2) {
      io.emit("validClick", boxId, "X")
    } else {
      console.log(`Invalid move from ${socket.id}`)
    }

    let result2: number = checkWinner()
    if (result2 === 2) {
      io.emit("gameOver", "O")
    } else if (result2 === 1) {
      io.emit("gameOver", "X")
    } else if (result2 === 0) {
      io.emit("draw")
    }
  })

  // Requests that all clients clean themselves
  socket.on("clear", () => {
    io.emit("clearAll")
    clearAll()
  })

  // When someone disconnects shows a log
  socket.on("disconnect", () => {
    console.log("A user disconnected")
  })
})

const PORT = process.env.PORT || 1472
server.listen(PORT, () => {
  console.log(`Server running on port ${PORT}`)
})
