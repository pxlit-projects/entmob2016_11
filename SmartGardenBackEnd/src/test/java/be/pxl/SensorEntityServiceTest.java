package be.pxl;

import be.pxl.Logger.Sender;
import be.pxl.Models.SensorEntity;
import be.pxl.Models.User;
import be.pxl.Repositories.SensorEntityRepository;
import be.pxl.Services.SensorEntityService;
import be.pxl.Services.UserService;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.dao.RecoverableDataAccessException;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.List;

import static org.mockito.Matchers.anyInt;
import static org.mockito.Mockito.when;

/**
 * Created by 11402946 on 21/10/2016.
 */
@RunWith(MockitoJUnitRunner.class)
public class SensorEntityServiceTest {

    @Mock
    private SensorEntityRepository repositoryMock;

    @Mock
    private Sender senderMock;

    @InjectMocks
    private SensorEntityService testSensorService;

    @Test
    public void testCreate(){
        SensorEntity entity = new SensorEntity(2.0, 2.0, 2.0, null, true);
        testSensorService.CreateEntity(entity);
        Mockito.verify(repositoryMock).save(entity);

    }

    @Test
    public void testFindOne(){

        when(repositoryMock.findOne(anyInt())).thenReturn(new SensorEntity(1.0, 1.0, 1.0, null, false));

        SensorEntity sTag = testSensorService.getEntityById(0);
        boolean eq = false;
        if(sTag.getHumidity() == 1.0 && sTag.getLight() == 1.0 && sTag.getTemperature() == 1.0 && !sTag.isAbove()){
            eq = true;
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
        when(repositoryMock.findAll()).thenReturn(sensorValues);

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
