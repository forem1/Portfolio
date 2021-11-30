package com.dryupin.warehouse.controllers;

import com.dryupin.warehouse.models.Role;
import com.dryupin.warehouse.models.User;
import com.dryupin.warehouse.repo.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;

import java.util.Collections;

@Controller
public class RegistrationController {
    @Autowired
    private UserRepository UserRepository;

    @GetMapping("/registration")
    public String registration() {
        return "registration";
    }

    @PostMapping("/registration")
    public String addUser(User user, Model model) {
        User userFromDb = UserRepository.findByUsername(user.getUsername());
        if (userFromDb != null) {
            model.addAttribute("message", "Такой пользователь уже существует");
            return "registration";
        }

        user.setActive(true);
        user.setRoles(Collections.singleton(Role.USER));
        user.setPassword(user.getPassword());
        UserRepository.save(user);
        return "redirect:/login";
    }
}
