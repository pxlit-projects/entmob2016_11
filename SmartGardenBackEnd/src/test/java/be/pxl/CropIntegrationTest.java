package be.pxl;

import be.pxl.Models.Crop;
import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;
import org.junit.After;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.*;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.springframework.test.context.web.WebAppConfiguration;
import org.springframework.web.client.RestTemplate;

import java.io.*;

import java.net.*;
import java.sql.Timestamp;
import java.util.*;

/**
 * Created by 11402946 on 28/10/2016.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@WebAppConfiguration
@SpringBootTest
public class CropIntegrationTest {

    private Crop tCrop;

    @Before
    public void init() throws Exception {
        tCrop = new Crop(2.0, 2.0, 2.0, new Timestamp(12000), "CecinestpasuneCrop");
        postAddCrop();
    }

    @After
    public void destroy() {
        try {
            deleteCrop();

        }catch (Exception e){
            e.printStackTrace();
        }
    }

    @Test
    public void testGet() {
        try {
            boolean added = false;
            List<Crop> sCrops = getCrops();

            for (Crop s:sCrops) {
                if(s.getHumidity() == tCrop.getHumidity() && s.getTemperature() == tCrop.getTemperature()
                    && s.getFinalDate().equals(tCrop.getFinalDate()) && s.getLight() == s.getLight()
                        && s.getName().equals(tCrop.getName())){
                    added = true;
                }
            }

            Assert.assertTrue(added);

        } catch (Exception e) {
            e.printStackTrace();
        }

    }

    public void deleteCrop() throws Exception{

        //Crop ID vinden
        RestTemplate restTemplate = new RestTemplate();
        String urlString = "http://localhost:9999/crop/getByName/CecinestpasuneCrop";

// set headers
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        String encoding = Base64.getEncoder().encodeToString("mkyong:123456".getBytes("UTF-8"));
        headers.set("Authorization", "Basic " + encoding);
        HttpEntity<String> entity = new HttpEntity<>(headers);

// send request

        Crop result = restTemplate.exchange(urlString, HttpMethod.GET, entity, Crop.class).getBody();

        //Crop verwijderen met id
        urlString = "http://localhost:9999/crop/delete/" + result.getId();
        restTemplate.exchange(urlString, HttpMethod.DELETE, entity, String.class);
    }

    public void postAddCrop() throws Exception {

        RestTemplate restTemplate = new RestTemplate();
        String urlString = "http://localhost:9999/crop/add";

        ObjectMapper mapper = new ObjectMapper();
        String jsonEntity = mapper.writeValueAsString(tCrop);
// set headers
        HttpHeaders headers = new HttpHeaders();
        headers.setContentType(MediaType.APPLICATION_JSON);
        String encoding = Base64.getEncoder().encodeToString("mkyong:123456".getBytes("UTF-8"));
        headers.set("Authorization", "Basic " + encoding);
        HttpEntity<String> entity = new HttpEntity<>(jsonEntity, headers);

// send request

        restTemplate.exchange(urlString, HttpMethod.POST, entity, String.class);
    }

    public List<Crop> getCrops() throws Exception {

        List<Crop> sCrops;

        URL url = new URL("http://localhost:9999/crop");
        String encoding = Base64.getEncoder().encodeToString("mkyong:123456".getBytes("UTF-8"));

        HttpURLConnection connection = (HttpURLConnection) url.openConnection();
        connection.setRequestMethod("GET");
        connection.setRequestProperty("Content-length", "0");
        connection.setDoOutput(true);
        connection.setRequestProperty("Authorization", "Basic " + encoding);

        InputStream content = connection.getInputStream();
        String jsonReply = convertStreamToString(content);

        ObjectMapper mapper = new ObjectMapper();
        sCrops = mapper.readValue(jsonReply, new TypeReference<List<Crop>>() {
        });
        connection.disconnect();
        return sCrops;

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
