package com.example.demo.repo;

import com.example.demo.models.Mood;
import com.example.demo.models.Post;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface MoodRepository extends CrudRepository<Mood, Long> {
    List<Mood> findByMoodContaining(String mood);
}
