package ac.uk.brunel.client.contextaware.service;

import ac.uk.brunel.client.contextaware.annotation.LoggingAspect;
import ac.uk.brunel.client.contextaware.integration.bluetooth.dto.BluetoothDevice;
import ac.uk.brunel.client.contextaware.integration.participant.MeetingUsersRegistration;
import com.google.inject.Inject;

import java.util.List;

@LoggingAspect
public class ParticipantServiceImpl implements ParticipantService {
    private final MeetingUsersRegistration meetingUsersRegistration;

    @Inject
    public ParticipantServiceImpl(final MeetingUsersRegistration meetingUsersRegistration) {
        this.meetingUsersRegistration = meetingUsersRegistration;
    }

    public void registerConnectedParticipants(final String meetingId, final List<BluetoothDevice> bluetoothDevices) {
        if (bluetoothDevices.size() > 0) {
            meetingUsersRegistration.registerConnectedParticipants(meetingId, bluetoothDevices);
        }
    }
}
