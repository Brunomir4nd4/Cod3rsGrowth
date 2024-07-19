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
	const ID_TABELA_INGREDIENTES = "tabelaIngrediente";
	const ID_BOTAO_OVERWORLD = "botaoOverWorld";
	const ID_BOTAO_NETHER = "botaoNether";
	const ID_BOTAO_THEEND = "botaoTheEnde";
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
				
				aTabelaDeveConterItensDoOverWorld() {
					const filtroDeInput = "OverWorld";
					return this.waitFor({
						controlType: "sap.m.Table",
						viewName: NOME_DO_VIEW,
						id: ID_TABELA_INGREDIENTES,
						matchers: (oTable) => { 
							oTable.getItems().map((row) => {
								const aCells = row.getCells();

								//console.log(aCells[3].getText())
								const result = aCells[3].getText().includes(filtroDeInput);

								if (result)
									return true;
								return false;
							})
						},
						success: function() {
							Opa5.assert.ok(true, "A tabela possui somente valores do OverWolrd");
						},
						errorMessage: "A tabela não possui somente valores do OverWolrd"
					})
				}
			}
		}
	});
});
