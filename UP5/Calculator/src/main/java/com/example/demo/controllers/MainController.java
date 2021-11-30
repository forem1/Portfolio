package com.example.demo.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class MainController {
  //  @GetMapping("/")
//    public  String home(HttpServletRequest request){
//        String name = request.getParameter("name");
//        String surname = request.getParameter("surname");
//        System.out.println("Hello, " + name + " " + surname);
//        return "home";
//    }
//       public  String home(@RequestParam (value = "name", required = false) String name,
//                        @RequestParam (value = "surname", required = false) String surname, Model model){
//        System.out.println("Hello, " + name + " " + surname);
//        model.addAttribute("name", name);
//        model.addAttribute("surname", surname);
//        return "home";
//    }

//    @GetMapping("/")
//    public String home(Model model){
//      return "home";
//    }
//    @PostMapping("add")
//    public String add(@RequestParam String title, Model model){
//      System.out.println(title);
//      return "home";
//    }
    @GetMapping("/")
    public String home(Model model){
      return "home";
    }
    double result2;
    @PostMapping("Post")
    public String num2(@RequestParam double number3, @RequestParam double number12,
                       Model model, @RequestParam String action2){
        switch (action2){
            case"umn":
                result2 = number3 * number12;
                break;
            case"del":
                result2 = number3 / number12;
                break;
            case"plus":
                result2 = number3 + number12;
                break;
            case"minus":
                result2 = number3 - number12;
                break;
        }

        model.addAttribute("number3", number3);
        model.addAttribute("number12", number12);
        model.addAttribute("result2", result2);
        return "home";
    }

    double result;
    @GetMapping("Get")
    public String num(@RequestParam(required = false) double number, double number2,
                      Model model, String action){
        switch (action){
            case"umn":
                result = number * number2;
                break;
            case"del":
                result = number / number2;
                break;
            case"plus":
                result = number + number2;
                break;
            case"minus":
                result = number - number2;
                break;
        }
        model.addAttribute("number", number);
        model.addAttribute("number2", number2);
        model.addAttribute("result", result);
      return "home";
    }
}
