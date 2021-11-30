package com.dryupin.warehouse.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;

@Entity
public class Component_Group {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotEmpty(message = "Поле не может быть пустым")
    private String componentGroupName;

    @NotEmpty(message = "Поле не может быть пустым")
    private String componentGroupCategoryId;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getComponentGroupName() {
        return componentGroupName;
    }

    public void setComponentGroupName(String componentGroupName) {
        this.componentGroupName = componentGroupName;
    }

    public String getComponentCategoryCategoryId() {
        return componentGroupCategoryId;
    }

    public void setComponentCategoryCategoryId(String componentCategoryCategoryId) {
        this.componentGroupCategoryId = componentCategoryCategoryId;
    }

    public Component_Group(String ComponentGroupName, String ComponentGroupCategoryId) {
        this.componentGroupName = ComponentGroupName;
        this.componentGroupName = ComponentGroupCategoryId;
    }
    public Component_Group() {
    }
}
