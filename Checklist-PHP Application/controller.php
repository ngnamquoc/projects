<?php
    //use the session to force the user to log in before accessing any page if user does not log in
    session_start();
    if(!isset($_SESSION['user_key']) && $_GET['page'] != 'registration'){
        $_GET['page'] = 'login';
    } 
    //default view is login page
    if (!$_GET['page']) $_GET['page'] = 'login';

    //Control the 6 views
    if(isset($_GET['page'])){
        switch ($_GET['page']) {
            case 'login':
                include "./view/login.php";
                break;
            case 'logout':
                session_destroy();
                include "./view/login.php";
                break;
            case 'completed':
                require "./model/functions.php";
                include "./view/completed.php";
                break;
            case 'upload':
                require "./model/functions.php";
                include "./view/upload.php";
                break;
            case 'current':
                require "./model/functions.php";
                include "./view/current.php";
                break;
            case 'addModule':
                require "./model/functions.php";
                include "./view/addModule.php";
                break;
        }
    }
?>
