package ac.uk.brunel.server.contextaware.presentation;

import org.apache.wicket.Component;
import org.apache.wicket.MarkupContainer;
import org.apache.wicket.markup.html.WebPage;
import org.apache.wicket.markup.html.border.Border;


public class BasePage extends WebPage {
    private Border border = null;

    protected MarkupContainer add(final Component child) {
        // Add child component of the page to the page's border component
        if (border == null) {
            // Create border and add it to the page
            border = new NavigationMenuBorder("menu");
            super.add(border);
        }

        border.add(child);
        return this;
    }
}
