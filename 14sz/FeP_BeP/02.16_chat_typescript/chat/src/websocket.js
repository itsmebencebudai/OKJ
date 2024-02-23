//Új webszoket kapcsolat létrehozása
export const socket = new WebSocket("ws://localhost:8081");

const message = [];



socket.addEventListener("open", (event) => {
    
})


socket.addEventListener("message", (event) => {

        message.push(event.data)

})


socket.addEventListener("close", () =>{

});

socket.addEventListener("error", ()=>{

})