package be.pxl;

import be.pxl.Models.SensorEntity;
import be.pxl.Models.User;
import be.pxl.Services.ISensorEntityService;
import be.pxl.Services.IUserService;
import javafx.application.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;

import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;

import java.util.Iterator;

/**
 * Created by 11402946 on 28/10/2016.
 */
@RunWith(SpringJUnit4ClassRunner.class)
//@SpringApplicationConfiguration(classes = Application.class)
@WebAppConfiguration
@SpringBootTest
public class SensorEntityControllerTest {

    @Autowired
    ISensorEntityService service;

    @Autowired
    IUserService userService;

    //models needed to test SensorEntityController
    SensorEntity entity;
    User user;

    @Before
    public void init(){
        user = userService.findUserByUserName("mkyong");
        entity = new SensorEntity(1.0, 1.0, 1.0, user, false);

        service.CreateEntity(entity);

    }

    @Test
    public void canGetAllSensors(){

        Iterator i = service.getAll().iterator();

        while(i.hasNext()) {

        }
    }

}
