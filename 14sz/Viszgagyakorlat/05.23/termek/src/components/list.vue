<template>
    <div class="container">
      <h2>Termékek listázása</h2>
      <table class="termek-table">
        <thead>
          <tr>
            <th>Név</th>
            <th>Ár</th>
            <th>Készlet</th>
            <th>Műveletek</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="termek in rendezettTermekek" :key="termek.nev">
            <td>{{ termek.nev }}</td>
            <td>{{ termek.ar }}</td>
            <td>{{ termek.keszlet }}</td>
            <td><button @click="torles(termek.nev)">Törlés</button></td>
          </tr>
        </tbody>
      </table>
    </div>
  </template>
  
  <script>
  export default {
    name: 'listComponent',
    data() {
      return {
        keszlet: JSON.parse(localStorage.getItem('keszlet')) || []
      };
    },
    computed: {
      rendezettTermekek() {
        return [...this.keszlet].sort((a, b) => b.keszlet - a.keszlet);
      }
    },
    methods: {
      torles(nev) {
        this.keszlet = this.keszlet.filter(t => t.nev.toLowerCase() !== nev.toLowerCase());
        localStorage.setItem('keszlet', JSON.stringify(this.keszlet));
      }
    }
  };
  </script>
  
  <style scoped>
  .container {
    width: max-content;
    min-width: 300px;
    margin: auto;
    padding: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
    text-align: center;
  }
  
  .termek-table {
    width: 100%;
    border-collapse: collapse;
    text-align: center;
  }
  
  .termek-table th, .termek-table td {
    border: 1px solid #ddd;
    padding: 8px;
    text-align: left;
  }
  
  .termek-table th {
    background-color: #f2f2f2;
  }
  
  .termek-table tr:nth-child(even) {
    background-color: #f2f2f2;
  }
  
  button {
    padding: 5px 10px;
    font-size: 14px;
    cursor: pointer;
    background-color: #dc3545;
    color: white;
    border: none;
    border-radius: 5px;
  }
  
  @media (max-width: 600px) {
    button {
      align-self: flex-end;
      margin-top: 10px;
    }
  }
  </style>  