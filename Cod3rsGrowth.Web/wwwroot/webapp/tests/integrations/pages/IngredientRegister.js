sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/actions/EnterText',
	'sap/ui/test/actions/Press',
	'sap/ui/test/matchers/PropertyStrictEquals'
], (
        Opa5, 
        EnterText, 
        Press,
        PropertyStrictEquals
    ) => {
	"use strict";

    const NOME_DA_VIEW = "CadastroIngrediente";
    const ID_PROPERTY_TITLE = "Title1";
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_QUANTIDADE = "inputQuantidade";
    const ID_MENSAGEM_ERRO = "errorMessageStrip";
    const ID_MENSAGEM_SECESSO = "successMessageStrip";
    const ID_BOTAO_SALVAR = "saveButton";
    const ID_SELECT_NATURALIDADE = "inputNaturalidade";
    const ID_BOTAO_NETHER = "__component2---cadastroIngrediente--Nether";
    const PROPRIEDADE_TEXT = "text";
    const PROPRIEDADE_VISIBLE = PROPRIEDADE_VISIBLE;

    Opa5.createPageObjects({

        naPaginaDeCadastroDeIngrediente: {
            actions: {
                aoInserirAbobor4NoInputNome(stringDeInput){
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id:ID_INPUT_NOME,
                        actions: new EnterText({
                            text: stringDeInput
                        }),
                        errorMessage: "Input nome não encontrado."
                    })
                },

                aoInserirAbobor4NoInputQuantidade(stringDeInput){
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_INPUT_QUANTIDADE,
                        actions: new EnterText({
                            text: stringDeInput
                        }),
                        errorMessage: "Input quantidade não encontrada."
                    })
                },

                aoClicarNoBotaoSalvar(){
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_SALVAR,
                        actions: new Press(),
                        errorMessage: "Botao não salvarencontrado."
                    })
                },

                aoInserirAboboraNoInputNome(stringDeInput) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id:ID_INPUT_NOME,
                        actions: new EnterText({
                            text: stringDeInput
                        }),
                        errorMessage: "Input nome não encontrado."
                    })
                }, 

                aoInserirAboboraNoInputQuantidade(stringDeInput) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_INPUT_QUANTIDADE,
                        actions: new EnterText({
                            text: stringDeInput
                        }),
                        errorMessage: "Input quantidade não encontrada."
                    })
                },

                aoInserir5NoInputQuantidade(stringDeInput) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_INPUT_QUANTIDADE,
                        actions: new EnterText({
                            text: stringDeInput
                        }),
                        errorMessage: "Input quantidade não encontrada."
                    })
                },

                aoInserir2NoInputQuantidade(stringDeInput) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_INPUT_QUANTIDADE,
                        actions: new EnterText({
                            text: stringDeInput
                        }),
                        errorMessage: "Input quantidade não encontrada."
                    })
                },

                aoClicarAbrirSelect() {
					return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: ID_SELECT_NATURALIDADE,
						actions: new Press(),
						errorMessage: "Botão Select não encontrado."
					});
				},

                aoSelecionarNaturalidadeNether() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_NETHER,
                        actions: new Press(),
                        errorMessage: "Botão Nether não encontrada."
                    })
                },
            },

            assertions: {
                deveAbrirViewDeCadastro(valorEsperado) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_PROPERTY_TITLE,
                        matchers: new PropertyStrictEquals({
                            name: PROPRIEDADE_TEXT,
                            value: valorEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A view de cadastro foi aberta corretamente com o valor esperado.");
                        },
                        errorMessage: "A view de cadastro não foi aberta corretamente com o valor esperado: " + valorEsperado
                    });
                },

                deveApresentarMenssagemDeErroEsperada(valorEsperado) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_MENSAGEM_ERRO,
                        matchers: new PropertyStrictEquals({
                            name: PROPRIEDADE_VISIBLE,
                            value: valorEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro está sendo exibida conforme esperado.");
                        },
                        errorMessage: "A mensagem de erro não está sendo exibida."
                    });
                },

                deveApresentarMenssagemDeSecessoEsperada(valorEsperado) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_MENSAGEM_SECESSO,
                        matchers: new PropertyStrictEquals({
                            name: PROPRIEDADE_VISIBLE,
                            value: valorEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de sucesso está sendo exibida corretamente.");
                        },
                        errorMessage: "A mensagem de sucesso não está sendo exibida."
                    });
                }
            }
        }
    });
})
