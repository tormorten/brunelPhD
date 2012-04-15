package ac.uk.brunel.cloudhomescreen.persistence.device;

import ac.uk.brunel.cloudhomescreen.dto.DeviceId;


public interface DeviceIdRetrieverDao {
    public DeviceId getDeviceId(final String email);
}
