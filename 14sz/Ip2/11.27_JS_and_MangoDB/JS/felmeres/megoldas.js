function hosszEllenor(input) {
    return input.length >= 8;
}

document.write('hosszEllenor ' + hosszEllenor('teszt'))
document.write('<br>')
document.write('hosszEllenor ' + hosszEllenor('feladatteszt'))
document.write('<br>')

function tajSzamEllenor(tajszam) {
    if (typeof tajszam !== 'string' || tajszam.length !== 9) {
        console.error("Hibás bemenet. A tajszám 9 karakter hosszúnak kell lennie.");
        return false;
    }

    let a = 0;
    for (let i = 1; i < 9; i += 2) {
        a += parseInt(tajszam[i]);
    }
    a *= 7;

    let b = 0;
    for (let i = 0; i < 8; i += 2) {
        b += parseInt(tajszam[i]);
    }
    b *= 3;

    return (a + b) % 10 === parseInt(tajszam[8]);
}
document.write('<br>')
document.write('tajSzamEllenor ' + tajSzamEllenor("040655330"));   
document.write('<br>')
document.write('tajSzamEllenor ' + tajSzamEllenor("111111111"));   
document.write('<br>')
document.write('tajSzamEllenor ' + tajSzamEllenor("037687210"));   
document.write('<br>')
document.write('tajSzamEllenor ' + tajSzamEllenor("019536646"));   
document.write('<br>')


function tombTerjedelem(array) {
    if (!Array.isArray(array) || array.length === 0 ){
        console.error('Hibás bemenet. A bemenetnek egy nem üres tömbnek kell lennie');
        return undefined;
    }

    let min = Math.min(...array);
    let max = Math.max(...array);

    let terjedelem = max - min;
    return terjedelem;
}

let vizsgaltTomb = [3, 5, 10, 16, 9];
let eredmeny = tombTerjedelem(vizsgaltTomb);

if (eredmeny !== undefined) {
    document.write('<br>')
    document.write("tombTerjedelem ", eredmeny);
}