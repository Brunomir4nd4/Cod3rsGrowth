sap.ui.define([
    "coders-growth/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/app/model/Formatter",
    "sap/m/MessageBox",
    "coders-growth/app/model/Validators"
], function(BaseController, JSONModel, Formatter, MessageBox, Validators) {
    'use strict';

    const URL_API_INGREDIENTE = "https://localhost:7224/api/Ingredientes";
    const URL_API_POCAO = "https://localhost:7224/api/Pocoes";
    const URL_API_RECEITA = "https://localhost:7224/api/Receitas";
    const NOME_DO_MODELO_INGREDIENTE = "ingrediente";
    const NOME_DO_MODELO_INGREDIENTES = "ingredientes";
    const NOME_DO_MODELO_RECEITA = "receita";
    const NOME_DO_MODELO_POCAO = "pocao";
    const ROTA_DETALHES = "appDetalhesIngrediente";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const ARGUMENTOS_DE_PARAMETRO = "arguments";
    const METODO_DE_REQUISICAO_DELETE = "DELETE";
    const CHAVE_DA_VIEW_HOME = "appListagem";
    const ID_SELECT_FILHOS = "selectItensFilho";
    const ID_TABELA_INGREDIENTE_DIALOGO_POCAO = "tabelaIngrediente1";
    const ID_TABELA_INGREDIENTE_DIALOGO_RECEITA = "tabelaIngrediente2";
    const VISIVEL = true;
    const NAO_VISIVEL = false;
    var MENSSAGEM_ERRO_CADASTRO_FILHO;
    var DIALOGO;
    var PARAMETRO_ID;
    var RECEITAS_ASSOCIADAS = [];
    var BOTAO_PRECIONADO;
    var ID_RECEITA_EDITADA;

    return BaseController.extend("coders-growth.app.ingrediente.DetalhesIngrediente", {
        formatter: Formatter,
        
        onInit(){
            this._aoCoincidirRota();
        },

        aoClicarIrParaCadastro() {
            this._processarAcao(() => {
                this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {}, true);
            })
        },

        aoClicarIrParaEditar(oEvent) {
            this._processarAcao(() => {
                const oItem = oEvent.getSource();
                this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {
                    id: oItem._getPropertiesToPropagate().oModels.ingrediente.oData.id
                }, true);
            })
        },

        aoClicarRemover(){
            const oRouter = this.getOwnerComponent().getRouter();
            MessageBox.warning("Deseja remover esse item?\nVocê não poderá retomar essa ação.", {
                actions: [ sap.m.MessageBox.Action.NO,
                    sap.m.MessageBox.Action.YES ],
                onClose: function (sAction) {
                    if (sAction === "YES") {
                        fetch(URL_API_INGREDIENTE + '/' + PARAMETRO_ID, {
                            method: METODO_DE_REQUISICAO_DELETE,
                            headers: { "Content-type": "application/json; charset=UTF-8" }
                        })
                        .then(response => {
                            if (response.ok) {
                                sap.m.MessageToast.show("Ingrediente removido com sucesso.");
                                oRouter.navTo(CHAVE_DA_VIEW_HOME, {}, true);    
                            }
                        })
                        .catch(err => MessageBox.error(err.message));
                    }
                },
                dependentOn: this.getView()
            });
        },

        aoClicarApresentarListagemFilhoRequerido(){
            const itemFilho = this.oView.byId(ID_SELECT_FILHOS).getSelectedItem().getText();
            const itemDoSelect = "Poções";

            if (itemFilho === itemDoSelect) {
                this.getView().byId("VBoxTabelaPocao").setVisible(VISIVEL);
                this.getView().byId("VBoxTabelaReceita").setVisible(NAO_VISIVEL);
                this.getView().byId("botaoEditarFilho").setVisible(NAO_VISIVEL);
            } else {
                this.getView().byId("VBoxTabelaPocao").setVisible(NAO_VISIVEL);
                this.getView().byId("VBoxTabelaReceita").setVisible(VISIVEL);   
                this.getView().byId("botaoEditarFilho").setVisible(VISIVEL);
            }
        },

        aoProcurarFiltrarTabela(oEvent) {
            const query = URL_API_RECEITA + "?Nome=" + oEvent.mParameters.query;
            this._carregarDadosFilho(query, NOME_DO_MODELO_RECEITA);
        },

        async aoClicarAbrirModalCadastroFilho(oEvent) {
            const itemFilho = this.getView().byId("selectItensFilho").getSelectedItem().getText();
            const tabelaReceita = this.getView().byId("tabelaReceita");
            let tabelaIngrediente;
            let listaIdIngrediente;
            let receita;

            BOTAO_PRECIONADO = oEvent.getSource().mProperties.text;
            
            DIALOGO = this.oDialog;
            if (itemFilho === "Receitas") {
                DIALOGO ??= await this.loadFragment({
                    type: "XML",
                    name: "coders-growth.app.ingrediente.fragments.DialogoCadastroReceita"
                });
                tabelaIngrediente = DIALOGO.getContent()[1].getItems()[1];

                if (BOTAO_PRECIONADO === "Editar") {
                    const primeiroItem = 0;
                    const vazio = 0;
                    const itemSelecionado = tabelaReceita.getSelectedItems();
                    
                    if (itemSelecionado.length !== vazio) {
                        receita = itemSelecionado[primeiroItem].getBindingContext(NOME_DO_MODELO_RECEITA); 
                        listaIdIngrediente = receita.getProperty("listaIdIngrediente");
                        ID_RECEITA_EDITADA = receita.getProperty("id");

                        this.getView().byId("inputNomeReceita").setValue(receita.getProperty("nome"));
                        this.getView().byId("inputValidadeReceita").setValue(receita.getProperty("validadeEmMeses"));
                        this.getView().byId("inputValorReceita").setValue(receita.getProperty("valor"));
                        this.getView().byId("inputDescricaoReceita").setValue(receita.getProperty("descricao"));
                        this._selecionarIngredientesNaTabela(tabelaIngrediente, listaIdIngrediente);
                        DIALOGO.open();
                    } else {
                        MessageBox.error("Deve haver uma receita selecionada.");
                        DIALOGO.destroy();
                    } 
                } else  
                    DIALOGO.open();

            } else {
                DIALOGO ??= await this.loadFragment({
                    type: "XML",
                    name: "coders-growth.app.ingrediente.fragments.DialogoCadastroPocao"
                });
                tabelaIngrediente = DIALOGO.getContent()[1].getItems()[0];
                DIALOGO.open();
            }
            MENSSAGEM_ERRO_CADASTRO_FILHO = DIALOGO.getContent()[0];
            this._selecionarItemDetalhadoNaTabela(tabelaIngrediente);
        },

        aoClicarFecharDialogo() {  
            DIALOGO.close();
            DIALOGO.destroy();
        },

        aoProcurarFiltrarTabelaDialogo(oEvent) {
            const query = URL_API_INGREDIENTE + "?Nome=" + oEvent.mParameters.query;
            this._filtrarTabelaIngrediente(query, NOME_DO_MODELO_INGREDIENTES);
        },

        aoAlterarValidarNome() {
            this._processarAcao(() => {
                const inputNome = this.getView().byId("inputNomeReceita");
                Validators.ValidarNome(inputNome);
            })
        },

        aoAlterarValidarValidade() {
            this._processarAcao(() => {
                const inputValidade = this.getView().byId("inputValidadeReceita");
                Validators.ValidarNumeros(inputValidade);
            })
        },

        aoAlterarValidarValor() {
            this._processarAcao(() => {
                const inputValor = this.getView().byId("inputValorReceita");
                Validators.ValidarNumeros(inputValor);
            })
        },

        aoAlterarValidarDescricao() {
            this._processarAcao(() => {
                const inputDescricao = this.getView().byId("inputDescricaoReceita");
                Validators.ValidarDescricao(inputDescricao);
            })
        },

        aoClicarSalvarAlteracoes() {
            this._processarAcao(() => {
                const itemFilho = this.oView.byId(ID_SELECT_FILHOS).getSelectedItem().getText();
                const inputNome = this.getView().byId("inputNomeReceita");
                const inputValidade = this.getView().byId("inputValidadeReceita");
                const inputValor = this.getView().byId("inputValorReceita");
                const inputDescricao = this.getView().byId("inputDescricaoReceita");
                if (itemFilho === "Receitas") {
                    const ehValido = Validators.ValidarReceita(inputNome, inputValidade, inputValor, inputDescricao);
                    if (ehValido) {
                        MENSSAGEM_ERRO_CADASTRO_FILHO.setVisible(NAO_VISIVEL);
                        this._cadastrarReceita(inputNome, inputValidade, inputValor, inputDescricao);     
                    }
                    else
                        MENSSAGEM_ERRO_CADASTRO_FILHO.setVisible(VISIVEL);
                }
                else 
                    this._cadastrarPocao();
            })
        },

        aoClicarExcluirIntemFilho() {
            const itemFilho = this.getView().byId("selectItensFilho").getSelectedItem().getText();
            const tabelaReceita = this.getView().byId("tabelaReceita");
            const tabelaPocao = this.getView().byId("tabelaPocao");
            const vazio = 0;
            const that = this;

            MessageBox.warning("Deseja remover esse item?\nVocê não poderá retomar essa ação.", {
                actions: [ sap.m.MessageBox.Action.NO,
                    sap.m.MessageBox.Action.YES ],
                onClose: function (sAction) {
                    if (sAction === "YES") {
                        if (itemFilho === "Receitas") {
                            const itens = tabelaReceita.getSelectedItems();
                            if (itens.length !== vazio) {
                                itens.map((item) => {
                                    const id = item.getBindingContext(NOME_DO_MODELO_RECEITA).getProperty("id");
                                    fetch(URL_API_RECEITA + '/' + id, {
                                            method: METODO_DE_REQUISICAO_DELETE,
                                            headers: { "Content-type": "application/json; charset=UTF-8" }
                                        })
                                        .then(response => {
                                            if (response.ok) 
                                                sap.m.MessageToast.show("Item removido com sucesso.");
                                        })
                                        .catch(err => MessageBox.error(err.message));
                                })
                            } else {
                                MessageBox.error("Deve haver uma receita selecionada.")
                            }            
                        } else {
                            const itens = tabelaPocao.getSelectedItems();
            
                            if (itens.length !== vazio) {
                                itens.map((item) => {
                                    const id = item.getBindingContext(NOME_DO_MODELO_POCAO).getProperty("id");
                                    fetch(URL_API_POCAO + '/' + id, {
                                            method: METODO_DE_REQUISICAO_DELETE,
                                            headers: { "Content-type": "application/json; charset=UTF-8" }
                                        })
                                        .then(response => {
                                            if (response.ok) 
                                                sap.m.MessageToast.show("Item removido com sucesso.");
                                        })
                                        .catch(err => MessageBox.error(err.message));
                                })
                            } else {
                                MessageBox.error("Deve haver uma poção selecionada.")
                            }
                        }
                        that._carregarDadosFilho(URL_API_RECEITA, NOME_DO_MODELO_RECEITA);
                        that._carregarDadosFilho(URL_API_POCAO, NOME_DO_MODELO_POCAO);
                    }
                },
                dependentOn: this.getView()
            });
        },

        _selecionarItemDetalhadoNaTabela(tabela) {
            const items = tabela.getItems();

            items.map((item) => {
                let id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty("id");
                if (id === parseInt(PARAMETRO_ID))
                    tabela.setSelectedItem(item);
            });
        },

        _cadastrarReceita(inputNome, inputValidade, inputValor, inputDescricao) {
            this._processarAcao(() => {
                const nome = inputNome.getValue();
                const descricao = inputDescricao.getValue();
                const valor = parseFloat(inputValor.getValue());
                const validade = parseInt(inputValidade.getValue());
                const nomeIngredienteDetalhado = this.getView().getModel(NOME_DO_MODELO_INGREDIENTE).getData().nome;
                let possuiItemDetalhado = false;
                
                const table = this.getView().byId(ID_TABELA_INGREDIENTE_DIALOGO_RECEITA);
                const selectedItems = table.getSelectedItems();
                const ingredientesSelecionados = [];
            
                selectedItems.forEach(item => {
                    const id = item.getBindingContext("ingredientes").getProperty("id");
    
                    if (id === parseInt(PARAMETRO_ID))
                        possuiItemDetalhado = true;
    
                    ingredientesSelecionados.push(id);
                });
            
                const receita = {
                    nome: nome,
                    descricao: descricao,
                    valor: valor,
                    validadeEmMeses: validade,
                    listaIdIngrediente: ingredientesSelecionados,
                    imagem: "string",
                }

                if (possuiItemDetalhado) {
                    const metodoPATCH = "PATCH";
                    const metodoPOST = "POST";
                    
                    BOTAO_PRECIONADO === "Adicionar" ? this._requisitarApi(URL_API_RECEITA, receita, metodoPOST)
                        : (
                            receita.id = ID_RECEITA_EDITADA,
                            this._requisitarApi(URL_API_RECEITA, receita, metodoPATCH)
                        );
                } else
                    MessageBox.error(`O cadastro deve possuir o ingrediente "${nomeIngredienteDetalhado}"`);
            })
        },

        _cadastrarPocao() {
            this._processarAcao(() => {
                const table = this.getView().byId(ID_TABELA_INGREDIENTE_DIALOGO_POCAO);
                const selectedItems = table.getSelectedItems();
                const ingredientesSelecionados = [];
                const nomeIngredienteDetalhado = this.getView().getModel(NOME_DO_MODELO_INGREDIENTE).getData().nome;
                let possuiItemDetalhado = false;

                const listaIngredientes = this.getView().getModel("ingredientes").getData();
    
                selectedItems.map(item => {
                    const id = item.getBindingContext("ingredientes").getProperty("id");
                    
                    if (id === parseInt(PARAMETRO_ID))
                        possuiItemDetalhado = true;

                    listaIngredientes.map((ingrediente) => {
                        if (ingrediente.id === id)
                            ingredientesSelecionados.push(ingrediente);
                    })
                });      

                if (possuiItemDetalhado) {
                    const metodoPATCH = "PATCH";
                    const metodoPOST = "POST";
                    
                    BOTAO_PRECIONADO === "Adicionar" ? this._requisitarApi(URL_API_POCAO, ingredientesSelecionados, metodoPOST)
                        : (
                            receita.id = ID_TABELA_INGREDIENTE_DIALOGO_POCAO,
                            this._requisitarApi(URL_API_RECEITA, receita, metodoPATCH)
                        );
                } else
                    MessageBox.error(`O cadastro deve possuir o ingrediente "${nomeIngredienteDetalhado}"`);
            })
        },

        _requisitarApi(url, item, metodo) {
            this._showBusyIndicator();
            let sucesso = true;
            fetch(url, {
                method: metodo,
                body: JSON.stringify(item),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
            .then(response => {
                if (!response.ok) 
                    sucesso = false;
                return response.json();
            })
            .then(json => {
                console.log(json);
                sucesso ? (
                    this.getView().byId("successMessageStrip").setVisible(VISIVEL),

                    url.includes("Receitas") ? this._carregarDadosFilho(url, NOME_DO_MODELO_RECEITA) 
                        : this._carregarDadosFilho(url, NOME_DO_MODELO_POCAO),

                    this.aoClicarFecharDialogo()

                ) : this._erroNaRequisicaoDaApi(json);
            })
            .catch(err => MessageBox.error(err.message))
            .finally(() => this._hideBusyIndicator());
        },

        _aoCoincidirRota() {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_DETALHES).attachPatternMatched((oEvent) => {
                    this._limparResquicios();
                    this._obterParametro(oEvent);
                    this._obterPorId(PARAMETRO_ID);
                    this._carregarDadosFilho(URL_API_RECEITA, NOME_DO_MODELO_RECEITA);
                    this._carregarDadosIngrediente(URL_API_INGREDIENTE, NOME_DO_MODELO_INGREDIENTES, this.getView());
                }, this);
            });
        },

        _selecionarIngredientesNaTabela(tabela, listaIdIngrediente) {
            const itens = tabela.getItems();

            itens.map((item) => {
                const id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty("id");

                listaIdIngrediente.map((idIngrediente) => {
                    if (id === idIngrediente)
                        tabela.setSelectedItem(item);
                })
            });
        },

        _limparResquicios(){
            this.getView().byId("filtroNome").setValue("");
            this.getView().byId("selectItensFilho").setSelectedKey("Receitas");
            this.getView().byId("successMessageStrip").setVisible(NAO_VISIVEL),
            this.aoClicarApresentarListagemFilhoRequerido();
        },

        _obterParametro(oEvent) {
            PARAMETRO_ID = oEvent.getParameter(ARGUMENTOS_DE_PARAMETRO).id;
        },
 
        _obterPorId(id) {
            this._processarAcao(() => {
                this._showBusyIndicator();
                const barraInvertida = "/";
                const query = URL_API_INGREDIENTE + barraInvertida + id;
                let sucesso = true;

                fetch(query)
                .then(resp => {
                    if (!resp.ok) 
                        sucesso = false;
                    return resp.json();
                })
                .then(data => {
                    sucesso ? this.getView().setModel(new JSONModel(data), NOME_DO_MODELO_INGREDIENTE)
                    : this._erroNaRequisicaoDaApi(data);
                })
                .catch((err) => MessageBox.error(err.message))
                .finally(() => this._hideBusyIndicator());
            })
        },

        _carregarDadosFilho(urlApi, nomeDoModelo) {
            this._showBusyIndicator();
            let sucesso = true;

            fetch(urlApi)
            .then((res) => {
                if (!res.ok)   
                    sucesso = false;
                return res.json();
            })
            .then((data) => {
                if (sucesso){
                    if (urlApi.includes("Receitas")){
                        RECEITAS_ASSOCIADAS = this._obterReceitasAssociadas(data);
                        this.getView().setModel(new JSONModel(RECEITAS_ASSOCIADAS), nomeDoModelo)
                        this._carregarDadosFilho(URL_API_POCAO, NOME_DO_MODELO_POCAO);
                    }
                    else {
                        const pocoesAssociadas = this._obterPocoesAssociadas(data, RECEITAS_ASSOCIADAS);
                        this.getView().setModel(new JSONModel(pocoesAssociadas), nomeDoModelo)
                    }
                } else {
                    this._erroNaRequisicaoDaApi(data);
                }
            })
            .catch((err) => MessageBox.error(err.message))
            .finally(() => this._hideBusyIndicator());
        },

        _filtrarTabelaIngrediente(query, nomeDoModelo){
            this._showBusyIndicator();
            let sucesso = true;
            fetch(query)
            .then((res) => {
                if (!res.ok)
                    sucesso = false;
                return res.json();
            })
            .then((data) => {
                sucesso ? this.getView().setModel(new JSONModel(data), nomeDoModelo)
                : this._erroNaRequisicaoDaApi(data);
            })
            .catch((err) => MessageBox.error(err.message))
            .finally(() => this._hideBusyIndicator());
        },

        _obterReceitasAssociadas(receitas) {
            let receitasAssociadas = [];
            receitas.filter((receita) => {
                if (receita.listaIdIngrediente.includes(parseInt(PARAMETRO_ID)))
                    receitasAssociadas.push(receita);
            });

            return receitasAssociadas;
        },

        _obterPocoesAssociadas(pocoes, receitasAssociadas) {
            let pocoesAssociadas = [];
            
            pocoes.map((pocao) => {
                receitasAssociadas.map(receita => {
                    if (pocao.idReceita === receita.id) 
                        pocoesAssociadas.push(pocao);
                });
            });

            return pocoesAssociadas;
        },
    })
});