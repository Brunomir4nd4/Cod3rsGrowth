sap.ui.define([
    "sap/ui/test/opaQunit",
    "coders-growth/tests/integrations/pages/IngredientsList",
    "coders-growth/tests/integrations/pages/IngredientDetails"
], function(opaTest) {
    'use strict';
    
    const NOME_ITEM_DA_TABELA_POLVORA = "Pólvora";
    const NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE = "Melancia Reluzente";
    const VALOR_ESPERADO_MELANCIA_RELUZENTE = "Melancia Reluzente";

    QUnit.module("Posts");

    opaTest("Deve entrar na página de detalhes de um ingrediente", function (Given, When, Then) {
        Given.iStartMyApp();
    
        When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_TABELA_POLVORA);
    
        Then.naPaginaDeDetalhesDoIngrediente.deveAbrirViewDeDetalhes();

        Then.iTeardownMyApp();
    });

    opaTest("Deve verificar se o título da página corresponde ao ingrediente esperado", function (Given, When, Then) {
        Given.iStartMyApp();
    
        When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE);
    
        Then.naPaginaDeDetalhesDoIngrediente.deveSerOIngredienteEsperado(VALOR_ESPERADO_MELANCIA_RELUZENTE);
    });
});