package be.pxl.Services;

import be.pxl.Models.User;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface IUserService {
    void createUser(User user);
    User findUserById(int id);
    void deleteUser(int id);
    Iterable<User> getAllUsers();
    User findUserByUserName(String name);
}
