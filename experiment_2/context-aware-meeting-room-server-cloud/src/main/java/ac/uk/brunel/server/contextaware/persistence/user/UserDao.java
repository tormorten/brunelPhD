package ac.uk.brunel.server.contextaware.persistence.user;

import ac.uk.brunel.server.contextaware.dto.User;
import com.google.inject.ImplementedBy;

import java.util.List;


@ImplementedBy(UserDaoImpl.class) // Wicket needs this
public interface UserDao {
    public void registerUser(final User user);
    public List<User> getAllUsers();
    public User findUser(final String email);
    public void deleteUser(final String secret, final String email);
}
