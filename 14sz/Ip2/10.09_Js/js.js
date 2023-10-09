const array = [];
for (var i = 0; i < 10; i++) {
    var rand= Math.floor(Math.random() * 100);
    array.push(rand);
}

for (var i = 0; i < array.length; i++) {
    // console.log(array[i]);
    document.write(array[i])+",";
}

