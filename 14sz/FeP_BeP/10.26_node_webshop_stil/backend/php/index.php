<?php
   /* echo "<h1 class=\"vmi\">hello world!<h1>";
      echo '<h1 class="vmi">hello world!<h1>';
    echo "<h1 class='vmi'>hello world!<h1>";
    */
  #konstans
    define("EMBER","emberke");
    const EMBER_2 = "Piroska";

    $vezetek_nev = "medve";
    $kereszt_nev = "Laci";
    echo $vezetek_nev. " " .$kereszt_nev."<br>";
    echo EMBER;
    
    echo EMBER_2;
   var_dump($kereszt_nev);
   $kereszt_nev = 5;
   $vezetek_nev = 10;
    var_dump($kereszt_nev);
    echo $kereszt_nev+$vezetek_nev;


    print EMBER;
# aritmetikai operátorok
    $szam1 = 10;
    $szam2 = 10;

    echo $szam1 + $szam2 ."<br>";
    echo $szam1 - $szam2."<br>";
    echo $szam1 * $szam2."<br>";
    echo $szam1 / $szam2."<br>";
    echo $szam1 % $szam2."<br>";

   #értékadó operátorok
   $szam1 = 50;
   $szam = $szam1;
   $szam1 += 1;
   $szam1 -= 1;
   $szam1 *= 1;
   $szam++;
   $szam--;

   #összehasónlító operátorok
   $a=4;
   $b= "4";
   $c = true ;
   
   var_dump($a==$b); //true
   var_dump($a===$b); //false

   $a <= $b;
   $a >= $b;
   $a > $b;
   $a < $b;

   $a !== $b;
   
   #logikai operátorok

   $x = 8;
   $y = 15;
   $z = true;


    if ($y == 15 && $z) {
        echo "befutoottunk";
    }
    
  #elágazások  
    if ($x == 50 || $z == false) {
        echo "befutoottunk";
    } elseif ($x === 8 && $z == true) {

    } else {
        echo "nem teljesült egyik fltétel sem";
    }
   
    switch($x) {
        case 8 : 
            echo "a megadott ertek 8";
            break;
        case 9 : 
            echo "a megadott ertek 9";
            break;
        case 10 : 
            echo "a megadott ertek 10";
            break;
        default: 
            echo "egyik sem";        
    }

    #ciklusok
    echo '<br>'; 
    $tomb = ['egy','ketto','harom'];    
    for ($i=0; $i < count($tomb) ; $i++) { 
        echo $i.": ".$tomb[$i].'<br>';

        }

        while ($a <= 10) {
        $a++;
        }

        do {
            # code...
        } while ($a <= 10);

        
        echo '<br>'; 
       foreach ($tomb as $key => $value) {
        echo $key.": ".$value.'<br>';
       } 

     
     #függvények
    function test(string $var = null)
     {
        echo 'maci';
        echo $var;
     }  
     test();

     echo strlen('maci alszik');
     echo print_r(explode(' ','maci Alszik')).'<br>'; 
     echo trim('maci alszika',"a").'<br>';
     echo ucwords('maci alszik').'<br>';
     echo str_replace('maci','macko','maci Alszik').'<br>';


     echo rand(0,100);
    
    echo $_SERVER['DOCUMENT_ROOT'].'<br>';
    echo $_GET['param'];
    echo $_GET['bubu'];
       


     phpinfo();

     if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $name = $_POST['nev'];
        if (empty($name)) {
            echo 'A nev üres';
                
        } else {
            echo 'a beírt név: '. $name;
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
    <input type="text" name="nev" alt="az ember neve" placeholder="ide írd a nevet">
    <input type="submit" value="küld">
    </form>
</body>
</html>