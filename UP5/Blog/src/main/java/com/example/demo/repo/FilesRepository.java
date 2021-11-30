package com.example.demo.repo;

import com.example.demo.models.Files;
import com.example.demo.models.Post;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface FilesRepository extends CrudRepository<Files, Long> {
    List<Files> findByName(String name);
}
