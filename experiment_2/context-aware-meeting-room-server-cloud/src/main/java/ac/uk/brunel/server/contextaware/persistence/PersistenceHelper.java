package ac.uk.brunel.server.contextaware.persistence;

import com.google.inject.ImplementedBy;

import javax.persistence.EntityManager;


@ImplementedBy(PersistenceHelperImpl.class)
// Wicket needs this
public interface PersistenceHelper {
    public EntityManager get();
}
