<?php

try{
    $pdo = new PDO('mysql:host=localhost;dbname=juego', 'unity', '12345');
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    $pdo->exec('SET NAMES "utf8"');
}
catch(PDOExeption $e){
    echo "Error conectando con la base de datos", $e->getMessage();
    exit();
}

?>