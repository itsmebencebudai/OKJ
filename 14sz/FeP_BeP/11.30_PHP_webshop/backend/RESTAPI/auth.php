<?php
if ($_SERVER['REQUEST_METHOD']  == 'OPTIONS') {
    return true;
}

$notAuthResources = [
    'GET' => ['user'],
    'POST' => [],
    'PUT' => [],
    'PATCH' => [],
    'DELETE' => []
];

if (in_array($resource,$notAuthResources[$_SERVER['REQUEST_METHOD']])) {
    return true;
}

$token = isset(apache_request_headers()['token']) ?  apache_request_headers()['token'] : null;
$stmt = $pdo->prepare('select userID from User where token = ?');
$stmt->execute([$token]);

if ($stmt->fetch(PDO::FETCH_ASSOC)) {
    return true;
}

http_response_code(401);
die("Azonosítási hiba");


