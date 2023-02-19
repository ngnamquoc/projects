<?php

include("./model/database_pdo.php");
   
//unlock after 3 minutes after 3 wrong attempts
if(isset($_SESSION['locked'])){
    $waiting_time = time() - $_SESSION['locked'];
    if($waiting_time > 60){
        unset($_SESSION['locked']);
        unset($_SESSION['login_attempts']);
    }
}

if(isset($_POST['submit'])){
     //checking if the user exists in the database
     $user_name = trim($_POST['user_name']);
     $user_pass=trim($_POST['user_password']);
     $searching_query = " SELECT * from user_credentials WHERE user_name = '$user_name' AND user_pass = '$user_pass'; ";
     $prepped_query = $db_con->prepare($searching_query);
     $success = $prepped_query->execute();
     $sql_results = $prepped_query->fetchAll();

    //if the inputs are not correct
    if($sql_results == null){
        $_SESSION['login_attempts'] += 1;
    }

    //if all the inputs are correct
    if($sql_results){
        //set up the directing url
        $url = 'https://'.$_SERVER['HTTP_HOST'].'/comp1230/assignments/assignment3/controller.php?page=current';
        //set the user_name cookie
        $user_name_value = $_POST['user_name'];
        setcookie('user_name',"$user_name_value",strtotime('+30 days'),'/');

        //when the user clicked the link sent by email and comeback to login page
        if($_GET['status'] == 'active' && isset($_COOKIE['user_name_not_validate'])){
            $user_name_not_active = $_COOKIE['user_name_not_validate'];
            //update account status of the new account
            $update_query = " UPDATE user_credentials SET account_status = 'activated' WHERE user_name = '$user_name_not_active'; ";
            $prepped_query = $db_con->prepare($update_query);
            $prepped_query->execute();
            //delete the activated cookie
            unset($_COOKIE['user_name_not_validate']); 
            setcookie('user_name_not_validate',null,strtotime('-1 days'),'/');
        }
        //set the session key and value
        $_SESSION['user_key'] = $user_name_value;
        header("Location: $url");
        exit;
    } 
}

?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Page</title>
</head>
<?php 
$register_url = 'https://'.$_SERVER['HTTP_HOST'].'/comp1230/assignments/assignment3/view/register.php';
?>
<body>
    <form class="box" method="POST" autocomplete="on">
        <h1>Login Page</h1>
        <input type="text" id="user_name" name="user_name" placeholder="username" 
        value="<?php if (isset($_COOKIE['user_name'])) {echo ($_COOKIE['user_name']);}?>"><br>
        <input type="password" id="user_password" name="user_password" placeholder="password"><br>
        <?php 
        //lock the login page after 3 failed attempts
            if($_SESSION['login_attempts']>2){
                echo "<div>Please wait 3 minutes</div>";
                $_SESSION['locked'] = time();
            }else{ ?>
                <input type="submit" name="submit" value="Login"> 
                <?php
            }
        ?>
        
    </form>
    <a href="<?php echo $register_url ?>"><input type="submit" value="Register An Account"></a>
    
    <?php  
        //print the message if the user credentials are not correct
        if(isset($_POST['submit'])){
            if($sql_results == null){
                $error_message = "<div id='error_message'>User name or password not correct</div>";
                echo $error_message;
            } 
        }
    ?>  
</body>
</html>

<?php 
    require "./model/footer.php";
?>




