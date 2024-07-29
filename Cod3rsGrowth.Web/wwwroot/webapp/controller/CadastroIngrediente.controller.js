sap.ui.define([
    "coders-growth/controller/BaseController",
    "coders-growth/model/Formatter",
    "coders-growth/model/Validators"
], function (BaseController, Formatter, Validators) {
    "use strict";

    const URL_API = "https://localhost:7224/api/Ingredientes";    
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_QUANTIDADE = "inputQuantidade";
    const ID_INPUT_NATURALIDADE = "inputNaturalidade";

    return BaseController.extend("coders-growth.controller.CadastroIngrediente", {
        onInit(){
        },

        aoAlterarNome(){
            this._processarEvento(() =>{
                const oInput = this.getView().byId(ID_INPUT_NOME);
                Validators.ValidarNome(oInput, oInput.getValue());
            });
        },
        
        aoAlterarQuantidade(){
            this._processarEvento(() => {
                const oInput = this.getView().byId(ID_INPUT_QUANTIDADE);
                Validators.ValidarQuantidade(oInput, oInput.getValue());
            });
        },

        aoClicarCriarIngrediente(){
            this._processarEvento(() => {
                const inputNome = this.oView.byId(ID_INPUT_NOME).getValue();
                const inputQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();
                const inputNaturalidade = this.oView.byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();
                
                const oIngrediente = {
                    Nome: inputNome,
                    Quantidade: inputQuantidade,
                    Naturalidade: Formatter.formatarStringDoEnum(inputNaturalidade)
                }
                this._criarIngrediente(URL_API, oIngrediente);
            });
        },

        _carregarDadosDaTabela(query, nomeDoModelo){
            fetch(query)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), nomeDoModelo))
                .catch((err) => console.error(err));
        },

        _criarIngrediente(urlApi, ingrediente) {
            let criadoComSucesso;
            fetch(urlApi, {
                method: "POST",
                body: JSON.stringify(ingrediente),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
            .then(response => {
                if (!response.ok) {
                    criadoComSucesso = false;
                    throw new Error('Erro ao fazer a requisição');
                } else {
                    criadoComSucesso = true;
                }
                return response.json();
            })
            .then(json => {
                console.log(json);
                if (criadoComSucesso){
                    this.getView().byId("successMessageStrip").setVisible(true);
                    this.getView().byId("errorMessageStrip").setVisible(false);
                }
            })
            .catch(err => {
                console.log(err);
                this.getView().byId("errorMessageStrip").setVisible(true);
                this.byId("successMessageStrip").setVisible(false);
            });
        },
    }) 
});