package be.pxl.Services;

import be.pxl.Models.SensorEntity;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface ISensorEntityService {
    public void CreateEntity(SensorEntity sensorEntity);
    public SensorEntity getEntityById(int id);
    public Iterable<SensorEntity> getAll();
}
