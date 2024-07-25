sap.ui.define([
    "./Formatter"
], function(Formatter) {
    'use strict';

    return{
        ValidarNome(oInput, nome){
            const regex = /[0-9!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;
            const mensagemErroNomeVazio = "Nome não informado.";
            const mensagemErroNomeComNumeroOuCaractersEspeciais = "Nome deve possuir apenas letras.";
            
            if (nome === ""){
                oInput.setValueState(sap.ui.core.ValueState.Error);
                oInput.setValueStateText(mensagemErroNomeVazio);
            } 
            else if(regex.test(nome)) {
                oInput.setValueState(sap.ui.core.ValueState.Error);
                oInput.setValueStateText(mensagemErroNomeComNumeroOuCaractersEspeciais);
            }
            else {
                oInput.setValueState(sap.ui.core.ValueState.Success);
            }
        },

        ValidarQuantidade(oInput, quantidade){      
            const regexNumeros = /[0-9]/;      
            const regexCaracters = /[a-zA-Z!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/; 
            const menssagemErroQuantidadeVazia = "Quantidade não informada.";
            const mensagemErroQuantidadeComLetrasOuCaractersEspeciais = "Quantidade deve conter apenas números.";
            
            if (quantidade === ""){
                oInput.setValueState(sap.ui.core.ValueState.Error);
			    oInput.setValueStateText(menssagemErroQuantidadeVazia);
            }
            else if (!regexNumeros.test(quantidade) | regexCaracters.test(quantidade)){
                oInput.setValueState(sap.ui.core.ValueState.Error);
			    oInput.setValueStateText(mensagemErroQuantidadeComLetrasOuCaractersEspeciais);
            }
            else {
                oInput.setValueState(sap.ui.core.ValueState.Success);
            }
        },
    }
});