package be.pxl.Services;

import be.pxl.Models.SensorAbove;
import be.pxl.Models.SensorBelow;
import be.pxl.Repositories.SensorAboveRepository;
import be.pxl.Repositories.SensorBelowRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Date;
import java.util.List;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Service
public class SensorBelowService {
    @Autowired
    SensorBelowRepository repository;

    public List<SensorBelow> findSensorEntitiesBetweenDates(Date d1, Date d2){
        return repository.findByTimeOfRecordingBetween(d1,d2);
    }
    public void CreateEntity(SensorBelow sensorBelow){
        repository.save(sensorBelow);
    }
    public SensorBelow getEntityById(int id){
       return repository.findOne(id);
    }
    public Iterable<SensorBelow> getAll(){
        return repository.findAll();
    }
}
