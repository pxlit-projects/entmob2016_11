package be.pxl.Services;

import be.pxl.Models.Crop;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface ICropService {
    Iterable<Crop> getAll();
    void createCrop(Crop crop);
    Crop getCropByName(String name);
}
