package be.pxl.Logger;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.messaging.Message;
import org.springframework.stereotype.Service;
import javax.jms.TextMessage;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;

/**
 * Created by 11308157 on 28/10/2016.
 */
@Service
public class Receiver {
    @JmsListener(destination = "ServiceQueue")
    public void onMessage(Message msg){
        File file = new File("Logging.txt");
        String text = null;
        try (BufferedWriter bw = new BufferedWriter(new FileWriter(file))) {
            text = ((TextMessage) msg).getText();
            bw.write(text);
        }catch (Exception e) {
            e.printStackTrace();
        }
    }
}
