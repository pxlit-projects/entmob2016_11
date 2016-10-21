package be.pxl.Models;

import javax.persistence.*;
import java.io.Serializable;
import java.util.Date;

/**
 * Created by 11308157 on 14/10/2016.
 */
@Entity
@Table(name="crops")
public class Crop implements Serializable {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name="id")
    private int id;

    @Column(name="humidity")
    private double humidity;

    @Column(name="name")
    private String name;

    @Column(name="temperature")
    private double temperature;

    @Column(name="light")
    private double light;

    @Column(name="finaldate")
    private Date finalDate;

    public Crop(double humidity, double temperature, double light, Date finalDate, String name) {
        this.humidity = humidity;
        this.temperature = temperature;
        this.light = light;
        this.finalDate = finalDate;
        this.name = name;
    }
    public Crop(){

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

    public Date getFinalDate() {
        return finalDate;
    }

    public void setFinalDate(Date finalDate) {
        this.finalDate = finalDate;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
}
