<?php

try {
    $pdo = new PDO("mysql:host=localhost;dbname=BDvideoJuego", 'root', 'criss');
    // Establecer el modo de error a excepción
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
}
catch(PDOException $e) {
    
    exit();
}

// Cerrar la conexión al finalizar la operación

?>