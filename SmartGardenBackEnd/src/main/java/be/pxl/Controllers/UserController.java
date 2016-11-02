package be.pxl.Controllers;

import be.pxl.Models.User;
import be.pxl.Services.IUserService;
import be.pxl.Services.UserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import javax.ws.rs.Path;
import java.util.Collection;

/**
 * Created by 11308157 on 10/10/2016.
 */
@Secured({"ROLE_ADMIN"})
@RestController
@RequestMapping("/user")
public class UserController {
    @Autowired
    private IUserService service;

    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<User>> GetAllUsers(){
        return new ResponseEntity<>((Collection<User>) service.getAllUsers(), HttpStatus.OK);
    }
    @RequestMapping(value="/getByName/{name}",method = RequestMethod.GET)
    public ResponseEntity<User> GetUserbyID(@PathVariable(value="name") String name){
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

    @RequestMapping(value = "/delete",method = RequestMethod.DELETE)
    @ResponseBody
    public void deleteUser(@RequestBody int id) {
        service.deleteUser(id);
    }

    public void deleteUser(@RequestBody User user){
        service.deleteUser(user);

    }

    @RequestMapping(value = "/update",method = RequestMethod.PUT)
    @ResponseBody
    public void updateUser(@RequestBody User user){
        service.updateUser(user);
    }
}
