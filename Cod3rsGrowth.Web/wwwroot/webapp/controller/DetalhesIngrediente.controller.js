sap.ui.define([
    "coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/model/Formatter",
    "sap/m/MessageBox"
], function(BaseController, JSONModel, Formatter, MessageBox) {
    'use strict';

    const URL_API = "https://localhost:7224/api/Ingredientes";
    const NOME_DO_MODELO = "ingrediente";
    const ROTA_DETALHES = "appDetalhesIngrediente";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const PROPERTY_ID = "id";
    const ARGUMENTOS_DE_PARAMETRO = "arguments";

    return BaseController.extend("coders-growth.controller.DetalhesIngrediente", {
        formatter: Formatter,
        
        onInit(){
            this.aoCoincidirRota();
        },

        aoCoincidirRota: function () {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_DETALHES).attachPatternMatched(this._obterPorId, this);
            });
        },

        aoClicarIrParaCadastro() {
            this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {}, true);
        },

        aoClicarIrParaCadastroParaEditar(oEvent) {
            const oItem = oEvent.getSource();
            this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {
                id: window.encodeURIComponent(oItem.getBindingContext(NOME_DO_MODELO).getProperty(PROPERTY_ID))
            }, true);
        },

        _obterPorId(oEvent) {
            const id = oEvent.getParameter(ARGUMENTOS_DE_PARAMETRO).id;
            const barraInvertida = "/";
            const query = URL_API + barraInvertida + id;
            fetch(query)
                .then(resp => resp.json())
                .then(data => this.getView().setModel(new JSONModel(data), NOME_DO_MODELO))
                .catch((err) => MessageBox.error(err.message));
        },
    })
});