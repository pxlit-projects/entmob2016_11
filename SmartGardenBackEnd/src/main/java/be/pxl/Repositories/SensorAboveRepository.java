package be.pxl.Repositories;

import be.pxl.Models.SensorAbove;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.Date;
import java.util.List;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Repository
public interface SensorAboveRepository extends CrudRepository<SensorAbove, Integer> {
    List<SensorAbove> findByTimeOfRecordingBetween(Date date1, Date date2);
}
