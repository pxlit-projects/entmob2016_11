package be.pxl.Services;

import be.pxl.Models.SensorAbove;
import be.pxl.Repositories.SensorAboveRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.Date;
import java.util.List;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Service
public class SensorAboveService {

    @Autowired
    SensorAboveRepository repository;

    public List<SensorAbove> findSensorEntitiesBetweenDates(Date d1, Date d2){
        return repository.findByTimeOfRecordingBetween(d1,d2);
    }
    public void CreateEntity(SensorAbove sensorAbove){
        repository.save(sensorAbove);
    }
    public SensorAbove getEntityById(int id){
       return repository.findOne(id);
    }
    public Iterable<SensorAbove> getAll(){
        return repository.findAll();
    }



}
