package be.pxl.repositories;

import be.pxl.models.SensorEntity;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Repository
public interface SensorEntityRepository extends CrudRepository<SensorEntity, Integer> {

}
