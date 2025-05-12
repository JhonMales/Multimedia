<?php

    include "dbConnection.php";
    #Mapeo de los datos
    $userName = $_POST['username']; 
    #Sentencia sql
    $sql = "SELECT usuario FROM Jugador WHERE usuario = '$userName' ";
    #Ejecucion de la sentencia sql
    $result = $pdo->query($sql);

    #Validacion, si retorna un registro bd ya existe
    if($result->rowCount() > 0){
        $data = array('done' => false, 'message' => "Ingreso exitoso...");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    } else{
        $sql = "INSERT INTO Jugador (usuario, score) VALUES ('$userName', 0)";
        #Ejecucion de la sentencia sql
        $pdo->query($sql);
        $data = array('done' => true, 'message' => "Usuario creado...");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();

    }
?>