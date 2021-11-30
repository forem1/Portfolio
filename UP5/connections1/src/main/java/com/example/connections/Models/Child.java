package com.example.connections.Models;

import javax.persistence.*;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Pattern;
import javax.validation.constraints.PositiveOrZero;

@Entity
@Table(name = "child")
public class Child {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String childNum;
    @OneToOne(optional = false, mappedBy = "child")
    private Parent owner;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getChildNum() {
        return childNum;
    }

    public void setChildNum(String childNum) {
        this.childNum = childNum;
    }

    public Parent getOwner() {
        return owner;
    }

    public void setOwner(Parent owner) {
        this.owner = owner;
    }

    public Child(String childNum) {
        this.childNum = childNum;
        this.owner = owner;
    }

    public Child() {
    }
}
