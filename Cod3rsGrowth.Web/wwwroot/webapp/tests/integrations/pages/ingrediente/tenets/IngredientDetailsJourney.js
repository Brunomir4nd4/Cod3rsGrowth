sap.ui.define([
    "sap/ui/test/opaQunit",
    "coders-growth/tests/integrations/pages/ingrediente/IngredientsList",
    "coders-growth/tests/integrations/pages/ingrediente/IngredientDetails"
], function(opaTest) {
    'use strict';
    
    const NAME_SPACE = "coders-growth";
    const HASH_DE_DETALHES = "DetalhesIngrediente/4";
    const NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE = "Melancia Reluzente";

    QUnit.module("Detalhes");

    opaTest("Deve entrar na página de detalhes de um ingrediente", function (Given, When, Then) {
        Given.iStartMyUIComponent({
            componentConfig: {
                name: NAME_SPACE
            } ,
            hash: HASH_DE_DETALHES
        });
    
        Then.naPaginaDeDetalhesDoIngrediente.deveEstarNaViewDeDetalhes();
    });

    opaTest("Deve verificar se o título da página corresponde ao ingrediente esperado", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoDeVoltarPagina();
        When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE);
    
        Then.naPaginaDeDetalhesDoIngrediente.deveSerOIngredienteEsperado(NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE);
    });
    
    opaTest("Testa o botao de cancelar no ato da remoção", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoDeRemover();
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoCancelarDoMessageBox();

        Then.naPaginaDeDetalhesDoIngrediente.deveEstarNaViewDeDetalhes();
    })
    
    opaTest("Deve remover um ingrediente da lista", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoDeRemover();
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoYesDoMessageBox();

        Then.naPaginaDeListagemDosIngredientes.verificaSeOIngredienteFoiRemovido(NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE);
        Then.iTeardownMyApp();
    })
});