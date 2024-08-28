sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/core/UIComponent",
	"sap/m/MessageBox",
    "sap/ui/core/BusyIndicator",
	"sap/ui/model/json/JSONModel",
], function(Controller, History, UIComponent, MessageBox, BusyIndicator, JSONModel) {
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

		_erroNaRequisicaoDaApi(problemDetails){
			debugger
            const mensagemErroPrincipal = problemDetails.Extensions.Erros.join(', ');
            const mensagemErroCompleta = `<p><strong>Status:</strong> ${problemDetails.Status}</p>` +
                `<p><strong>Detalhes:</strong><br/> ${problemDetails.Detail}</p>` +
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

		_carregarIngredientes(query, nomeDoModelo, oView){
            this._showBusyIndicator();
			
            fetch(query)
				.then(response => response.json())
				.then((data) => {
					!data.Detail ? 
						oView.setModel(new JSONModel(data), nomeDoModelo)
						: this._erroNaRequisicaoDaApi(data);
				})
				.catch((err) => MessageBox.error(err.message))
				.finally(() => this._hideBusyIndicator());
        },

		_carregarEnumNaturalidade(query, nomeDoModelo, teraTodos) {
            this._showBusyIndicator();
            query += "/naturalidade";
			const campoTodos = "Todos";

            fetch(query)
                .then(response => response.json())
                .then((data) => {
					if (teraTodos) data.push(campoTodos);
					
                    data.Detail ? 
						this._erroNaRequisicaoDaApi(data)
						: this.getView().setModel(new JSONModel({
                            descricao: data.map(item => ({ text: item }))
                        }), nomeDoModelo);
                })
                .catch((err) => MessageBox.error(err.message))
                .finally(() => this._hideBusyIndicator());
        },
	});
});
    