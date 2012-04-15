package ac.uk.brunel.server.contextaware.config;

import ac.uk.brunel.server.contextaware.presentation.error.ErrorPage;
import org.apache.wicket.Page;
import org.apache.wicket.Response;
import org.apache.wicket.protocol.http.WebApplication;
import org.apache.wicket.protocol.http.WebRequest;
import org.apache.wicket.protocol.http.WebRequestCycle;


class WicketRuntimeExceptionHandler extends WebRequestCycle {

    public WicketRuntimeExceptionHandler(WebApplication application, WebRequest request, Response response) {
        super(application, request, response);
    }

    @Override
    public Page onRuntimeException(Page page, RuntimeException exception) {
        return new ErrorPage(page, exception);
    }
}
