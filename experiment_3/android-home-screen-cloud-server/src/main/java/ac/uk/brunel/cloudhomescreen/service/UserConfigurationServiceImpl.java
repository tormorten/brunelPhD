package ac.uk.brunel.cloudhomescreen.service;

import ac.uk.brunel.cloudhomescreen.dto.UserConfiguration;
import ac.uk.brunel.cloudhomescreen.integration.Cloud2DevicePush;
import ac.uk.brunel.cloudhomescreen.persistence.configuration.UserConfigurationDao;
import ac.uk.brunel.cloudhomescreen.persistence.device.DeviceIdRetrieverDao;
import com.google.inject.Inject;


public class UserConfigurationServiceImpl implements UserConfigurationService {
    private final UserConfigurationDao userConfigurationDao;
    private final Cloud2DevicePush cloud2DevicePush;

    @Inject
    public UserConfigurationServiceImpl(final UserConfigurationDao userConfigurationDao,
                                        final Cloud2DevicePush cloud2DevicePush) {
        this.userConfigurationDao = userConfigurationDao;
        this.cloud2DevicePush = cloud2DevicePush;
    }

    public UserConfiguration getConfiguration(final String user) {
        return userConfigurationDao.getConfiguration(user);
    }

    public void pushConfiguration(final UserConfiguration userConfiguration) {
        userConfigurationDao.persistConfiguration(userConfiguration);
        cloud2DevicePush.pushConfiguration(userConfiguration);
    }
}
