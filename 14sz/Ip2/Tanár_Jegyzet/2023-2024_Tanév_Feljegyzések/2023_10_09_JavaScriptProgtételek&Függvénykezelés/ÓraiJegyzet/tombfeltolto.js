let tomb= [];
for(let i=0;i<10;i++)
{
	let randomSzam=Math.round(Math.random()*100);
    tomb.push(randomSzam);
}

for(let i=0;i<tomb.length;i++){
	document.write(tomb[i]+",");
}