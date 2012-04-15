package ac.uk.brunel.server.contextaware.presentation.register;

import ac.uk.brunel.server.contextaware.persistence.user.UserDao;
import ac.uk.brunel.server.contextaware.presentation.BasePage;
import ac.uk.brunel.server.contextaware.presentation.propertymodel.UserWicketPropertyModel;
import com.google.inject.Inject;
import org.apache.wicket.markup.html.basic.Label;



class ConfirmRegistration extends BasePage {
    @Inject
    private UserDao userDao; // Wicket needs it to be field injection

    ConfirmRegistration(final UserWicketPropertyModel wicketUser) {
        registerUser(wicketUser);
    }

    // Should only be used for testing!
    ConfirmRegistration(final UserDao userDao, final UserWicketPropertyModel wicketUser) {
        this.userDao = userDao;
        registerUser(wicketUser);
    }

    private void registerUser(final UserWicketPropertyModel wicketUser) {
        userDao.registerUser(wicketUser.getUser());

        add(new Label("email", wicketUser.getEmail()));
    }
}
