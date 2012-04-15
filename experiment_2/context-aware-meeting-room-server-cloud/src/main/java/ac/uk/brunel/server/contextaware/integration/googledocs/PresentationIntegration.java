package ac.uk.brunel.server.contextaware.integration.googledocs;

import ac.uk.brunel.server.contextaware.dto.Meeting;
import ac.uk.brunel.server.contextaware.dto.MeetingNote;


public interface PresentationIntegration {
    public MeetingNote createPresentationNoteObject(final Meeting meeting);
}
