<?php 
    //Connect to sql server
    $db_info = 'mysql:host=127.0.0.1;dbname=f2396830_test';
    $username = 'f2396830';
    global $secret_pass;
    $secret_pass="Aa17092016>";
    $password = $secret_pass;

    try {
        $db_con = new PDO($db_info,$username,$password);
    } catch (PDOException $e) {
        $error_message = $e->getMessage();
        echo "PDO Database is not connected: $error_message <br>";
        exit();
    }

?>