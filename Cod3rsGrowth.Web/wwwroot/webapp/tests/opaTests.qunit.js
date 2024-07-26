QUnit.config.autoStart = false;

sap.ui.require([
    "sap/ui/core/Core",
    "coders-growth/tests/AllJourneys"
    // "sap/ui/core/Core"
], async (Core) => {
    "use strict";

    await Core.ready();

    // sap.ui.require([
    //     "coders-growth/tests/AllJourneys"
    // ], () => {
    //     QUnit.start();
    // })
    QUnit.config.semaphore = 0;
    QUnit.start();
});
