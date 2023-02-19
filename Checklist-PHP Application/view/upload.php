<?php 
    require "./model/header.php";
    require "./model/nav.php";
    include("./model/database_pdo.php");
?>
<h1>Upload Assessments File</h1>

<form method="POST" enctype="multipart/form-data">
  <label for="new_file">Upload a file:</label>
  <input type="file"  accept=".csv,.txt" id="new_file" name="new_file"> 
  <br><input type="submit" value="Upload" name="submit"> 
  <p>CSV file must be in the following format - id, course_name, assessment_name, date, time, status [Completed/Current]</p>
  <?php
    //get the uploading file name and store inside a variable
    $fileName = getUploadFileName();
    //set the path for the uploading file
    $user_dir = getcwd() . "/data/" . $_COOKIE['user_name'];
    $dataDic = getcwd() . "/data/" . $_COOKIE['user_name']."/".$fileName;
    $default_file_name = $_COOKIE['user_name'] . "_default.txt";
    $default_url = "./data/" . $_COOKIE['user_name']."/$default_file_name";


    if (isset($_POST['submit'])) {
        $error_count = false;
        $cell_error_count = false;
        //create a new data directory for first-time user
        if (!file_exists($user_dir)) {
          mkdir($user_dir, 0777, true);
        }
        //check if the file exists or not
        if (file_exists($dataDic)) {
            echo "<div class='error'>The file name exists, please try again! </div> <br>";
          }else{ //if not exist
            move_uploaded_file($_FILES['new_file']['tmp_name'], $dataDic);
          }
      
        //***UPLOADED FILE VALIDATION***
        $whole_string = file_get_contents("$dataDic");
        $sub_string = ",";
        //comma seperated or not
        if(strpos($whole_string,$sub_string) == false){
          $error_count = true; 
          echo "<div class='error'> Please upload the file with comma separated! </div> <br>";
        } 
        //contains special characters
        if(strpos($whole_string,"<") == true || strpos($whole_string,">") == true || strpos($whole_string,"?") == true
        || strpos($whole_string,"*") == true){
          $error_count = true; 
          echo "<div class='error'> These characters: <,>,?,* are not allowed in uploaded file </div> <br>";
        } 
        //cells' format checking
        $status_array = array("Completed","Current");
        $file_handler = fopen($dataDic, 'r');
        while ($row = fgetcsv($file_handler)) {
          if (count($row) != 6 or is_numeric($row[0]) != 1 or strlen($row[1]) != 8 or is_string($row[2]) != 1 or in_array($row[5], $status_array) == false) {
            $cell_error_count = true;
          }
        }
        if($cell_error_count == true){echo "<div class='error'> The file cells's format of the file is not correct </div> <br>";}
        fclose($file_handler);

        //if there is any error occurs, delete the file
        if($error_count == true or $cell_error_count == true){
          unlink($dataDic);
        } else{
          //check if the username_default.txt created in user_folder or not, if not create a new one
          if(!file_exists($default_url)){
            $file_handler = fopen($default_url,"w") or die("Unable to open file!");
            fclose($file_handler);
          }
          //overwrite the current indexing data file by the uploaded file
          copy($dataDic,$default_url);

          $filename_without_ext = substr($fileName, 0, strrpos($fileName, "."));
          $user_name = $_COOKIE['user_name']; //get the user name by cookies 
          $table_name = $filename_without_ext."_".$user_name;

          $select_query = " SELECT * from $table_name;  ";
          $prepped_query = $db_con->prepare($select_query);
          $prepped_query->execute();
          $sql_results = $prepped_query->fetchAll(); 

          //if not, create a new table and insert new data
          if(empty($sql_results)){  
            $create_table_query = " CREATE TABLE f2396830_test.$table_name(  
              id int(4) NOT NULL  
              ,course_code varchar(10) NOT NULL  
              ,assessment_type varchar(20) NOT NULL  
              ,assessment_date date NOT NULL  
              ,assessment_time varchar(8) NOT NULL  
              ,assessment_status varchar(10) NOT NULL);  ";
            $prepped_query = $db_con->prepare($create_table_query);
            $prepped_query->execute();

            //it scans the uploaded file and insert new row 
            $read_file = fopen($dataDic, 'r');  
            while( $row = fgetcsv($read_file)) 
            {  
                $insert_query = " INSERT INTO $table_name(id,course_code,assessment_type,assessment_date, assessment_time, assessment_status) VALUES ('$row[0]','$row[1]','$row[2]','$row[3]','$row[4]','$row[5]'); ";
                $prepped_query = $db_con->prepare($insert_query);
                $prepped_query->execute();   
            }
            fclose($read_file);
          } 
        }
    }
  ?>
</form>

<hr>
<h2>Files Previously Uploaded (Now in data Folder)</h2>

<?php
  //scan the user_data directory and store into a variable as an array
  $data_directory = "./data/" . $_COOKIE['user_name'];
  $user_data_directory = scandir($data_directory);
  printUploadedFiles($user_data_directory); 

  //Check if the user click to the link by the $_GET method
  if(isset($_GET['param'])){
    //set the path for the clicked item
    $click_file_name = $_GET['param'];
    $clickedFile = $data_directory . "/" . $click_file_name;
    copy($clickedFile,$default_url);
    update_default_list($default_url);
  }
  //update default list using uploaded file
  update_default_list($default_url);
  require "./model/footer.php";
?>

