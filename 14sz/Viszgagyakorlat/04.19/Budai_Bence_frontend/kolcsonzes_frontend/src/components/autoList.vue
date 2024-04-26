<script setup>
import { ref, onMounted } from 'vue'
import BackToMainpageComponent from "./autolist/backtoMainpageComponent.vue";

const cars = ref([]);

const getAutoList = async () => {
    try {
        const response = await fetch("http://localhost:8000/api/auto");
        const data = await response.json();
        cars.value = data;

        if (data.length === 0) {
            alert('A nincs autó az adatbázisban');
        }

    } catch (error) {
        console.error("Error fetching auto list:", error);
    }
};

onMounted(() => {
    getAutoList();
});

const sortBy = (order) => {
    cars.value.sort((a, b) => {
        if (order === 'asc') {
            return a.tipus.localeCompare(b.tipus);
        } else {
            return b.tipus.localeCompare(a.tipus);
        }
    });
};
</script>

<template>
    <div class="main">
        <BackToMainpageComponent />
        <div class="autoList">
            <h2>Autók adatai</h2>
            <table class="table table-striped">
                <tr>
                    <th>Rendszam</th>
                    <th>Típus
                        <span>
                            <button v-on:click="sortBy('desc')">
                                ˅
                            </button>
                        </span>
                        <span>
                            <button v-on:click="sortBy('asc')">
                                ˄
                            </button>
                        </span>
                    </th>
                    <th>Évjárat</th>
                    <th>Szín</th>
                </tr>
                <tr v-for="car in cars" :key="car.id">
                    <td>{{ car.rendszam }}</td>
                    <td>{{ car.tipus }}</td>
                    <td>{{ car.evjarat }}</td>
                    <td>{{ car.szin }}</td>
                </tr>
            </table>
        </div>
    </div>
</template>

<style scoped>
.main {
    background-image: url("../assets/kolcsonzes.jpg");
    background-position: center;
    background-repeat: repeat-y;
    height: 90vh;
}

.autoList {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.autoListName {
    width: 100%;
    height: 50px;
    background-color: rgb(128, 213, 0);
    color: white;
    font-size: 30px;
    font-weight: 300px;
    cursor: pointer;
    margin-bottom: 2%;

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

h2 {
    text-shadow: 1px 1px 1px black;
    background-color: white;
}

table {
    border-collapse: collapse;
    width: 26%;
    border: 1px solid black;
    background-color: white;
    box-shadow: 1px 1px 1px black;

    th {
        background-color: lightblue;
    }

    td {
        border: 1px solid black;
    }
}
</style>