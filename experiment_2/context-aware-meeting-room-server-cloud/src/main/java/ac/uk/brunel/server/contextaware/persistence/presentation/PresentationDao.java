package ac.uk.brunel.server.contextaware.persistence.presentation;

import ac.uk.brunel.server.contextaware.dto.MeetingNote;

import java.util.List;


public interface PresentationDao {
    public void persistStartedMeeting(final MeetingNote meetingNote);
    public MeetingNote findMeetingNote(final String meetingId);
    public List<MeetingNote> findAllMeetingNotes();
}
