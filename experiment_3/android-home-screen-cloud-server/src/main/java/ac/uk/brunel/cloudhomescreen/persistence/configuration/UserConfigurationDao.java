package ac.uk.brunel.cloudhomescreen.persistence.configuration;

import ac.uk.brunel.cloudhomescreen.dto.UserConfiguration;


public interface UserConfigurationDao {
    public void persistConfiguration(final UserConfiguration userConfiguration);
    public UserConfiguration getConfiguration(final String user);
    public void deleteAll();
}
