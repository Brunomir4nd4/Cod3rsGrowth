sap.ui.define([
	"sap/ui/test/opaQunit",
	"coders-growth/tests/pages/IngredientsList"
], function (opaTest) {
		"use strict";

		const NAME_SPACE = "coders-growth";
		const STRING_INPUT_OLHO = "Olho";
		const STRING_INPUT_PÓ = "Pó";
		const QUANTIDADE_INPUT_15 = 15;

		QUnit.module("Posts");

		opaTest("Deve aparecer os ingredientes cotendo Olho no nome", function (Given, When, Then) {
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

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConter7Itens();

		});

		opaTest("Clicar no botão Nether deve apresetar somente os itens do Nether", function (Given, When, Then) {
			
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoNether();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConter2Itens();
		});

		opaTest("Clicar no botão TheEnd deve apresetar somente os itens do TheEnd", function (Given, When, Then) {
			
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoTheEnd();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConter1Item();
		});

		opaTest("Deve apresentar os ingredientes contendo Pó no nome e com quantidade igual a 15", function (Given, When, Then) {
			//Actions
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoTodos();
			When.naPaginaDeListagemDosIngredientes.aoInserirPoNoInputNome(STRING_INPUT_PÓ);
			When.naPaginaDeListagemDosIngredientes.aoInserir15NoInputQuantidade(QUANTIDADE_INPUT_15);

			// Assertions
			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItensComNomePoEQuantidade15();
			
			// Cleanup
			Then.iTeardownMyApp();
		});

	}
);