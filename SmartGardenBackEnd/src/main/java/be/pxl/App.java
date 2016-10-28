package be.pxl;


import be.pxl.Logger.Receiver;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.jms.annotation.EnableJms;
import org.springframework.jms.config.DefaultJmsListenerContainerFactory;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;


import javax.sql.DataSource;


/**
 * Hello world!
 *
 */

@EnableGlobalMethodSecurity(securedEnabled = true)
@SpringBootApplication
@EnableJms
public class App
{
    public static void main( String[] args )
    {
        SpringApplication.run(App.class, args);
    }
    @Autowired
    DataSource dataSource;

    @Autowired
    Receiver receiver;

    @Autowired
    public void configAuthentication(AuthenticationManagerBuilder auth) throws Exception {

        auth.jdbcAuthentication().dataSource(dataSource)

                .usersByUsernameQuery(
                        "select username,password, enabled from users where username=?")
                .authoritiesByUsernameQuery(
                        "select username, role from user_roles where username=?");

    }
    @Autowired
    public void configure(DefaultJmsListenerContainerFactory fact){
        fact.setPubSubDomain(true);
    }

}

