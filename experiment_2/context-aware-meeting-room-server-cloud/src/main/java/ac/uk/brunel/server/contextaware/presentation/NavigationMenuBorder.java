package ac.uk.brunel.server.contextaware.presentation;

import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.border.Border;

class NavigationMenuBorder extends Border {

    NavigationMenuBorder(final String componentName) {
        super(componentName);
        add(new Label("title", "Context-aware Meeting Room"));
    }
}
