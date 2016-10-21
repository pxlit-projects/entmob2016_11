package be.pxl;

import be.pxl.Models.SensorEntity;
import be.pxl.Models.User;
import be.pxl.Services.SensorEntityService;
import be.pxl.Services.UserService;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.dao.RecoverableDataAccessException;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.List;

/**
 * Created by 11402946 on 21/10/2016.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes= SensorEntityServiceTestConfig.class)
@DirtiesContext
public class SensorEntityServiceTest {

    @Autowired
    private SensorEntityService testSensorService;

    @Test(expected = RecoverableDataAccessException.class)
    public void testCreate(){
        testSensorService.CreateEntity(new SensorEntity());
    }

    @Test
    public void testFindOne(){
        SensorEntity sTag = testSensorService.getEntityById(0);
        boolean eq = false;
        if(sTag.getHumidity() == 1.0 && sTag.getLight() == 1.0 && sTag.getTemperature() == 1.0 && !sTag.isAbove()){
            eq = true;
        }

        Assert.assertTrue(eq);
    }

    @Test
    public void testFindBetween(){
        boolean eq = false;
        int index = 0;
        SensorEntity current;
        List<SensorEntity> sensorValues = new ArrayList<>();
        sensorValues.add(new SensorEntity(1.0, 1.0, 1.0, null, false));

        Iterator i = testSensorService.findSensorEntitiesBetweenDates(new Date(), new Date()).iterator();

        while(i.hasNext()){
            current = (SensorEntity) i.next();
            if(current.getHumidity() == sensorValues.get(index).getHumidity()
                    && current.getLight() == sensorValues.get(index).getLight()
                    && current.getTemperature() == sensorValues.get(index).getTemperature()
                    && current.isAbove() == sensorValues.get(index).isAbove()){
                eq = true;
            }else{
                eq = false;
            }
            index++;
        }

        Assert.assertTrue(eq);
    }

    @Test
    public void testFindAll(){

        boolean eq = false;
        int index = 0;
        SensorEntity current;
        List<SensorEntity> sensorValues = new ArrayList<>();
        sensorValues.add(new SensorEntity(1.0, 1.0, 1.0, null, false));

        Iterator i = testSensorService.getAll().iterator();

        while(i.hasNext()){
            current = (SensorEntity) i.next();
            if(current.getHumidity() == sensorValues.get(index).getHumidity()
                    && current.getLight() == sensorValues.get(index).getLight()
                    && current.getTemperature() == sensorValues.get(index).getTemperature()
                    && current.isAbove() == sensorValues.get(index).isAbove()){
                eq = true;
            }else{
                eq = false;
            }
            index++;
        }

        Assert.assertTrue(eq);

    }

}
