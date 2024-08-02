sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/actions/Press'
], (
        Opa5,
        PropertyStrictEquals,
        Press
    ) => {
	"use strict";
    
    const NOME_DA_VIEW = "DetalhesIngrediente";
    const ID_TITULO = "tituloDeDetalhes";
    const ID_TITULO_NOME = "tituloNomeDoIngrediente";
    const ID_BOTAO_EDITAR = "botaoEditar";
    const PROPRIEDADE_TEXT = "text"
    const VALOR_TITULO_PAGE = "Detalhes";

    Opa5.createPageObjects({

        naPaginaDeDetalhesDoIngrediente: {

            actions: {
                aoClicarNoBotaoEditar() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_EDITAR,
                        actions: new Press(),
                        errorMessage: "Botão Editar não encontrado"
                    })
                }
            },

            assertions: {
                deveAbrirViewDeDetalhes() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_TITULO,
                        matchers: new PropertyStrictEquals({
                            name: PROPRIEDADE_TEXT,
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
                        id: ID_TITULO_NOME,
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