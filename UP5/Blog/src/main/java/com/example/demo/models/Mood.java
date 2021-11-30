package com.example.demo.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.Size;

@Entity
public class Mood {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)

    private Long id;
    @NotEmpty(message = "Поле не может быть пустым")
    private String date;
    @NotEmpty(message = "Поле не может быть пустым")
    @Size(min = 1, max=100, message = "Размер данного поля от 1 до 100 символов")
    private String mood;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getDate() {
        return date;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public String getMood() {
        return mood;
    }

    public void setMood(String mood) {
        this.mood = mood;
    }

    public Mood(String date, String mood) {
        this.date = date;
        this.mood = mood;
    }

    public Mood() {
    }
}
