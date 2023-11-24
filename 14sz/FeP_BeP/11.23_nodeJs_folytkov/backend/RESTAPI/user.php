<?php

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
        $sql = "select * from User where userId = 1";
        $stmt = $pdo->prepare($sql);
        $stmt->execute();
        $data = $stmt->fetchAll(PDO::FETCH_ASSOC)[0];
    return;    
}

if ($_SERVER['REQUEST_METHOD'] == 'POST') {

    
}

