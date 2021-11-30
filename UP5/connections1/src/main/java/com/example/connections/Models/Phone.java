package com.example.connections.Models;

import javax.persistence.*;
import java.util.Collection;

@Entity
@Table(name = "phone")
public class Phone {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String phone;
    @OneToMany(mappedBy = "phone", fetch = FetchType.EAGER)
    private Collection<Human> humans;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getPhone() {
        return phone;
    }

    public void setPhone(String phone) {
        this.phone = phone;
    }

    public Collection<Human> getHumans() {
        return humans;
    }

    public void setHumans(Collection<Human> humans) {
        this.humans = humans;
    }

    public Phone(String phone) {
        this.phone = phone;
        this.humans = humans;
    }

    public Phone() {

    }
}
