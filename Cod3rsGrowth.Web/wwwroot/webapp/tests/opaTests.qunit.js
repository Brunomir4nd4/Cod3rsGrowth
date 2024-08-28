QUnit.config.autoStart = false;

sap.ui.require([
    "sap/ui/core/Core",
    "coders-growth/tests/AllJourneys"
], async (Core) => {
    "use strict";

    await Core.ready();

    QUnit.config.semaphore = 0;
    QUnit.start();
});
