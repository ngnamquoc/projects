package com.example.questionaire;

import java.util.HashMap;
import java.util.Map;

public class Question {
    private String question;
    private String[] mca;
    private String userAnswer;
    private String correctAnswer;

    static int score = 0;

    public Question(String question, String[] mca,String correctAnswer) {
        this.question = question;
        this.mca = mca;
        this.userAnswer = "X";
        this.correctAnswer = correctAnswer;
    }

    public String getQuestion() {
        return question;
    }

    public void setQuestion(String question) {
        this.question = question;
    }

    public Map<String, String> getMcaHashMap() {
        String[] letters = {"A","B","C","D"};
        Map<String, String> hashMap = new HashMap<>();
        for (int i = 0; i < mca.length; i++) {
            hashMap.put(mca[i],letters[i]);
        }
        return hashMap;
    }

    public String[] getMca() {
        return mca;
    }

    public String getCorrectAnswer() {
        return correctAnswer;
    }

    public void setCorrectAnswer(String correctAnswer) {
        this.correctAnswer = correctAnswer;
    }

    public void setMca(String[] mca) {
        this.mca = mca;
    }

    public String getUserAnswer() {
        return userAnswer;
    }

    public void setUserAnswer(String userAnswer) {
        this.userAnswer = userAnswer;
    }
}
