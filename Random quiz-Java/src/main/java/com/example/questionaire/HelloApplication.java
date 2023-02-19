package com.example.questionaire;

import javafx.application.Application;
import javafx.event.ActionEvent;
import javafx.event.EventHandler;
import javafx.geometry.HPos;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Node;
import javafx.scene.Scene;
import javafx.scene.control.*;
import javafx.scene.layout.Border;
import javafx.scene.layout.GridPane;
import javafx.scene.paint.Paint;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.TextAlignment;
import javafx.stage.Stage;

import java.io.*;
import java.util.*;
import java.util.stream.Stream;


public class HelloApplication extends Application {
    @Override

    public void start(Stage stage) throws IOException {

        //---------------- Components --------------------------
        Label instructions1 = new Label("You should answer the following questions.");
        Label instructions2 = new Label("Select a single answers from the four choices.");
        instructions1.setFont(Font.font("Arial", FontWeight.BOLD, 15));
        instructions2.setFont(Font.font("Arial", FontWeight.BOLD, 15));
        Label userName = new Label("Student's Name: ");
        TextField userNameInput = new TextField();
        Label totalGrade = new Label("");
        Label avg = new Label("");
        totalGrade.setBorder(Border.stroke(Paint.valueOf("blue")));
        totalGrade.setPrefWidth(120);
        avg.setBorder(Border.stroke(Paint.valueOf("blue")));
        avg.setPrefWidth(120);
        avg.setTextAlignment(TextAlignment.CENTER);


        //------------------Buttons
        Button submitButton = new Button("Submit");
        submitButton.setPrefWidth(120);
        Button calculateGrade = new Button("Calculate Grade");
        calculateGrade.setPrefWidth(120);
        Button calculateAvg = new Button("Calculate Average");
        calculateAvg.setPrefWidth(120);

        // ----------------- Layout------------------
        GridPane grid = new GridPane();
        grid.setPadding(new Insets(10));
        grid.setVgap(5);
        grid.setHgap(10);
        grid.add(instructions1, 0, 0,2,1);
        grid.add(instructions2, 0, 1,2,1);
        grid.add(userName, 0, 2);
        grid.add(userNameInput, 1, 2);





        // ------- Read from file  ---------------
        File file = new File("exam.txt");
        Scanner keyboard = new Scanner(file);
        ArrayList<Question> questions = new ArrayList<Question>();

        int col = 0;
        int row = 3;

        ToggleGroup q1 = new ToggleGroup();
        ToggleGroup q2 = new ToggleGroup();
        ToggleGroup q3 = new ToggleGroup();
        ToggleGroup q4 = new ToggleGroup();
        ToggleGroup q5 = new ToggleGroup();


        // Loop for creating Question objects and storing them in a ArrayList
        while (keyboard.hasNext()){
            String[] temp_arr = keyboard.nextLine().split(",");
            String[] mca = {temp_arr[1],temp_arr[2],temp_arr[3],temp_arr[4]};
            Question temp_question = new Question(temp_arr[0], mca,temp_arr[5]);
            questions.add(temp_question);
        }



        int i = 0;

        // Shuffles the ArrayList of questions
        Collections.shuffle(questions);
        List<Question> questionsToShow = questions.subList(0,5);


        for (Question question:questionsToShow
             ) {
            Label questionLabel = new Label(question.getQuestion());
            grid.add(questionLabel,col,row,2,1);
            row++;
            for (String option:question.getMca()
            ) {
                RadioButton mca_option = new RadioButton(option);
                grid.add(mca_option,col,row);
                mca_option.setToggleGroup(q1);
                row++;


                if(i < 4){
                    mca_option.setToggleGroup(q1);
                    i++;
                } else if (i >= 4 && i<8) {
                    mca_option.setToggleGroup(q2);
                    i++;
                }else if (i >= 8 && i<12) {
                    mca_option.setToggleGroup(q3);
                    i++;
                }else if (i >= 12 && i<16) {
                    mca_option.setToggleGroup(q4);
                    i++;
                }else if (i >= 16) {
                    mca_option.setToggleGroup(q5);
                    i++;
                }

            }
        }


        //add submit button
        grid.add(submitButton,col,row);
        row++;
        grid.add(calculateGrade,col,row);
        col++;
        grid.add(totalGrade,col,row);
        col--;
        row++;
        grid.add(calculateAvg,col,row);
        col++;
        grid.add(avg,col,row);
        //Add event lister for clicking submit button action
        submitButton.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent actionEvent) {
                if (!userNameInput.getText().isEmpty() || !userNameInput.getText().isBlank()){
                    int temp_score = 0;
                    //get the username, chosen value from user
                    RadioButton chk1 = (RadioButton)q1.getSelectedToggle(); // Cast object to radio button
                    RadioButton chk2 = (RadioButton)q2.getSelectedToggle();
                    RadioButton chk3 = (RadioButton)q3.getSelectedToggle();
                    RadioButton chk4 = (RadioButton)q4.getSelectedToggle();
                    RadioButton chk5 = (RadioButton)q5.getSelectedToggle();
                    RadioButton[] arr_rb = {chk1,chk2,chk3,chk4,chk5};


                    for (int j = 0; j < questionsToShow.size(); j++) {
                        try {
                            questionsToShow.get(j).setUserAnswer(questionsToShow.get(j).getMcaHashMap().get(arr_rb[j].getText()));
                            if (questionsToShow.get(j).getUserAnswer().equals(questionsToShow.get(j).getCorrectAnswer())){
                                temp_score += 20;

                            }else {
                                temp_score -= 5;
                            }
                            Question.score = temp_score;
                        }catch (NullPointerException e){

                        }
                    }
                    if (Question.score < 0 ){
                        Question.score = 0;
                    }

                    // Write to the text file
                    String out = "";
                    out += userNameInput.getText();
                    out += " ";
                    for (Question q:questionsToShow
                    ) {
                        out += q.getUserAnswer();
                    }
                    out += " ";
                    out += Question.score;


                    try {
                        FileWriter result = new FileWriter("result.txt",true);
                        result.append(out + "\n");
                        result.close();

                    } catch (IOException e) {
                        throw new RuntimeException(e);
                    }

                }else {
                    Alert alr = new Alert(Alert.AlertType.ERROR);
                    alr.setTitle("Empty name field");
                    alr.setContentText("Must fill the name field to submit!");
                    alr.show();
                }

            }
        });


        calculateGrade.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent actionEvent) {
                totalGrade.setText(Integer.toString(Question.score));
            }
        });

        calculateAvg.setOnAction(new EventHandler<ActionEvent>() {
            @Override
            public void handle(ActionEvent actionEvent){
                int totalScore = 0;
                int numOfUsers = 0;
                FileReader resultFile = null;
                try {
                    resultFile = new FileReader("result.txt");
                } catch (FileNotFoundException e) {
                    throw new RuntimeException(e);
                }
                Scanner averageScoresData = new Scanner(resultFile);
                while (averageScoresData.hasNext()){
                    String[] temp_arr = averageScoresData.nextLine().split(" ");
                    totalScore += Integer.parseInt(temp_arr[2]);
                    numOfUsers++;
                }

                int avgScore = totalScore/numOfUsers;
                avg.setText(Integer.toString(avgScore));

            }
        });




        //---------- Stage ------------------------
        Scene scene = new Scene(grid);
        stage.setScene(scene);
        stage.setWidth(550);
        stage.setTitle("Multiple Choice Exam");
        stage.show();
    }



    public static void main(String[] args) throws FileNotFoundException {

        launch();


    }
}