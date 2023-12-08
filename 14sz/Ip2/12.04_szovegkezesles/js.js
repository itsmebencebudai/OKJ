function Maganhangzók_szama(word) {
    let maganhangzok = ["a", "á", "e", "é", "i", "í", "o", "ó", "ö", "ő", "u", "ú", "ü", "ű"];
    let count = 0;

    for (let i = 0; i < word.length; i++) {
        if (maganhangzok.includes(word[i])) {
            count++;
        }
    }

    return count;
}
let word_maganhangzo = "maganhangzok";
let result = Maganhangzók_szama(word_maganhangzo);
console.log(`A magánhangzók száma "${word_maganhangzo}" ${result}.`);

function Atalakito(word) {
    let result = "";

    for (let i = 0; i < word.length; i++) {
        switch (word[i]) {
            case "A":
            case "a":
                result += "4";
                break;
            case "E":
            case "e":
                result += "3";
                break;
            case "I":
            case "i":
                result += "1";
                break;
            case "O":
            case "o":
                result += "0";
                break;
            case "S":
            case "s":
                result += "5";
                break;
            case "T":
            case "t":
                result += "7";
                break;
            default:
                result += word[i];
        }
    }

    return result;
}

let word_atalakito = "Ez egy nagyon hosszu teszt szöveg";
let result_atalakito = Atalakito(word_atalakito);
console.log(`Az átalakitótt szöveg: ${result_atalakito}`);



