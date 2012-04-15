package ac.uk.brunel.client.contextaware.transport.servlet;

import com.google.inject.Singleton;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@Singleton
public class PingServletImpl extends HttpServlet implements PingServlet {
    private static final Logger logger = LoggerFactory.getLogger(PingServletImpl.class);

    public PingServletImpl() {
    }

    public HttpServlet getServletObject() {
        return this;
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) {
        logPing(request);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response) {
        logPing(request);
    }

    private void logPing(final HttpServletRequest request) {
        if (logger.isInfoEnabled()) {
            logger.info("Connection ping received from: " + request.getRemoteAddr());
        }
    }
}
