package be.pxl;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.jms.annotation.EnableJms;

/**
 * Created by 11308157 on 7/11/2016.
 */
@SpringBootApplication
@EnableJms
public class Applicatie {
    public static void main(String[] args) {

        {
            SpringApplication.run(Applicatie.class, args);
        }
    }
}
