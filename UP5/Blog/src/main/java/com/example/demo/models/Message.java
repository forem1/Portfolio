package com.example.demo.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.Size;

@Entity
public class Message {

    public Message() {
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotEmpty(message = "Поле не может быть пустым")
    @Size(min = 1, max=40, message = "Размер данного поля от 1 до 40 символов")
    private String toMes;

    @NotEmpty(message = "Поле не может быть пустым")
    @Size(min = 1, max=40, message = "Размер данного поля от 1 до 40 символов")
    private String fromMes;

    @NotEmpty(message = "Поле не может быть пустым")
    private String textMes;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getToMes() {
        return toMes;
    }

    public void setToMes(String toMes) {
        this.toMes = toMes;
    }

    public String getFromMes() {
        return fromMes;
    }

    public void setFromMes(String fromMes) {
        this.fromMes = fromMes;
    }

    public String getTextMes() {
        return textMes;
    }

    public void setTextMes(String textMes) {
        this.textMes = textMes;
    }

    public Message(String toMes, String fromMes, String textMes) {
        this.toMes = toMes;
        this.fromMes = fromMes;
        this.textMes = textMes;
    }
}
