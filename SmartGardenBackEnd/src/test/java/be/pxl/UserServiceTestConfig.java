package be.pxl;

import be.pxl.Models.User;
import be.pxl.Repositories.UserRepository;
import be.pxl.Services.IUserService;
import be.pxl.Services.UserService;
import org.mockito.Mockito;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.dao.RecoverableDataAccessException;

import java.util.ArrayList;
import java.util.List;

import static org.mockito.Matchers.any;
import static org.mockito.Matchers.anyObject;
import static org.mockito.Mockito.doThrow;
import static org.mockito.Mockito.when;

/**
 * Created by 11402946 on 21/10/2016.
 */
@Configuration
public class UserServiceTestConfig {


    @Bean
    public UserRepository repository(){

        List<User> users = new ArrayList<>();
        User john = new User("john", "test");
        users.add(john);
        UserRepository testRepo =  Mockito.mock(UserRepository.class);
        doThrow(new RecoverableDataAccessException("error")).when(testRepo).save((User) anyObject());
        doThrow(new RecoverableDataAccessException("error")).when(testRepo).delete((Integer) anyObject());
        when(testRepo.findAll()).thenReturn(users);
        when(testRepo.findOne( any())).thenReturn(john);
        return testRepo;
    }

    @Bean
    public IUserService testUserService(){
        return new UserService();
    }
}
