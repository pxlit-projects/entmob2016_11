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

    public User(String username, String password) {
        this.username = username;
        this.password = password;
    }
    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name="id")
    private int id;

    @Column(name="username")
    private String username;

    @Column(name="password")
    private String password;


    @Column(name="enabled")
    private boolean enabled;

    @OneToMany(mappedBy = "user")
    private Set<SensorEntity> sensorEntities = new HashSet<SensorEntity>();

    @OneToMany(mappedBy = "user")
    private Set<UserRole> userRoles = new HashSet<UserRole>();

    public Set<UserRole> getUserRoles() {
        return userRoles;
    }

    public void setUserRoles(Set<UserRole> userRoles) {
        this.userRoles = userRoles;
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

    public boolean isEnabled() {
        return enabled;
    }

    public void setEnabled(boolean enabled) {
        this.enabled = enabled;
    }

    public Set<SensorEntity> getSensorEntities() {
        return sensorEntities;
    }

    public void setSensorEntities(Set<SensorEntity> sensorEntities) {
        this.sensorEntities = sensorEntities;
    }

}
