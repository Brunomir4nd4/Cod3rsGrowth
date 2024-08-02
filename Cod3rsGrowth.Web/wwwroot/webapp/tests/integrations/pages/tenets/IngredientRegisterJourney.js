sap.ui.define([
	"sap/ui/test/opaQunit",
	"coders-growth/tests/integrations/pages/IngredientsList",
	"coders-growth/tests/integrations/pages/IngredientRegister",
    "coders-growth/tests/integrations/pages/IngredientDetails"
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
        const VALOR_INPUT_TESTE_DE_EDICAO = "Teste de Edição";
        const VALOR_INPUT_34 = 34;
        const NOME_DO_ITEM = "Perola do End";

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

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeErroEsperada(VALOR_ESPERADO_TRUE);
        });
		
		opaTest("Criar Abobora como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_ABOBORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(INPUT_5);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada(VALOR_ESPERADO_TRUE);
        });

		opaTest("Criar Polvora como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_POLVORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(INPUT_15);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada(VALOR_ESPERADO_TRUE);
        });

		opaTest("Criar Lagíma de Ghast como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(INPUT_LAGRIMA_DE_GHAST);
            When.naPaginaDeCadastroDeIngrediente.aoInserir2NoInputQuantidade(INPUT_2);
            When.naPaginaDeCadastroDeIngrediente.aoClicarAbrirSelect();
            When.naPaginaDeCadastroDeIngrediente.aoSelecionarNaturalidadeNether();
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada(VALOR_ESPERADO_TRUE);
        });

        opaTest("Deve editar um ingrediente escolhido na listagem", function(Given, When, The) {
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoDeVoltarPagina();
            When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(NOME_DO_ITEM);
            When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoEditar();
            When.naPaginaDeCadastroDeIngrediente.aoInserirValorNoInputQuantidade(VALOR_INPUT_34);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoDeVoltarPagina();

            The.naPaginaDeListagemDosIngredientes.aTabelaDeveConterOItemEsperado(VALOR_INPUT_34);
        })
    }
);