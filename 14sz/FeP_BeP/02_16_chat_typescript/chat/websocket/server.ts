
import Websocket from 'ws'; 
const clients = new Set();

const server = new Websocket.Server({ port: 8081})
server.on ('connection',(socket:Websocket) => {

    clients.add(socket)

    socket.on('message', (message)=> {
            broadcast(message,socket)
        })
    socket.on('close',() => {
        clients.delete(socket)
    })
})

function broadcast(message:any,sender:any) {
    let client :any;
    for (client of clients) {
       // if (client != sender) {
            client.send(message)
       // }
    }
}