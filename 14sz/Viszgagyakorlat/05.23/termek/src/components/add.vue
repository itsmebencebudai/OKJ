<template>
    <div class="container">
        <h2>Termék hozzáadása</h2>
        <div class="form-group">
            <label>Termék név:</label>
            <input v-model="ujTermek.nev" placeholder="Termék név">
        </div>
        <div class="form-group">
            <label>Termék ár:</label>
            <input v-model.number="ujTermek.ar" type="number" placeholder="Termék ár">
        </div>
        <div class="form-group">
            <label>Készlet mennyiség:</label>
            <input v-model.number="ujTermek.keszlet" type="number" placeholder="Készlet mennyiség">
        </div>
        <button @click="hozzaadas">Hozzáadás</button>
    </div>
</template>

<script>
export default {
    name: 'addComponent',
    data() {
        return {
            ujTermek: {
                nev: '',
                ar: 0,
                keszlet: 0
            },
            keszlet: JSON.parse(localStorage.getItem('keszlet')) || []
        };
    },
    methods: {
        hozzaadas() {
            const termek = this.keszlet.find(t => t.nev.toLowerCase() === this.ujTermek.nev.toLowerCase());
            if (termek) {
                termek.keszlet += this.ujTermek.keszlet;
            } else {
                this.keszlet.push({ ...this.ujTermek });
            }
            this.ujTermek.nev = '';
            this.ujTermek.ar = 0;
            this.ujTermek.keszlet = 0;
            localStorage.setItem('keszlet', JSON.stringify(this.keszlet));
            alert('Termék hozzáadva/frissítve.');

            this.$router.push('/list');
        }
    }
};
</script>

<style scoped>
div {
    display: flex;
    flex-direction: column;
    align-items: center;
}

.container {
    display: flex;
    flex-direction: column;
    width: max-content;
    margin: auto;
    padding: 20px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

.form-group {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-bottom: 15px;
}

input {
    padding: 10px;
    font-size: 16px;
    margin-top: 5px;
}

button {
    padding: 10px;
    font-size: 16px;
    cursor: pointer;
    background-color: #007bff;
    color: white;
    border: none;
    border-radius: 5px;
    margin-top: 10px;
    align-self: center;
}

@media (max-width: 600px) {
    .container {
        padding: 10px;
    }

    button {
        width: 100%;
    }
}
</style>