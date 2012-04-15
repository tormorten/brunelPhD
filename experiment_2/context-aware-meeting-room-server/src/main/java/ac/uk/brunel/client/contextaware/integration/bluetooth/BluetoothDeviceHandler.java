package ac.uk.brunel.client.contextaware.integration.bluetooth;

import ac.uk.brunel.client.contextaware.integration.bluetooth.dto.BluetoothDevice;

import java.util.List;


public interface BluetoothDeviceHandler {
    public void addFoundDevice(final BluetoothDevice bluetoothDevice);
    public List<BluetoothDevice> getNewBluetoothDevices();
    public void bluetoothDevicePingFinished();
    public boolean isBluetoothDevicePingFinished();
}
