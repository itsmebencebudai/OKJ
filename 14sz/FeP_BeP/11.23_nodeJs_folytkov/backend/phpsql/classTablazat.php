<?php

require("config.php");
class Tablazat
{
    public $res = null;
    public $sql ='';
    function  __construct($tablazetNev)
    {
        
       
      
            $pdo = new PDO('mysql:host=' . Config::SECRET['mysqlHost'] . ';dbname=' . Config::SECRET['mysqlDb'], Config::SECRET['mysqlUser'], Config::SECRET['mysqlPass'], null);
            $this->sql = "select * from " . $tablazetNev . ";";
            $this->res = $pdo->query($this->sql);
      

    }

   public function kiir()
    { 

        echo '<table border = "1">';
        foreach ($this->res as $key => $row) {
            echo '<tr>';
            foreach ($row as $value) {
                echo '<td>' . $value . '</td>';
            }
            echo '</tr>';
        }
        echo '</table>';
    }
}
