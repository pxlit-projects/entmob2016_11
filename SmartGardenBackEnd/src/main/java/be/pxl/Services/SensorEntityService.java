package be.pxl.Services;

import be.pxl.Logger.Sender;
import be.pxl.Models.SensorEntity;
import be.pxl.Repositories.SensorEntityRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;
import java.util.Date;
import java.util.List;

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
