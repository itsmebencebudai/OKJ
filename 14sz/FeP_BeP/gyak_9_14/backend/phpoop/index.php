<?php
class Teszt{
    var $nev = "Maci Laci";
    var $színek = ['red', 'green', 'blue', 'yellow'];
    const MAX_SZAM = 10;
    protected $bankszamla_szam = '48596241-74526354-98643125-87216437';
    private $fizetes = 1200;
    public $valami = 'ez valami';

    public function __construct($nev, $színek, $bankszamla){
        $this->nev = $nev;
        $this->színek = $színek;
        $this->bankszamla_szam = $bankszamla;
    }

    public function getNev(){
        return $this->nev;
    }
    
    public function setNev($nev){
        $this->nev = $nev;
    }

    public function eviFizetes() {
        echo self::MAX_SZAM;
        echo Teszt::$színek . '<br>';
        echo "bankszamla szam: " . $this->bankszamla_szam . "<br>";
        echo "fizetes: ". $this->fizetes . "<br>";
        return 15000;
    }
}

// $teszt = new Teszt();
// echo $teszt->eviFizetes();
// echo '<br>';
// echo $teszt->nev;
// echo '<br>';

class Teszt2 extends Teszt{
    public function teszt2func(){
        echo Teszt::MAX_SZAM;
        // echo self::$színek. '<br>';
        // $this->valami;
        // $this->fizetes;
        return "teszt2";
    }
}

$teszt2 = new Teszt2('bubu', ['egy', 'ketto'],'12346-456789-12345-678912');
echo $teszt2->nev;
echo $teszt2->teszt2func();
echo $teszt2->valami;
// echo $teszt->fizetes;
// echo $teszt->bankszamla_szam;
// echo $teszt->színek;
// echo $teszt->nev;











?>