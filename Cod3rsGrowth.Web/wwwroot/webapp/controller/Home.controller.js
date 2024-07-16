sap.ui.define([
    "coders-growth/controller/BaseController",
    "sap/ui/model/resource/ResourceModel"
 ], function (BaseController, ResourceModel) {
    "use strict";
 
    return BaseController.extend("coders-growth.controller.Home", {
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