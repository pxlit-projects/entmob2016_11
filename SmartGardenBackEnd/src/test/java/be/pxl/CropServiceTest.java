package be.pxl;

import be.pxl.Logger.Sender;
import be.pxl.Models.Crop;
import be.pxl.Repositories.CropRepository;
import be.pxl.Services.CropService;

import org.junit.Assert;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.runners.MockitoJUnitRunner;

import java.sql.Timestamp;
import java.util.*;

import static org.mockito.Matchers.anyString;
import static org.mockito.Mockito.when;

/**
 * Created by 11402946 on 19/10/2016.
 */
@RunWith(MockitoJUnitRunner.class)
public class CropServiceTest {

    @Mock
    private CropRepository repositoryMock;

    @Mock
    private Sender senderMock;

    @InjectMocks
    private CropService testCropService;

    @Test
    public void testFindAll(){

        List<Crop> crops = new ArrayList<Crop>();
        crops.add(new Crop(2.0, 2.0, 2.0, new Timestamp(12345), "Wiet"));
        when(repositoryMock.findAll()).thenReturn(crops);

        Assert.assertEquals(testCropService.getAll().getClass(), crops);

    }

    @Test
    public void testCropByName(){

        Crop newCrop = new Crop(2.0, 2.0, 2.0, new Timestamp(12345), "Wiet");
        when(repositoryMock.findCropByName(anyString())).thenReturn(newCrop);

        Crop crop = testCropService.getCropByName("Wiet");
        Assert.assertEquals(newCrop.getClass(), crop.getClass());

    }

    @Test
    public void testCreate(){
        Crop crop = new Crop(2.0, 2.0, 2.0, new Timestamp(12345), "Wiet");
        testCropService.createCrop(crop);
        Mockito.verify(repositoryMock).save(crop);
    }

}
