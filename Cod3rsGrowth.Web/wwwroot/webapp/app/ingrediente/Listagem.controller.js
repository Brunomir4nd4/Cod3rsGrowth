sap.ui.define([
    "coders-growth/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/app/model/Formatter",
    "sap/m/MessageBox",
 ], function (BaseController,JSONModel, Formatter, MessageBox) {
    "use strict";

    const URL_API = "https://localhost:7224/api/Ingredientes";
    const NOME_DO_MODELO = "ingrediente";
    const NOME_DO_MODELO_ENUM = "enum";
    const ID_INPUT_NOME = "filtroNome";
    const ID_INPUT_QUANTIDADE = "filtroQuantidade";
    const ID_INPUT_NATURALIDADE = "filtroNaturalidade";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const CHAVE_VIEW_DETALHES_INGREDIENTE = "appDetalhesIngrediente";
    const ROTA_LISTAGEM = "appListagem";
    const PROPRIEDADE_ID = "id";
    
    return BaseController.extend("coders-growth.app.ingrediente.Listagem", {
        formatter: Formatter,

        onInit(){
            this._aoCoincidirRota();
        },

        aoAlterarFiltrar(){
            this._processarAcao(() => {
                const queryParts = [];
                const obterTodasNaturalidades = "Todos";
                const filtroNome = this.getView().byId(ID_INPUT_NOME).getValue();
                const filtroQuantidade = this.getView().byId(ID_INPUT_QUANTIDADE).getValue();
                const filtroNaturalidade = this.getView().byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();
                
                if (filtroNome) {
                    queryParts.push(`Nome=${filtroNome}`);
                }
                
                if (filtroQuantidade) {
                    queryParts.push(`Quantidade=${filtroQuantidade}`);
                }
                
                if (filtroNaturalidade !== obterTodasNaturalidades) {
                    queryParts.push(`Naturalidade=${filtroNaturalidade}`);
                }
                
                const query = URL_API + "?" + queryParts.join("&");
                
                this._carregarIngredientes(query, NOME_DO_MODELO, this.getView());
            });
        },

        aoClicarIrParaCadastro() {
            this._processarAcao(() => {
                this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {}, true);
            })
        },

        aoClicarIrParaDetalhes(oEvent) {
            this._processarAcao(() => {
                const oItem = oEvent.getSource();
                
                this.getRouter().navTo(CHAVE_VIEW_DETALHES_INGREDIENTE, {
                    id: window.encodeURIComponent(oItem.getBindingContext(NOME_DO_MODELO).getProperty(PROPRIEDADE_ID))
                });
            })
        },

        _aoCoincidirRota() {
            this._processarAcao(() => {
                const oSelect = this.getView().byId(ID_INPUT_NATURALIDADE);

                const campoTodos = "Todos";
                const sim = true;

                this.getRouter().getRoute(ROTA_LISTAGEM).attachPatternMatched(() => {
                    this._carregarIngredientes(URL_API, NOME_DO_MODELO, this.getView());
                    this._carregarEnumNaturalidade(URL_API, NOME_DO_MODELO_ENUM, sim);
                    oSelect.setSelectedKey(campoTodos);
                }, this);
            });
        },
    });
});