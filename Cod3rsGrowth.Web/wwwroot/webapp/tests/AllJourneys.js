sap.ui.define([
	"sap/ui/test/Opa5",
    "./integrations/arrangements/Startup",
    "./integrations/pages/ingrediente/tenets/IngredientsListJourney",
    "./integrations/pages/ingrediente/tenets/IngredientRegisterJourney",
    "./integrations/pages/ingrediente/tenets/IngredientDetailsJourney"
], function (Opa5, Startup) {
    "use Strict";

    const NAME_SPACE = "coders-growth.app";
    Opa5.extendConfig({
        arrangements: new Startup(),
        viewNamespace: NAME_SPACE,
        autoWait: true
    })
})