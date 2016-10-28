package be.pxl.Services;


import be.pxl.Models.Crop;
import be.pxl.Repositories.CropRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

/**
 * Created by 11308157 on 14/10/2016.
 */
@Service
public class CropService implements ICropService {

    @Autowired
    CropRepository repository;

    public Iterable<Crop> getAll(){
        return repository.findAll();
    }
    public void createCrop(Crop crop){repository.save(crop);}
    public Crop getCropByName(String name){return repository.findCropByName(name);}
}
