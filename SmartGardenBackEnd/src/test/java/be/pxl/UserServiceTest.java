package be.pxl;

import be.pxl.Logger.Sender;
import be.pxl.Models.User;
import be.pxl.Repositories.UserRepository;
import be.pxl.Services.UserService;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.runners.MockitoJUnitRunner;

import org.springframework.dao.RecoverableDataAccessException;

import java.util.ArrayList;

import java.util.Iterator;
import java.util.List;

import static org.mockito.Matchers.anyInt;
import static org.mockito.Matchers.anyString;
import static org.mockito.Mockito.verify;
import static org.mockito.Mockito.when;

/**
 * Created by 11402946 on 21/10/2016.
 */
@RunWith(MockitoJUnitRunner.class)
public class UserServiceTest {

    @Mock
    private UserRepository repositoryMock;

    @Mock
    private Sender senderMock;

    @InjectMocks
    private UserService testUserService;

    private User testUser;

    @Before
    public void init(){
        testUser = new User("john", "123456");
    }

    @Test
    public void testCreate(){
        testUserService.createUser(testUser);
        verify(repositoryMock).save(testUser);
    }

    @Test
    public void testDelete(){
        User testUser = new User("john", "123456");
        testUserService.deleteUser(testUser);
        verify(repositoryMock).delete(testUser);

    }

    @Test
    public void testFindOne(){
        when(repositoryMock.findByusername(anyString())).thenReturn(testUser);
        Assert.assertEquals(testUserService.findUserByUserName("john").getClass(), User.class);

    }

    @Test
    public void testFindAll(){

        List<User> users = new ArrayList<>();
        users.add(testUser);
        when(repositoryMock.findAll()).thenReturn(users);

        Assert.assertEquals(testUserService.getAllUsers().getClass(), users.getClass());

    }

}
