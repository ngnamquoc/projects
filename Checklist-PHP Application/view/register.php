<?php
ob_start();
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registration Page</title>
</head>
<body>
    <?php
    include("../model/database_pdo.php");
    require('../model/header.php');
    function test_input($data) {
      $data = trim($data);
      $data = stripslashes($data);
      $data = htmlspecialchars($data);
      return $data;
    }
    $nameErr = $emailErr = $passErr = "";
    //validate username
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
      if (empty($_POST["user_name"])) {
        $nameErr = "Name is required";
      } else {
        $user_name = test_input($_POST["user_name"]);
        if(!preg_match("/^[a-zA-Z-' ]*$/",$user_name)){
          $nameErr = "Only letters and white space allowed";
        } else if(strlen($user_name)<4 || strlen($user_name)>8){
          $nameErr = "Username must be between 4-8 characters";
        }
      }

      //validate password
      if (empty($_POST["user_pass"])) {
        $passErr = "Password is required";
      } else {
        //password must be more than 8 characters
        $user_pass = test_input($_POST["user_pass"]);
        if(strlen($user_pass)<= 8){
            $passErr = "Your password must be more than 8 characters";
        }
      }
      //validate email
      if (empty($_POST["user_email"])) {
        $emailErr = "Email is required";
      } else {
        $user_email = test_input($_POST["user_email"]);
        if (!filter_var($user_email, FILTER_VALIDATE_EMAIL)) {
          $emailErr = "Invalid email format"; 
        }
      }
    }
    $controller_url = 'https://'.$_SERVER['HTTP_HOST'].'/comp1230/assignments/assignment3/controller.php';
    ?>

    <h1>Registration Page</h1>
    <p><span class="error">* required field</span></p>
    <form method="POST" action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]);?>" >
        <title>Registration Form</title>
        <label for="user_name">User Name</label>
        <input type="text" id="user_name" name="user_name">
        <span class="error">* <?php echo $nameErr;?></span><br><br>

        <label for="user_pass">Password</label>
        <input type="password" id="user_pass" name="user_pass" >
        <span class="error">* <?php echo $passErr;?></span><br><br>

        <label for="user_email">Email</label>
        <input type="email" id="user_email" name="user_email">
        <span class="error">* <?php echo $emailErr;?></span><br><br>

        <input type="submit" name="submit" value="submit">
    </form>
    <a href="<?php echo $controller_url ?>"><input type="submit" value="Back To Login Page"></a>


    <?php
    if (isset($_POST['submit'])) {
      $search_query = " SELECT * FROM user_credentials WHERE user_name = '$user_name' OR user_email = '$user_email'; ";
      $prepped_query = $db_con->prepare($search_query);
      $prepped_query->execute();
      $result = $prepped_query->fetchAll();
      
      //case user does not exist and no error
      if($result == null && $nameErr == null && $result == null) {
        $insert_query = " INSERT INTO user_credentials VALUES(DEFAULT,'$user_name','$user_pass','$user_email','not activated'); ";
        $prepped_query = $db_con->prepare($insert_query);
        $success = $prepped_query->execute();
        if ($success) {
          setcookie('user_name_not_validate',"$user_name",strtotime('+30 days'),'/');
          echo "<br><div class='success'>Successfully registered the account!</div>";
          //send the activation email to user
          $url = 'https://'.$_SERVER['HTTP_HOST'].'/comp1230/assignments/assignment3/controller.php?page=login&status=active';
          $message="Hello $user_name!\nyour account has been successfully created. Please click the link below to active your account: \n$url";
          mail("$user_email", "ACTIVATE YOUR ACCOUNT", $message);
        } 
      }
      //case user exist
      if($result != null){
        echo "<br><div class='error'>Username $user_name or email $user_email is already existed!</div>";
      } 
    }
    ob_end_flush();
    ?>
</body>
</html>

<?php 
    require "../model/footer.php";
?>