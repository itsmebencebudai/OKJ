const getRendel = () => {
    return new Promise((resolve, reject) => { // Promise constructor => async function // feltudjuk oldani ha vmi sikerült (promise = igéret)
        // resolve();

        // reject();

        /* setTimeout(() => {
            resolve();
        },3000);*/

        setTimeout(() => { // setTimeout is called after the promise is resolved
            const rand = Math.random(); // random number generator
            if (0.5 > rand) { // random number generator should never fail with an error message 
                data = { a: 5 }; // data will be stored 
                resolve({ status: 200, data: data }); // kiír ha igaz
            }
            reject({ status: 404, hiba: "hiba van" }); // reject
        }, 3000); // in ms 
    })
}
// console.log(getRendel()); // console kiír
// setTimeout(() => { console.log(rendel) }); // setTimeout-al (hanem írom bele a getRendel-be) kiír

let a = getRendel(); // getRendel => a 
// console.log(a); // a kiírása 

// getRendel().then((res) => { // getRendel meghívása és a res kiírása (IF NOT ERROR)
//     console.log(res);
// }).catch((res) => { // getRendel meghívása és a res kiírása (IF ERROR)
//     console.log(res);
// }).finally(() => { // run ((if not error) OR (if error))
//     console.log('mindketto');
// });

getRendel().then((res) => {

    a = res; // a => res

}).catch((res) => {
    console.log(res);
}).finally(() => {
    console.log('mindketto');
})

const rend = /*await*/ getRendel(); // rend => getRendel function // await only valid if async function is available and top level bodies of modules
rend.then((res) => {
    console.log(rend); // rend kiírása consolra 
}); // gerRendel => rend 
console.log('ertek: ', a); // már lefutott szóval nem valid // a !=> res
