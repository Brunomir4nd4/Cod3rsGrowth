sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent"
], function(Controller, History, UIComponent) {
	"use strict";

	const CHAVE_DA_VIEW_HOME = "appListagem";

	return Controller.extend("coders-growth.controller.BaseController", {

		getRouter() {
			return UIComponent.getRouterFor(this);
		},

		onNavBack() {
			let history, previousHash;

			history = History.getInstance();
			previousHash = history.getPreviousHash();

			if (previousHash !== undefined) {
				window.history.go(-1);
			} else {
				this.getRouter().navTo(CHAVE_DA_VIEW_HOME, {}, true);
			}
		},

		_processarAcao(action) {
			try {
				const result = action();
				return result;
			} catch (error) {
				MessageBox.error(error.message);
			}
		}
	});
});
    