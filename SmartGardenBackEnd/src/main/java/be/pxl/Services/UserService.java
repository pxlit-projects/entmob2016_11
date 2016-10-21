package be.pxl.Services;

import be.pxl.Models.User;
import be.pxl.Repositories.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Iterator;
import java.util.List;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Service
public class UserService  {

    @Autowired
    UserRepository repository;

    public void createUser(User user){
        repository.save(user);
    }
    public User findUserById(int id){
        return repository.findOne(id);
    }
    public void deleteUser(int id){
        repository.delete(id);
    }
    public Iterable<User> getAllUsers(){
        return repository.findAll();
    }
    public User findUserByUserName(String name){return repository.findByusername(name);}

}
