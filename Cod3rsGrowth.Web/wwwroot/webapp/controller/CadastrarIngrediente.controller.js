sap.ui.define([
    "coders-growth/controller/BaseController",
    "coders-growth/model/Formatter",
    "coders-growth/model/Validators"
], function (BaseController, Formatter, Validators) {
    "use strict";

    const URL_DA_API = "https://localhost:7224/api/Ingredientes";
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_QUANTIDADE = "inputQuantidade";
    const ID_INPUT_NATURALIDADE = "inputNaturalidade";

    return BaseController.extend("coders-growth.controller.CadastrarIngrediente", {
        onInit(){
        },

        aoAlterarValidarNome(){
            const inputNome = this.oView.byId(ID_INPUT_NOME).getValue();

            Validators.ValidarNome(this.getView().byId(ID_INPUT_NOME), inputNome);
        },
        
        aoAlterarValidarQuantidade(){
            const inputQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();

            Validators.ValidarQuantidade(this.getView().byId(ID_INPUT_QUANTIDADE), inputQuantidade);
        },

        aoClicarCriarIngrediente(){
            const inputNome = this.oView.byId(ID_INPUT_NOME).getValue();
            const inputQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();
            const inputNaturalidade = this.oView.byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();
            
            const Ingrediente = {
                Nome: inputNome,
                Quantidade: inputQuantidade,
                Naturalidade: Formatter.formatarStringDoEnum(inputNaturalidade)
            }

            let criadoComSucesso;
            fetch(URL_DA_API, {
                method: "POST",
                body: JSON.stringify(Ingrediente),
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
        }
    }) 
});