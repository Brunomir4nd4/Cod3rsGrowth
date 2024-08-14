sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/m/MessageBox",
    "sap/ui/core/BusyIndicator"
], function(Controller, History, UIComponent, MessageBox, BusyIndicator) {
	"use strict";

	const CHAVE_DA_VIEW_HOME = "appListagem";

	return Controller.extend("coders-growth.app.common.BaseController", {

		getRouter() {
			return UIComponent.getRouterFor(this);
		},
		
		getModel : function (sName) {
			return this.getView().getModel(sName);
		},

		onNavBack() {
			// let history, previousHash;

			// history = History.getInstance();
			// previousHash = history.getPreviousHash();

			// if (previousHash !== undefined) {
			// 	window.history.go(-1);
			// } else {
			// 	this.getRouter().navTo(CHAVE_DA_VIEW_HOME, {}, true);
			// }
			this.getRouter().navTo(CHAVE_DA_VIEW_HOME, {}, true);
		},
		
		_processarAcao(action) {
			try {
				const result = action();
				return result;
			} catch (error) {
				MessageBox.error(error.message);
			}
		},

		_erroNaRequisicaoDaApi(erroRfc){
            const mensagemErroPrincipal = erroRfc.Extensions.Erros.join(', ');
            const mensagemErroCompleta = `<p><strong>Status:</strong> ${erroRfc.Status}</p>` +
                `<p><strong>Detalhes:</strong><br/> ${erroRfc.Detail}</p>` +
                "<p>Para mais ajuda acesse <a href='//www.sap.com' target='_top'>aqui</a>.";

            MessageBox.error(mensagemErroPrincipal, {
                title: "Error",
                details: mensagemErroCompleta,
                styleClass: "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer",
                dependentOn: this.getView()
            }); 
        },

        _hideBusyIndicator : function() {
			BusyIndicator.hide();
		},

		_showBusyIndicator : function () {
			BusyIndicator.show(0);
		},
	});
});
    