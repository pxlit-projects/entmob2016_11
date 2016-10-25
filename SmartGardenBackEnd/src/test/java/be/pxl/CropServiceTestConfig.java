package be.pxl;

import be.pxl.Models.Crop;
import be.pxl.Models.User;
import be.pxl.Repositories.CropRepository;
import be.pxl.Repositories.UserRepository;
import be.pxl.Services.CropService;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.invocation.InvocationOnMock;
import org.mockito.stubbing.Answer;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.dao.NonTransientDataAccessException;
import org.springframework.dao.RecoverableDataAccessException;
import org.springframework.stereotype.Component;

import javax.script.ScriptException;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import static org.mockito.Mockito.*;

/**
 * Created by 11402946 on 19/10/2016.
 */
@Configuration
public class CropServiceTestConfig {

    @Bean
    public CropRepository repository(){

        List<Crop> crops = new ArrayList<>();
        crops.add(new Crop(2.0, 2.0, 2.0, new Date(12345), "Wiet"));
        CropRepository testRepo =  Mockito.mock(CropRepository.class);
        doThrow(new RecoverableDataAccessException("error")).when(testRepo).save((Crop)anyObject());
        when(testRepo.findAll()).thenReturn(crops);
        return testRepo;
    }

    @Bean
    public CropService testCropService(){
        return new CropService();
    }

}
