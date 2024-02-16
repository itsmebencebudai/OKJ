import {socket} from  './websocket.js'

export function sendMessage() {

const messageInput = document.getElementById("message")
const message = messageInput.value
    socket.send(message);
    messageInput.value = '';
}
