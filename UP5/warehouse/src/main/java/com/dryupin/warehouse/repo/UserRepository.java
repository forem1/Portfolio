package com.dryupin.warehouse.repo;

import com.dryupin.warehouse.models.User;
import org.springframework.data.jpa.repository.JpaRepository;

public interface UserRepository extends JpaRepository<User, Long> {
    User findByUsername(String username);
}
