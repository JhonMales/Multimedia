<?php
    include "dbConnection.php";
    #Mapeo de los datos
    #$userName = $_POST['username'];
    #$userScore =  $_POST['userScore'];
    $userName = "Miguel";
    $userScore = 10;
    #Sentencia sql
    // Sentencia SQL para actualizar el registro con el ID proporcionado
    $sql = "UPDATE jugador SET score = '$userScore' WHERE usuario = '$userName'";
    #Ejecucion de la sentencia sql
    $pdo->query($sql);
    $data = array('done' => true, 'message' => "Score modificado...");
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();
?>