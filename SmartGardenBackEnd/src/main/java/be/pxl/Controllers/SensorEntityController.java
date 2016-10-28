package be.pxl.Controllers;

import be.pxl.Models.SensorEntity;
import be.pxl.Services.SensorEntityService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

/**
 * Created by 11308157 on 7/10/2016.
 */
@RestController
@RequestMapping("/sensorentity")
public class SensorEntityController {
    @Autowired
    private SensorEntityService service;
    @Secured({"ROLE_ADMIN"})
    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<SensorEntity>> getAllSensors(){
        return new ResponseEntity<>((Collection<SensorEntity>) service.getAll(), HttpStatus.OK);
    }
}
