<?php 
class Teszt {
    var $nev ="";
    var $szinek = [];
    const MAX_SZAM = 10;
    protected $bankszamla_szam='';
    private $fizetes = 1200;
    public $valami ='ez valami';
    public function __construct($nev,$szinek,$bankszamla)
    {
        $this->nev = $nev;
        $this->szinek = $szinek;
        $this->bankszamla_szam = $bankszamla;    

    }


    static function eviFizetes () {
        echo self::MAX_SZAM;
        return 15000;
    }
}


class Teszt2 extends Teszt {
    public function teszt2func () {
        echo Teszt::MAX_SZAM;  

        //$this->fizetes;
        echo $this->bankszamla_szam;
        return "teszt2";
    }
}


$teszt2 = new Teszt2('bubu',['egy','ketto'],'1243-5684-4587-2654');
echo $teszt2->nev;
echo $teszt2->teszt2func();
echo $teszt2->valami;
echo Teszt2::$szinek;






?>