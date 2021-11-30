package com.example.demo.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.Size;

@Entity
public class Register {
    public String getLogin() {
        return login;
    }

    public void setLogin(String login) {
        this.login = login;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)

    private Long id;
    @NotEmpty(message = "Поле не может быть пустым")
    @Size(min = 3, max=40, message = "Размер данного поля от 3 до 40 символов")
    private String login;

    @NotEmpty(message = "Поле не может быть пустым")
    @Size(min = 6, max=100, message = "Размер данного поля от 6 до 100 символов")
    private String password;

    public Register(String login, String password) {
        this.login = login;
        this.password = password;
    }

    public Register() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }
}
