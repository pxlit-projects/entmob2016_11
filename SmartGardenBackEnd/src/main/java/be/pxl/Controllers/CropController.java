package be.pxl.Controllers;

import be.pxl.Models.Crop;
import be.pxl.Models.SensorAbove;
import be.pxl.Services.CropService;
import be.pxl.Services.SensorAboveService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

/**
 * Created by 11308157 on 14/10/2016.
 */
@RestController
@RequestMapping("/Crops")
public class CropController {
    @Autowired
    private CropService service;

    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<Crop>> getAllCrops(){
        return new ResponseEntity<>((Collection<Crop>) service.getAll(), HttpStatus.OK);

    }
}
