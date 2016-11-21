package be.pxl.services;

import be.pxl.logger.Sender;
import be.pxl.models.SensorEntity;
import be.pxl.repositories.SensorEntityRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Service
public class SensorEntityService implements ISensorEntityService {

    @Autowired
    Sender sender;

    @Autowired
    SensorEntityRepository repository;

    public void CreateEntity(SensorEntity sensorEntity){
        sender.sendMessage("Created entity at : " + LocalDateTime.now());
        repository.save(sensorEntity);

    }
    public SensorEntity getEntityById(int id){
        sender.sendMessage("Searched entity with id : " + id + "at : " + LocalDateTime.now());
        return repository.findOne(id);
    }
    public Iterable<SensorEntity> getAll(){
        sender.sendMessage("Searched all entities at : " + LocalDateTime.now());
        return repository.findAll();}
}
