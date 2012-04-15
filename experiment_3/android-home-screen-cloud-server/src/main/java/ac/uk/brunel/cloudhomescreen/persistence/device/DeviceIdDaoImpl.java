package ac.uk.brunel.cloudhomescreen.persistence.device;

import ac.uk.brunel.cloudhomescreen.dto.DeviceId;
import com.googlecode.objectify.NotFoundException;
import com.googlecode.objectify.Objectify;
import com.googlecode.objectify.ObjectifyService;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;


public class DeviceIdDaoImpl implements DeviceIdRegistrationDao, DeviceIdRetrieverDao {
    private final Logger logger = LoggerFactory.getLogger(DeviceIdDaoImpl.class);

    static {
        ObjectifyService.register(DeviceId.class);
    }


    public DeviceIdDaoImpl() {
    }

    public void persistDeviceId(final DeviceId deviceId) {
        logger.info("Persisting: " + deviceId);

        final Objectify objectify = ObjectifyService.begin();
        objectify.put(deviceId);
    }

    public DeviceId getDeviceId(final String email) {
        final Objectify objectify = ObjectifyService.begin();
        DeviceId deviceId = null;

        try {
            deviceId = objectify.get(DeviceId.class, email);
        } catch(NotFoundException nfe) {
            logger.error("The device id for user: " + email + " was not found");
        }

        return deviceId;
    }
}
