sap.ui.define([
    "coders-growth/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/app/model/Formatter",
    "sap/m/MessageBox"
], function(BaseController, JSONModel, Formatter, MessageBox) {
    'use strict';

    const URL_API_INGREDIENTE = "https://localhost:7224/api/Ingredientes";
    const URL_API_POCAO = "https://localhost:7224/api/Pocoes";
    const URL_API_RECEITA = "https://localhost:7224/api/Receitas";
    const NOME_DO_MODELO_INGREDIENTE = "ingrediente";
    const NOME_DO_MODELO_RECEITA = "receita";
    const NOME_DO_MODELO_POCAO = "pocao";
    const ROTA_DETALHES = "appDetalhesIngrediente";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const PROPRIEDADE_ID = "id";
    const ARGUMENTOS_DE_PARAMETRO = "arguments";
    const METODO_DE_REQUISICAO_DELETE = "DELETE";
    const CHAVE_DA_VIEW_HOME = "appListagem";
    const ID_SELECT_FILHOS = "selectItensFilho";
    let RECEITAS_ASSOCIADAS = [];
    var PARAMETRO_ID;

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

        aoClicarIrParaCadastroParaEditar(oEvent) {
            this._processarAcao(() => {
                const oItem = oEvent.getSource();
                this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {
                    id: window.encodeURIComponent(oItem.getBindingContext(NOME_DO_MODELO_INGREDIENTE).getProperty(PROPRIEDADE_ID))
                }, true);
            })
        },

        aoClicarremover(){
            const oRouter = this.getOwnerComponent().getRouter();
            MessageBox.warning("Deseja remover esse item?\nVocê não poderá retomar essa ação.", {
                actions: [ sap.m.MessageBox.Action.NO,
                    sap.m.MessageBox.Action.YES ],
                onClose: function (sAction) {
                    if (sAction === "YES") {
                        fetch(URL_API_INGREDIENTE, {
                            method: METODO_DE_REQUISICAO_DELETE,
                            body: JSON.stringify(PARAMETRO_ID),
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

            if (itemFilho === "Poção") {
                this.getView().byId("VBoxTabelaPocao").setVisible(true);
                this.getView().byId("VBoxTabelaReceita").setVisible(false);
            } else {
                this.getView().byId("VBoxTabelaPocao").setVisible(false);
                this.getView().byId("VBoxTabelaReceita").setVisible(true);   
            }
        },

        _aoCoincidirRota() {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_DETALHES).attachPatternMatched((oEvent) => {
                    this._obterPorId(oEvent);
                    this._carregarDadosFilhos(URL_API_RECEITA, NOME_DO_MODELO_RECEITA);
                    this._carregarDadosFilhos(URL_API_POCAO, NOME_DO_MODELO_POCAO);
                }, this);
            });
        },

        _obterPorId(oEvent) {
            this._processarAcao(() => {
                this._showBusyIndicator();
                PARAMETRO_ID = oEvent.getParameter(ARGUMENTOS_DE_PARAMETRO).id;
                const barraInvertida = "/";
                const query = URL_API_INGREDIENTE + barraInvertida + PARAMETRO_ID;
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

        _carregarDadosFilhos(urlApi, nomeDoModelo) {
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
                        this.getView().setModel(new JSONModel(this._obterReceitasAssociadas(data)), nomeDoModelo)
                    }
                    else {
                        this.getView().setModel(new JSONModel(this._obterPocoesAssociadas(data, RECEITAS_ASSOCIADAS)), nomeDoModelo)
                    }
                } else {
                    this._erroNaRequisicaoDaApi(data);
                }
            })
            .catch((err) => MessageBox.error(err.message))
            .finally(() => this._hideBusyIndicator());
        },

        _obterReceitasAssociadas(receitas) {
            RECEITAS_ASSOCIADAS = [];
            receitas.filter((receita) => {
                if (receita.listaIdIngrediente.includes(parseInt(PARAMETRO_ID)))
                    RECEITAS_ASSOCIADAS.push(receita);
            });

            return RECEITAS_ASSOCIADAS;
        },

        _obterPocoesAssociadas(pocoes, receitasAssociadas) {
            let pocoesAssociadas = [];
            pocoes.map((pocao) => {
                receitasAssociadas.map(receita => {
                    if (pocao.idReceita === receita.id) 
                        pocoesAssociadas.push(pocao);
                });
            });
            console.log(receitasAssociadas)
            console.log(pocoesAssociadas)

            return pocoesAssociadas;
        }
    })
});