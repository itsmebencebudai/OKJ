<?php

// echo "<h1 class=\"vmi\">hello world!</h1>";
// echo "<h1 class=\"vmi\">hello world!</h1>";
// echo "<h1 class=\"vmi\">hello world!</h1>";

// $maci = "medve";
// echo $maci;

define("EMBER","emberke");

$vezetek_nev ="medve";
$kereszt_nev = "Laci";

echo $vezetek_nev = " ".$kereszt_nev."<br>";
echo EMBER;
const EMBER_2 = "Piroska";
echo EMBER_2;
// string integer float boolean array object null 
// var_dump($kereszt_nev)
// $kereszt_nev = 5;
// $vezetek_nev = 10;
// var_dump($kereszt_nev);
// echo $kereszt_nev+$vezetek_nev;


print EMBER;
# aritmetikai operátorok
$szam1= 10;
$szam2 =10;

echo $szam1+$szam2. "<br>";
echo $szam1/$szam2. "<br>";
echo $szam1-$szam2. "<br>";
echo $szam1*$szam2. "<br>";
echo $szam1+$szam2. "<br>";
echo $szam1%$szam2. "<br>";

# értékadó operátorok

$szam1 = 50;
$szam= $szam1;

$szam1 += 1;
$szam1 -= 1;
$szam1 *= 2;
$szam1 /= 2;
$szam1 %= 2;
$szam1 **= 2;
$szam1--;
$szam1++;

# összehasonlító operátorok

$a=4;
$b="4";
$c=true;
echo $a==$b; // true
echo $a===$b; // false 

var_dump($a==$b); // true
var_dump($a===$b); // false 

$a <= $b; 
$a >= $b;
$a > $b;
$a < $b;
$a!= $b;
$a!== $b;

# logikai operátorok

$x =8;
$y = 15;
$z = true;

if ($y == 50 || $z == false) {
    echo "befutottunk";
} elseif ($x === 8 && $z == true){

}else {
echo "nem teljesült egyik feltétel sem";
}


switch ($a) {
    case 8: 
        echo "a megadott ertek 8";
        break;
    case 15:
        echo "a megadott ertek 15";
        break;
    case 9 : 
        echo "a megadott ertek 9";
        break;
    default:
        echo "nem megfelelő ertek"; 
        break;
}

#ciklusok 

for ($i = 0; $i < 10; $i++) {
    # code...
}
while ($i < 10) {
    # code...
}

do {
    # code...
} while ($i < 10);

foreach ($variable as $key => $value) {
    # code...
}
#függvények
// public function __construct(Type $var = null) {
//     # code...
// }
?>