package ac.uk.brunel.server.contextaware.service;

import ac.uk.brunel.server.contextaware.dto.Meeting;
import ac.uk.brunel.server.contextaware.dto.MeetingNote;

public interface PresentationService {
    public MeetingNote registerStartedMeeting(final Meeting meeting);
    public void registerConnectedUser(final String meetingId, final String btAddress);
    public void updateCurrentSlideNumber(final String meetingId, final int currentSlideNumber);
    public String getCurrentSlideNote(final String meetingId, final String participant);
    public String[] getCurrentSlideNote(final String participantBtAddress);
}
