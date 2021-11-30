package com.dryupin.warehouse.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;

@Entity
public class Component {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotEmpty(message = "Поле не может быть пустым")
    private String ComponentName;

    private String ComponentFullName;

    private String ComponentSerial;

    @NotEmpty(message = "Поле не может быть пустым")
    private String ComponentUnit;

    private String ComponentTag;

    @NotEmpty(message = "Поле не может быть пустым")
    private String ComponentGroupId;
    @NotEmpty(message = "Поле не может быть пустым")
    private String ComponentAmount;
    private String ComponentLocation;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getComponentName() {
        return ComponentName;
    }

    public void setComponentName(String componentName) {
        ComponentName = componentName;
    }

    public String getComponentFullName() {
        return ComponentFullName;
    }

    public void setComponentFullName(String componentFullName) {
        ComponentFullName = componentFullName;
    }

    public String getComponentSerial() {
        return ComponentSerial;
    }

    public void setComponentSerial(String componentSerial) {
        ComponentSerial = componentSerial;
    }

    public String getComponentUnit() {
        return ComponentUnit;
    }

    public void setComponentUnit(String componentUnit) {
        ComponentUnit = componentUnit;
    }

    public String getComponentTag() {
        return ComponentTag;
    }

    public void setComponentTag(String componentTag) {
        ComponentTag = componentTag;
    }

    public String getComponentGroupId() {
        return ComponentGroupId;
    }

    public void setComponentGroupId(String componentGroupId) {
        ComponentGroupId = componentGroupId;
    }

    public String getComponentAmount() {
        return ComponentAmount;
    }

    public void setComponentAmount(String componentAmount) {
        ComponentAmount = componentAmount;
    }

    public String getComponentLocation() {
        return ComponentLocation;
    }

    public void setComponentLocation(String componentLocation) {
        ComponentLocation = componentLocation;
    }

    public Component(String ComponentName, String ComponentFullName, String ComponentSerial, String ComponentUnit, String ComponentTag, String ComponentGroupId, String ComponentAmount, String ComponentLocation) {
        this.ComponentName = ComponentName;
        this.ComponentFullName = ComponentFullName;
        this.ComponentSerial = ComponentSerial;
        this.ComponentUnit = ComponentUnit;
        this.ComponentTag = ComponentTag;
        this.ComponentGroupId = ComponentGroupId;
        this.ComponentAmount = ComponentAmount;
        this.ComponentLocation = ComponentLocation;
    }

    public Component() {
    }
}
