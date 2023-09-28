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

$tmb = ['egy','ketto', 'harom'];
echo '<br>';
for ($i = 0; $i < 10; $i++) {
    //echo $i.
}
while ($i < 10) {
    # code...
}

do {
    # code...
} while ($i < 10);

/*
$tomb= ['egy','ketto','harom'];
echo '<br>';
foreach ($tomb as $key => $value) {
 echo $key. ": ". $value.'<br>';
}*/

#függvények
function test(string $var = null) 
{
    echo 'maci';
    echo $var;
}
test();

echo '<br>';
echo strlen('maci alszik');
echo (print_r(explode(' ','maci Alszik'))); //bont vmilyen karakter alapján 
echo '<br>';
echo trim('maci alszik','a'); //kiszedi az adott betűt
echo '<br>';
echo ucwords('maci alszik'); //nagy betű
echo '<br>';
echo str_replace('maci','macko','maci Alszik'); //kicserl egy stringet
echo '<br>';
echo rand(0,100); //random szám
echo '<br>';
//echo $_SERVER['DOCUMENT_ROOT'];
//echo $_GET['param'];
//echo $_POST;
//echo $_COOKIE;    

echo '<br>';
$tomb = [];
for ($i = 0; $i < 10; $i++) {
    array_push($tomb, rand(0,100));
}
for ($i = 0; $i < 10; $i++) {
    echo $i.": ". $tomb[$i]. '<br>';
}

function Maximum(array $tomb2) {
    $max = $tomb2[0];
    for ($i = 0; $i < count($tomb2); $i++) {
        if ($tomb2[$i] > $max){
            $max = $tomb2[$i];
        }
    }
    return $max;
}
echo "Maximum: ". Maximum($tomb);
echo '<br>';

function Minimum(array $tomb2) {
    $min = $tomb2[0];
    for ($i = 0; $i < count($tomb2); $i++) {
        if ($tomb2[$i] < $min){
            $min = $tomb2[$i];
        }
        return $min;
    }
}
echo  "Minimum: ". Minimum($tomb);
echo '<br>';

// //phpinfo();
if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $name = $_POST['name'];
    if (empty($name)) {
        echo 'Please enter your name';
    } else {
        echo 'Hello '. $name;
    }
}

?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <form action="" method="post">
        <input type="text" name="name">
        <input type="submit" value="submit">
    </from>
</body>
</html>