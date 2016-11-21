package be.pxl.services;

import be.pxl.models.SensorEntity;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface ISensorEntityService {
    void CreateEntity(SensorEntity sensorEntity);
    SensorEntity getEntityById(int id);
    Iterable<SensorEntity> getAll();
}
