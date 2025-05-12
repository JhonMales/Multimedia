<?php

include "dbConnection.php";
    #Mapeo de los datos
    #Sentencia sql
    # Obtener el primer registro del nuevo usuario
    $sqlSelect = "SELECT * FROM Jugador ORDER BY score DESC  LIMIT 5";
    $resultSelect = $pdo->query($sqlSelect);
    $newUsers = $resultSelect->fetchAll(PDO::FETCH_ASSOC);

    # Crear una respuesta con la información de los nuevos usuarios
    $data = array('newUsers' => $newUsers);
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();
?>