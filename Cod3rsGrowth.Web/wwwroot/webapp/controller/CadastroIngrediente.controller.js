sap.ui.define([
    "coders-growth/controller/BaseController",
    "coders-growth/model/Formatter",
    "coders-growth/model/Validators",
    "sap/m/MessageBox"
], function (BaseController, Formatter, Validators, MessageBox) {
    "use strict";

    const URL_API = "https://localhost:7224/api/Ingredientes";    
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_QUANTIDADE = "inputQuantidade";
    const ID_INPUT_NATURALIDADE = "inputNaturalidade";
    const ROTA_CADASTRO = "appCadastroIngrediente";
    const REQUISICAO_POST = "POST";
    const REQUISICAO_PATCH = "PATCH";
    const ARGUMENTOS_DE_PARAMETRO = "arguments";
    const ID_MENSSAGE_STRIP_SECESSO = "successMessageStrip";
    const ID_MENSSAGE_STRIP_ERRO = "errorMessageStrip";
    const ID_BOTAO_SALVAR = "saveButton";
    var PARAMETRO_ID;

    return BaseController.extend("coders-growth.controller.CadastroIngrediente", {
        onInit(){
            this.aoCoincidirRota();
        },

        aoCoincidirRota: function () {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_CADASTRO).attachPatternMatched((oEvent) => {
                    this._limparResquisiosDeCadastro();
                    this._regatarParamentroUrl(oEvent);
                    this._obterPorId();
                }, this);
            });
        },

        aoAlterarNome(){
            const inputNome = this.getView().byId(ID_INPUT_NOME);       
            this._processarAcao(() =>{
                Validators.ValidarNome(inputNome, inputNome.getValue());
            });
        },
        
        aoAlterarQuantidade(){
            const inputQuantidade = this.getView().byId(ID_INPUT_QUANTIDADE);
            this._processarAcao(() => {
                Validators.ValidarQuantidade(inputQuantidade, inputQuantidade.getValue());
            });
        },

        aoClicarCadastrarIngrediente(){
            const nome = this.getView().byId(ID_INPUT_NOME).getValue();
            const quantidade = this.getView().byId(ID_INPUT_QUANTIDADE).getValue();
            const naturalidade = this.getView().byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();

            if (PARAMETRO_ID) {
                const oIngrediente = {
                    Id: PARAMETRO_ID,
                    Nome: nome,
                    Quantidade: quantidade,
                    Naturalidade: Formatter.formatarStringDoEnum(naturalidade)
                }
                this._requistarApi(URL_API, oIngrediente, REQUISICAO_PATCH);

            } else {
                const oIngrediente = {
                    Nome: nome,
                    Quantidade: quantidade,
                    Naturalidade: Formatter.formatarStringDoEnum(naturalidade)
                }
                this._requistarApi(URL_API, oIngrediente, REQUISICAO_POST);
            }
        },

        _limparResquisiosDeCadastro() {
            const iconSave = "sap-icon://save";
            const keyOverWorld = "0";
            const SEM_VALORES = "";
            const inputNome = this.getView().byId(ID_INPUT_NOME);
            const inputQuantidade = this.getView().byId(ID_INPUT_QUANTIDADE);
            const inputNaturalidade = this.getView().byId(ID_INPUT_NATURALIDADE);

            this.getView().byId(ID_MENSSAGE_STRIP_SECESSO).setVisible(false);
            this.getView().byId(ID_MENSSAGE_STRIP_ERRO).setVisible(false);
            this.getView().byId(ID_BOTAO_SALVAR).setIcon(iconSave);
            inputNome.setValueState(sap.ui.core.ValueState.None);
            inputQuantidade.setValueState(sap.ui.core.ValueState.None);
            inputNome.setValue(SEM_VALORES);
            inputQuantidade.setValue(SEM_VALORES);
            inputNaturalidade.getItems().map((item) => {
                if (item.getKey() === keyOverWorld){
                    inputNaturalidade.setSelectedItem(item);
                }
            });
        },

        _regatarParamentroUrl(oEvent){
            var oRouter = sap.ui.core.UIComponent.getRouterFor(this); // Obtém o roteador associado ao controlador

            var sRouteName = oRouter.getRoute(oEvent.getParameter("name"))._oConfig.name;

            console.log(sRouteName)
            console.log(oEvent)
            PARAMETRO_ID = oEvent.getParameter(ARGUMENTOS_DE_PARAMETRO).id;
        },

        _obterPorId() {
            const barraInvertida = "/";
            if (PARAMETRO_ID){
                let query = URL_API + barraInvertida + PARAMETRO_ID;
                fetch(query)
                    .then(resp => resp.json())
                    .then(data => this._inserirDadosDeEdicao(data))
                    .catch((err) => MessageBox.error(err.message));
            }
        },

        _inserirDadosDeEdicao(ingrediente){
            const oSelect = this.getView().byId(ID_INPUT_NATURALIDADE);
            this.getView().byId(ID_INPUT_NOME).setValue(ingrediente.nome);
            this.getView().byId(ID_INPUT_QUANTIDADE).setValue(ingrediente.quantidade);
            oSelect.getItems().map((item) => {
                if (item.getKey() == ingrediente.naturalidade){
                    oSelect.setSelectedItem(item);
                }
            });
        },
        
        _requistarApi(urlApi, ingrediente, metodoDaRequisicao){
            let sucesso = true;
            let iconComplete = "sap-icon://complete";
            fetch(urlApi, {
                method: metodoDaRequisicao,
                body: JSON.stringify(ingrediente),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
            .then(response => {
                if (!response.ok) {
                    sucesso = false;
                    throw new Error();
                }
                return response.json();
            })
            .then(json => {
                console.log(json);
                if (sucesso){
                    this.getView().byId(ID_BOTAO_SALVAR).setIcon(iconComplete);
                    this.getView().byId(ID_MENSSAGE_STRIP_SECESSO).setVisible(true);
                    this.getView().byId(ID_MENSSAGE_STRIP_ERRO).setVisible(false);
                }
            })
            .catch(err => {
                this.getView().byId(ID_MENSSAGE_STRIP_ERRO).setVisible(true);
                this.getView().byId(ID_MENSSAGE_STRIP_SECESSO).setVisible(false);
            });
        },
    }) 
});