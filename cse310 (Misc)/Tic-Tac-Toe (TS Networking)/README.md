# Overview

This is a Tic Tac-Toe game that runs on a local server. The communication between client and server is made though sockets. The game is playable on one computer as well by two people in two different computers connected to the same network.  

## How to run the program

### Running the Server

The program has two main parts, the client and the server. To set the server running you need to have **Node.js** installed and run `npm i` to install all *node_modules* necessary (as seen in package.json). In the *src* folder there is a TypeScript file called *server.ts*, this is the file responsible for setting the server that will manage all clients. To set it running, run `node server.ts` (Make sure you are in the right directory!) if done correct the terminal will show a message like this: `Server running on port 1472` this pc now is the server.  

### Connecting to the Client

To connect another computer, it must be on te same network as the server. You must find what is the server pc's IP, on Windows open CMD or Powershell and run `ipconfig`, you will see a line like `IPv4...` the number that follows is your key to the game, it will probably be something in this format *192.168.x.x*, no go to a web browser and type the IP number followed by the port, something like this: `192.168.x.x:1472`. (If you are on the same computer where the server is running you can just use localhost:1472 instead)

#### Purpose of This Program

I love game development, and handcrafted software (Not AI generated). My purpose for writing this was so I could learn more about networking in general as well as improve my TypeScript skills, so I can develop my own projects in the future.

## Network Communication

As described earlier I used Client/Server communication, mainly because I wanted to use TypeScript/JavaScript and run my program on a Web Browser so I could easily make the visual aspect of the application with HTML and CSS, however I learned that Web Browsers, for security reasons, do not have access to low-level network functions from the OS. So I could not connect to PCs directly, instead I would have to have a simple server running. Sockets use TCP instead of UDP

Relevant messages beeing exchanged between client and server can be seen in logs on the terminal where the server is running. Messages are sent through sockets.

## Development Environment

Visual Studio Code with Prettier - IDE
TypeScript, Node.js, Express.js and Sockets.io - Server (as seen in src folder)
HTML, CSS, JavaScript - Client (as seen in public folder)

## Useful Websites

**Big thanks to all people that helped me with their websites:**

* [Geeks for Geeks Tic Tac Toe JS tutorial](https://www.geeksforgeeks.org/javascript/simple-tic-tac-toe-game-using-javascript)
* [Sockets.IO Documentation](https://socket.io/docs/v4/tutorial/step-5)

## Future Work

* Add real time chat
* Add turn indicator
* Add random first player assignment
