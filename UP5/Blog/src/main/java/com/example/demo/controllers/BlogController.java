package com.example.demo.controllers;

import com.example.demo.models.*;
import com.example.demo.repo.*;
import org.apache.commons.codec.digest.DigestUtils;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.validation.BindingResult;
import org.springframework.validation.ObjectError;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Controller
public class BlogController {
    @Autowired
    private PostRepository postRepository;
    @Autowired
    private MessageRepository messageRepository;
    @Autowired
    private FilesRepository filesRepository;
    @Autowired
    private RegisterRepository registerRepository;
    @Autowired
    private MoodRepository moodRepository;

    @GetMapping("/blog")
    public String blogMain(Model model) {
        Iterable<Post> posts = postRepository.findAll();
        model.addAttribute("posts", posts);

        Iterable<Message> messages = messageRepository.findAll();
        model.addAttribute("messages", messages);

        Iterable<Files> files = filesRepository.findAll();
        model.addAttribute("files", files);

        Iterable<Register> register = registerRepository.findAll();
        model.addAttribute("register", register);

        Iterable<Mood> mood = moodRepository.findAll();
        model.addAttribute("mood", mood);

        return "blog-main";
    }

    @GetMapping("/blog/AddPost")
    public String blogAddPost(Post post, Model model) {
        return "AddPost";
    }
    @GetMapping("/blog/AddMessage")
    public String blogAddMessage(Message message, Model model) {
        return "AddMessage";
    }
    @GetMapping("/blog/AddFile")
    public String blogAddFile(Files files, Model model) {
        return "AddFile";
    }
    @GetMapping("/blog/AddUser")
    public String blogAddUser(Register register, Model model) {
        return "AddUser";
    }
    @GetMapping("/blog/AddMood")
    public String blogAddMood(Mood mood, Model model) {
        return "AddMood";
    }

    @GetMapping("/blog/blog-filter")
    public String blogFilter(Model model) {
        return "blog-filter";
    }

    //Post Adding Handlers
    @PostMapping("/blog/AddPost")
    public String blogAddPost(@Valid Post post, BindingResult bindingResult, @RequestParam String title) {
        if(bindingResult.hasErrors()) return "AddPost";

        List<Post> res = postRepository.findByTitle(title);
        if(res.size()>0) {
            ObjectError error = new ObjectError("title", "Такой заголовок уже есть");
            bindingResult.addError(error);
            return "AddPost";
        }
        postRepository.save(post);

        return "redirect:/blog";
    }

    //Message Adding Handlers
    @PostMapping("/blog/AddMessage")
    public String blogAddMessage(@Valid Message message, BindingResult bindingResult, @RequestParam String toMes, @RequestParam String fromMes, @RequestParam String textMes) {
        if(bindingResult.hasErrors()) return "AddMessage";
        messageRepository.save(message);

        return "redirect:/blog";
    }

    //File Adding Handlers
    @PostMapping("/blog/AddFile")
    public String blogAddFile(@Valid Files file, BindingResult bindingResult, @RequestParam String name) {
        if(bindingResult.hasErrors()) return "AddFile";

        List<Files> res = filesRepository.findByName(name);
        if(res.size()>0) {
            ObjectError error = new ObjectError("title", "Такой файл уже есть");
            bindingResult.addError(error);
            return "AddFile";
        }
        filesRepository.save(file);

        return "redirect:/blog";
    }

    //File Adding Handlers
    @PostMapping("/blog/AddUser")
    public String blogAddUser(@Valid Register user, BindingResult bindingResult, @RequestParam String login) {
        if(bindingResult.hasErrors()) return "AddUser";

        List<Register> res = registerRepository.findByLogin(login);
        if(res.size()>0) {
            ObjectError error = new ObjectError("title", "Такой пользователь уже есть");
            bindingResult.addError(error);
            return "AddUser";
        }
        registerRepository.save(user);

        return "redirect:/blog";
    }

    @PostMapping("/blog/AddMood")
    public String blogAddMood(@Valid Mood mood, BindingResult bindingResult) {
        if(bindingResult.hasErrors()) return "AddMood";

        moodRepository.save(mood);

        return "redirect:/blog";
    }

    /*@PostMapping("/blog")
    public String blogAdd(@Valid Post post, BindingResult bindingResult, @RequestParam String action, @RequestParam String arg1, @RequestParam String arg2, @RequestParam String arg3) {
        switch(action) {
            case "AddPost":
                if(bindingResult.hasErrors()) return "blog-main";

                List<Post> res = postRepository.findByTitle(arg1);
                if(res.size()>0) {
                    ObjectError error = new ObjectError("title", "Такой заголовок уже есть");
                    bindingResult.addError(error);
                    return "blog-main";
                }

                postRepository.save(post);
                break;

            case "AddMessage":
                Message message = new Message(arg1, arg2, arg3);
                messageRepository.save(message);
                break;
            case "AddFile":
                Files files = new Files(arg1, arg2);
                filesRepository.save(files);
                break;
            case "AddUser":
                Register register = new Register(arg1, DigestUtils.md5Hex(arg2+"76f68GGHgj487"));
                registerRepository.save(register);
                break;
            case "AddMood":
                Mood mood = new Mood(arg1, arg2);
                moodRepository.save(mood);
                break;
        }

        return "redirect:/blog";
    }*/

    @PostMapping("/blog/filter/result")
    public String blogResult(@RequestParam String where, @RequestParam String search, Model model) {
        switch (where) {
            case "Post":
                List<Post> post_str = postRepository.findByTitleContaining(search);
                model.addAttribute("post", post_str);
                break;
            case "Messages":
                List<Message> message_str = messageRepository.findByTextMesContaining(search);
                model.addAttribute("message", message_str);
                break;
            case "Files":
                List<Files> file_str = filesRepository.findByName(search);
                model.addAttribute("files", file_str);
                break;
            case "Users":
                List<Register> user_str = registerRepository.findByLogin(search);
                model.addAttribute("users", user_str);
                break;
            case "Mood":
                List<Mood> mood_str = moodRepository.findByMoodContaining(search);
                model.addAttribute("mood", mood_str);
                break;
        }
        return "blog-filter";
    }

    @GetMapping("/blog/{id}")
    public String blogDetails(@PathVariable(value = "id") long id, Model model) {
        Optional<Post> post = postRepository.findById(id);
        ArrayList<Post> res = new ArrayList<>();
        post.ifPresent(res::add);
        model.addAttribute("post", res);
        return "blog-details";
    }

    @GetMapping("/blog/{id}/edit")
    public String blogEdit(@PathVariable(value = "id") long id, Model model) {
        Optional<Post> post = postRepository.findById(id);
        ArrayList<Post> res = new ArrayList<>();
        post.ifPresent(res::add);
        model.addAttribute("post", res);
        return "blog-edit";
    }

    @PostMapping("/blog/{id}/edit")
    public String blogPostUpdate(@PathVariable(value = "id") long id, @RequestParam String title, @RequestParam String anons, @RequestParam String text, Model model) {
        Post post =postRepository.findById(id).orElseThrow();
        post.setTitle(title);
        post.setAnons(anons);
        post.setText(text);
        postRepository.save(post);
        return "redirect:/blog";
    }

    @GetMapping("/blog/{id}/file-edit")
    public String blogFileEdit(@PathVariable(value = "id") long id, Model model) {
        Optional<Files> file = filesRepository.findById(id);
        ArrayList<Files> res = new ArrayList<>();
        file.ifPresent(res::add);
        model.addAttribute("file", res);
        return "file-edit";
    }

    @PostMapping("/blog/{id}/file-edit")
    public String blogFileUpdate(@PathVariable(value = "id") long id, @RequestParam String name, Model model) {
        Files file = filesRepository.findById(id).orElseThrow();
        file.setName(name);
        filesRepository.save(file);
        return "redirect:/blog";
    }

    @GetMapping("/blog/{id}/remove/{table}")
    public String blogPostDelete(@PathVariable(value = "id") long id, @PathVariable(value = "table") String table, Model model) {
        switch (table) {
            case "Post":
                Post post = postRepository.findById(id).orElseThrow();
                postRepository.delete(post);
                break;
            case "Message":
                Message message = messageRepository.findById(id).orElseThrow();
                messageRepository.delete(message);
                break;
            case "File":
                Files file = filesRepository.findById(id).orElseThrow();
                filesRepository.delete(file);
                break;
            case "User":
                Register user = registerRepository.findById(id).orElseThrow();
                registerRepository.delete(user);
                break;
            case "Mood":
                Mood mood = moodRepository.findById(id).orElseThrow();
                moodRepository.delete(mood);
                break;
        }
        return "redirect:/blog";
    }

    @GetMapping("/blog/users/{id}")
    public String blogUserDetails(@PathVariable(value = "id") long id, Model model) {
        Optional<Register> register = registerRepository.findById(id);
        ArrayList<Register> res = new ArrayList<>();
        register.ifPresent(res::add);
        model.addAttribute("user", res);
        return "blog-user-details";
    }
}
