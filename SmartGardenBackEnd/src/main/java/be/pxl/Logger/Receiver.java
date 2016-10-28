package be.pxl.Logger;

import org.springframework.jms.annotation.JmsListener;
import org.springframework.messaging.Message;
import org.springframework.stereotype.Service;

import javax.jms.JMSException;
import javax.jms.TextMessage;

/**
 * Created by 11308157 on 28/10/2016.
 */
@Service
public class Receiver {
    @JmsListener(destination = "ServiceQueue")
    public void onMessage(Message msg){
        try {
            System.out.println(((TextMessage) msg).getText());
        } catch (JMSException e) {
            e.printStackTrace();
        }
    }
}
