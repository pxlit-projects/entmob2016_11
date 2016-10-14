package be.pxl.Services;

import be.pxl.Models.SensorAbove;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by 11308157 on 8/10/2016.
 */
public class Test {
    public static void main(String[] args) {
        SensorAboveService service = new SensorAboveService();

        List<SensorAbove> test = new ArrayList<SensorAbove>();
        service.getAll();
    }
}
