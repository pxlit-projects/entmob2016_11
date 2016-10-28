package be.pxl.Logger;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.jms.core.JmsTemplate;
import org.springframework.stereotype.Component;

/**
 * Created by 11308157 on 28/10/2016.
 */
@Component
public class Sender {

    @Autowired
    private JmsTemplate jmsTemplate;

    public void sendMessage(String text){
        jmsTemplate.send("ServiceQueue", s -> s.createTextMessage(text));
    }
}
