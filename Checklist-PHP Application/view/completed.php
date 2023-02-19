<?php 
    require "./model/header.php";
    require "./model/nav.php";
    include("./model/database_pdo.php");
?>

<h1>List of Completed Assessments</h1>
<!-- Print out the checkbox after reading from file -->
<form method = "POST" enctype = "multipart/form-data">
    <?php
    printCheckbox("Completed");
    ?>
    <input type = 'submit' value = 'update' name = 'submit'>
</form>

<?php
    $default_file_name = $_COOKIE['user_name'] . "_default.txt";
    $default_url = "./data/" . $_COOKIE['user_name']."/$default_file_name";
    //overwrite the file after clicking update based on user input
    if (isset($_POST['submit']) && isset($_POST['number'])) {
        //get all the user number and store inside a variable
        $numberArray = $_POST['number']; 
        overwriteData($numberArray, "Current",$default_url);
        $numUpdate = count($numberArray);
        echo "<br><div>The number of Updated assessments from current to completed are: $numUpdate</div>";
    }
?>

<?php 
    require "./model/footer.php";
?>