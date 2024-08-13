sap.ui.define([
    "coders-growth/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/app/model/Formatter",
    "sap/m/MessageBox"
], function(BaseController, JSONModel, Formatter, MessageBox) {
    'use strict';

    const URL_API = "https://localhost:7224/api/Ingredientes";
    const NOME_DO_MODELO = "ingrediente";
    const ROTA_DETALHES = "appDetalhesIngrediente";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const PRORIEDADE_ID = "id";
    const ARGUMENTOS_DE_PARAMETRO = "arguments";
    const METODO_DE_REQUISICAO_DELETE = "DELETE";
    const CHAVE_DA_VIEW_HOME = "appListagem";
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
                    id: window.encodeURIComponent(oItem.getBindingContext(NOME_DO_MODELO).getProperty(PRORIEDADE_ID))
                }, true);
            })
        },

        aoClicarremover(){
            const oRouter = this.getOwnerComponent().getRouter();
            let sucesso = true;
            MessageBox.warning("Deseja remover esse item?\nVocê não poderá retomar essa ação.", {
                actions: [ sap.m.MessageBox.Action.YES,
                    sap.m.MessageBox.Action.NO ],
                onClose: function (sAction) {
                    if (sAction === "YES") {
                        fetch(URL_API, {
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

        _aoCoincidirRota() {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_DETALHES).attachPatternMatched(this._obterPorId, this);
            });
        },

        _obterPorId(oEvent) {
            this._processarAcao(() => {
                PARAMETRO_ID = oEvent.getParameter(ARGUMENTOS_DE_PARAMETRO).id;
                const barraInvertida = "/";
                const query = URL_API + barraInvertida + PARAMETRO_ID;
                let sucesso = true;
                fetch(query)
                    .then(resp => {
                        if (!resp.ok) 
                            sucesso = false;
                        return resp.json();
                    })
                    .then(data => {
                        sucesso ? this.getView().setModel(new JSONModel(data), NOME_DO_MODELO) 
                        : this._erroNaRequisicaoDaApi(data);
                    })
                    .catch((err) => MessageBox.error(err.message));
            })
        },
    })
});