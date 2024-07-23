sap.ui.define([], function() {
    'use strict';
    
    return{

        formatarEnum(valorInteiroDoEnum) {

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
        }
    }
});