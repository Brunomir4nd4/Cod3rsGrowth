sap.ui.define([
], function() {
    'use strict';

    var ehValido;
    return{

        ValidarIngrediente(inputNome, inputQuantidade) {
            ehValido = true;
            const nomeDoInput = "Quantidade"
            this.ValidarNome(inputNome);
            this.ValidarNumeros(inputQuantidade, nomeDoInput);

            return ehValido;
        },

        ValidarReceita(inputNome, inputValidade, inputValor, inputDescricao) {
            ehValido = true;
            const nomeInputValidade = "Validade";
            const nomeInputValor = "Valor";
            this.ValidarNome(inputNome);
            this.ValidarNumeros(inputValidade, nomeInputValidade);
            this.ValidarNumeros(inputValor, nomeInputValor);
            this.ValidarDescricao(inputDescricao);

            return ehValido;
        },

        ValidarDescricao(oInput) {
            const mensagemErroDescricaoVazia = "Descrição não informada.";
            
            if (!oInput.getValue()){
                oInput.setValueState(sap.ui.core.ValueState.Error);
                oInput.setValueStateText(mensagemErroDescricaoVazia);
                ehValido = false;
            } 
            else {
                oInput.setValueState(sap.ui.core.ValueState.Success);
            }
        },

        ValidarNome(oInput){
            const regex = /[0-9!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/;
            const mensagemErroNomeVazio = "Nome não informado.";
            const mensagemErroNomeComNumeroOuCaractersEspeciais = "Nome deve possuir apenas letras.";
            
            if (!oInput.getValue()){
                oInput.setValueState(sap.ui.core.ValueState.Error);
                oInput.setValueStateText(mensagemErroNomeVazio);
                ehValido = false;
            } 
            else if(regex.test(oInput.getValue())) {
                oInput.setValueState(sap.ui.core.ValueState.Error);
                oInput.setValueStateText(mensagemErroNomeComNumeroOuCaractersEspeciais);
                ehValido = false;
            }
            else {
                oInput.setValueState(sap.ui.core.ValueState.Success);
            }
        },

        ValidarNumeros(oInput, nomeDoInput){      
            const regexNumeros = /[0-9]/;      
            const regexCaracters = /[a-zA-Z!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/; 
            const menssagemErroInputVazio = nomeDoInput + " não informado(a).";
            const mensagemErroInputComLetrasOuCaractersEspeciais = nomeDoInput + " deve conter apenas números.";
            
            if (!oInput.getValue()){
                oInput.setValueState(sap.ui.core.ValueState.Error);
			    oInput.setValueStateText(menssagemErroInputVazio);
                ehValido = false;
            }
            else if (!regexNumeros.test(oInput.getValue()) || regexCaracters.test(oInput.getValue())){
                oInput.setValueState(sap.ui.core.ValueState.Error);
			    oInput.setValueStateText(mensagemErroInputComLetrasOuCaractersEspeciais);
                ehValido = false;
            }
            else {
                oInput.setValueState(sap.ui.core.ValueState.Success);
            }
        },
    }
});