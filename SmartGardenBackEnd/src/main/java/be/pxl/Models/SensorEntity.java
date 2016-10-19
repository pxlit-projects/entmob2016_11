package be.pxl.Models;


import com.fasterxml.jackson.annotation.JsonIgnore;

import javax.persistence.*;
import java.io.Serializable;
import java.time.LocalDateTime;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Entity
@Table(name="sensor_entities")
public class SensorEntity implements Serializable {

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

    @Column(name="time_of_recording")
    private LocalDateTime timeOfRecording;

    @Column(name = "above")
    private boolean above;

    @JsonIgnore
    @ManyToOne
    private User user;

    public SensorEntity(double humidity, double temperature, double light, User user, boolean above) {
        this();
        this.humidity = humidity;
        this.temperature = temperature;
        this.light = light;
        this.user = user;
        this.above = above;
    }

    public SensorEntity(){
        this.timeOfRecording = LocalDateTime.now();
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

    public LocalDateTime getTimeOfRecording() {
        return timeOfRecording;
    }

    public void setTimeOfRecording(LocalDateTime timeOfRecording) {
        this.timeOfRecording = timeOfRecording;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public boolean isAbove() {
        return above;
    }

    public void setAbove(boolean above) {
        this.above = above;
    }
}
