package ac.uk.brunel.client.contextaware.integration.participant;

import ac.uk.brunel.client.contextaware.integration.bluetooth.dto.BluetoothDevice;

import java.util.List;

public interface MeetingUsersRegistration {
    public void registerConnectedParticipants(final String meetingId, final List<BluetoothDevice> bluetoothDevices);
}
