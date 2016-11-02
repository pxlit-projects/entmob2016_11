package be.pxl.Repositories;

import be.pxl.Models.UserRole;
import org.springframework.data.repository.CrudRepository;

/**
 * Created by 11308157 on 2/11/2016.
 */
public interface UserRoleRepository extends CrudRepository<UserRole, Integer> {
    void deleteByUserId(int id);
}
