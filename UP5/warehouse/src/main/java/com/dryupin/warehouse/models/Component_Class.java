package com.dryupin.warehouse.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;

@Entity
public class Component_Class {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotEmpty(message = "Поле не может быть пустым")
    private String componentClassName;

    public Component_Class(String ComponentClassName) {
        this.componentClassName = ComponentClassName;
    }
    public Component_Class() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getComponentClassName() {
        return componentClassName;
    }

    public void setComponentClassName(String ComponentClassName) {
        ComponentClassName = ComponentClassName;
    }
}
