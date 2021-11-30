package com.example.connections.Repo;

import com.example.connections.Models.Phone;
import org.springframework.data.repository.CrudRepository;

public interface PhoneRepository extends CrudRepository<Phone, Long> {
    Phone findByPhone(String phone);
}
