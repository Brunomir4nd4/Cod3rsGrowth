sap.ui.define([], function() {
    'use strict';
    
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
    }
});