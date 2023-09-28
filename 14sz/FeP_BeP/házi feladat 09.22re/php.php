<?php
require('config.php');
$pdo = new PDO('mysql:host=' . $secret['mysqlHost'] . ';dbname=' . $secret['mysqlDb'], $secret['mysqlUser'], $secret['mysqlPassword'], null);

class Tetelek
{
    private $tomb;
    public function __construct($tomb)
    {
        $this->tomb = $tomb;
    }
    public function szetvalogatas($feltetel)
    {
        $igazak = [];
        $hamisak = [];
        foreach ($this->tomb as $elem) {
            if ($feltetel($elem)) {
                $igazak[] = $elem;
            } else {
                $hamisak[] = $elem;
            }
        }
        return [
            'igazak' => $igazak,
            'hamisak' => $hamisak
        ];
    }
    public function osszegzes()
    {
        $osszeg = 0;
        foreach ($this->tomb as $elem) {
            $osszeg += $elem;
        }
        return $osszeg;
    }
    public function Osszefuttatas($tomb1, $tomb2)
    {
        $eredmeny = [];
        $i = 0;
        $j = 0;
        while ($i < count($tomb1) && $j < count($tomb2)) {
            if ($tomb1[$i] < $tomb2[$j]) {
                $eredmeny[] = $tomb1[$i];
                $i++;
            } else {
                $eredmeny[] = $tomb2[$j];
                $j++;
            }
        }
        while ($i < count($tomb1)) {
            $eredmeny[] = $tomb1[$i];
            $i++;
        }
        while ($j < count($tomb2)) {
            $eredmeny[] = $tomb2[$j];
            $j++;
        }
        return $eredmeny;
    }
}

/**********************************************************************/

$tomb = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$tetelek = new Tetelek($tomb);
$feltetel = function ($elem) {
    return $elem % 2 === 0; // Páros számok
};

/**********************************************************************/

$szetvalogatasEredmeny = $tetelek->szetvalogatas($feltetel);
echo "Páros számok: " . implode(", ", $szetvalogatasEredmeny['igazak']) . "<br>";
echo "Páratlan számok: " . implode(", ", $szetvalogatasEredmeny['hamisak']) . "<br>";

/**********************************************************************/

$osszeg = $tetelek->osszegzes();
echo "A tömb elemeinek összege: $osszeg" . "<br>";

/**********************************************************************/

$tomb1_Osszefuttatas = [1, 3, 5, 7, 9];
$tomb2_Osszefuttatas = [2, 4, 6, 8, 10];
$osszefuttatottTomb = $tetelek->Osszefuttatas($tomb1_Osszefuttatas, $tomb2_Osszefuttatas);
echo "Összefuttatott tömb: " . implode(", ", $osszefuttatottTomb) . "<br>";

/**********************************************************************/


?>
<!DOCTYPE html>
<html lang="hu">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>php_OOP</title>
</head>

<body>

</body>

</html>