<script setup lang="ts">

const props = defineProps(['userID','message','name','sendTime','user']);

</script>
 
<template>
    
    <div class="msg-box-left" v-if="props.userID === user ">
      <div class="left-container">
        <div class="name">
          <font-awesome-icon :icon="['far', 'user']" :title="props.name"  size="2x" />
        </div>
        <div class="message">{{props.message}}
          <div class="time">{{new Date(props.sendTime).toTimeString().substring(0,5)}}</div>
        </div>
      </div>
    </div>
    <div class="msg-box-right" v-else>
      <div class="left-container">
        
        <div class="message">{{props.message}}
          <div class="time">{{new Date(props.sendTime).toTimeString().substring(0,5) }}</div>
        </div>
        <div class="name">
          <font-awesome-icon :icon="['far', 'user']" :title="props.name"  size="2x" />
        </div>
      </div>
    </div>
    
</template>
 
<style scoped>
    .msg-box-left {
  float: left;    
  background-color: #20689f;
  color: #fff;
  width: auto;
  
 
  padding: 10px;
  border-radius: 10px;
  margin-bottom: 10px;
}
#profile {
width: 40px;
  margin-right: 10px;
}
.msg-box-right {
  float: right;
  background-color: #1c98f7;
  color: #fff;
  width: auto;
  
  padding: 10px;
  border-radius: 10px;
  margin-bottom: 10px;
}
.left-container {
  display: flex;
  .name {
    min-width: fit-content;
    width:5%;
    height: 2rem;
  }
  .message {
   
    width:95%;
  }

}
.right-container {
  display: flex;
  .name {
    min-width: fit-content;
    width:95%;
  }
  .message {
    
    width:5%;
  }
  .time{
    width:fit-content;
    text-align: right;
  }
}

 </style>