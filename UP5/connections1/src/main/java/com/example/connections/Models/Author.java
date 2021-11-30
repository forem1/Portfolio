package com.example.connections.Models;

import javax.persistence.*;
import java.util.Collection;
import java.util.List;

@Entity
@Table(name = "author")
public class Author {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    private String name;
    @ManyToMany
    @JoinTable(name = "book_author",
            joinColumns = @JoinColumn(name = "author_id"),
            inverseJoinColumns = @JoinColumn(name = "book_id"))
    private List<Book> cities;

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<Book> getCities() {
        return cities;
    }

    public void setCities(List<Book> cities) {
        this.cities = cities;
    }

    public Author(String name) {
        this.name = name;
        this.cities = cities;
    }

    public Author() {
    }
}
