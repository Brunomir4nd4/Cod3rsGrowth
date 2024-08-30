sap.ui.define([
	"sap/ui/test/opaQunit",
	"coders-growth/tests/integrations/pages/ingrediente/IngredientRegister",
    "coders-growth/tests/integrations/pages/ingrediente/IngredientDetails"
], function (opaTest) {
		"use strict";
		
        const NAME_SPACE = "coders-growth";
        const HASH_DE_CADASTRO = "CadastroIngrediente";
		const NOME_INVALIDO_DO_PRODUTO = "Abobor4";
		const NOME_DO_PRODUTO_ABOBORA = "Abobora";
		const NOME_DO_PRODUTO_POLVORA = "Polvora";
		const NOME_DO_PRODUTO_LAGRIMA_DE_GHAST = "Lagíma de Ghast";
        const NOME_DO_PRODUTO_PEROLA_DO_END = "Pérola do End";
		const QUANTIDADE_DO_PRODUTO_15 = 15;
		const QUANTIDADE_DO_PRODUTO_5 = 5;
		const QUANTIDADE_DO_PRODUTO_2 = 2;
        const QUANTIDADE_DO_PRODUTO_34 = 34;
        const VALOR_ESPERADO_TRUE = true;

        QUnit.module("Cadastro");

		opaTest("Deve tentar criar um ingrediente com valores inválidos", function (Given, When, Then) {
            Given.iStartMyUIComponent({
                componentConfig: {
                    name: NAME_SPACE
                } ,
                hash: HASH_DE_CADASTRO
            });

            When.naPaginaDeCadastroDeIngrediente.aoInserirAbobor4NoInputNome(NOME_INVALIDO_DO_PRODUTO);
            When.naPaginaDeCadastroDeIngrediente.aoInserirAbobor4NoInputQuantidade(NOME_INVALIDO_DO_PRODUTO);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeErroEsperada(VALOR_ESPERADO_TRUE);
        });

		opaTest("Deve tentar criar um ingrediente com valor quantidade inválidos", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(NOME_DO_PRODUTO_ABOBORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputQuantidade(NOME_DO_PRODUTO_ABOBORA);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeErroEsperada(VALOR_ESPERADO_TRUE);
        });
		
		opaTest("Criar Abobora como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(NOME_DO_PRODUTO_ABOBORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(QUANTIDADE_DO_PRODUTO_5);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada(VALOR_ESPERADO_TRUE);
        });

		opaTest("Criar Polvora como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(NOME_DO_PRODUTO_POLVORA);
            When.naPaginaDeCadastroDeIngrediente.aoInserir5NoInputQuantidade(QUANTIDADE_DO_PRODUTO_15);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada(VALOR_ESPERADO_TRUE);
        });

		opaTest("Criar Lagíma de Ghast como um ingrediente", function (Given, When, Then) {

            When.naPaginaDeCadastroDeIngrediente.aoInserirAboboraNoInputNome(NOME_DO_PRODUTO_LAGRIMA_DE_GHAST);
            When.naPaginaDeCadastroDeIngrediente.aoInserir2NoInputQuantidade(QUANTIDADE_DO_PRODUTO_2);
            When.naPaginaDeCadastroDeIngrediente.aoClicarAbrirSelect();
            When.naPaginaDeCadastroDeIngrediente.aoSelecionarNaturalidadeNether();
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada(VALOR_ESPERADO_TRUE);
        });

        opaTest("Deve editar um ingrediente escolhido na listagem", function(Given, When, Then) {
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoDeVoltarPagina();
            When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(NOME_DO_PRODUTO_PEROLA_DO_END);
            When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoEditar();
            When.naPaginaDeCadastroDeIngrediente.aoInserirValorNoInputQuantidade(QUANTIDADE_DO_PRODUTO_34);
            When.naPaginaDeCadastroDeIngrediente.aoClicarNoBotaoSalvar();

            Then.naPaginaDeCadastroDeIngrediente.deveApresentarMenssagemDeSecessoEsperada(VALOR_ESPERADO_TRUE);
            Then.iTeardownMyApp();
        })
    }
);