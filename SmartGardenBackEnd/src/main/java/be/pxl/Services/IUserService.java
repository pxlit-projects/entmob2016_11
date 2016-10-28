package be.pxl.Services;

import be.pxl.Models.User;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface IUserService {
    void createUser(User user);
    Iterable<User> getAllUsers();
    User findUserByUserName(String name);
    void updateUser(User user);
    void deleteUser(String name);
}
