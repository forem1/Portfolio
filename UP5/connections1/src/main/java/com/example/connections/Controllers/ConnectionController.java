package com.example.connections.Controllers;

import com.example.connections.Models.*;
import com.example.connections.Repo.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class ConnectionController {
    @Autowired
    private ParentRepository parentRepository;
    @Autowired
    private ChildRepository childRepository;
    @Autowired
    private HumanRepository humanRepository;
    @Autowired
    private PhoneRepository phoneRepository;
    @Autowired
    private BookRepository bookRepository;
    @Autowired
    private AuthorRepository authorRepository;

    @GetMapping("/")
    public String connectionMain(Model model) {
        return "main-view";
    }

    @GetMapping("/onetoone")
    public String parentView(Model model) {
        Iterable<Parent> parent = parentRepository.findAll();
        Iterable<Child> child = childRepository.findAll();
        model.addAttribute("parent", parent);
        model.addAttribute("child", child);
        return "onetoone";
    }

    @GetMapping("/parent/add")
    public String parentAdd(Model model) {
        Iterable<Child> child = childRepository.findAll();
        model.addAttribute("child", child);
        return "parent-add";
    }

    @PostMapping("/parent/add")
    public String parentAdd(@RequestParam String fio,
                            @RequestParam String childNum,
                            Model model) {
        Child child = childRepository.findByChildNum(childNum);
        Parent parent = new Parent(fio, child);
        parentRepository.save(parent);
        return "redirect:/onetoone";
    }

    @GetMapping("/child/add")
    public String childAdd(Model model) {
        return "child-add";
    }

    @PostMapping("/child/add")
    public String childAdd(@RequestParam String childNum,
                         Model model) {
        Child child = new Child(childNum);
        childRepository.save(child);
        return "redirect:/onetoone";
    }

    @GetMapping("/onetomany")
    public String humanView(Model model) {
        Iterable<Human> human = humanRepository.findAll();
        Iterable<Phone> phone = phoneRepository.findAll();
        model.addAttribute("human", human);
        model.addAttribute("phone", phone);
        return "onetomany";
    }

    @GetMapping("/human/add")
    public String humanAdd(Model model) {
        Iterable<Phone> phone = phoneRepository.findAll();
        model.addAttribute("phone", phone);
        return "human-add";
    }

    @PostMapping("/human/add")
    public String humanAdd(@RequestParam String fio,
                            @RequestParam String phone,
                            Model model) {
        Phone phones = phoneRepository.findByPhone(phone);
        Human human = new Human(fio, phones);
        humanRepository.save(human);
        return "redirect:/onetomany";
    }

    @GetMapping("/phone/add")
    public String phoneAdd(Model model) {
        return "phone-add";
    }

    @PostMapping("/phone/add")
    public String phoneAdd(@RequestParam String phone,
                           Model model) {
        Phone phones = new Phone(phone);
        phoneRepository.save(phones);
        return "redirect:/onetomany";
    }

    @GetMapping("/manytomany")
    public String manytomanyView(Model model) {
        Iterable<Book> cities = bookRepository.findAll();
        Iterable<Author> authors = authorRepository.findAll();
        model.addAttribute("book", cities);
        model.addAttribute("author", authors);
        return "manytomany";
    }

    @PostMapping("/manytomany")
    public String manytomanyAdd(@RequestParam String book,
                                @RequestParam String author,
                                Model model){
        Book book1 = bookRepository.findByName(book);
        Author author1 = authorRepository.findByName(author);
        book1.getAuthors().add(author1);
        bookRepository.save(book1);
        return "redirect:/manytomany";
    }

    @GetMapping("/book/add")
    public String bookAdd(Model model) {

        return "book-add";
    }

    @PostMapping("/book/add")
    public String bookAdd(@RequestParam String name,
                            Model model) {
        Book book = new Book(name);
        bookRepository.save(book);
        return "redirect:/manytomany";
    }

    @GetMapping("/author/add")
    public String authorAdd(Model model) {

        return "author-add";
    }

    @PostMapping("/author/add")
    public String authorAdd(@RequestParam String name,
                           Model model) {
        Author author = new Author(name);
        authorRepository.save(author);
        return "redirect:/manytomany";
    }
}
