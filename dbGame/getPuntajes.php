<?php
include "dbConnection.php";


$sql = "SELECT correo , puntaje FROM usuarios ORDER by puntaje DESC LIMIT 7";
$sth = $pdo->query($sql);
$sth->setFetchMode(PDO::FETCH_ASSOC);
$result = $sth->fetchAll();

if(count($result) > 0) {
    foreach($result as $r) {
        echo $r['correo'], "\n";
        // , ".......................", $r['puntaje'], "\n"
    }
}

?>