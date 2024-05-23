<template>
    <div class="container">
      <h1>Termék kezelése</h1>
      <div class="button-container">
        <button @click="add">Add</button>
        <button @click="list">List</button>
      </div>
    </div>
  </template>
  
  <script>
  export default {
    name: 'homeComponent',
    methods: {
      add() {
        this.$router.push('/add');
      },
      list() {
        this.$router.push('/list');
      }
    }
  };
  </script>
  
  <style scoped>
  .container {
    max-width: 600px;
    margin: auto;
    text-align: center;
  }
  
  h1 {
    font-size: 24px;
    margin-bottom: 20px;
  }
  
  .button-container {
    display: flex;
    justify-content: center;
  }
  
  button {
    margin: 0 10px;
    padding: 10px 20px;
    font-size: 16px;
    cursor: pointer;
    border: none;
    border-radius: 5px;
    background-color: #007bff;
    color: #fff;
  }
  
  button:hover {
    background-color: #0056b3;
  }
  </style>
  