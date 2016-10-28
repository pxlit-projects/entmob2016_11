package be.pxl;

import be.pxl.Models.User;
import be.pxl.Services.IUserService;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.dao.RecoverableDataAccessException;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

/**
 * Created by 11402946 on 21/10/2016.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes= UserServiceTestConfig.class)
@DirtiesContext
public class UserServiceTest {

    @Autowired
    private IUserService testUserService;

    @Test(expected = RecoverableDataAccessException.class)
    public void testCreate(){
        testUserService.createUser(new User());
    }

    @Test(expected = RecoverableDataAccessException.class)
    public void testDelete(){
        testUserService.deleteUser(0);
    }

    @Test
    public void testFindOne(){
        User john = testUserService.findUserById(0);
        Assert.assertEquals(john.getUsername(), "john");
    }

    @Test
    public void testFindAll(){

        boolean eq = false;
        int index = 0;
        User current;
        List<User> users = new ArrayList<>();
        users.add(new User("john", "test", "admin"));

        Iterator i = testUserService.getAllUsers().iterator();

        while(i.hasNext()){
            current = (User) i.next();
            if((current.getPassword()).equals(users.get(index).getPassword())
                    && current.getUsername() == users.get(index).getUsername()){
                eq = true;
            }else{
                eq = false;
            }
            index++;
        }

        Assert.assertTrue(eq);

    }

}
