sap.ui.define([
    "coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel"
 ], function (BaseController, JSONModel) {
    "use strict";

    const NOME_DO_MODELO = 'ingrediente';
 
    return BaseController.extend("coders-growth.controller.Listagem", {
        onInit(){
            fetch("https://localhost:7224/api/Ingredientes")
                .then((res) => res.json())
                .then((data) => {
                    const jsonModel = new JSONModel(data)

                    this.getView().setModel(jsonModel, NOME_DO_MODELO);
                })
                .catch((err) => console.error(err));
        }
    });
});