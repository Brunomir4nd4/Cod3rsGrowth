sap.ui.define([
    "sap/ui/core/library",
    "sap/ui/core/format/DateFormat",
    "sap/ui/core/format/NumberFormat"
], function(coreLibrary, DateFormat, NumberFormat) {
    'use strict';

    const VALUE_STATE = coreLibrary.ValueState;
    const S_OVERWORLD = "OverWorld";
    const S_NETHER = "Nether";
    const S_THE_END = "TheEnd";
    const S_IDEFINIDO = "Indefinido";
    const I_OVERWORLD = 0;
    const I_NETHER = 1;
    const I_THE_END = 2;

    return{
        formatarNaturalidadeParaString(valorInteiroDoEnum) {
            switch(valorInteiroDoEnum){
                case I_OVERWORLD:
                    return S_OVERWORLD;

                case I_NETHER:
                    return S_NETHER;

                case I_THE_END:
                    return S_THE_END;

                default:
                    return S_IDEFINIDO;
            }
        },

        formatarNaturalidadeParaInteiro(valorDoEnum) {
            switch(valorDoEnum){
                case S_OVERWORLD:
                    return I_OVERWORLD;

                case S_NETHER:
                    return I_NETHER;

                case S_THE_END:
                    return I_THE_END;

                default:
                    return S_IDEFINIDO;
            }
        },

        quantityState: function(valor) {
            const quantidadeAlertaVermelho = 2;
            const quantidadeAlertarAmarelo = 10;

            switch(valor) {
                case valor <= quantidadeAlertaVermelho:
                    return VALUE_STATE.Error;

                case valor <= quantidadeAlertarAmarelo:
                    return VALUE_STATE.Warning;

                default:
                    return VALUE_STATE.Success;
            }
		},

        obterImagem: function(naturalidade) {
            const overWorld = 0;
            const nether = 1;

            switch(naturalidade) {
                case overWorld:
                    return sap.ui.require.toUrl("coders-growth/images/overworld_block.png");

                case nether:
                    return sap.ui.require.toUrl("coders-growth/images/nether_block.png");

                default:
                    return sap.ui.require.toUrl("coders-growth/images/the_end_block.png");
            }
        },

        formatarValidade: function(valido) {
            return valido ? VALUE_STATE.Error : VALUE_STATE.Success; 
        },

        formatarTextoValidade: function(valido) {
            return valido ? "Sim" : "Não";
        },

        formatarData(data) {
            const formatoDefinido = "dd/MM/YYYY";
            const oDateFormat = DateFormat.getDateInstance({
                pattern: formatoDefinido
            });
            const sFormattedDate = oDateFormat.format(new Date(data));

            return sFormattedDate;
        },

        formatarValorDaMoeda: function (valor) {
            const oNumberFormat = NumberFormat.getCurrencyInstance({
                currencyCode: false
            });

            return oNumberFormat.format(valor, "R$");
        },
    }
});