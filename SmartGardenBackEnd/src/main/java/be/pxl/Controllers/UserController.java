package be.pxl.Controllers;

import be.pxl.Models.User;
import be.pxl.Services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

/**
 * Created by 11308157 on 10/10/2016.
 */
@RestController
@RequestMapping("/user")
public class UserController {
    @Autowired
    private UserService service;

    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<User>> GetAllUsers(){
        return new ResponseEntity<>((Collection<User>) service.getAllUsers(), HttpStatus.OK);

    }
}