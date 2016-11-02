package be.pxl.Services;


import be.pxl.Logger.Sender;
import be.pxl.Models.Crop;
import be.pxl.Repositories.CropRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.time.LocalDateTime;

/**
 * Created by 11308157 on 14/10/2016.
 */
@Service
public class CropService implements ICropService {

    @Autowired
    private CropRepository repository;

    @Autowired
    private Sender sender;

    public Iterable<Crop> getAll(){
        sender.sendMessage("Searched all crops at : " + LocalDateTime.now());
        return repository.findAll();
    }
    public void createCrop(Crop crop){
        sender.sendMessage("Crop : " + crop.getName() + " created at : " + LocalDateTime.now());
        repository.save(crop);
    }
    public Crop getCropByName(String name){
        sender.sendMessage("Crop with name " + name+ " searched at : " + LocalDateTime.now());
        return repository.findCropByName(name);
    }

    public void deleteCrop(Crop crop){
        sender.sendMessage("Crop : " + crop.getName() + " deleted at : " + LocalDateTime.now());
        repository.delete(crop);
    }
}
