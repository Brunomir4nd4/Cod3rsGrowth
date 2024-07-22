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
					const primeiroItem = 0;
					const filtroDeInput = "Olho";
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: (oTable) => {
							const aCells = oTable.getItems()[primeiroItem].getCells();

							const result = aCells.map((cell) => {
								return cell.getText().includes(filtroDeInput);
							})

							if (result)
								return true;
							return false;
						},
						success: function() {
							Opa5.assert.ok(true, "A tabela possui somente valores com Olho em seus nomes");
						},
						errorMessage: "A tabela não possui somente valores com Olho em seus nomes"
					});
				},

				aTabelaDeveConterItensComNomePoEQuantidade15() {
					const tamanhoEsperado = 2
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: "items",
							length: tamanhoEsperado
						}),
						success: function() {
							Opa5.assert.ok(true, `A tabela possui somente ${tamanhoEsperado} valores`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores`
					})
				},
				
				aTabelaDeveConter7Itens() {
					const tamanhoEsperado = 7;
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: "items",
							length: tamanhoEsperado
						}),
						success: function() {
							Opa5.assert.ok(true, `A tabela possui somente ${tamanhoEsperado} valores`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores`
					})
				},

				aTabelaDeveConter2Itens() {
					const tamanhoEsperado = 2;
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: "items",
							length: tamanhoEsperado
						}),
						success: function() {
							Opa5.assert.ok(true, `A tabela possui somente ${tamanhoEsperado} valores`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores`
					})
				},

				aTabelaDeveConter1Item() {
					const tamanhoEsperado = 1;
					return this.waitFor({
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationLengthEquals({
							name: "items",
							length: tamanhoEsperado
						}),
						success: function() {
							Opa5.assert.ok(true, `A tabela possui somente ${tamanhoEsperado} valores`);
						},
						errorMessage: `A tabela não possui somente ${tamanhoEsperado} valores`
					})
				}
			}
		}
	});
});
