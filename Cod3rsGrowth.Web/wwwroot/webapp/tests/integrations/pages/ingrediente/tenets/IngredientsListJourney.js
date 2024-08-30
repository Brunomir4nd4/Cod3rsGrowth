sap.ui.define([
	"sap/ui/test/opaQunit",
	"coders-growth/tests/integrations/pages/ingrediente/IngredientsList"
], function (opaTest) {
		"use strict";

		const QUERY_OLHO = "Olho";
		const QUERY_PO = "Pó";
		const QUERY_15 = 15;

		QUnit.module("Listagem");

		opaTest("Deve aparecer os ingredientes cotendo Olho no nome", function (Given, When, Then) {
			Given.iStartMyApp();

			//Actions
			When.naPaginaDeListagemDosIngredientes.aoInserirOlhoNoInputNome(QUERY_OLHO);

			// Assertions
			Then.naPaginaDeListagemDosIngredientes.aListaDeveConterItensComNomeOlho();
			
			// Cleanup
			Then.iTeardownMyApp();
		});

		opaTest("Clicar no botão OverWorld deve apresentar somentes os itens do OverWorld", function (Given, When, Then) {
			Given.iStartMyApp();

			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoOverWorld();
			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItensDoOverWorld();
		});

		opaTest("Clicar no botão Nether deve apresetar somente os itens do Nether", function (Given, When, Then) {
			
			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoNether();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItensDoNether();
		});

		opaTest("Clicar no botão TheEnd deve apresetar somente os itens do TheEnd", function (Given, When, Then) {
			
			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoTheEnd();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItemDoTheEnd();
		});

		opaTest("Deve apresentar os ingredientes contendo Pó no nome e com quantidade igual a 15", function (Given, When, Then) {
			//Actions
			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoTodos();
			When.naPaginaDeListagemDosIngredientes.aoInserirPoNoInputNome(QUERY_PO);
			When.naPaginaDeListagemDosIngredientes.aoInserir15NoInputQuantidade(QUERY_15);

			// Assertions
			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItensComNomePoEQuantidade15();
			
			// Cleanup
			Then.iTeardownMyApp();
		});
	}
);