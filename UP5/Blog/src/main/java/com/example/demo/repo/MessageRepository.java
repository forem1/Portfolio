package com.example.demo.repo;

import com.example.demo.models.Message;
import com.example.demo.models.Post;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface MessageRepository extends CrudRepository<Message, Long> {
    List<Message> findByTextMesContaining(String message);
}
