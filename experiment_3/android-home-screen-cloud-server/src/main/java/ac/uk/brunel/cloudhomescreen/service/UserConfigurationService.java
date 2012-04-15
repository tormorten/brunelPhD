package ac.uk.brunel.cloudhomescreen.service;

import ac.uk.brunel.cloudhomescreen.dto.UserConfiguration;

public interface UserConfigurationService {
    public UserConfiguration getConfiguration(final String user);
    public void pushConfiguration(final UserConfiguration userConfiguration);
}
