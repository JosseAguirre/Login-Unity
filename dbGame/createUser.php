<?php
    include "dbConnection.php";

    $correo = $_POST['correo'];
    $paralelo = $_POST['paralelo'];
    $contaseña = hash('sha256', $_POST['contraseña']);

    $sql = "SELECT correo FROM usuarios WHERE correo = '$correo'";
    $result = $pdo->query($sql);

    if($result->rowCount() > 0)
    {
        $data = array('done' => false, 'mensaje' => "Error, ese correo ya esta registrado");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    }
    else 
    {
        $sql = "INSERT INTO usuarios SET correo  = '$correo', paralelo = '$paralelo', contraseña = '$contaseña'";
        $pdo->query($sql);

        $data = array('done' => true, 'mensaje' => "Usuario creado");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    }
?>