sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/matchers/PropertyStrictEquals'
], (
        Opa5,
        PropertyStrictEquals
    ) => {
	"use strict";
    
    const NOME_DA_VIEW = "DetalhesIngrediente";
    const ID_PAGE = "paginaDeDetalhes";
    const ID_TITULO = "tituloNomeDoIngrediente";
    const PROPRIEDADE_TITULO = "title";
    const PROPRIEDADE_TEXT = "text"
    const VALOR_TITULO_PAGE = "Detalhes";

    Opa5.createPageObjects({

        naPaginaDeDetalhesDoIngrediente: {

            actions: {
            },

            assertions: {
                deveAbrirViewDeDetalhes() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_PAGE,
                        matchers: new PropertyStrictEquals({
                            name: PROPRIEDADE_TITULO,
                            value: VALOR_TITULO_PAGE
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A view de detalhes foi aberta com sucesso.");
                        },
                        errorMessage: "A view de detalhes não foi aberta corretamente."
                    });
                },

                deveSerOIngredienteEsperado(nomeEsperado) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_TITULO,
                        matchers: new PropertyStrictEquals({
                            name: PROPRIEDADE_TEXT,
                            value: nomeEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "O texto corresponde ao esperado.");
                        },
                        errorMessage: "O texto não corresponde ao esperado: " + nomeEsperado
                    });
                }
            }
        }
    })
});