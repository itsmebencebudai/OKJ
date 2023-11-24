<?php
try {
        $pdo = new PDO('mysql:host='.$secret['mysqlHost'].';dbname='.$secret['mysqlDb'], $secret['mysqlUser'],$secret['mysqlPass'],null);
    } catch (PDOException $e) {
        echo 'Error: '. $e->getMessage();
    };