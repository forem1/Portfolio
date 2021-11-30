package com.example.connections.Repo;

import com.example.connections.Models.Parent;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface ParentRepository extends CrudRepository<Parent, Long> {
    List<Parent> findByFio(String fio);
}
