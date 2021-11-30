package com.example.demo.repo;

import com.example.demo.models.Post;
import com.example.demo.models.Register;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface RegisterRepository extends CrudRepository<Register, Long> {
    List<Register> findByLogin(String title);
}
