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

    return BaseController.extend("coders-growth.controller.CadastroIngrediente", {
        onInit(){
            this.aoCoincidirRota();
        },

        aoCoincidirRota: function () {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_CADASTRO).attachPatternMatched(this._obterPorId, this);
            });
        },

        aoAlterarNome(){
            this._processarAcao(() =>{
                const oInput = this.getView().byId(ID_INPUT_NOME);
                Validators.ValidarNome(oInput, oInput.getValue());
            });
        },
        
        aoAlterarQuantidade(){
            this._processarAcao(() => {
                const oInput = this.getView().byId(ID_INPUT_QUANTIDADE);
                Validators.ValidarQuantidade(oInput, oInput.getValue());
            });
        },

        aoClicarCriarIngrediente(){
            const oRouter = this.getOwnerComponent().getRouter();

            oRouter.getRoute(ROTA_CADASTRO).attachPatternMatched(function(oEvent) {
                const id = oEvent.getParameter("arguments").id;
                const inputNome = this.oView.byId(ID_INPUT_NOME).getValue();
                const inputQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();
                const inputNaturalidade = this.oView.byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();

                if (id) {
                    console.log("ID recuperado da URI: " + id);
                    const oIngrediente = {
                        Id: id,
                        Nome: inputNome,
                        Quantidade: inputQuantidade,
                        Naturalidade: Formatter.formatarStringDoEnum(inputNaturalidade)
                    }
                    this._requistarApi(URL_API, oIngrediente, REQUISICAO_PATCH);

                } else {
                    console.log("Nenhum ID encontrado na URI.");
                    const oIngrediente = {
                        Nome: inputNome,
                        Quantidade: inputQuantidade,
                        Naturalidade: Formatter.formatarStringDoEnum(inputNaturalidade)
                    }
                    this._requistarApi(URL_API, oIngrediente, REQUISICAO_POST);
                }
            });
        },

        _obterPorId(oEvent) {
            let id = oEvent.getParameter("arguments").id;
            if (id != undefined){
                let query = URL_API + "/" + id;
                fetch(query)
                    .then(resp => resp.json())
                    .then(data => this._inserirDadosDeEdicao(data))
                    .catch((err) => MessageBox.error(err.message));
            }
        },

        _inserirDadosDeEdicao(ingrediente){
            const idInputNome = "inputNome";
            const idInputQuantidade = "inputQuantidade";
            const idInputNaturalidade = "inputNaturalidade";

            this.getView().byId(idInputNome).setValue(ingrediente.nome);
            this.getView().byId(idInputQuantidade).setValue(ingrediente.quantidade);
            this.getView().byId(idInputNaturalidade).setValue(ingrediente.naturalidade);
        },
        
        _requistarApi(urlApi, ingrediente, metodoDaRequisicao){
            let sucesso = true;
            fetch(urlApi, {
                method: metodoDaRequisicao,
                body: JSON.stringify(ingrediente),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
            .then(response => {
                if (!response.ok) {
                    sucesso = false;
                    throw new Error('Erro ao fazer a requisição');
                }
            
                return response.json();
            })
            .then(json => {
                console.log(json);
                if (sucesso){
                    this.getView().byId("successMessageStrip").setVisible(true);
                    this.getView().byId("errorMessageStrip").setVisible(false);
                }
            })
            .catch(err => {
                this.getView().byId("errorMessageStrip").setVisible(true);
                this.byId("successMessageStrip").setVisible(false);
                MessageBox.error(err.message);
            });
        },
    }) 
});