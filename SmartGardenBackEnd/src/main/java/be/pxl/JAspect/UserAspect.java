package be.pxl.jaspect;

import be.pxl.logger.Sender;
import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

/**
 * Created by 11308157 on 21/11/2016.
 */
@Component
@Aspect
public class UserAspect {
    @Autowired
    private Sender sender;

    @Around("execution(* be.pxl.controllers.UserController.GetUserbyUserName(..))")
    public Object AroundGetUserByUsername(ProceedingJoinPoint pjp) throws  Throwable {
        sender.sendMessage("Aanvraag gebruiker");
        Object returnValue = pjp.proceed();
        sender.sendMessage("Aanvraag gebruiker OK");
        return returnValue;
    }

    @AfterThrowing(value = "execution(* be.pxl.controllers.UserController.GetUserbyUserName(..))", throwing = "ex")
    public void afterExceptionGetUserByUsername(Exception ex)   {
        sender.sendMessage("Aanvraag gebruiker error: " + ex.getMessage());
    }

    @Before("execution(* be.pxl.controllers.UserController.GetUserbyUserName(..))")
    public void beforeGettingUser(){
        sender.sendMessage("Aanvraag gebruiker executie");
    }
    @AfterReturning(value = "execution(* be.pxl.controllers.UserController.GetUserbyUserName(..))", returning = "returnValue")
    public void afterGettingUser(String returnValue) {
        sender.sendMessage(returnValue);
    }

}





