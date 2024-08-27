sap.ui.define([
    "sap/ui/core/library",
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"
], function(coreLibrary, DateFormat, NumberFormat) {
    'use strict';

    var ValueState = coreLibrary.ValueState;

    return{
        formatarValorInteiroDoEnum(valorInteiroDoEnum) {

            switch(valorInteiroDoEnum){
                case 0:
                    return "OverWorld";
                case 1:
                    return "Nether";
                case 2:
                    return "TheEnd";
                default:
                    return "Indefinido";
            }
        },

        formatarStringDoEnum(valorDoEnum) {
            switch(valorDoEnum){
                case "OverWorld":
                    return 0;
                case "Nether":
                    return 1;
                case "TheEnd":
                    return 2;
                default:
                    return "Indefinido";
            }
        },

        quantityState: function(iValue) {
			if (iValue <= 2) {
				return ValueState.Error;
			} else if (iValue <= 10) {
				return ValueState.Warning;
			} else {
				return ValueState.Success;
			}
		},

        obterImagem: function(naturalidade) {
            if (naturalidade === 0) {
                return sap.ui.require.toUrl("coders-growth/images/overworld_block.png");
            } 
            else if (naturalidade === 1) {
                return sap.ui.require.toUrl("coders-growth/images/nether_block.png");
            } 
            else {
                return sap.ui.require.toUrl("coders-growth/images/the_end_block.png");
            }
        },

        formatarValidade: function(valido) {
            return valido ? ValueState.Error : ValueState.Success; 
        },

        formatarTextoValidade: function(valido) {
            return valido ? "Sim" : "Não";
        },

        formatarData(data) {
            const oDateFormat = DateFormat.getDateInstance({
                pattern: "dd/MM/YYYY"
            });
            const sFormattedDate = oDateFormat.format(new Date(data));
            return sFormattedDate;
        },

        formatarValorDaMoeda: function (value) {
            const oNumberFormat = NumberFormat.getCurrencyInstance({
                currencyCode: false
            });

            return oNumberFormat.format(value, "R$");
        },
    }
});