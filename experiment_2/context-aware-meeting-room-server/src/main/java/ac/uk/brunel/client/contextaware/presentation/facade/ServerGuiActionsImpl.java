package ac.uk.brunel.client.contextaware.presentation.facade;

import ac.uk.brunel.client.contextaware.annotation.LoggingAspect;
import ac.uk.brunel.client.contextaware.presentation.callback.BluetoothDeviceCallback;
import ac.uk.brunel.client.contextaware.service.MeetingService;
import ac.uk.brunel.server.contextaware.presentation.swing.ServerGuiActions;
import ac.uk.brunel.server.contextaware.presentation.swing.ServerGuiCallback;
import ac.uk.brunel.server.contextaware.presentation.swing.dto.PresentationMeeting;
import com.google.inject.Inject;

import java.util.List;

@LoggingAspect
public class ServerGuiActionsImpl implements ServerGuiActions {
    private final MeetingService meetingService;
    private final BluetoothDeviceCallback bluetoothDeviceCallback;

    @Inject
    public ServerGuiActionsImpl(final MeetingService meetingService, final BluetoothDeviceCallback bluetoothDeviceCallback) {
        this.meetingService = meetingService;
        this.bluetoothDeviceCallback = bluetoothDeviceCallback;
    }

    public List<PresentationMeeting> getMeetingList(String email) {
        return meetingService.getPresenterMeetingList(email);
    }

    public void registerMeeting(PresentationMeeting presentationMeeting) {
        meetingService.registerMeeting(presentationMeeting);
        bluetoothDeviceCallback.startBackgroundThread(presentationMeeting.getMeetingId());
    }

    public void setGuiCallback(ServerGuiCallback serverGuiCallback) {
        bluetoothDeviceCallback.setServerGuiCallback(serverGuiCallback);
    }
}
