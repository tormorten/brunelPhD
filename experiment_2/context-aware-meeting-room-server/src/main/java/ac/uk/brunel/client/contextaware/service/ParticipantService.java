package ac.uk.brunel.client.contextaware.service;

import ac.uk.brunel.client.contextaware.integration.bluetooth.dto.BluetoothDevice;

import java.util.List;

public interface ParticipantService {
    public void registerConnectedParticipants(final String meetingId, final List<BluetoothDevice> bluetoothDevices);
}
