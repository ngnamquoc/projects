<?php
    //function to read the data file and print the checkbox
    function printCheckbox($searchValue=""){
        include("./model/database_pdo.php");
        $table_name = "default_list_".$_COOKIE['user_name'];
        //prepare and fetch the query
        $searching_query = " SELECT id,course_code,assessment_type,assessment_date, assessment_time from $table_name WHERE assessment_status='$searchValue'; ";
        $prepped_query = $db_con->prepare($searching_query);
        $prepped_query->execute();
        $sql_results = $prepped_query->fetchAll(); 
        //print the checkbox
        foreach ($sql_results as $result) { 
            $value=$result['id'].", ".$result['course_code'].", ".$result['assessment_type'].", ".$result['assessment_date'].", ".$result['assessment_time'];
            ?>
            <label for="<?php echo $result['id']?>"> <?php echo $value ?></label>
            <input type="checkbox" id="<?php echo $result['id']?>" value="<?php echo $result['id']?>" name="number[]"><br>
        <?php
        }
    }
    
    //function to rewrite the data file when user update
    function overwriteData($array, $changeValue="",$default_url){
        include("./model/database_pdo.php");
        foreach ($array as $number){ 
            //prepare and fetch the query
            $table_name = "default_list_".$_COOKIE['user_name'];
            $update_query = " UPDATE $table_name SET assessment_status = '$changeValue' WHERE id = '$number'; ";
            $prepped_query = $db_con->prepare($update_query);
            $prepped_query->execute();

            //next step, overwite data on the file as well
            $user_dir_temp = "./data/" . $_COOKIE['user_name']."/temporary.txt";
            $read_file = fopen($default_url, 'r');  //open for reading
            $write_file = fopen($user_dir_temp, 'w'); //open for writing
                while( $row = fgetcsv( $read_file)) 
                {  
                        if ($row[0] == $number) {
                            $row[5] = $changeValue;
                        }
                        fputcsv($write_file, $row);
                }
            fclose($read_file);
            fclose($write_file);
            unlink($default_url);
            rename($user_dir_temp, $default_url); 
           
         }
    }
 
    //function to get the uploaded file name
    function getUploadFileName(){
        return $_FILES['new_file']['name'];
    }

    //function to print the recently uploaded files 
    function printUploadedFiles($folder){
        echo "<ul>";
        for ($i = 2; $i < count($folder); $i++) { 
          echo "<li><a href = 'controller.php?page=upload&param=$folder[$i]'>$folder[$i]</a></li>";
        }
        echo "</ul>";
      }


      //function to rewrite the default list by new content of uploaded file
      function update_default_list($default_url){
        include("./model/database_pdo.php");
        //check if the default table with user_name in database exists or not, if not create a new one
        $table_name = "default_list_".$_COOKIE['user_name'];
        $select_query = " SELECT * from $table_name; ";
        $prepped_query = $db_con->prepare($select_query);
        $prepped_query->execute();
        $sql_results = $prepped_query->fetchAll(); 

        if(empty($sql_results)){ //default_table not exist
            $create_table_query = " CREATE TABLE f2396830_test.$table_name(  
                id int(4) NOT NULL PRIMARY KEY AUTO_INCREMENT
                ,course_code varchar(10) NOT NULL  
                ,assessment_type varchar(20) NOT NULL  
                ,assessment_date date NOT NULL  
                ,assessment_time varchar(8) NOT NULL  
                ,assessment_status varchar(10) NOT NULL);  ";
            $prepped_query = $db_con->prepare($create_table_query);
            $prepped_query->execute();

            $read_file = fopen($default_url, 'r');  //open the most recent upload file for reading

            while( $row = fgetcsv($read_file)) //iterate through each row
            {  
                //Insert new data from uploaded file
                $insert_query = " INSERT INTO $table_name(id,course_code,assessment_type,assessment_date, assessment_time, assessment_status) VALUES ('$row[0]','$row[1]','$row[2]','$row[3]','$row[4]','$row[5]'); ";
                $prepped_query = $db_con->prepare($insert_query);
                $prepped_query->execute();   
            }
            fclose($read_file);
        } else{ //case exist
            //Delete current data in default table
            $delete_query = " DELETE from $table_name; ";
            $prepped_query = $db_con->prepare($delete_query);
            $prepped_query->execute();
            $read_file = fopen($default_url, 'r');  //open the most recent upload file for reading
            
            while( $row = fgetcsv($read_file)) //iterate through each row
            {  
                //Insert new data to default database from uploaded file
                $insert_query = " INSERT INTO $table_name(id,course_code,assessment_type,assessment_date, assessment_time, assessment_status) VALUES ('$row[0]','$row[1]','$row[2]','$row[3]','$row[4]','$row[5]'); ";
                $prepped_query = $db_con->prepare($insert_query);
                $prepped_query->execute();   
            }
            fclose($read_file);
        }
      }
  
?>
      

