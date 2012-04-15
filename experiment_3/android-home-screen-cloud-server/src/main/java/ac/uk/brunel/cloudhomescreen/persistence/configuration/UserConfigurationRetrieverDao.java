package ac.uk.brunel.cloudhomescreen.persistence.configuration;

import ac.uk.brunel.cloudhomescreen.dto.UserConfiguration;


public interface UserConfigurationRetrieverDao {
    public UserConfiguration getConfiguration(final String user);
}
