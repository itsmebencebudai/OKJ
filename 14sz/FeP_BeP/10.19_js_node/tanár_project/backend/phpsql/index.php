<?php
require('classTablazat.php');

    $t= new Tablazat('User');

    $t->kiir();

// require('config.php');

// try {
//     $pdo = new PDO('mysql:host='.$secret['mysqlHost'].';dbname='.$secret['mysqlDb'], $secret['mysqlUser'],$secret['mysqlPass'],null);

//     $sql = "select * from User Join Address on User.addressID = Address.addressID where userID = :userID or Address.addressID = :addressID";
//     $stmt = $pdo->prepare($sql);
//     $param = 1;
//     $param2 = 2;
//     $stmt->bindParam(':userID',$param);
//     $stmt->bindParam(':addressID',$param2);
//     $stmt->execute();
//     $res = $stmt;
// } catch (PDOException $e) {
//     echo 'Error: '. $e->getMessage();
// }



// echo '<table border = "1">';

// foreach ( $res as $key=>$row) {
//     echo '<tr>';
//     foreach($row as $value) {
//         echo '<td>'.$value.'</td>';  
//     }
//     echo '</tr>';
// }
// echo '</table>'




?>