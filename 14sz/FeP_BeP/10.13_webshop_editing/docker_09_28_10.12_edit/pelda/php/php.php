<?php
require ('config.php');

try {
    $pdo=new PDO('mysql:host='.$secret['mysqlHost'].';dbname='.$secret['mysqlDb'],$secret ['mysqlUser'], $secret['mysqlPassword'],null);
    $sql = "select * from Users Join Address on Users.addressId = Address.id where usersId = :usersId";
    $stmt = $pdo->prepare($sql);
    $param = 1;
    $stmt->bindParam(':usersId',$param);
    $stmt->execute();

    $res = $stmt;
} catch (PDOException $e) {
    echo 'Error:'. $e->getMessage();
}



echo '<table border=1>';

foreach ($res as $key => $row) {
    // echo "<tr><td>". $value[0]. "</td><td>". $value[1]. "</td>";
    echo '<tr>';
    foreach ($row as $value) {
        echo '<td>'. $value. '</td>';
    }
    echo '</tr>';
}
echo "</table>";




?>