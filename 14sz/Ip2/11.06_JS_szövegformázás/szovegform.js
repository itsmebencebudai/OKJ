
//////////////////////////////// TEXT TRANSFORMATION ////////////////////////////////

var szoveg = "This text is generated with AI";
var Tombszoveg = ['This', 'text', 'is', 'generated', 'with', 'AI'];
var Rossz_szoveg = "     This text is generated with AI      ";

document.writeln('szoveg ->' + szoveg);
document.write('<br>');

document.writeln('charAt -> ' + szoveg.charAt(1)); // returns the specified character '1'
document.write('<br>');

document.writeln('concat -> ' + szoveg.concat(' this text is added to the original')); // add text to the original
document.write('<br>');

document.writeln('includes -> ' + szoveg.includes('text')); // text exists in the original = true
document.write('<br>');

document.writeln('includes -> ' + szoveg.includes('this')); // this does not exist in the original = false | only 'This'
document.write('<br>');

document.writeln('indexOf -> ' + szoveg.indexOf('is')); // returns the index of the specified item 
document.write('<br>');

document.writeln('indexOf -> ' + szoveg.indexOf('end')); // returns -1 if the text doesn't exist
document.write('<br>');

document.writeln('length -> ' + szoveg.length); // returns the length of the text
document.write('<br>');

document.writeln('repeat -> ' + szoveg.repeat(3)) // repeat the text until it reaches the specified number
document.write('<br>');

document.writeln('replace -> ' + szoveg.replace('e', 'T')); // replace ever 'e' to 'T'
document.write('<br>');

document.writeln('substr -> ' + szoveg.substr(7, 6)); // subtring the specified indexes  |  deprecated 
document.writeln('<br>');

document.writeln('substring -> ' + szoveg.substring(7, 6)); // substring the specified indexes
document.write('<br>');

document.writeln('slice -> ' + szoveg.slice(2, 14)); // slice the text between the specified index
document.write('<br>');

document.writeln('split -> ' + szoveg.split(' ')); // split the text by the specified character
document.write('<br>');

document.writeln('join -> ' + Tombszoveg.join(' ')); // join the text by the specified character from array
document.write('<br>');

document.writeln('toUpperCase -> ' + szoveg.toUpperCase()); // uppercase the text
document.write('<br>');

document.writeln('toLowerCase -> ' + szoveg.toLowerCase()); // lowercase the text
document.write('<br>');

document.writeln('trim ->' + Rossz_szoveg.trim()); // trim the unnecessary spaces before and after the text
document.write('<br>');