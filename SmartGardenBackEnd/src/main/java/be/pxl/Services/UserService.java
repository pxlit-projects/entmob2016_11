package be.pxl.Services;

import be.pxl.Logger.Sender;
import be.pxl.Models.SensorEntity;
import be.pxl.Models.User;
import be.pxl.Models.UserRole;
import be.pxl.Repositories.SensorEntityRepository;
import be.pxl.Repositories.UserRepository;
import be.pxl.Repositories.UserRoleRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import sun.management.Sensor;

import java.time.LocalDateTime;
import java.util.Iterator;
import java.util.List;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Service
public class UserService implements IUserService {

    @Autowired
    UserRepository userRepository;

    @Autowired
    UserRoleRepository userRoleRepository;

    @Autowired
    SensorEntityRepository sensorEntityRepository;

    @Autowired
    Sender sender;


    @Transactional
    public void createUser(User user) {
        sender.sendMessage("User with username : " + user.getUsername() + " created at : " + LocalDateTime.now());

        user = userRepository.save(user);

        for (UserRole userRole : user.getUserRoles()) {
            userRole.setUser(user);
            userRoleRepository.save(userRole);
        }
    }

    @Transactional
    public void deleteUser(int id) {
        sender.sendMessage("User with id : " + id + " deleted at : " + LocalDateTime.now());
        userRoleRepository.deleteByUserId(id);
        userRepository.delete(id);
    }

    public void deleteUser(User user) {
        sender.sendMessage("User with name : " + user.getUsername() + " deleted at : " + LocalDateTime.now());
        userRepository.delete(user);
    }

    public Iterable<User> getAllUsers() {
        sender.sendMessage("Searched all users at : " + LocalDateTime.now());
        return userRepository.findAll();
    }

    public User findUserByUserName(String name) {
        sender.sendMessage("Searched user with name : " + name + " at : " + LocalDateTime.now());
        return userRepository.findByusername(name);
    }

    public void updateUser(User user) {
        sender.sendMessage("Updated user with name : " + user.getUsername() + " at : " + LocalDateTime.now());
        User thisUser = userRepository.findByusername(user.getUsername());
        userRepository.save(thisUser);
        SensorEntity entity = null;
        for (SensorEntity ENTITY : user.getSensorEntities()) {
            entity = ENTITY;
        }

        SensorEntity Entity = new SensorEntity();
        Entity.setUser(thisUser);
        Entity.setAbove(entity.isAbove());
        Entity.setHumidity(entity.getHumidity());
        Entity.setLight(entity.getLight());
        Entity.setTemperature(entity.getTemperature());
        sensorEntityRepository.save(Entity);
    }

    }

