package be.pxl;

import be.pxl.Models.Crop;
import be.pxl.Services.CropService;
import org.junit.*;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.dao.RecoverableDataAccessException;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.*;

/**
 * Created by 11402946 on 19/10/2016.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes= CropServiceTestConfig.class)
@DirtiesContext
public class CropServiceTest {

    @Autowired
    private CropService testCropService;

    @Test
    public void testFindAll(){

        boolean eq = false;
        int index = 0;
        Crop current;
        List<Crop> crops = new ArrayList<Crop>();
        crops.add(new Crop(2.0, 2.0, 2.0, new Date(12345), "Wiet"));

        Iterator i = testCropService.getAll().iterator();

        while(i.hasNext()){
            current = (Crop)i.next();
            if((current.getFinalDate()).equals(crops.get(index).getFinalDate())
                    && current.getHumidity() == crops.get(index).getHumidity()
                    && current.getLight() == crops.get(index).getLight()
                    && current.getTemperature() == crops.get(index).getTemperature()){
                eq = true;
            }else{
                eq = false;
            }
            index++;
        }

        Assert.assertTrue(eq);

    }

    @Test(expected = RecoverableDataAccessException.class)
    public void testCreate(){
        testCropService.createUser(new Crop());
    }

}
