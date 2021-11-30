package com.example.demo.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.Pattern;
import javax.validation.constraints.Size;

@Entity
public class Post {
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getTitle() {
        return title;
    }

    public void setTitle(String title) {
        this.title = title;
    }

    public String getAnons() {
        return anons;
    }

    public void setAnons(String anons) {
        this.anons = anons;
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)

    private Long id;

    @NotEmpty(message = "Поле не может быть пустым")
    @Size(min = 5, max=40, message = "Размер данного поля от 5 до 40 символов")
    private String title;

    @NotEmpty(message = "Поле не может быть пустым")
    @Size(min = 5, max=40, message = "Размер данного поля от 5 до 40 символов")
    private String anons;

    @NotEmpty(message = "Поле не может быть пустым")
    private String text;

    @Pattern(regexp = "^((25[0-5]|(2[0-4]|1[0-9]|[1-9]|)[0-9])(\\.(?!$)|$)){4}$",
            message = "Данное поле должно быть в формате 94.29.60.85")
    private String ipAddress;

    public Post(String title, String anons, String text) {
        this.title = title;
        this.anons = anons;
        this.text = text;
    }

    public Post() {
    }
}
