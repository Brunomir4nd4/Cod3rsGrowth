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

	const NOME_DA_VIEW = "Listagem";
    const ID_INPUT_NOME = "filtroNome";
    const ID_INPUT_QUANTIDADE = "filtroQuantidade";
	const ID_TABELA_INGREDIENTES = "tabelaIngrediente";
	const ID_SELECT_NATURALIDADE = "filtroNaturalidade";
	const ID_BOTAO_OVERWORLD = "__component1---listagem--OverWorld";
	const ID_BOTAO_NETHER = "__component1---listagem--Nether";
	const ID_BOTAO_THEEND = "__component1---listagem--TheEnd";
	const ID_BOTAO_TODOS = "__component1---listagem--Todos";
	const ID_BOTAO_ADICIOANAR = "botaoAdicionar";
	const NOME_DO_JSONMODEL = "ingrediente";
	const PROPARTY_NOME = "nome";
	const PROPARTY_NATURALIDADE = "naturalidade";
	const PROPARTY_QUANTIDADDE = "quantidade";
	const PROPRIEDADE_TEXT = "text";

	Opa5.createPageObjects({
	
		naPaginaDeListagemDosIngredientes: {

			actions: {
				aoInserirOlhoNoInputNome(valorDeBusca) {
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_INPUT_NOME,
						actions: new EnterText({
							text: valorDeBusca
						}),
						errorMessage: "Campo Nome não encontrado."
					});
				},

				aoClicarAbrirSelect() {
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_SELECT_NATURALIDADE,
						actions: new Press(),
						errorMessage: "Botão Select não encontrado."
					});
				},

				aoClicarNoBotaoOverWorld(){
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_BOTAO_OVERWORLD,
						actions: new Press(),
						errorMessage: "Botão OverWorld não encontrado."
					});
				},

				aoClicarNoBotaoNether(){
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_BOTAO_NETHER,
						actions: new Press(),
						errorMessage: "Botão Nether não encontrado."
					});
				},

				aoClicarNoBotaoTheEnd() {
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_BOTAO_THEEND,
						actions: new Press(),
						errorMessage: "Botão TheEnd não encontrado."
					});
				},

				aoClicarNoBotaoTodos() {
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_BOTAO_TODOS,
						actions: new Press(),
						errorMessage: "Botão Todos não encontrado."
					});
				},

				aoInserirPoNoInputNome(valorDeBusca){
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_INPUT_NOME,
						actions: new EnterText({
							text: valorDeBusca
						}),
						errorMessage: "Campo nome não encontrado."
					})
				},

				aoInserir15NoInputQuantidade(valorDeBusca) {
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_INPUT_QUANTIDADE,
						actions: new EnterText({
							text: valorDeBusca
						}),
						errorMessage: "Campo nome não encontrado."
					})
				},

				aoClicarNoBotaoDeAdiconar() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_ADICIOANAR,
                        actions: new Press(),
                        errorMessage: "Botão adicionar não encontrado."
                    })
                },

				aoClicarEmUmItemDaTabela(valorEsperado) {
					return this.waitFor({
						controlType: "sap.m.Text",
						matchers: [
							new sap.ui.test.matchers.PropertyStrictEquals({
								name: PROPRIEDADE_TEXT,
								value: valorEsperado
							})
						],
						actions: new Press(),
						errorMessage: "Item não encontrado com o nome esperado: " + valorEsperado
					});
				}
			},

			assertions: {
				aListaDeveConterItensComNomeOlho() {
					const stringEsperada = "Olho";
					const tagDasLinhas = "items";
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationFilled({
							name: tagDasLinhas
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = true;
							items.map((item) => {
								let nome = item.getBindingContext(NOME_DO_JSONMODEL).getProperty(PROPARTY_NOME);
								if (!nome.includes(stringEsperada)) 
									result = false;
							});
				
							Opa5.assert.ok(result, "Todos os itens da tabela possuem 'Olho' em seus nomes");
						},
						errorMessage: "Alguns itens na tabela não possuem 'Olho' em seus nomes"
					});
				},

				aTabelaDeveConterItensComNomePoEQuantidade15() {
					const tagDasLinhas = "items";
					const stringEsperada = "Pó";
					const quantidadeEsperada = 15;
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationFilled({
							name: tagDasLinhas
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = true; 
							items.map((item) => {
								let nome = item.getBindingContext(NOME_DO_JSONMODEL).getProperty(PROPARTY_NOME);
								let quantidade = item.getBindingContext(NOME_DO_JSONMODEL).getProperty(PROPARTY_QUANTIDADDE);
								if (!nome.includes(stringEsperada) & quantidade !== quantidadeEsperada)
									result = false;
							});

							Opa5.assert.ok(result, `A tabela possui o valor com nome ${stringEsperada} e quantidade ${quantidadeEsperada}`);
						},
						errorMessage: `A tabela não possui o valor com nome ${stringEsperada} e quantidade ${quantidadeEsperada}`
					});
				},
				
				aTabelaDeveConterItensDoOverWorld() {
					const tagDasLinhas = "items";
					const stringEsperada = "OverWorld";
				
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationFilled({
							name: tagDasLinhas
						}),
						success: function(oTable) {
							const items = oTable.getItems();
				
							let result = true;
							items.map((item) => {
								let naturalidade = formatarEnum(item.getBindingContext(NOME_DO_JSONMODEL).getProperty(PROPARTY_NATURALIDADE));
								if (naturalidade !== stringEsperada) {
									result = false;
								}
							});
				
							Opa5.assert.ok(result, "Todos os itens possuem a naturalidade " + stringEsperada);
						},
						errorMessage: "Alguns itens na tabela não possuem a naturalidade " + stringEsperada
					});
				},

				aTabelaDeveConterItensDoNether() {
					const tagDasLinhas = "items";
					const stringEsperada = "Nether";
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationFilled({
							name: tagDasLinhas
						}),
						success: function(oTable) {
							const items = oTable.getItems();
							
							let result = true;
							items.map((item) => {
								let naturalidade = formatarEnum(item.getBindingContext(NOME_DO_JSONMODEL).getProperty(PROPARTY_NATURALIDADE));
								if (naturalidade !== stringEsperada)
									result = false;
							});

							Opa5.assert.ok(result, "Todos os itens possuem a naturalidade " + stringEsperada);
						},
						errorMessage: "Alguns itens na tabela não possuem a naturalidade " + stringEsperada
					})
				},

				aTabelaDeveConterItemDoTheEnd() {
					const tagDasLinhas = "items";
					const stringEsperada = "TheEnd";
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: new sap.ui.test.matchers.AggregationFilled({
							name: tagDasLinhas
						}),
						success: function(oTable) {
							const items = oTable.getItems();

							let result = true;
							items.map((item) => {
								let naturalidade = formatarEnum(item.getBindingContext(NOME_DO_JSONMODEL).getProperty(PROPARTY_NATURALIDADE));
								if (naturalidade !== stringEsperada)
									result = false;
							});

							Opa5.assert.ok(result, "Todos os itens possuem a naturalidade " + stringEsperada);
						},
						errorMessage: "Alguns itens na tabela não possuem a naturalidade " + stringEsperada
					})
				},
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
