package be.pxl.Controllers;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.Persistence;

/**
 * Created by 11308157 on 14/10/2016.
 */
public class oefening {
    public static void main(String[] args) {
        EntityManagerFactory emf = Persistence.createEntityManagerFactory("course");
        EntityManager em = emf.createEntityManager();
        EntityTransaction tx = em.getTransaction();
        tx.begin();
        tx.commit();
        em.close();
        emf.close();
    }
}
