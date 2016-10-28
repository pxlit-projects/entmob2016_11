package be.pxl.Services;

import be.pxl.Models.SensorEntity;
import be.pxl.Repositories.SensorEntityRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Date;
import java.util.List;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Service
public class SensorEntityService implements ISensorEntityService {

    @Autowired
    SensorEntityRepository repository;

    public void CreateEntity(SensorEntity sensorEntity){
        repository.save(sensorEntity);
    }
    public SensorEntity getEntityById(int id){
       return repository.findOne(id);
    }
    public Iterable<SensorEntity> getAll(){
        return repository.findAll();
    }



}
