<?php

$params = explode('=', $_SERVER['QUERY_STRING']);

if (!isset($params[1])) {
    if ($_SERVER['REQUEST_METHOD'] == 'GET') {
        $sql = "select * from User";
        $stmt = $pdo->prepare($sql);
        $stmt->execute();
        $data = $stmt->fetchAll(PDO::FETCH_ASSOC);
        return;
    }
}

if ($_SERVER['REQUEST_METHOD'] == 'POST') {
    $sql = "select * from User where userID = ?";
    $stmt = $pdo->prepare($sql);
    $stmt->execute([$params[1]]);
    $data = $stmt->fetchAll(PDO::FETCH_ASSOC)[0];
    return;
}

$data = json_decode(file_get_contents('php://input')) !== null ? json_decode(file_get_contents('php://input')) : null;

if ($data) {
    if ($_SERVER['REQUEST_METHOD'] == 'POST') {
        $data = json_decode(file_get_contents('php://input'));
        $stmt = $pdo->prepare('insert into User values(null,?,?,?,?,null)');
        $stmt->execute([$data->name, $data->email, $data->password, $data->accountNumber]);
        var_dump($stmt);
        return $data;
    }
} else {
    http_response_code(400);
    die("Nem megfelőlen kitöltött adat");
}

