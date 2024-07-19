QUnit.config.autoStart = false;

sap.ui.require([
    "sap/ui/core/Core"
], async (Core) => {
    "use strict";

    await Core.ready();

    sap.ui.require([
		"coders-growth/tests/integrations/IngredientsListJourney"
	], () => {
		QUnit.start();
	});
});