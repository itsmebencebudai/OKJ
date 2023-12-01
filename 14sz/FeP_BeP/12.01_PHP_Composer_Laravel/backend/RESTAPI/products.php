<?php

// Adatbázis kapcsolódás
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "webshop_tanar3";

$conn = new mysqli($servername, $username, $password, $dbname);

if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

// GET - Összes termék lekérdezése
if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $sql = "SELECT * FROM products";
    $result = $conn->query($sql);

    $products = array();

    if ($result->num_rows > 0) {
        while ($row = $result->fetch_assoc()) {
            $products[] = $row;
        }
    }

    echo json_encode($products);
}

// POST - Új termék hozzáadása
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $data = json_decode(file_get_contents("php://input"), true);

    $name = $data['productName'];
    $price = $data['price'];
    $description = $data['description'];

    $sql = "INSERT INTO products (productName,description, price) VALUES ('$name','$description','$price')";
    $result = $conn->query($sql);

    if ($result === TRUE) {
        echo "New product added successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

// PUT - Termék frissítése
if ($_SERVER['REQUEST_METHOD'] === 'PUT') {
    parse_str(file_get_contents("php://input"), $data);

    $id = $data['productID'];
    $name = $data['productName'];
    $price = $data['price'];

    $sql = "UPDATE products SET productName='$name', price='$price' WHERE productID='$id'";
    $result = $conn->query($sql);

    if ($result === TRUE) {
        echo "Product updated successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

// DELETE - Termék törlése
if ($_SERVER['REQUEST_METHOD'] === 'DELETE') {
    parse_str(file_get_contents("php://input"), $data);

    $id = $data['productID'];

    $sql = "DELETE FROM products WHERE productID='$id'";
    $result = $conn->query($sql);

    if ($result === TRUE) {
        echo "Product deleted successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

$conn->close();

?>
