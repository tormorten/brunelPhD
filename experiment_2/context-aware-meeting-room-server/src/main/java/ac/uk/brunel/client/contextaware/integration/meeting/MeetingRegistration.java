package ac.uk.brunel.client.contextaware.integration.meeting;

import ac.uk.brunel.client.contextaware.dto.Meeting;

import java.util.List;

public interface MeetingRegistration {
    public List<String> registerMeetingAndGetRegisteredParticipants(final Meeting meeting);
}
