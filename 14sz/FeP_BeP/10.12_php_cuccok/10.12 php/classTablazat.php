<?php
require('config.php');
class Tablazat
{
    public $res = NULL;
    function __constructor($tablazatNev)
    {
        try {
            $pdo = new PDO('mysql:host=' . Config::secret['mysqlHost'] . ';dbname=' . Config::secret['mysqlDb'], Config::secret['mysqlUser'], Config::secret['mysqlPass'], null);
            $sql = "select * from" . $tablazatNev . ";";
            $this->res = $pdo->query($sql);
        } catch (Exception $e) {
            echo 'Error: ' . $e->getMessage();
        }
    }
    function kiir()
    {
        echo '<table border="1">';
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

// $tabla = new Tablazat('User');

// $tabla->kiir();
