package be.pxl.repositories;


import be.pxl.models.User;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

/**
 * Created by 11308157 on 7/10/2016.
 */
@Repository
public interface UserRepository extends CrudRepository<User, Integer> {
    User findByusername(String name);
    void delete(User user);
}
