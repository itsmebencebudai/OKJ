<script>
import { ref, onMounted } from 'vue';
    
export default {
    name: "allatoklistaPag",
    setup() {
        const pets = ref([]);

        const getPetList = async () => {
            try {
                const response = await fetch("http://localhost:8000/api/pet");
                const data = await response.json();
                pets.value = data;
                
                if (data.length === 0) {
                    alert('Nincs kisállat az adatbázisban.');
                }

            } catch (error) {
                console.error("Error fetching pets list:", error);
            }
        };

        onMounted(() => {
            getPetList();
        });

        return {
            pets
        };
    }
};
</script>

<template>
    <h1 class="title">Kisállatok listája</h1>
    <BackToMainpageComponent />
    <div class="listContainer">
        <div v-for="pet in pets" :key="pet.id" class="petCard">
            <div class="imgContainer">
                <img src="../assets/kiskutya.jpg" alt="pet">
            </div>
            <p> <b>Név</b>: {{ pet.nev }}</p>
            <p><b>Leírás</b>:</p>
            <p>{{ pet.leiras }}</p>
            <p>Ár: <b>{{ pet.ar }} Ft</b></p>
            <p>Raktáron: <b>{{ pet.raktaron }}</b></p>
        </div>
    </div>
</template>

<style scoped>
.title {
    text-align: center;
    font-size: 30px;
    font-weight: 300px;
    margin-bottom: 2%;
}

.listContainer {
    display: flex;
    flex-wrap: wrap;
    justify-content: center;
    align-items: center;
    gap: 20px;
}

.petCard {
    width: calc(20% - 10px);
    border: 1px solid #ccc;
    padding: 10px;
    background-color: lightblue;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-content: center;
    flex-wrap: wrap;
}

.imgContainer img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}
</style>