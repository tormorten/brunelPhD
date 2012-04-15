package ac.uk.brunel.server.contextaware.persistence.presentation;

import com.google.inject.ImplementedBy;


@ImplementedBy(PresentationDaoImpl.class)
public interface PresentationDaoWicketFacade {
    public void deleteAllMeetingNotes(final String secret);
    public int getNumberOfMeetingNotes();
}
    