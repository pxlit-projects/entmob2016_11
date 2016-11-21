package be.pxl;

import be.pxl.logger.Sender;
import be.pxl.models.SensorEntity;
import be.pxl.repositories.SensorEntityRepository;
import be.pxl.services.SensorEntityService;
import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;

import java.util.ArrayList;
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

        SensorEntity newTag = new SensorEntity(1.0, 1.0, 1.0, null, false);
        when(repositoryMock.findOne(anyInt())).thenReturn(newTag);

        SensorEntity sTag = testSensorService.getEntityById(0);

        Assert.assertSame(sTag, newTag);
    }

    @Test
    public void testFindAll(){

        List<SensorEntity> sensorValues = new ArrayList<>();
        sensorValues.add(new SensorEntity(1.0, 1.0, 1.0, null, false));
        when(repositoryMock.findAll()).thenReturn(sensorValues);

        Assert.assertSame(testSensorService.getAll(), sensorValues);

    }

}
