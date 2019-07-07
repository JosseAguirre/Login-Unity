<?php
include "dbConnection.php";

$correo = $_POST['correo'];
$contaseña = hash('sha256', $_POST['contraseña']);

$sql = "SELECT correo FROM usuarios WHERE correo = '$correo' AND contraseña = '$contaseña'";
$result = $pdo->query($sql);

if($result->rowCount() > 0)
    {
        $data = array('done' => true, 'mensaje' => "Bienvenido");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    }
    else 
    {
        $data = array('done' => false, 'mensaje' => "Correo o contraseña incorrectos");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    }

?>