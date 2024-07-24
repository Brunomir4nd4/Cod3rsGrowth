sap.ui.define([
    "coders-growth/controller/BaseController",
    "coders-growth/model/Formatter",
    "sap/ui/core/ElementRegistry",
    "sap/m/MessageStrip"
], function (BaseController, Formatter, ElementRegistry, MessageStrip) {
    "use strict";

    const URL_DA_API = "https://localhost:7224/api/Ingredientes";
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_QUANTIDADE = "inputQuantidade";
    const ID_INPUT_NATURALIDADE = "inputNaturalidade";
    
    return BaseController.extend("coders-growth.controller.CadastrarIngrediente", {
        formatter: Formatter,

        onInit(){
        },

        aoClicarCriarIngrediente(){
            let Ingrediente = {
                Nome: null,
                Quantidade: null,
                Naturalidade: null
            }
            let urlParaPost = "https://localhost:7224/api/Ingredientes?";
            const inputNome = this.oView.byId(ID_INPUT_NOME).getValue();
            const inputQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();
            const inputNaturalidade = this.oView.byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();
            
            if (inputNome){
                urlParaPost += "Nome="+inputNome+"&";
                Ingrediente.Nome = inputNome;
            }
            
            if (inputQuantidade){
                urlParaPost += "Quantidade="+inputQuantidade+"&";
                Ingrediente.Quantidade = inputQuantidade;
            }

            if (inputNaturalidade){
                urlParaPost += "Naturalidade="+inputNaturalidade;
                Ingrediente.Naturalidade = inputNaturalidade;
            }

            // fetch(urlParaPost, {
            //     method: "POST",
            //     body: JSON.stringify(Ingrediente),
            //     headers: {"Content-type": "application/json; charset=UTF-8"}
            // })
            // .then(response => response.json()) 
            // .then(json => console.log(json))
            // .catch(err => console.log(err));

            this.byId("buttonSave").setIcon('sap-icon://complete');
            this.byId("successMessageStrip").setVisible(true);
        }
    }) 
    
});