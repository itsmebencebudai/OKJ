    //Ide illessze be a JavasScript kódot a teszteléshez
    function ParosSzamok(alsoHatar, felsoHatar) {
        let parosSzamok = [];
        for (let i = alsoHatar; i <= felsoHatar; i++) {
            if (i % 2 === 0) {
                parosSzamok.push(i);
            }
        }
        return parosSzamok;
    }

    let alsoHatar = 1;
    let felsoHatar = 10;
    let parosTomb = ParosSzamok(alsoHatar, felsoHatar);
    console.log(parosTomb);

    function snake_case_szoveg(kifejezes) {
        let kisbetus_kifejezes = kifejezes.toLowerCase();
        let snake_case_kifejezes = kisbetus_kifejezes.replace(/\s+/g, '_');
        return snake_case_kifejezes;
    }

    let kifejezes = "Ez egy PéLdA Kifejezés";
    let snake_case_kifejezes = snake_case_szoveg(kifejezes);
    console.log(snake_case_kifejezes);

    function KepviselokSzama(vizsgaltTomb, partNeve) {
        let kepviselokSzama = 0;
        for (let i = 0; i < vizsgaltTomb.length; i++) {
            if (vizsgaltTomb[i].part === partNeve) {
                kepviselokSzama++;
            }
        }
        return kepviselokSzama;
    }

    const partNeve = "GYEP";
    const kepviselok = KepviselokSzama(szavazatok, partNeve);
    console.log(`A ${partNeve} pártba tartozó képviselők száma: ${kepviselok}`);

