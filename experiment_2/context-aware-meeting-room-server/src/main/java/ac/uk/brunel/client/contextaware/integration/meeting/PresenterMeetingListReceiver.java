package ac.uk.brunel.client.contextaware.integration.meeting;

import ac.uk.brunel.client.contextaware.dto.Meeting;

import java.util.List;

public interface PresenterMeetingListReceiver {
    public List<Meeting> getPresenterMeetingList(final String email);
}
