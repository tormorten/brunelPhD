package ac.uk.brunel.cloudhomescreen.presentation.beans;

import ac.uk.brunel.cloudhomescreen.persistence.configuration.UserConfigurationDao;
import com.google.inject.Inject;
import net.sourceforge.stripes.action.DefaultHandler;
import net.sourceforge.stripes.action.ForwardResolution;
import net.sourceforge.stripes.action.Resolution;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;


public class DeleteConfigurationActionBean extends CommonActionBean {
    private final Logger logger = LoggerFactory.getLogger(DeleteConfigurationActionBean.class);
    private static final String VIEW = "/WEB-INF/views/delete_configuration_view.jsp";

    private final UserConfigurationDao userConfigurationDao;

    @Inject
    public DeleteConfigurationActionBean(final UserConfigurationDao userConfigurationDao) {
        this.userConfigurationDao = userConfigurationDao;
    }

    @DefaultHandler
    public Resolution showDeleteConfigurationScreen() {
        return new ForwardResolution(VIEW);
    }

    public Resolution deleteAll() {
        userConfigurationDao.deleteAll();
        
        return new ForwardResolution(VIEW);
    }
}
