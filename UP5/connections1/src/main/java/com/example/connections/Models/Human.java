package com.example.connections.Models;

import javax.persistence.*;

@Entity
@Table(name = "human")
public class Human {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String fio;

    @ManyToOne(optional = false, cascade = CascadeType.ALL)
    @JoinColumn(name="phone_id")
    private Phone phone;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getFio() {
        return fio;
    }

    public void setFio(String fio) {
        this.fio = fio;
    }

    public Phone getPhone() {
        return phone;
    }

    public void setPhone(Phone phone) {
        this.phone = phone;
    }

    public Human(String fio, Phone phone) {
        this.fio = fio;
        this.phone = phone;
    }

    public Human() {
    }
}
