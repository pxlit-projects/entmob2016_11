package be.pxl.Controllers;

import be.pxl.Models.SensorAbove;
import be.pxl.Models.SensorBelow;
import be.pxl.Repositories.SensorBelowRepository;
import be.pxl.Services.SensorBelowService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

/**
 * Created by 11308157 on 11/10/2016.
 */
@RestController
@RequestMapping("/SensorBelow")
public class SensorBelowController{
    @Autowired
    private SensorBelowService service;

    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<SensorBelow>> getAllBelowSensors(){
        return new ResponseEntity<>((Collection<SensorBelow>) service.getAll(), HttpStatus.OK);

    }
}
