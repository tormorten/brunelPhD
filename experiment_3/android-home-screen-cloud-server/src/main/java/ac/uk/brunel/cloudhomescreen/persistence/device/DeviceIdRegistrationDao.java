package ac.uk.brunel.cloudhomescreen.persistence.device;

import ac.uk.brunel.cloudhomescreen.dto.DeviceId;


public interface DeviceIdRegistrationDao {
    public void persistDeviceId(final DeviceId deviceId);
}
