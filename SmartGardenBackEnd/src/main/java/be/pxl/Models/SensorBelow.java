package be.pxl.Models;

import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Entity
@Table(name="sensorbelow")
public class SensorBelow {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name="id")
    private int id;

    @Column(name="humidity")
    private double humidity;

    @Column(name="temperature")
    private double temperature;

    @Column(name="light")
    private double light;

    @Column(name="timeofrecording")
    private Date timeOfRecording;

    @JsonIgnore
    @ManyToOne
    private User user;

    public SensorBelow(double humidity, double temperature, double light, User user) {
        this.humidity = humidity;
        this.temperature = temperature;
        this.light = light;
        this.user = user;

        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        Date date = new Date();
        try {
            timeOfRecording = dateFormat.parse(date.toString());
        }
        catch(ParseException ex){
            System.out.println("Cannot parse");
        }

    }

    public SensorBelow() {
        SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        Date date = new Date();
        try {
            timeOfRecording = dateFormat.parse(date.toString());
        }
        catch(ParseException ex){
            System.out.println("Cannot parse");
        }
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public double getHumidity() {
        return humidity;
    }

    public void setHumidity(double humidity) {
        this.humidity = humidity;
    }

    public double getTemperature() {
        return temperature;
    }

    public void setTemperature(double temperature) {
        this.temperature = temperature;
    }

    public double getLight() {
        return light;
    }

    public void setLight(double light) {
        this.light = light;
    }

    public Date getTimeOfRecording() {
        return timeOfRecording;
    }

    public void setTimeOfRecording(Date timeOfRecording) {
        this.timeOfRecording = timeOfRecording;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }
}
