const app = require('./index');
const port = 8000;

// ez a végpont mutatja, hogy fut a node js szerver
app.get('/', (req, res) => {
    res.send("<h1>Szerver fut</h1>")
})

// publikáljuk a szervert
app.listen(port, () => {
    console.log(`Példa alkalmazás publikálva ${port}-on`);

})

