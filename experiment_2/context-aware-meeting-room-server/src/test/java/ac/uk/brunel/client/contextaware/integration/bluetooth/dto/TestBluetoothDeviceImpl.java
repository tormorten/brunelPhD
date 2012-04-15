package ac.uk.brunel.client.contextaware.integration.bluetooth.dto;


public class TestBluetoothDeviceImpl implements BluetoothDevice {
    private final String btAddress;
    private final String name;

    public TestBluetoothDeviceImpl(final String btAddress, final String name) {
        this.btAddress = btAddress;
        this.name = name;
    }

    public String getBluetoothAddress() {
        return btAddress;
    }
    
    public String getName() {
        return name;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder();
        sb.append("TestBluetoothDeviceImpl");
        sb.append("{btAddress='").append(btAddress).append('\'');
        sb.append(", name='").append(name).append('\'');
        sb.append('}');
        return sb.toString();
    }
}
