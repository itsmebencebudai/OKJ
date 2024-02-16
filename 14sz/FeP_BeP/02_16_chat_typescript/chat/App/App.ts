import app from "./index";
const { PORT } = process.env;

// ez a végpont mutatja, hogy fut a node js szerver
app.get('/',(req,res) => {
    res.send("<h1>Szerver fut</h1>")
})
 
// publikáljuk a szervert
app.listen(PORT, () => {
console.log(`Példa alkalmazás publikálva ${PORT}-on`);

})

