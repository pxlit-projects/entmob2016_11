package be.pxl.controllers;

import be.pxl.models.User;
import be.pxl.services.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.util.Collection;

/**
 * Created by 11308157 on 10/10/2016.
 */
@Secured({"ROLE_ADMIN"})
@RestController // default json
@RequestMapping("/user")
public class UserController {
    @Autowired
    private IUserService service;

    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<User>> GetAllUsers(){
        return new ResponseEntity<>((Collection<User>) service.getAllUsers(), HttpStatus.OK);
    }
    @RequestMapping(value="/getByName/{name}",method = RequestMethod.GET)
    public ResponseEntity<User> GetUserbyID(@PathVariable(value="name") String name){ //requestparameter
        return new ResponseEntity<>(service.findUserByUserName(name), HttpStatus.OK);
    }
    @RequestMapping(value="/getByUsername/{name}", method = RequestMethod.GET)
    public ResponseEntity<User> GetUserbyUserName(@PathVariable(value="name") String name){
        return new ResponseEntity<>(service.findUserByUserName(name), HttpStatus.OK);
    }
    @RequestMapping(value = "/add",method = RequestMethod.POST)
    @ResponseBody

    public void addUser(@RequestBody User user){
        service.createUser(user);
    }

    @RequestMapping(value = "/delete/{id}",method = RequestMethod.DELETE)
    @ResponseBody
    public void deleteUser(@PathVariable(value="id") int id) {
        service.deleteUser(id);
    }

    @RequestMapping(value = "/update",method = RequestMethod.PUT)
    @ResponseBody
    public void updateUser(@RequestBody User user){
        service.updateUser(user);
    }
}
