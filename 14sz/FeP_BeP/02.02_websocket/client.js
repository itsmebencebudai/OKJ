document.addEventListener('DOMContentLoaded', function () {
    const socket = new WebSocket('ws://localhost:3000');
    let username;
    let password;

    socket.onopen = (event) => {
        console.log('WebSocket connection opened:', event);
    };

    socket.onmessage = (event) => {
        console.log('WebSocket message received:', event);
        const message = event.data.toString('utf-8');
        console.log('Received message:', message);

        const receivedMessagesDiv = document.getElementById('receivedMessages');
        receivedMessagesDiv.innerHTML += `<p>${message}</p>`;

        const data = JSON.parse(event.data);
        console.log(data)
        switch (data.type) {
            case 'loginResponse':
                if (data.success) {
                    console.log('Login successful');
                    document.getElementById('loginForm').style.display = 'none';
                    document.getElementById('registerForm').style.display = 'none';
                    document.getElementById('messageForm').style.display = 'block';
                } else {
                    receivedMessagesDiv.innerHTML += ('Login failed: ', message);
                }
                break;
        }
    };

    socket.onclose = (event) => {
        console.log('WebSocket connection closed:', event);
    };


    document.getElementById('loginForm').addEventListener('submit', (event) => {
        event.preventDefault();
        const usernameInput = document.getElementById('logusername');
        const passwordInput = document.getElementById('logpassword');
        username = usernameInput.value;
        password = passwordInput.value;

        if (username.trim() !== '') {
            const loginmessage = { type: 'login', username, password };
            socket.send(JSON.stringify(loginmessage));
        }
    });

    document.getElementById('registerForm').addEventListener('submit', (event) => {
        event.preventDefault();
        const registerUsernameInput = document.getElementById('regusername');
        const registerPasswordInput = document.getElementById('regpassword');
        const username = registerUsernameInput.value;
        const password = registerPasswordInput.value;

        if (username.trim() !== '' && password.trim() !== '') {
            const registerMessage = { type: 'register', username, password };
            socket.send(JSON.stringify(registerMessage));
        }
    });

    document.getElementById('messageForm').addEventListener('submit', (event) => {
        event.preventDefault();
        const messageInput = document.getElementById('message');
        const messageMessage = messageInput.value;

        if (messageMessage.trim() !== '') {
            const message = { type: 'message', username, messageMessage };
            console.log(message);
            socket.send(JSON.stringify(message));
            messageInput.value = '';
        }
    });

    socket.onmessage = (event) => {
        const data = JSON.parse(event.data);
    
        const chatMessages = document.getElementById('chat-messages');
        chatMessages.innerHTML += `<div><strong>${data.username}:</strong> ${data.messageMessage}</div>`;
    };
});