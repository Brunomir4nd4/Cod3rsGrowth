sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/resource/ResourceModel"
 ], function (Controller, ResourceModel) {
    "use strict";
 
    return Controller.extend("coders-growth.controller.Home", {
        onInit(){
            const modeloI18n = new ResourceModel({
                bundleName: "coders-growth.i18n.i18n"
            });
            this.getView().setModel(modeloI18n, "i18n");
        },
        
        onPress() {
            this.byId("cliqueEmMim").setText("Fui clicado!");
        }
    });
 
 });