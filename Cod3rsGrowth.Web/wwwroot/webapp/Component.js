sap.ui.define([
	"sap/ui/core/UIComponent",
	"sap/ui/model/json/JSONModel"
], (UIComponent) => {
	"use strict";

	return UIComponent.extend("coders-growth.Component", {
		metadata: {
			interfaces: ["sap.ui.core.IAsyncContentCreation"],
			manifest: "json"
		},

		init() {
			UIComponent.prototype.init.apply(this, arguments);

			this.getRouter().initialize();
		}
	});
});
