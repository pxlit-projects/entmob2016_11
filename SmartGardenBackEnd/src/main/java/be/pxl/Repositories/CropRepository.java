package be.pxl.repositories;

import be.pxl.models.Crop;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

/**
 * Created by 11308157 on 14/10/2016.
 */
@Repository
public interface CropRepository extends CrudRepository<Crop,Integer> {
    Crop findCropByName(String name);
}
