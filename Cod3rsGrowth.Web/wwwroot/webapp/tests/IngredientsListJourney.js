sap.ui.define([
	"sap/ui/test/opaQunit",
	"coders-growth/tests/integrations/pages/IngredientsList",
	"coders-growth/tests/integrations/pages/IngredientRegister"
], function (opaTest) {
		"use strict";

		const NAME_SPACE = "coders-growth";
		const INPUT_OLHO = "Olho";
		const INPUT_PÓ = "Pó";
		const INPUT_ABOBOR4 = "Abobor4";
		const INPUT_ABOBORA = "Abobora";
		const INPUT_POLVORA = "Polvora";
		const INPUT_LAGRIMA_DE_GHAST = "Lagíma de Ghast";
		const INPUT_15 = 15;
		const INPUT_5 = 5;
		const INPUT_2 = 2;

		QUnit.module("Posts");

		opaTest("Deve aparecer os ingredientes cotendo Olho no nome", function (Given, When, Then) {
			//Arrangements
			Given.iStartMyUIComponent({
				componentConfig: {
					name: NAME_SPACE
				}
			});

			//Actions
			When.naPaginaDeListagemDosIngredientes.aoInserirOlhoNoInputNome(INPUT_OLHO);

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
			
			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoOverWorld();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItensDoOverWorld();
		});

		opaTest("Clicar no botão Nether deve apresetar somente os itens do Nether", function (Given, When, Then) {
			
			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoNether();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConter2ItensDoNether();
		});

		opaTest("Clicar no botão TheEnd deve apresetar somente os itens do TheEnd", function (Given, When, Then) {
			
			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoTheEnd();

			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConter1ItemDoTheEnd();
		});

		opaTest("Deve apresentar os ingredientes contendo Pó no nome e com quantidade igual a 15", function (Given, When, Then) {
			//Actions
			When.naPaginaDeListagemDosIngredientes.aoClicarAbrirSelect();
			When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoTodos();
			When.naPaginaDeListagemDosIngredientes.aoInserirPoNoInputNome(INPUT_PÓ);
			When.naPaginaDeListagemDosIngredientes.aoInserir15NoInputQuantidade(INPUT_15);

			// Assertions
			Then.naPaginaDeListagemDosIngredientes.aTabelaDeveConterItensComNomePoEQuantidade15();
			
			// Cleanup
			Then.iTeardownMyApp();
		});

		// opaTest("Deve trocar para view Cadastro de Ingredientes", function (Given, When, Then) {
		// 	Given.iStartMyUIComponent({
		// 		componentConfig: {
		// 			name: NAME_SPACE
		// 		}
		// 	});

        //     When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoDeAdiconar();

        //     Then.naPaginaDeCadastroDeIngrediente.deveAbrirViewDeCadastro();
        // });

		// opaTest("Deve tentar criar um ingrediente com valores inválidos", function (Given, When, Then) {

        //     When.naPaginaDeCadastroDeIngrediente.aoInserirAbobor4NoInputNome(INPUT_ABOBOR4);
        //     When.naPaginaDeCadastroDeIngrediente.aoInserirAbobor4NoInputQuantidade(INPUT_ABOBOR4);
        //     When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

        //     Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeErroEsperada();
        // });

		// opaTest("Deve tentar criar um ingrediente com valor quantidade inválidos", function (Given, When, Then) {

        //     When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_ABOBORA);
        //     When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputQuantidade(INPUT_ABOBORA);
        //     When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

        //     Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeErroEsperada();
        // });
		
		// opaTest("Criar Abobora como um ingrediente", function (Given, When, Then) {

        //     When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_ABOBORA);
        //     When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(INPUT_5);
        //     When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

        //     Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada();
        // });

		// opaTest("Criar Polvora como um ingrediente", function (Given, When, Then) {

        //     When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_POLVORA);
        //     When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(INPUT_15);
        //     When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

        //     Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada();
        // });

		// opaTest("Criar Lagíma de Ghast como um ingrediente", function (Given, When, Then) {

        //     When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_LAGRIMA_DE_GHAST);
        //     When.naPaginaDeCadastroDeIngrediente.aoInserir2NoInputQuantidade(INPUT_2);
        //     When.naPaginaDeCadastroDeIngrediente.aoClicarAbrirSelect();
        //     When.naPaginaDeCadastroDeIngrediente.aoSelecionarNaturalidadeNether();
        //     When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

        //     Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada();
        // });
	}
);