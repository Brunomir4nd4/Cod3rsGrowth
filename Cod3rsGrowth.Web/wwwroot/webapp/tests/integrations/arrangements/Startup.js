sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/model/odata/v2/ODataModel"
], function(Opa5, ODataModel) {
	"use strict";

	const NAME_SPACE = "coders-growth";

    return Opa5.extend("coders-growth.tests.itegrations.arrangements.Startup", {
        iStartMyApp : function (oOptionsParameter) {
			var oOptions = oOptionsParameter || {};

			this._clearSharedData();
			oOptions.delay = oOptions.delay || 1;
			this.iStartMyUIComponent({
				componentConfig: {
					name: NAME_SPACE,
					async: true
				},
				hash: oOptions.hash,
				autoWait: oOptions.autoWait
			});
		},

		_clearSharedData: function () {
			ODataModel.mSharedData = { server: {}, service: {}, meta: {} };
		}
    })
})