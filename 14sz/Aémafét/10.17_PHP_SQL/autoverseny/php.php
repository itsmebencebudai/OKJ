<?php
//config
$servername = "localhost";
$username = "root";
$password = "";
$database = "autoverseny_2";
$connectionString = "servername: $servername, username: $username, password: $password , database: $database";

//connection
try {
    $conn = new PDO("mysql:host=$servername;dbname=$database", $username, $password);
    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    // echo "Connected successfully";
    // echo $connectionString;
} catch (PDOException $e) {
    echo "Connection failed: " . $e->getMessage();
}

//table creation

$csapat = null;
try {
    $sql_create_table_csapat = "CREATE TABLE IF NOT EXISTS csapat (
        id INT AUTO_INCREMENT PRIMARY KEY,
        nev VARCHAR(255),
        alapitva INT
    );";

    $csapat = $conn->prepare($sql_create_table_csapat);
    $csapat->execute();
} catch (\Throwable $th) {
    echo "An error occurred: " . $th->getMessage();
}

$versenyzo = null;
try {
    $sql_create_table_versenyzo = "CREATE TABLE IF NOT EXISTS versenyzo (
        id INT AUTO_INCREMENT PRIMARY KEY,
        nev VARCHAR(255),
        eletkor INT,
        csapatid INT,
        CONSTRAINT FK_versenyzo_csapat_id FOREIGN KEY (csapatid) REFERENCES csapat (id)
    );";

    $versenyzo = $conn->prepare($sql_create_table_versenyzo);
    $versenyzo->execute();
} catch (\Throwable $th) {
    echo "An error occurred: " . $th->getMessage();
}


$palya = null;
try {
    $sql_create_table_palya = "CREATE TABLE IF NOT EXISTS palya (
        id INT AUTO_INCREMENT PRIMARY KEY,
        nev VARCHAR(255),
        hossz FLOAT,
        orszag VARCHAR(255)
    );";

    $palya = $conn->prepare($sql_create_table_palya);
    $palya->execute();
} catch (\Throwable $th) {
    echo "An error occurred: " . $th->getMessage();
}


$korido = null;
try {
    $sql_create_table_korido = "CREATE TABLE IF NOT EXISTS korido (
        id INT AUTO_INCREMENT PRIMARY KEY,
        palyaid INT,
        versenyzoid INT,
        korido TIME DEFAULT NULL,
        kor INT DEFAULT NULL,
        CONSTRAINT FK_korido_palya_id FOREIGN KEY (palyaid) REFERENCES palya (id),
        CONSTRAINT FK_korido_versenyzo_id FOREIGN KEY (versenyzoid) REFERENCES versenyzo (id)
    );";

    $korido = $conn->prepare($sql_create_table_korido);
    $korido->execute();
} catch (\Throwable $th) {
    echo "An error occurred: " . $th->getMessage();
}

//***************************************NOT WORKING*********************************************
// //upload data
// try {
//     $sqlFilePath = 'C:\Users\budai.bence\Desktop\OKJ\14sz\Aémafét\10.17_PHP_SQL\autoverseny\adatok.sql';
//     $command = "C:\xampp\mysql -h $servername -u $username -p$password $database < $sqlFilePath";
//     exec($command, $output, $returnVar);

//     if ($returnVar === 0) {
//         echo "Data imported successfully!";
//     } else {
//         echo "Error importing data. Error code: $returnVar";
//         print_r($output);
//     }
// } catch (PDOException  $e) {
//     echo "Error executing SQL command: " . $e->getMessage() . "<br>";
// }
//**********************************************************************************************/



//Query
$sql_query_1 = "SELECT versenyzo.nev FROM versenyzo ORDER BY versenyzo.eletkor";
$sql_query_2 = "SELECT COUNT(palya.nev) FROM palya";
$sql_query_3 = "SELECT csapat.nev AS csapat_nev, versenyzo.nev AS versenyzo_nev
                FROM csapat
                INNER JOIN versenyzo ON csapat.id = versenyzo.csapatid
                WHERE csapat.nev LIKE '%z%'
                ORDER BY csapat_nev ASC";

$sql_query_4 = "SELECT palya.nev AS palya_nev, versenyzo.nev AS versenyzo_nev, korido.korido
                FROM versenyzo
                INNER JOIN korido ON korido.versenyzoid = versenyzo.id
                INNER JOIN palya ON korido.palyaid = palya.id
                WHERE palya.orszag = 'Olaszország'
                ORDER BY korido.korido ASC";

// Execute and display

echo '<!DOCTYPE html>';
echo '<html lang="hu">';
echo '<head>';
echo '<meta charset="UTF-8">';
echo '<meta name="viewport" content="width=device-width, initial-scale=1.0">';
echo '<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">';
echo '<link rel="stylesheet" type="text/css" href="./style.css">';
echo '<title>Autó Verseny</title>';
echo '</head>';
echo '<body>';
echo '<h1 style="color: #007BFF; font-size: 24px; text-align: center;">Autóverseny</h1>';
echo '<div class="container">';
echo "<h3>Query 1: A résztvevők nevei életkor szerint rendezve</h3>";
$sql_query_1_stmt = $conn->prepare($sql_query_1);
$sql_query_1_stmt->execute();

echo "<div class='table-responsive' style='font-family: Arial, sans-serif; background-color: #f5f5f5;'>";
echo "<table class='table table-striped table-sm my-custom-table' style='font-family: Arial, sans-serif; background-color: #ffffff;'>";
echo "<thead><tr><th>Résztvevő neve</th></tr></thead>";
echo "<tbody>";

while ($row = $sql_query_1_stmt->fetch()) {
    echo "<tr>";
    echo "<td>" . $row['nev'] . "</td>";
    echo "</tr>";
}

echo "</tbody>";
echo "</table>";
echo "</div>";


echo "<h3>Query 2: A „nev” száma a „palya” táblázatban</h3>";
$sql_query_2_stmt = $conn->prepare($sql_query_2);
$sql_query_2_stmt->execute();
$count = $sql_query_2_stmt->fetchColumn();

echo "<div class='table-responsive' style='font-family: Arial, sans-serif; background-color: #f5f5f5;'>";
echo "<table class='table table-bordered table-sm my-custom-table' style='font-family: Arial, sans-serif; background-color: #ffffff;'>";

echo "<thead><tr><th>Száma</th></tr></thead>";
echo "<tbody>";
echo "<tr><td>" . $count . "</td></tr>";
echo "</tbody>";
echo "</table>";
echo "</div>";



echo "<h3>Query 3: Csapatok és résztvevők nevei (csapat.nev LIKE '%z%')</h3>";
$sql_query_3_stmt = $conn->prepare($sql_query_3);
$sql_query_3_stmt->execute();

echo "<div class='table-responsive' style='font-family: Arial, sans-serif; background-color: #f5f5f5;'>";
echo "<table class='table table-striped table-sm my-custom-table' style='font-family: Arial, sans-serif; background-color: #ffffff;'>";
echo "<thead><tr><th>Csapat</th><th>Résztvevő</th></tr></thead>";
echo "<tbody>";

while ($row = $sql_query_3_stmt->fetch()) {
    echo "<tr>";
    echo "<td>" . $row['csapat_nev'] . "</td>";
    echo "<td>" . $row['versenyzo_nev'] . "</td>";
    echo "</tr>";
}

echo "</tbody>";
echo "</table>";
echo "</div>";



echo "<h3>Query 4: Palyai Olaszország résztvevőinek nevei</h3>";
$sql_query_4_stmt = $conn->prepare($sql_query_4);
$sql_query_4_stmt->execute();

echo "<div class 'table-responsive' style='font-family: Arial, sans-serif; background-color: #f5f5f5;'>";
echo "<table class='table table-bordered table-hover table-sm my-custom-table' style='font-family: Arial, sans-serif; background-color: #ffffff;'>";
echo "<thead><tr><th>Track</th><th>Participant</th><th>Lap Time</th></tr></thead>";
echo "<tbody>";

while ($row = $sql_query_4_stmt->fetch()) {
    echo "<tr>";
    echo "<td>" . $row['palya_nev'] . "</td>";
    echo "<td>" . $row['versenyzo_nev'] . "</td>";
    echo "<td>" . $row['korido'] . "</td>";
    echo "</tr>";
}

echo "</tbody>";
echo "</table>";
echo "</div>";
echo "</div>";
echo '</body>';
echo '</html>';

?>
