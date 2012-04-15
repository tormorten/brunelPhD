package ac.uk.brunel.cloudhomescreen.integration;

import ac.uk.brunel.cloudhomescreen.dto.UserConfiguration;


public interface Cloud2DevicePush {
    public void pushConfiguration(final UserConfiguration userConfiguration);
}
