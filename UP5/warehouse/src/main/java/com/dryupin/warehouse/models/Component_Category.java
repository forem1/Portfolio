package com.dryupin.warehouse.models;

import javax.persistence.*;
import javax.validation.constraints.NotEmpty;
import java.util.Collection;

@Entity
public class Component_Category {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotEmpty(message = "Поле не может быть пустым")
    private String componentCategoryName;

    @NotEmpty(message = "Поле не может быть пустым")
    private String componentCategoryClassId;

    public Component_Category(String ComponentCategoryName, String ComponentCategoryClassId) {
        this.componentCategoryName = ComponentCategoryName;
        this.componentCategoryClassId = ComponentCategoryClassId;
    }
    public Component_Category() {
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getComponentCategoryName() {
        return componentCategoryName;
    }

    public void setComponentCategoryName(String componentCategoryName) {
        this.componentCategoryName = componentCategoryName;
    }

    public String getComponentCategoryClassId() {
        return componentCategoryClassId;
    }

    public void setComponentCategoryClassId(String componentCategoryClassId) {
        this.componentCategoryClassId = componentCategoryClassId;
    }
}
