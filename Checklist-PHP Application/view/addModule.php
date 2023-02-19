<?php 
    require "./model/header.php";
    require "./model/nav.php";
    include("./model/database_pdo.php");
?>

<h1>Add Module</h1>
<form method = "POST" enctype = "multipart/form-data">
   Course Code:<input type="text" name="course_code"><br>
   Assessment Type:<input type="text" name="assessment_type"><br>
   Assessment Date:<input type="text" name="assessment_date"><br>
   Assessment Time:<input type="text" name="assessment_time"><br>
   Assessment Status:<input type="text" name="assessment_status"><br>
    <input type = "submit" value = "update" name = "submit">
</form>
<?php 
if(isset($_POST['submit'])){
    $course_code = $_POST['course_code'];
    $assessment_type = $_POST['assessment_type'];
    $assessment_date = $_POST['assessment_date'];
    $assessment_time = $_POST['assessment_time'];
    $assessment_status = $_POST['assessment_status'];

    $table_name = "default_list_".$_COOKIE['user_name'];
    $insert_query = " INSERT INTO $table_name(id,course_code,assessment_type,assessment_date, assessment_time, assessment_status) 
    VALUES (default,'$course_code','$assessment_type',' $assessment_date','$assessment_time','$assessment_status'); ";
    $prepped_query = $db_con->prepare($insert_query);
    $success = $prepped_query->execute(); 
    if($success){
        echo "Successfully add a new module to database...";
    }
}
?>

<?php 
    require "./model/footer.php";
?>




