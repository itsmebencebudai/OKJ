//Tömb feltöltés:
let tomb= [];
for(let i=0;i<10;i++)
{
	let randomSzam=Math.round(Math.random()*100);
    tomb.push(randomSzam);
}

for(let i=0;i<tomb.length;i++){
	console.log(tomb[i]);
}

//Összegzés tétele: A tömbben lévő elemek összegét adja vissza
let osszeg=0;
for(let i=0;i<tomb.length;i++)
{
    osszeg+=tomb[i];
}
console.log("A tömb elemeinek összege:"+osszeg)




//Átlagszámítás tétele: A tömbben lévő elemek átlagát adja vissza
//Ugyanaz az alapja mint összegzésnek a módosítás csak a kiíratásnál van:
console.log("A tömb elemeinek átlaga:"+osszeg/tomb.length)





//Minimum keresés
//-értékkel: A tömbben szereplő legkisebb éréket adjuk vissza
let minErtek=tomb[0];
for(let i=0;i<tomb.length;i++){
    if(tomb[i]<minErtek){
        minErtek=tomb[i];
    }    
}console.log("A tömb legkisebb elemének értéke:"+minErtek);


//-indexxel: A tömbben szereplő legkisebb értéknek a helyét adjuk vissza
let minIndex=0;
for(let i=0;i<tomb.length;i++){
    if(tomb[i]<tomb[minIndex]){
        minIndex=i;
    }
}
console.log("A tömb legkisebb elemének indexe:"+minIndex);




//Maximum keresés
//-értékkel: A tömbben szereplő legnagyobb éréket adjuk vissza
let maxErtek=tomb[0];
for(let i=0;i<tomb.length;i++){
    if(tomb[i]>maxErtek){
        maxErtek=tomb[i];
    }    
}console.log("A tömb legnagyobb elemének értéke:"+maxErtek);

//-indexxel: A tömbben szereplő legnagyobb értéknek a helyét adjuk vissza
let maxIndex=0;
for(let i=0;i<tomb.length;i++){
    if(tomb[i]>tomb[maxIndex]){
        maxIndex=i;
    }
}
console.log("A tömb legnagyobb elemének indexe:"+maxIndex);

//Megszámlálás: Adott T tulajdonságú elemek számát adja vissza a tömbből(feltéte határozza meg)
let parosakSzama=0;
for(let i=0;i<tomb.length;i++)
{
    if(tomb[i]%2==0){
        parosakSzama++;
    }
}
console.log("A tömbben lévő páros elemek mennyisége:"+parosakSzama);

//Kiválogatás: Adott T tulajdonságú elemek listáját adja vissza a tömbből(feltéte határozza meg)
let parosakListaja=[];
for(let i=0;i<tomb.length;i++){
    if(tomb[i]%2==0){
        parosakListaja.push(tomb[i]);
    }
}
console.log("A tömbben lévő páros elemek listája a következő:"+parosakListaja);