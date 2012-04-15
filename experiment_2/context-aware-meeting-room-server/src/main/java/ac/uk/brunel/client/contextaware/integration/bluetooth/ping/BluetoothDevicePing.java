package ac.uk.brunel.client.contextaware.integration.bluetooth.ping;

import java.util.List;


public interface BluetoothDevicePing {
    public void startSearch(List<String> registeredBluetoothDevices);
    public void stopSearch();
}
