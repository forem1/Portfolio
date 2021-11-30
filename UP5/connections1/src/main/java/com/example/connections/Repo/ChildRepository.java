package com.example.connections.Repo;


import com.example.connections.Models.Child;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface ChildRepository extends CrudRepository<Child, Long> {
    Child findByChildNum(String childNum);
}
