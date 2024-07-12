sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/test/actions/Press",
    "sap/ui/test/matchers/PropertyStrictEquals"
], (Opa5, Press, PropertyStrictEquals) => {
	"use strict";

	const NOME_DO_VIEW = "coders-growth.view.App";
    const ID_DO_BOTAO = "cliqueEmMim";

	Opa5.createPageObjects({
	
		onTheAppPage: {

			actions: {
				euClicoNoBotao() {
					return this.waitFor({
						id: ID_DO_BOTAO,
						viewName: NOME_DO_VIEW,
						actions: new Press(),
						errorMessage: "Não foi posível clicar no botão"
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
							Opa5.assert.ok(true, "The button's text changed to: " + oButton.getText());
						},
						errorMessage : "did not change the Button's text"
					});
				}
			}
		}
	});
});
