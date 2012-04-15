package ac.uk.brunel.client.contextaware.presentation.callback;

import ac.uk.brunel.server.contextaware.presentation.swing.ServerGuiCallback;

public interface BluetoothDeviceCallback {
    public void setServerGuiCallback(final ServerGuiCallback serverGuiCallback);
    public void startBackgroundThread(final String meetingId);
}
