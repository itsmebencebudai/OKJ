<script setup lang="ts">
const { message, name, sendTime } = defineProps(['message', 'name', 'sendTime']);

const formatSendTime = (timeString: string) => {
  const date = new Date(timeString);
  const hour = date.getHours().toString().padStart(2, '0');
  const minute = date.getMinutes().toString().padStart(2, '0');
  const second = date.getSeconds().toString().padStart(2, '0');
  return `${hour}:${minute}:${second}`;
};
</script>

<template>
  <span class="msg-box">

    <span>{{ message }}</span>
    <span class="send-time"> <span><svg height="20px" width="20px" version="1.1" id="Capa_1"
          xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" viewBox="0 0 60.671 60.671"
          xml:space="preserve">
          <g>
            <g>
              <ellipse style="fill:#010002;" cx="30.336" cy="12.097" rx="11.997" ry="12.097" />
              <path style="fill:#010002;" d="M35.64,30.079H25.031c-7.021,0-12.714,5.739-12.714,12.821v17.771h36.037V42.9
			C48.354,35.818,42.661,30.079,35.64,30.079z" />
            </g>
          </g>
        </svg></span>{{ name }} {{ formatSendTime(sendTime) }}</span>
  </span>
</template>

<style scoped>
.msg-box {
  background-color: #1c98f7;
  color: #fff;
  max-width: max-content;
  padding: 10px;
  border-radius: 10px;
  margin-bottom: 10px;
  display: flex;
  flex-direction: column;
}

.send-time {
  margin-top: 5px;
  align-self: flex-end;
  font-size: 0.8em;
}
</style>

