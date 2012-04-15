package ac.uk.brunel.cloudhomescreen.integration;


public interface AppEngineAuthentication {
    public String getAuthToken();
    public void persistToken(final String updatedToken);
}
