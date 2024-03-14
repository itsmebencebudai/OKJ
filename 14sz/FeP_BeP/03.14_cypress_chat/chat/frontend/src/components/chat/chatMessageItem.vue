<script setup lang="ts">
import router from '../../router';

const props = defineProps(['userID', 'message', 'name', 'sendTime', 'user']);


const redirectToprofile = () => {
  router.push('/profile');
}

</script>
 
<template>
  <div class="msg-box-right" v-if="props.userID === user">
    <div class="right-container">
      <div class="message">{{ props.message }}
        <div class="time">{{ new Date(props.sendTime).toLocaleTimeString().substring(0, 5) }}</div>
      </div>
      <div class="name" @click="redirectToprofile">
        <font-awesome-icon :icon="['far', 'user']" :title="props.name" size="1x" />
        <div class="username"> {{ props.name }}</div>
      </div>
    </div>
  </div>
  <div class="msg-box-left" v-else>
    <div class="left-container">
      <div class="message">{{ props.message }}
        <div class="time">{{ new Date(props.sendTime).toTimeString().substring(0, 5) }}</div>
      </div>
      <div class="name" @click="redirectToprofile">
        <font-awesome-icon :icon="['far', 'user']" :title="props.name" size="1x" />
        <div class="username"> {{ props.name }}</div>
      </div>
    </div>
  </div>
</template>
 
<style scoped>
#profile {
  width: 40px;
  margin-right: 10px;
  align-self: left;
}

.msg-box-left {
  float: left;
  background-color: #20689f;
  color: #fff;
  width: max-content;
  max-width: 50%;
  height: fit-content;

  padding: 10px;
  border-radius: 10px;
  margin-bottom: 10px;
}

.msg-box-right {
  float: right;
  background-color: #1c98f7;
  color: #fff;
  width: max-content;
  height: fit-content;

  padding: 10px;
  border-radius: 10px;
  margin-bottom: 10px;
}

.left-container {
  display: flex;
  flex-direction: row-reverse;
  gap: 10px;

  .name {
    min-width: fit-content;
    display: flex;
    align-items: center;
    flex-direction: column;
    justify-content: center;
  }

  .username {
    width: fit-content;
    text-align: center;
  }

  .message {
    width: max-content;

    .time {
      width: 100%;
      text-align: left;
    }
  }
}

.right-container {
  display: flex;
  flex-direction: row;
  gap: 10px;

  .name {
    min-width: fit-content;
    display: flex;
    align-items: center;
    flex-direction: column;
    justify-content: center;
  }

  .username {
    width: fit-content;
    text-align: center;
  }

  .message {
    width: max-content;

    .time {
      width: 100%;
      text-align: right;
    }
  }
}
</style>