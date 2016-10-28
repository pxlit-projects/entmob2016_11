package be.pxl.Services;

import be.pxl.Logger.Sender;
import be.pxl.Models.User;
import be.pxl.Repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.Iterator;
import java.util.List;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Service
public class UserService implements IUserService {

    @Autowired
    UserRepository repository;

    @Autowired
    Sender sender;

    public void createUser(User user){
        sender.sendMessage("User with username : " + user.getUsername() + " created at : " + LocalDateTime.now());
        repository.save(user);
    }
    public void deleteUser(String name){
        sender.sendMessage("User with name : " + name + " deleted at : " + LocalDateTime.now());
        repository.deleteByusername(name);
    }
    public Iterable<User> getAllUsers(){
        sender.sendMessage("Searched all users at : " + LocalDateTime.now());
        return repository.findAll();
    }
    public User findUserByUserName(String name){
        sender.sendMessage("Searched user with name : " + name + " at : " + LocalDateTime.now());
        return repository.findByusername(name);
    }
    public void updateUser(User user){
        sender.sendMessage("Updated user with name : " + user.getUsername() + " at : " + LocalDateTime.now());
        repository.save(user);
    }
}
