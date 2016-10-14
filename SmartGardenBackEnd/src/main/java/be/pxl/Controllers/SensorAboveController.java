package be.pxl.Controllers;

import be.pxl.Models.SensorAbove;
import be.pxl.Repositories.SensorAboveRepository;
import be.pxl.Services.SensorAboveService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import java.util.Collection;

/**
 * Created by 11308157 on 7/10/2016.
 */
@RestController
@RequestMapping("/SensorAbove")
public class SensorAboveController {
    @Autowired
    private SensorAboveService service;

    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<SensorAbove>> getAllAboveSensors(){
        return new ResponseEntity<>((Collection<SensorAbove>) service.getAll(), HttpStatus.OK);

    }

}
