sap.ui.define([
	"sap/ui/test/opaQunit",
	"coders-growth/tests/integrations/pages/IngredientsList",
	"coders-growth/tests/integrations/pages/IngredientRegister"
], function (opaTest) {
		"use strict";
		
		const INPUT_ABOBOR4 = "Abobor4";
		const INPUT_ABOBORA = "Abobora";
		const INPUT_POLVORA = "Polvora";
		const INPUT_LAGRIMA_DE_GHAST = "Lagíma de Ghast";
		const INPUT_15 = 15;
		const INPUT_5 = 5;
		const INPUT_2 = 2;
        const VALOR_ESPERADO_CADASTRO = "Cadastro";
        const VALOR_ESPERADO_TRUE = true;

        QUnit.module("Posts");

		opaTest("Deve trocar para view Cadastro de Ingredientes", function (Given, When, Then) {
			Given.iStartMyApp();

            When.naPaginaDeListagemDosIngredientes.aoClicarNoBotaoDeAdiconar();

            Then.naPaginaDeCadastroDeIngrediente.deveAbrirViewDeCadastro(VALOR_ESPERADO_CADASTRO);
        });

		opaTest("Deve tentar criar um ingrediente com valores inválidos", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAbobor4NoInputNome(INPUT_ABOBOR4);
            When.naPaginaDeCadastroDeIngrediente.aoInserirAbobor4NoInputQuantidade(INPUT_ABOBOR4);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeErroEsperada(VALOR_ESPERADO_TRUE);
        });

		opaTest("Deve tentar criar um ingrediente com valor quantidade inválidos", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_ABOBORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputQuantidade(INPUT_ABOBORA);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeErroEsperada();
        });
		
		opaTest("Criar Abobora como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_ABOBORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(INPUT_5);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada();
        });

		opaTest("Criar Polvora como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_POLVORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(INPUT_15);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada();
        });

		opaTest("Criar Lagíma de Ghast como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_LAGRIMA_DE_GHAST);
            When.naPaginaDeCadastroDeIngrediente.aoInserir2NoInputQuantidade(INPUT_2);
            When.naPaginaDeCadastroDeIngrediente.aoClicarAbrirSelect();
            When.naPaginaDeCadastroDeIngrediente.aoSelecionarNaturalidadeNether();
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada();
        });
    }
);