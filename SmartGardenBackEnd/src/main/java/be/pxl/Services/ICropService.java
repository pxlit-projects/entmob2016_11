package be.pxl.Services;

import be.pxl.Models.Crop;

/**
 * Created by 11308157 on 28/10/2016.
 */
public interface ICropService {
    public Iterable<Crop> getAll();
    public void createCrop(Crop crop);
    public Crop getCropByName(String name);
}
