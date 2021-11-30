package com.mpt.Demo.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;

import javax.servlet.http.HttpServletRequest;

@Controller
@RequestMapping("/first")
public class HelloController {
    @GetMapping("/hello-world")
    public String sayHello(@RequestParam(value = "name", required = false) String name, @RequestParam(value = "surname", required = false) String surname, Model model) {
        System.out.println("Hello, "+ name + " "+surname);
        model.addAttribute("message", "Hello, "+ name + " "+surname);
        return "hello_world";
    }
}
