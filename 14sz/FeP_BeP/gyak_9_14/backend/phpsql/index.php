<?php
require ('config.php');
$pdo=new PDO('mysql:host='.$secret['mysqlHost'].';dbname='.$secret['mysqlDb'],$secret ['mysqlUser'], $secret['mysqlPassword'],null);

// phpinfo();
// foreach ($pdo->query("select * from maci") as $row) {
//     print_r($row) . '<br>';

// $servername = "localhost";
// $username = "root";
// $password = "";

// // Create connection
// $conn = new mysqli($servername, $username, $password);
// echo '<table border="1">';

// foreach ($pdo->query("select * from maci") as $key => $value) {
//     echo "<tr><td>". $value[0]. "</td><td>". $value[1]. "</td>";
// }
// // foreach ($conn->query("select * from maci") as $key => $value) {
// //     echo "<tr><td>". $value[0]. "</td><td>". $value[1]. "</td>";
// // }

// echo "</table>";
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Viszgaremek</title>
</head>
<body>

</body>
</html>