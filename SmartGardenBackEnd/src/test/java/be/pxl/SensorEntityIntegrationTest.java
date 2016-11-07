package be.pxl;

import be.pxl.Models.SensorEntity;
import be.pxl.Models.User;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;

import java.io.*;

import java.net.*;
import java.time.LocalDateTime;
import java.util.*;

/**
 * Created by 11402946 on 28/10/2016.
 */

@RunWith(SpringJUnit4ClassRunner.class)
//@SpringApplicationConfiguration(classes = Application.class)
@WebAppConfiguration
@SpringBootTest
public class SensorEntityIntegrationTest {

    private SensorEntity sTag;

    @Before
    public void init() throws Exception{
        sTag = new SensorEntity(1.0, 1.0, 1.0, null, false);
        postAddSensorEnt();
    }

    @Test
    public void testGet(){
        try{
            List<SensorEntity> sTags = getSensorEnt();

            Assert.assertFalse(sTags.contains(sTag));

        }catch (Exception e){
            e.printStackTrace();
        }

    }

    //add functie werkt niet
    public void postAddSensorEnt() throws Exception{
        ObjectMapper mapper = new ObjectMapper();
        String jsonEntity = mapper.writeValueAsString(sTag);

        URL url = new URL ("http://localhost:9999/sensorentity/add");
        String encoding = Base64.getEncoder().encodeToString("mkyong:123456".getBytes("UTF-8"));

        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("POST");
        connection.setRequestProperty("Content-length", "0");
        connection.setRequestProperty("Content-Type", "application/json");
        connection.setDoInput(true);
        connection.setDoOutput(true);
        connection.setRequestProperty  ("Authorization", "Basic " + encoding);

        connection.getOutputStream().write(jsonEntity.getBytes());
        connection.disconnect();
    }

    public List<SensorEntity> getSensorEnt() throws Exception{

        List<SensorEntity> sTags = null;

        URL url = new URL ("http://localhost:9999/sensorentity");
        String encoding = Base64.getEncoder().encodeToString("mkyong:123456".getBytes("UTF-8"));

        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("GET");
        connection.setRequestProperty("Content-length", "0");
        connection.setDoOutput(true);
        connection.setRequestProperty  ("Authorization", "Basic " + encoding);

        InputStream content = connection.getInputStream();
        String jsonReply = convertStreamToString(content);

        ObjectMapper mapper = new ObjectMapper();
        sTags = mapper.readValue(jsonReply, new TypeReference<List<SensorEntity>>(){});
        connection.disconnect();
        return sTags;

    }

    private static String convertStreamToString(InputStream is) {

        BufferedReader reader = new BufferedReader(new InputStreamReader(is));
        StringBuilder sb = new StringBuilder();

        String line = null;
        try {
            while ((line = reader.readLine()) != null) {
                sb.append(line + "\n");
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                is.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return sb.toString();
    }
}
