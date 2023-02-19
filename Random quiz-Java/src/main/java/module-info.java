module com.example.questionaire {
    requires javafx.controls;
    requires javafx.fxml;


    opens com.example.questionaire to javafx.fxml;
    exports com.example.questionaire;
}