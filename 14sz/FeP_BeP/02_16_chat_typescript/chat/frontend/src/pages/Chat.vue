<template>
    <div class="center_div">
        <div class="chat-container">
            <div class="chat" ref="chat">
                <div v-for="(message, index) in messages" :key="index"
                    :class="{ 'sender': message.sender === 'A user', 'recipient': message.sender === 'B user' }"
                    class="message">
                    <div class="message-sender">{{ message.sender }}</div>
                    <div class="message-text">{{ message.text }}</div>
                </div>
            </div>
            <div class="input-container">
                <input v-model="newMessage" @keyup.enter="sendMessage('A user')" type="text" class="message-input"
                    placeholder="Írja be az üzenetét ...">
                <button @click="sendMessage('A user')" class="send-button">Küld</button>
            </div>
        </div>
        <div class="chat-container">
            <div class="chat" ref="chat">
                <div v-for="(message, index) in messages" :key="index"
                    :class="{ 'sender': message.sender === 'B user', 'recipient': message.sender === 'A user' }"
                    class="message">
                    <div class="message-sender">{{ message.sender }}</div>
                    <div class="message-text">{{ message.text }}</div>
                </div>
            </div>
            <div class="input-container">
                <input v-model="newMessage" @keyup.enter="sendMessage('B user')" type="text" class="message-input"
                    placeholder="Írja be az üzenetét ...">
                <button @click="sendMessage('B user')" class="send-button">Küld</button>
            </div>
        </div>
    </div>
</template>
  
<script>
import { ref } from 'vue';

export default {
    setup() {
        const messages = ref([
            // { text: 'Szia!', sender: 'A user' },
            // { text: 'Szia! Miben segíthetek?', sender: 'B user' }
        ]);

        const newMessage = ref('');

        const sendMessage = (sender) => {
            if (newMessage.value.trim() !== '') {
                messages.value.push({ text: newMessage.value, sender });
                newMessage.value = '';
                scrollToBottom();
            }
        };

        const scrollToBottom = () => {
            const chatContainer = document.querySelector('.chat');
            chatContainer.scrollTop = chatContainer.scrollHeight;
        };

        return {
            messages,
            newMessage,
            sendMessage
        };
    }
};
</script>
  
<style scoped>
.center_div {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    width: 100vw;
    background-image: url(https://wallsneedlove.com/cdn/shop/products/w0518_1s_art-deco-arches-wallpaper-for-walls-all-that-jazz_Repeating-Pattern-Sample-1.jpg?v=1620245484);
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover;
    background-attachment: fixed;
}

.chat-container {
    width: 500px;
    margin: 20px auto;
    border: 1px solid goldenrod;
    border-radius: 10px;
    padding: 20px;
    background-color: #333;
    font-family: Arial, sans-serif;
}

.chat {
    max-height: 400px;
    overflow-y: auto;
}

.message {
    margin: 10px 0;
    padding: 15px;
    border-radius: 10px;
    max-width: 80%;
    word-wrap: break-word;
    position: relative;
}

.message-sender {
    position: absolute;
    top: 0.5px;
    font-size: 12px;
    color: #888;
}

.message-text {
    margin-top: 10px;
}

.sender {
    background-color: goldenrod;
    color: white;
    align-self: flex-end;
}

.recipient {
    background-color: #f0f0f0;
    color: #333;
    align-self: flex-start;
}

.input-container {
    margin-top: 20px;
    display: flex;
    align-items: center;
}

.message-input {
    flex: 1;
    padding: 12px;
    border: 1px solid #ccc;
    border-radius: 10px;
    margin-right: 15px;
    font-size: 14px;
}

.send-button {
    padding: 12px 20px;
    background-color: goldenrod;
    color: white;
    border: 1px solid transparent;
    border-radius: 10px;
    cursor: pointer;
    font-size: 14px;
}

.send-button:hover {
    background-color: #333;
    border: 1px solid #ccc; 
    padding: 12px 20px;
    color: white;
    border-radius: 10px;
    cursor: pointer;
    font-size: 14px;
}
</style>
  