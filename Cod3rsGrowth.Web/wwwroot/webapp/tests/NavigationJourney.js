sap.ui.require([
    "sap/ui/test/opaQunit",
    "coders-growth/tests/pages/App"
], (opaTest) => {

    QUnit.module("Navigation");

    opaTest("Ao pressionar o botão", (Given, When, Then) => {
        //Arrangements
        Given.iStartMyUIComponent({
            componentConfig: {
                name: "coders-growth"
            }
        });

        //Actions
        When.onTheAppPage.euClicoNoBotao();

        //Assertions
        Then.onTheAppPage.oBotaoDeveTerOTextoAlterado();

        // Cleanup
		Then.iTeardownMyApp()
    });
});