package ac.uk.brunel.client.contextaware.config;

import com.google.inject.Guice;
import com.google.inject.Injector;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertFalse;


public class GuiceApplicationConfigTest {
    private Injector injector;

    @Before
    public void setup() {
        injector = Guice.createInjector(new ServerAppModule());
    }

    @Test
    public void testGuiceConfig() {
        assertFalse(injector == null);
    }
}
