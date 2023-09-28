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
    function szetvalogatas($feltetel)
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
    function osszegzes()
    {
        $osszeg = 0;
        foreach ($this->tomb as $elem) {
            $osszeg += $elem;
        }
        return $osszeg;
    }
    function Osszefuttatas($tomb1, $tomb2)
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
    function rendezesMinimumKivalasztassal(&$tomb)
    {
        $n = count($tomb);
        for ($i = 0; $i < $n - 1; $i++) {
            $minIndex = $i;
            for ($j = $i + 1; $j < $n; $j++) {
                if ($tomb[$j] < $tomb[$minIndex]) {
                    $minIndex = $j;
                }
            }
            $temp = $tomb[$i];
            $tomb[$i] = $tomb[$minIndex];
            $tomb[$minIndex] = $temp;
        }
    }
    function metszet($tomb1, $tomb2)
    {
        return array_intersect($tomb1, $tomb2);
    }
    function megszamolas($tomb, $feltetel)
    {
        $szamlalo = 0;
        foreach ($tomb as $elem) {
            if ($feltetel($elem)) {
                $szamlalo++;
            }
        }
        return $szamlalo;
    }
    function maximumKivalasztas($tomb)
    {
        if (empty($tomb)) {
            throw new Exception("A tömb üres, nincs maximum.");
        }
        $maximum = $tomb[0];
        foreach ($tomb as $elem) {
            if ($elem > $maximum) {
                $maximum = $elem;
            }
        }
        return $maximum;
    }
    function linearisKereses($tomb, $keresett)
    {
        foreach ($tomb as $index => $elem) {
            if ($elem === $keresett) {
                return $index;
            }
        }
        return -1;
    }
    function kivalogatas($tomb, $feltetel)
    {
        $kivalogatottElemek = [];
        foreach ($tomb as $elem) {
            if ($feltetel($elem)) {
                $kivalogatottElemek[] = $elem;
            }
        }
        return $kivalogatottElemek;
    }
    function kivalasztas($tomb)
    {
        if (empty($tomb)) {
            throw new Exception("A tömb üres, nincs elem kiválasztva.");
        }
        $legnagyobb = $tomb[0];
        foreach ($tomb as $elem) {
            if ($elem > $legnagyobb) {
                $legnagyobb = $elem;
            }
        }
        return $legnagyobb;
    }
    function indexvektorosRendezes($tomb)
    {
        $indexek = range(0, count($tomb) - 1);
        usort($indexek, function ($a, $b) use ($tomb) {
            return $tomb[$a] - $tomb[$b];
        });
        $rendezettTomb = [];
        foreach ($indexek as $index) {
            $rendezettTomb[] = $tomb[$index];
        }
        return $rendezettTomb;
    }
    function GyorsRendezes($tomb)
    {
        $n = count($tomb);
        if ($n <= 1) {
            return $tomb;
        }
        $pivot = $tomb[0];
        $kisebb = $nagyobb = [];
        for ($i = 1; $i < $n; $i++) {
            if ($tomb[$i] < $pivot) {
                $kisebb[] = $tomb[$i];
            } else {
                $nagyobb[] = $tomb[$i];
            }
        }
        return array_merge(
            self::GyorsRendezes($kisebb),
            [$pivot],
            self::GyorsRendezes($nagyobb)
        );
    }
    function eldontes($tomb, $feltetel)
    {
        foreach ($tomb as $elem) {
            if ($feltetel($elem)) {
                return true;
            }
        }
        return false;
    }
    function bubiRendezes($tomb)
    {
        $n = count($tomb);
        $cserelve = true;
        while ($cserelve) {
            $cserelve = false;
            for ($i = 0; $i < $n - 1; $i++) {
                if ($tomb[$i] > $tomb[$i + 1]) {
                    $temp = $tomb[$i];
                    $tomb[$i] = $tomb[$i + 1];
                    $tomb[$i + 1] = $temp;
                    $cserelve = true;
                }
            }
        }
        return $tomb;
    }
    function binarisKereses($tomb, $keresett)
    {
        $bal = 0;
        $jobb = count($tomb) - 1;
        while ($bal <= $jobb) {
            $kozep = floor(($bal + $jobb) / 2);
            if ($tomb[$kozep] == $keresett) {
                return $kozep;
            } elseif ($tomb[$kozep] < $keresett) {
                $bal = $kozep + 1;
            } else {
                $jobb = $kozep - 1;
            }
        }
        return -1;
    }
    function unio($tomb1, $tomb2)
    {
        $unioTomb = array_unique(array_merge($tomb1, $tomb2));
        return $unioTomb;
    }
    function shellRendezes($tomb)
    {
        $n = count($tomb);
        $h = 1;
        while ($h < $n / 3) {
            $h = 3 * $h + 1;
        }
        while ($h >= 1) {
            for ($i = $h; $i < $n; $i++) {
                for ($j = $i; $j >= $h && $tomb[$j] < $tomb[$j - $h]; $j -= $h) {
                    $temp = $tomb[$j];
                    $tomb[$j] = $tomb[$j - $h];
                    $tomb[$j - $h] = $temp;
                }
            }
            $h = floor($h / 3);
        }
        return $tomb;
    }
    function kozvetlenKivalasztasRendezes($tomb) {
        $n = count($tomb);
        for ($i = 0; $i < $n - 1; $i++) {
            $minIndex = $i;
            for ($j = $i + 1; $j < $n; $j++) {
                if ($tomb[$j] < $tomb[$minIndex]) {
                    $minIndex = $j;
                }
            }
            $temp = $tomb[$i];
            $tomb[$i] = $tomb[$minIndex];
            $tomb[$minIndex] = $temp;
        }
        return $tomb;
    }
    function beszurasosRendezes($tomb) {
        $n = count($tomb);
            for ($i = 1; $i < $n; $i++) {
            $ertek = $tomb[$i];
            $j = $i - 1;
            while ($j >= 0 && $tomb[$j] > $ertek) {
                $tomb[$j + 1] = $tomb[$j];
                $j--;
            }
            $tomb[$j + 1] = $ertek;
        }
        return $tomb;
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

$tomb_rendezesMinimumKivalasztassal = [64, 25, 12, 22, 11];
$tetelek->rendezesMinimumKivalasztassal($tomb_rendezesMinimumKivalasztassal);
echo "Rendezett tömb: " . implode(", ", $tomb_rendezesMinimumKivalasztassal) . "<br>";

/**********************************************************************/

$tomb1_metszet = [1, 2, 3, 4, 5];
$tomb2_metszet = [3, 4, 5, 6, 7];
$metszetTomb = $tetelek->metszet($tomb1_metszet, $tomb2_metszet);
echo "A két tömb metszete: " . implode(", ", $metszetTomb) . "<br>";

/**********************************************************************/

$tomb_megszamolas = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$feltetel_megszamolas = function ($elem) {
    return $elem % 2 === 0;
};
$szamoltElemek_megszamolas = $tetelek->megszamolas($tomb_megszamolas, $feltetel_megszamolas);
echo "Megszámolt elemek száma: $szamoltElemek_megszamolas <br>";

/**********************************************************************/

$tomb_maximumKivalasztas = [3, 7, 1, 9, 2, 6, 4, 8, 5];
try {
    $maxElem = $tetelek->maximumKivalasztas($tomb_maximumKivalasztas);
    echo "A tömb legnagyobb eleme: $maxElem<br>";
} catch (Exception $e) {
    echo $e->getMessage() . "<br>";
}

/**********************************************************************/

$tomb_linearisKereses = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$keresettElem_linearisKereses = 6;
$talalatIndex_linearisKereses = $tetelek->linearisKereses($tomb_linearisKereses, $keresettElem_linearisKereses);
if ($talalatIndex_linearisKereses !== -1) {
    echo "A keresett elem ($keresettElem_linearisKereses) a(z) $talalatIndex_linearisKereses indexen található.<br>";
} else {
    echo "A keresett elem ($keresettElem_linearisKereses) nem található a tömbben.<br>";
}

/**********************************************************************/

$tomb_kivalogatas = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$feltetel_kivalogatas = function ($elem) {
    return $elem % 2 === 0;
};
$kivalogatottElemek = $tetelek->kivalogatas($tomb_kivalogatas, $feltetel_kivalogatas);
echo "Kiválogatott elemek: " . implode(", ", $kivalogatottElemek) . "<br>";

/**********************************************************************/

$tomb_kivalasztas = [3, 7, 1, 9, 2, 6, 4, 8, 5];
try {
    $kivalasztottElem = $tetelek->kivalasztas($tomb_kivalasztas);
    echo "A tömb legnagyobb eleme: $kivalasztottElem<br>";
} catch (Exception $e) {
    echo $e->getMessage() . "<br>";
}

/**********************************************************************/

$tomb_indexvektorosRendezes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$rendezettTomb_indexvektorosRendezes = $tetelek->indexvektorosRendezes($tomb_indexvektorosRendezes);
echo "Rendezett tömb: " . implode(", ", $rendezettTomb_indexvektorosRendezes) . "<br>";

/**********************************************************************/

$tomb_GyorsRendezes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$rendezettTomb_GyorsRendezes = $tetelek->GyorsRendezes($tomb_GyorsRendezes);
echo "Rendezett tömb: " . implode(", ", $rendezettTomb_GyorsRendezes) . "<br>";

/**********************************************************************/

$tomb_eldontes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$feltetel_eldontes = function ($elem) {
    return $elem > 10;
};
$eredmeny_eldontes = $tetelek->eldontes($tomb_eldontes, $feltetel_eldontes);
if ($eredmeny_eldontes) {
    echo "Van olyan elem, amelyre igaz a feltétel.<br>";
} else {
    echo "Nincs olyan elem, amelyre igaz a feltétel.<br>";
}

/**********************************************************************/

$tomb_bubiRendezes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$rendezettTomb_bubiRendezes = $tetelek->bubiRendezes($tomb_bubiRendezes);
echo "Rendezett tömb: " . implode(", ", $rendezettTomb_bubiRendezes) . "<br>";

/**********************************************************************/

$tomb_binarisKereses = [1, 2, 3, 4, 5, 6, 7, 8, 9];
$keresettElem_binarisKereses = 6;
$talalatIndex_binarisKereses = $tetelek->binarisKereses($tomb_binarisKereses, $keresettElem_binarisKereses);
if ($talalatIndex_binarisKereses !== -1) {
    echo "A keresett elem ($keresettElem_binarisKereses) a(z) $talalatIndex_binarisKereses indexen található.<br>";
} else {
    echo "A keresett elem ($keresettElem_binarisKereses) nem található a tömbben.<br>";
}

/**********************************************************************/

$tomb1_unio = [1, 2, 3, 4];
$tomb2_unio = [3, 4, 5, 6];
$unioTomb = $tetelek->unio($tomb1_unio, $tomb2_unio);
print_r(($unioTomb ));
echo  "<br>";

/**********************************************************************/

$tomb_array = array(
    "kulcs1" => "ertek1",
    "kulcs2" => "ertek2",
    "kulcs3" => "ertek3"
);

$tomb_array = ["ertek1", "ertek2", "ertek3"];

/**********************************************************************/

$tomb_shellRendezes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$rendezettTomb_shellRendezes = $tetelek->shellRendezes($tomb_shellRendezes);
echo "Rendezett tömb: " . implode(", ", $rendezettTomb_shellRendezes) . "<br>";

/**********************************************************************/

$tomb_kozvetlenKivalasztasRendezes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$rendezettTomb_kozvetlenKivalasztasRendezes = $tetelek->kozvetlenKivalasztasRendezes($tomb_kozvetlenKivalasztasRendezes);
echo "Rendezett tömb: " . implode(", ", $rendezettTomb_kozvetlenKivalasztasRendezes) . "<br>";

/**********************************************************************/

$tomb_beszurasosRendezes = [3, 7, 1, 9, 2, 6, 4, 8, 5];
$rendezettTomb_beszurasosRendezes = $tetelek->beszurasosRendezes($tomb_beszurasosRendezes);

echo "Rendezett tömb: " . implode(", ", $rendezettTomb_beszurasosRendezes) . "<br>";

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