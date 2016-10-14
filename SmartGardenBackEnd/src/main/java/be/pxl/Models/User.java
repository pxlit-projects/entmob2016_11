package be.pxl.Models;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Entity
@Table(name="users")
public class User {

    public User(){

    }

    public User(String username, String password, String discriminator) {
        this.username = username;
        this.password = password;
        this.discriminator = discriminator;
    }

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    @Column(name="id")
    private int id;

    @Column(name="username")
    private String username;

    @Column(name="password")
    private String password;

    @Column(name="discriminator")
    private String discriminator;

    @OneToMany(mappedBy = "user")
    private Set<SensorAbove> sensorAboves = new HashSet<SensorAbove>();

    @OneToMany(mappedBy = "user")
    private Set<SensorBelow> sensorBelows = new HashSet<SensorBelow>();


    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getDiscriminator() {
        return discriminator;
    }

    public void setDiscriminator(String discriminator) {
        this.discriminator = discriminator;
    }

    public Set<SensorAbove> getSensorAboves() {
        return sensorAboves;
    }

    public void setSensorAboves(Set<SensorAbove> sensorAboves) {
        this.sensorAboves = sensorAboves;
    }

    public Set<SensorBelow> getSensorBelows() {
        return sensorBelows;
    }

    public void setSensorBelows(Set<SensorBelow> sensorBelows) {
        this.sensorBelows = sensorBelows;
    }
}
