package ac.uk.brunel.server.contextaware.service;

import ac.uk.brunel.server.contextaware.dto.Meeting;

import java.util.List;


public interface MeetingService {
    public void refreshMeetingList();
    public List<Meeting> getTodaysPresenterMeetings(final String email);
}
