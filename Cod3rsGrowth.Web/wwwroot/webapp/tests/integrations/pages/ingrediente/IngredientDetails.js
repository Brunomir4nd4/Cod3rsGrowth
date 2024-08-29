sap.ui.define([
	"sap/ui/test/Opa5",
	'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
], (
        Opa5,
        PropertyStrictEquals,
        Press,
        EnterText
    ) => {
	"use strict";
    
    const NOME_DA_VIEW = "ingrediente.DetalhesIngrediente";
    const ID_TITULO_NOME = "tituloNomeDoIngrediente";
    const ID_BOTAO_EDITAR = "botaoEditar";
    const ID_BOTAO_VOLTAR_PAGINA = "botaoVoltarPagina";
    const PROPRIEDADE_TEXT = "text"
    const VALOR_TITULO_PAGE = "Detalhes";
    const ID_BOTAO_REMOVER = "botaoRemover";
    const ID_FILTRO = "filtroNome";
    const ID_SELECT = "selectItensFilho";
    const ID_MENSAGEM_DE_SUCESSO = "successMessageStrip";
    const ID_MENSAGEM_DE_ERRO = "errorMessageStrip"
    const ID_BOTAO_ADICIONAR = "botaoAdicionarFilho";
    const ID_BOTAO_SALVAR = "botaoSalvarAlteracao";

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
                },

                aoClicarNoBotaoDeVoltarPagina(){
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_VOLTAR_PAGINA,
                        actions: new Press(),
                        errorMessage: "Botão de voltar página não encontrado."
                    })
                },

                aoClicarNoBotaoDeRemover() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_REMOVER,
                        actions: new Press(),
                        errorMessage: "Botão de remover não encontrado."
                    })
                },

                aoClicarNoBotaoCancelarDoMessageBox() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        searchOpenDialogs: true,
                        controlType: "sap.m.Button",
                        success: function (aButtons) {
                            return aButtons.filter(function (oButton) {
                                if(oButton.getText() == "Não") {
                                    oButton.firePress();
                                }
                            });
                        },
                        errorMessage: "Botão de CANCELAR não encontrado."
                    })
                },

                aoClicarNoBotaoYesDoMessageBox() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        searchOpenDialogs: true,
                        controlType: "sap.m.Button",
                        success: function (aButtons) {
                            return aButtons.filter(function (oButton) {
                                if(oButton.getText() == "Sim") {
                                    oButton.firePress();
                                }
                            });
                        },
                        errorMessage: "Botão de YES não encontrado."
                    })
                },

                aoFiltrarTabelaFilha(query) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_FILTRO,
                        actions: new EnterText({
                            text: query
                        }),
                        errorMessage: "Não foi possível encontrar o input de filtro"
                    })
                },

                aoSelecionarATabelaFilho(titulo){
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_SELECT,
                        actions: new Press(),
                        success: function () {
                            return this.waitFor({
                                controlType: "sap.ui.core.Item",
                                matchers: [
                                    new sap.ui.test.matchers.PropertyStrictEquals({
                                        name: "key",
                                        value: titulo
                                    })
                                ],
                                actions: new Press(),
                                errorMessage: `Botão ${titulo} não encontrado.`
                            })
                        },
                        errorMessage: "Não foi possível encontrar o select"
                    })
                },

                aoClicarNoBotaoAdicionar() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_ADICIONAR,
                        actions: new Press(),
                        errorMessage: "Botão Adcionar não encontrado."
                    })
                },

                aoInserirValorAoInput(idInput, valor, label) {
                    return this.waitFor({
                        searchOpenDialogs: true,
                        viewName: NOME_DA_VIEW,
                        id: idInput,
                        actions: new EnterText({
                            text: valor
                        }),
                        errorMessage: `Input ${label} não encontrado.`
                    })
                },

                aoClicarNoBotaoSalvar() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_BOTAO_SALVAR,
                        searchOpenDialogs: true,
                        actions: new Press(),
                        errorMessage: "Botão Salvar não encontrado."
                    })
                },

                aoDesmacarItemDaTabela(idTable) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: idTable,
                        searchOpenDialogs: true,
                        actions: function(oTable) {
                            oTable.removeSelections();
                        },
                        errorMessage: "Tabela não encontrada."
                    })
                },

                aoClicarEmUmItemDaTabela(valor, idTabela) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: idTabela,
                        searchOpenDialogs: true,
						actions: function(oTable) {
                            const items = oTable.getItems();

                            items.map((item) => {
                                let nome = item.getBindingContext("ingredientes").getProperty("nome");
                                if (nome === valor) {
                                    oTable.setSelectedItem(item);
                                    return true;
                                }
                            });
                        },
						errorMessage: "Item com o nome: " + valor + " não encontrado"
					});
                },

                aoClicarNoBotaoCancelar() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: 'Cancelar'
                        }),
                        actions: new Press(),
                        success: function() {
                            Opa5.assert.ok(true, "Botão Cancelar foi clicado.");
                        },
                        errorMessage: "Botão Cancelar não encontrado."
                    })
                },

                aoClicarNoBotaoEditarItemFilho() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: "Editar",
                        }),
                        actions: new Press(),
                        success: function() {
                            Opa5.assert.ok(true, "Botão Editar foi clicado.");
                        },
                        errorMessage: "Botão Editar não foi encontrado."
                    })
                },

                aoClicarEmUmItemDaTabelaFilho(valor) {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: valor
                        }),
                        actions: new Press(),
                        success: function() {
                            Opa5.assert.ok(true, `Item ${valor} foi encontrado.`)
                        },
                        errorMessage: `Item ${valor} não foi enconrado.`
                    })
                },

                aoClicarNoBotaoRemoverFilho() {
                    return this.waitFor({
                        controlType: "sap.m.Button",
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: "Remover"
                        }),
                        actions: new Press(),
                        success: function() {
                            Opa5.assert.ok(true, "Botão remover item filho foi clicado.")
                        },
                        errorMessage: "Botão remover item filho não foi encontrado."
                    })
                }
            },

            assertions: {
                deveEstarNaViewDeDetalhes() {
                    return this.waitFor({
                        controlType: "sap.m.Title",
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
                },

                deveApresentarOItemEsperado(nomeEsperado) {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        matchers: new PropertyStrictEquals({
                            name: PROPRIEDADE_TEXT,
                            value: nomeEsperado
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "O texto corresponde ao esperado.");
                        },
                        errorMessage: "O texto não corresponde ao esperado: " + nomeEsperado 
                    })
                },

                deveEstarNoModalEsperado(titulo) {
                    return this.waitFor({
                        controlType: "sap.m.Dialog",
                        matchers: new PropertyStrictEquals({
                            name: "title",
                            value: titulo
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "O modal corresponde ao esperado.");
                        },
                        errorMessage: "O modal não corresponde ao esperado: " + titulo 
                    })
                },

                deveApresentarMensagemDeSucessoEsperada() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_MENSAGEM_DE_SUCESSO,
                        matchers: new PropertyStrictEquals({
                            name: "visible",
                            value: true
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "Mensagem de sucesso é apresentada.");
                        },
                        errorMessage: "Mensagem de sucesso não é apresentada."
                    })
                },

                deveApresentarMensagemDeErroEsperada() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_MENSAGEM_DE_ERRO,
                        matchers: new PropertyStrictEquals({
                            name: "visible",
                            value: true
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "Mensagem de erro é apresentada.");
                        },
                        errorMessage: "Mensagem de erro não é apresentada."
                    })
                },

                deveApresentarDialogoDeErroEsperado(nomeItem) {
                    return this.waitFor({
                        controlType: "sap.m.Text",
                        searchOpenDialogs: true,
                        matchers: new PropertyStrictEquals({
                            name: "text",
                            value: `O cadastro deve possuir o ingrediente "${nomeItem}"`
                        }),
                        success: function () {
                            return this.waitFor({
                                controlType: "sap.m.Button",
                                matchers: new PropertyStrictEquals({
                                    name: "text",
                                    value: 'Fechar'
                                }),
                                actions: new Press(),
                                success: function() {
                                    Opa5.assert.ok(true, "Dialogo de erro é apresentado.");
                                },
                                errorMessage: "Botão Fechar não encontrado."
                            })
                        },
                        errorMessage: "Dialogo de erro não é apresentado."
                    })
                },

                deveRemoverOItemEsperado(valor, idTabela, jsonModel) {
                    return this.waitFor({
						viewName: NOME_DA_VIEW,
						id: idTabela,
                        matchers: (oTable) => {
							const items = oTable.getItems();

							items.map((item) => {
								let nome = item.getBindingContext(jsonModel).getProperty("nome");
								if (nome === valor)
									return false;
							});
							
							return true;
						},
                        success: () => {
                            Opa5.assert.ok(true, `O item filho ${valor} não está na listagem.`);
                        },
                        errorMessage: `O item filho ${valor} está na listagem.`
                    })
                }
            }
        }
    })
});