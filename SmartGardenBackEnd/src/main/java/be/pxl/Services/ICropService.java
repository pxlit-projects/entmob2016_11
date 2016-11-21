package be.pxl.services;

import be.pxl.models.Crop;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface ICropService {
    Iterable<Crop> getAll();
    void createCrop(Crop crop);
    Crop getCropByName(String name);

    void deleteCrop(int cropID);
}
