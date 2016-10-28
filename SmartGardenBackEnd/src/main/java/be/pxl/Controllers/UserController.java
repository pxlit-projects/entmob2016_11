package be.pxl.Controllers;

import be.pxl.Models.User;
import be.pxl.Services.IUserService;
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
<<<<<<< HEAD

=======
>>>>>>> ca0f3c2755c9c6d9b58cd7aad2cb7d3faf0b2971
    public void addUser(@RequestBody User user){
        service.createUser(user);
    }
    @RequestMapping(value = "/delete",method = RequestMethod.POST)
    @ResponseBody
    public void deleteUser(@RequestBody String name){
        service.deleteUser(name);
    }

    @RequestMapping(value = "/update",method = RequestMethod.PUT)
    @ResponseBody
    public void updateUser(@RequestBody User user){
        service.updateUser(user);
    }
}
