package be.pxl.Services;

import be.pxl.Models.User;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface IUserService {
    public void createUser(User user);
    public User findUserById(int id);
    public void deleteUser(int id);
    public Iterable<User> getAllUsers();
    public User findUserByUserName(String name);
}
