package ac.uk.brunel.cloudhomescreen.persistence.auth;

import ac.uk.brunel.cloudhomescreen.dto.AuthToken;


public interface AuthTokenDao {
    public void persistToken(final AuthToken token);
    public AuthToken getToken();
}
