<?php
require ('config.php');
$pdo=new PDO('mysql:host='.$secret['mysqlHost'].';dbname='.$secret['mysqlDb'],$secret ['mysqlUser'], $secret['mysqlPassword'],null);

echo '<table border=1>';
foreach ($pdo->query("select * from gazda") as $key => $value) {
    echo "<tr><td>". $value[0]. "</td><td>". $value[1]. "</td>";
}
echo "</table>";
    
?>