package be.pxl;

import org.springframework.jms.annotation.JmsListener;

import org.springframework.stereotype.Component;
import org.springframework.stereotype.Service;
import javax.jms.JMSException;
import javax.jms.Message;
import javax.jms.TextMessage;

/**
 * Created by 11308157 on 7/11/2016.
 */
@Service
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