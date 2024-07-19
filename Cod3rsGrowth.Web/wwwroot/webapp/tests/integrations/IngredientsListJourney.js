sap.ui.define([
	"sap/ui/test/opaQunit",
	"coders-growth/tests/pages/IngredientsList"
], function (opaTest) {
		"use strict";

		const NAME_SPACE = "coders-growth";
		const STRING_INPUT_OLHO = "Olho";

		QUnit.module("Posts");

		opaTest("Deveria aparecer os ingredientes cotendo Olho no nome", function (Given, When, Then) {
			//Arrangements
			Given.iStartMyUIComponent({
				componentConfig: {
					name: NAME_SPACE
				}
			});

			//Actions
			When.naPaginaDeListagemDosIngredientes.aoInserirOlhoNoInputNome(STRING_INPUT_OLHO);

			// Assertions
			Then.naPaginaDeListagemDosIngredientes.aListaDeveConterItensComNomeOlho();
			
			// Cleanup
			Then.iTeardownMyApp();
		});

		opaTest("Clicar no botão OverWorld deve apresentar somentes os itens do OverWorld", function (Given, When, Then) {
			//Arrangements
			Given.iStartMyUIComponent({
				componentConfig: {
					name: NAME_SPACE
				}
			});
			
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoOverWorld();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItensDoOverWorld();

			Then.iTeardownMyApp();
		})

	}
);