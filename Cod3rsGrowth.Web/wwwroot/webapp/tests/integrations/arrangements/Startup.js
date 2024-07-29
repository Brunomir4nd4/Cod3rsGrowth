sap.ui.define([
	"sap/ui/test/Opa5",
	"sap/ui/model/odata/v2/ODataModel"
], function(Opa5, ODataModel) {
	"use strict";

	const NAME_SPACE = "coders-growth";

    return Opa5.extend("coders-growth.tests.Startup", {
		/**
		 * Initializes mock server, then starts the app component
		 * @param {object} oOptionsParameter An object that contains the configuration for starting up the app
		 * @param {int} oOptionsParameter.delay A custom delay to start the app with
		 * @param {string} [oOptionsParameter.hash] The in app hash can also be passed separately for better readability in tests
		 * @param {boolean} [oOptionsParameter.autoWait=true] Automatically wait for pending requests while the application is starting up.
		 */

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