package be.pxl.Controllers;

import be.pxl.Models.Crop;
import be.pxl.Services.ICropService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.annotation.Secured;
import org.springframework.web.bind.annotation.*;

import java.util.Collection;

/**
 * Created by 11308157 on 14/10/2016.
 */
@RestController
@Secured({"ROLE_ADMIN"})
@RequestMapping("/crop")
public class CropController {
    @Autowired
    private ICropService service;

    @RequestMapping(method = RequestMethod.GET)
    public ResponseEntity<Collection<Crop>> getAllCrops(){
        return new ResponseEntity<>((Collection<Crop>) service.getAll(), HttpStatus.OK);

    }
    @RequestMapping(value="/getByName/{name}", method = RequestMethod.GET)
    public ResponseEntity<Crop> getCropByName(@PathVariable(value="name") String name){
        return new ResponseEntity<>(service.getCropByName(name), HttpStatus.OK);

    }
    @RequestMapping(value = "/add",method = RequestMethod.POST)
    @ResponseBody
    public void addCrop(@RequestBody Crop crop){
        service.createCrop(crop);
    }

}
