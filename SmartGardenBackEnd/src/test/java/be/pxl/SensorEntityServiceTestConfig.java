package be.pxl;

import be.pxl.Models.SensorEntity;
import be.pxl.Repositories.SensorEntityRepository;
import be.pxl.Services.ISensorEntityService;
import be.pxl.Services.SensorEntityService;
import org.mockito.Mockito;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.dao.RecoverableDataAccessException;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import static org.mockito.Matchers.any;
import static org.mockito.Matchers.anyObject;
import static org.mockito.Mockito.doThrow;
import static org.mockito.Mockito.when;

/**
 * Created by 11402946 on 21/10/2016.
 */
@Configuration
public class SensorEntityServiceTestConfig {


    @Bean
    public SensorEntityRepository repository(){

        List<SensorEntity> sensorValues = new ArrayList<>();
        SensorEntity sTag = new SensorEntity(1.0, 1.0, 1.0, null, false);
        sensorValues.add(sTag);
        SensorEntityRepository testRepo =  Mockito.mock(SensorEntityRepository.class);
        doThrow(new RecoverableDataAccessException("error")).when(testRepo).save((SensorEntity) anyObject());
        when(testRepo.findAll()).thenReturn(sensorValues);
        when(testRepo.findOne( any())).thenReturn(sTag);
        return testRepo;
    }

    @Bean
    public ISensorEntityService testSensorService(){
        return new SensorEntityService();
    }
}
