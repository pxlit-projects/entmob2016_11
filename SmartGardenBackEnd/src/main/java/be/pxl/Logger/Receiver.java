package be.pxl.Logger;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.messaging.Message;
import org.springframework.stereotype.Component;

import javax.jms.JMSException;
import javax.jms.TextMessage;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;

/**
 * Created by 11308157 on 28/10/2016.
 */
@Component
public class Receiver {
    @JmsListener(destination = "ServiceQueue")
    public void onMessage(Message msg){
        try{
            if (msg instanceof TextMessage) {
                String text = ((TextMessage)msg).getText();
                System.out.println("Testing the text" + text);
            }
        }
        catch(JMSException e){
            e.printStackTrace();
        }
        /**
        File file = new File("C:/Logging.txt");
        if(!file.exists()){
            try {
                file.createNewFile();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        String text = null;
        try (BufferedWriter bw = new BufferedWriter(new FileWriter(file))) {
            text = ((TextMessage) msg).getText();
            bw.write(text);
            bw.newLine();
        }catch (Exception e) {
            e.printStackTrace();
        }
         */
    }
}
