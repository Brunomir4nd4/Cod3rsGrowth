sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/actions/Press'
], (
	Opa5, 
	EnterText, 
	Press
) => {
	"use strict";

	const NOME_DO_VIEW = "coders-growth.view.Listagem";
    const ID_INPUT_NOME = "filtroNome";
    const ID_INPUT_QUANTIDADE = "filtroQuantidade";
	const ID_TABELA_INGREDIENTES = "tabelaIngrediente";
	const ID_BOTAO_OVERWORLD = "botaoOverWorld";
	const ID_BOTAO_NETHER = "botaoNether";
	const ID_BOTAO_THEEND = "botaoTheEnd";
	const ID_BOTAO_TODOS = "botaoTodos";

	Opa5.createPageObjects({
	
		naPaginaDeListagemDosIngredientes: {

			actions: {
				aoInserirOlhoNoInputNome(stringDeBusca) {
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_INPUT_NOME,
						actions: new EnterText({
							text: stringDeBusca
						}),
						errorMessage: "Campo Nome não encontrado."
					});
				},

				aoClicarNoBotaoOverWorld(){
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_BOTAO_OVERWORLD,
						actions: new Press(),
						errorMessage: "Botão OverWorld não encontrado."
					});
				},

				aoClicarNoBotaoNether(){
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_BOTAO_NETHER,
						actions: new Press(),
						errorMessage: "Botão Nether não encontrado."
					});
				},

				aoClicarNoBotaoTheEnd() {
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_BOTAO_THEEND,
						actions: new Press(),
						errorMessage: "Botão TheEnd não encontrado."
					});
				},

				aoClicarNoBotaoTodos() {
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_BOTAO_TODOS,
						actions: new Press(),
						errorMessage: "Botão Todos não encontrado."
					});
				},

				aoInserirPoNoInputNome(stringDeBusca){
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_INPUT_NOME,
						actions: new EnterText({
							text: stringDeBusca
						}),
						errorMessage: "Campo nome não encontrado."
					})
				},

				aoInserir15NoInputQuantidade(stringDeBusca) {
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_INPUT_QUANTIDADE,
						actions: new EnterText({
							text: stringDeBusca
						}),
						errorMessage: "Campo nome não encontrado."
					})
				}
			},

			assertions: {
				aListaDeveConterItensComNomeOlho() {
					const stringEsperada = "Olho";
					const tamanhoEsperado = 2;
					const tagDasLinhas = "items";
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: tagDasLinhas,
							length: tamanhoEsperado
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = items.every((item) => {
								let itemDesejado = item.getBindingContext("ingrediente").getProperty("nome");
								return itemDesejado.includes(stringEsperada);
							});
				
							Opa5.assert.ok(result, "A tabela possui somente valores com Olho em seus nomes");
						},
						errorMessage: "A tabela não possui somente valores com Olho em seus nomes"
					});
				},

				aTabelaDeveConterItensComNomePoEQuantidade15() {
					const tamanhoEsperado = 1;
					const tagDasLinhas = "items";
					const stringEsperada = "Pó";
					const quantidadeEsperada = 15;
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: tagDasLinhas,
							length: tamanhoEsperado
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = items.every((item) => {
								let nome = item.getBindingContext("ingrediente").getProperty("nome");
								let quantidade = item.getBindingContext("ingrediente").getProperty("quantidade");
								return nome.includes(stringEsperada) & quantidade === quantidadeEsperada;
							});

							Opa5.assert.ok(result, `A tabela possui somente ${tamanhoEsperado} valores`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores`
					})
				},
				
				aTabelaDeveConter7ItensDoOverWorld() {
					const tamanhoEsperado = 7;
					const tagDasLinhas = "items";
					const stringEsperada = "OverWorld";
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: tagDasLinhas,
							length: tamanhoEsperado
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = items.every((item) => {
								let naturalidade = item.getBindingContext("ingrediente").getProperty("naturalidade");
								naturalidade = formatarEnum(naturalidade);
								return naturalidade === stringEsperada;
							});

							Opa5.assert.ok(result, `A tabela possui somente ${tamanhoEsperado} valores do OverWorld`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores do OverWorld`
					})
				},

				aTabelaDeveConter2ItensDoNether() {
					const tamanhoEsperado = 2;
					const tagDasLinhas = "items";
					const stringEsperada = "Nether";
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: tagDasLinhas,
							length: tamanhoEsperado
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = items.every((item) => {
								let naturalidade = item.getBindingContext("ingrediente").getProperty("naturalidade");
								naturalidade = formatarEnum(naturalidade);
								return naturalidade === stringEsperada;
							});

							Opa5.assert.ok(result, `A tabela possui somente ${tamanhoEsperado} valores do Nether`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores do Nether`
					})
				},

				aTabelaDeveConter1ItemDoTheEnd() {
					const tamanhoEsperado = 1;
					const tagDasLinhas = "items";
					const stringEsperada = "TheEnd";
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: tagDasLinhas,
							length: tamanhoEsperado
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = items.every((item) => {
								let naturalidade = item.getBindingContext("ingrediente").getProperty("naturalidade");
								naturalidade = formatarEnum(naturalidade);
								return naturalidade === stringEsperada;
							});

							Opa5.assert.ok(result, `A tabela possui somente ${tamanhoEsperado} valores do TheEnd`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores do TheEnd`
					})
				}
			}
		}
	});

	let formatarEnum = (valorInteiroDoEnum) => {

		switch(valorInteiroDoEnum){
			case 0:
				return "OverWorld";
			case 1:
				return "Nether";
			case 2:
				return "TheEnd";
			default:
				return "Indefinido";
		}
	};
});
