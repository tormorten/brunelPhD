package ac.uk.brunel.client.contextaware.service;

import ac.uk.brunel.server.contextaware.presentation.swing.dto.PresentationMeeting;

import java.util.List;


public interface MeetingService {
    public List<PresentationMeeting> getPresenterMeetingList(final String email);
    public void registerMeeting(final PresentationMeeting presentationMeeting);
}
