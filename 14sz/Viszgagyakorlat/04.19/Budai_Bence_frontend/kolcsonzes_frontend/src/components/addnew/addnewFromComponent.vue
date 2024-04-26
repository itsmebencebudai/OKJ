<script>
export default {
    name: "AddnewFromComponent",
    data() {
        return {};
    },
    methods: {
        uploadData: async function () {
            try {
                const response = await fetch("http://localhost:8000/api/auto", {
                    method: "POST",
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: JSON.stringify({
                        tipus: document.getElementById("tipus").value,
                        rendszam: document.getElementById("rendszam").value,
                        evjarat: document.getElementById("evjarat").value,
                        szin: document.getElementById("szin").value
                    })
                });
                const data = await response.ok;
                if (data === true) {
                    this.$router.push("/list");
                } else {
                    document.getElementById("error").innerHTML = "Hiba történt";
                    document.getElementById("error").style.color = "red";
                    document.getElementById("error").style.fontSize = "20px";
                    document.getElementById("error").style.fontWeight = "bolder";

                    document.getElementById("tipus").value = "";
                    document.getElementById("rendszam").value = "";
                    document.getElementById("evjarat").value = "";
                    document.getElementById("szin").value = "";
                }
            } catch (error) {
                console.error("Error fetching auto list:", error);
            }
        }
    }
};
</script>

<template>
    <div class="addnew">
        <div class="addnewName">
            <h2>Új autó hozzáadása</h2>
            <p id="error"></p>
            <form>
                <div class="form-group">
                    <label for="name">Rendszám</label>
                    <input type="text" class="form-control" id="rendszam" placeholder="Rendszam">
                </div>
                <div class="form-group">
                    <label for="name">Típus</label>
                    <input type="text" class="form-control" id="tipus" placeholder="Típus">
                </div>
                <div class="form-group">
                    <label for="name">Szín</label>
                    <input type="text" class="form-control" id="szin" placeholder="Szín">
                </div>
                <div class="form-group">
                    <label for="name">Évjárat</label>
                    <input type="text" class="form-control" id="evjarat" placeholder="Évjárat">
                </div>
                <div class="form-group">
                    <button type="button" @click="uploadData">Felvetel</button>
                </div>
            </form>
        </div>
    </div>
</template>

<style scoped>
.addnew {
    background-position: center;
    background-repeat: repeat-y;
    height: 90vh;
}

.addnewName {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.addnewName h2 {
    text-shadow: 1px 1px 1px black;
    background-color: white;
    padding: 20px;
}

.addnewName form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.form-group {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.form-group label {
    width: 100px;
    height: 30px;
    color: rgb(128, 213, 0);
    font-size: 20px;
    font-weight: 300px;
    cursor: pointer;
    margin-bottom: 2%;

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.form-group input {
    width: 200px;
    height: 30px;
    color: rgb(128, 213, 0);
    font-weight: 300px;
    cursor: pointer;
    margin-bottom: 2%;

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.form-group button {
    width: 200px;
    height: 30px;
    color: white;
    font-weight: 300px;
    cursor: pointer;
    margin-bottom: 2%;

    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.form-group button:hover {
    background-color: rgb(128, 213, 0);
    font-weight: bolder;
    border-radius: 10px;
}
</style>