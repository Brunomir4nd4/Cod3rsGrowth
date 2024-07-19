sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/actions/EnterText'
], (Opa5, EnterText) => {
	"use strict";

	const NOME_DO_VIEW = "coders-growth.view.Listagem";
    const ID_FILTRO_NOME = "filtroNome";

	Opa5.createPageObjects({
	
		naPaginaDeListagemDosIngredientes: {

			actions: {
				euInsiroBlazeNoInputNome(stringDeBusca) {
					return this.waitFor({
						id: ID_FILTRO_NOME,
						viewName: NOME_DO_VIEW,
						actions: new EnterText({
							text: stringDeBusca
						}),
						errorMessage: "Campo Nome não encontrado."
					});
				}
			},

			assertions: {
				oBotaoDeveTerOTextoAlterado() {
					return this.waitFor({
						viewName : NOME_DO_VIEW,
						id : ID_DO_BOTAO,
						matchers : new PropertyStrictEquals({
							name : "text",
							value : "Fui clicado!"
						}),
						success : function (oButton) {
							Opa5.assert.ok(true, "O texto do botão mudou para: " + oButton.getText());
						},
						errorMessage : "Não foi possível trocar o texto do botão"
					});
				}
			}
		}
	});
});
