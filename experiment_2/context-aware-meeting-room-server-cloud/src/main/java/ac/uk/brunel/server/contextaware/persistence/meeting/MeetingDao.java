package ac.uk.brunel.server.contextaware.persistence.meeting;

import ac.uk.brunel.server.contextaware.dto.Meeting;

import java.util.List;


public interface MeetingDao {
    public void registerMeeting(final Meeting meeting);
    public List<Meeting> getPresenterMeetings(final String email, final String date);
}
