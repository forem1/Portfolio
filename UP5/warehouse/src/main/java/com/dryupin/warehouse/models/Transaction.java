package com.dryupin.warehouse.models;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.validation.constraints.NotEmpty;

@Entity
public class Transaction {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotEmpty(message = "Поле не может быть пустым")
    private String ComponentId;

    @NotEmpty(message = "Поле не может быть пустым")
    private String Date;

    @NotEmpty(message = "Поле не может быть пустым")
    private String Different;

    @NotEmpty(message = "Поле не может быть пустым")
    private String StaffId;

    @NotEmpty(message = "Поле не может быть пустым")
    private String Place;

    private String Note;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getComponentId() {
        return ComponentId;
    }

    public void setComponentId(String componentId) {
        ComponentId = componentId;
    }

    public String getDate() {
        return Date;
    }

    public void setDate(String date) {
        Date = date;
    }

    public String getDifferent() {
        return Different;
    }

    public void setDifferent(String different) {
        Different = different;
    }

    public String getStaffId() {
        return StaffId;
    }

    public void setStaffId(String staffId) {
        StaffId = staffId;
    }

    public String getPlace() {
        return Place;
    }

    public void setPlace(String place) {
        Place = place;
    }

    public String getNote() {
        return Note;
    }

    public void setNote(String note) {
        Note = note;
    }


    public Transaction(String ComponentId, String Date, String Different, String StaffId, String Place, String Note) {
        this.ComponentId = ComponentId;
        this.Date = Date;
        this.Different = Different;
        this.StaffId = StaffId;
        this.Place = Place;
        this.Note = Note;
    }

    public Transaction() {
    }
}
