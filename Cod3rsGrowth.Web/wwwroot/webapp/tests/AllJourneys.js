sap.ui.define([
	"sap/ui/test/Opa5",
    "./Startup",
    "./IngredientsListJourney",
    "./IngredientRegisterJourney"
], function (Opa5, Startup) {
    "use Strict";

    const NAME_SPACE = "coders-growth.view";
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: NAME_SPACE,
        autoWait: true
    })
})