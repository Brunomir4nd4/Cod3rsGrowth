sap.ui.define([
    "sap/ui/test/opaQunit",
    "coders-growth/tests/integrations/pages/ingrediente/IngredientsList",
    "coders-growth/tests/integrations/pages/ingrediente/IngredientDetails"
], function(opaTest) {
    'use strict';
    
    const NAME_SPACE = "coders-growth";
    const HASH_DE_DETALHES = "DetalhesIngrediente/4";
    const NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE = "Melancia Reluzente";
    const NOME_ITEM_DA_OLHO_DE_ARANHA = "Olho de Aranha";
    const QUERY_POCAO_DE_CURA = "Poção de Cura";
    const QUERY_POCAO_DE_FORCA = "Poção de Força";
    const VALOR_VAZIO = "";
    const ID_INPUT_NOME = "inputNomeReceita";
    const ID_INPUT_VALIDADE = "inputValidadeReceita";
    const ID_INPUT_VALOR = "inputValorReceita";
    const ID_INPUT_DESCRICAO = "inputDescricaoReceita";
    const INPUT_NOME = "Nome";
    const INPUT_VALIDADE = "Validade";
    const INPUT_VALOR = "Valor";
    const INPUT_DESCRICAO = "Descrição";
    const VALOR_POCAO_TESTE = "Poção Teste";
    const VALOR_DESCRICAO_TESTE = "Descrição Teste";
    const VALOR_12 = 12;
    const VALOR_50 = 50;
    const TITULO_POCOES = "Poções";
    const TITULO_RECEITAS = "Receitas";
    const MODAL_RECEITAS = "Cadastar Receita";
    const NOME_ITEM_DA_TABELA_PEROLA_DO_END = "Pérola do End";
    const ID_TABELA_INGREDIENTE_DIALOGO_RECEITA = "tabelaIngrediente2";
    const ID_TABELA_INGREDIENTE_DIALOGO_POCAO = "tabelaIngrediente1";
    const VALOR_POCAO_TESTE_DE_EDICAO = "Poção Teste de Edição"

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
        When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE, ID_TABELA_INGREDIENTE_DIALOGO_RECEITA);
    
        Then.naPaginaDeDetalhesDoIngrediente.deveSerOIngredienteEsperado(NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE);
    });
    
    opaTest("Testa o botao de cancelar no ato da remoção", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoDeRemover();
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoCancelarDoMessageBox();

        Then.naPaginaDeDetalhesDoIngrediente.deveEstarNaViewDeDetalhes();
        Then.iTeardownMyApp();
    });
    
    // opaTest("Deve remover um ingrediente da lista", function (Given, When, Then) {
    //     When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoDeRemover();
    //     When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoYesDoMessageBox();

    //     Then.naPaginaDeListagemDosIngredientes.verificaSeOIngredienteFoiRemovido(NOME_ITEM_DA_TABELA_MELANCIA_RELUZENTE);
    // });

    QUnit.module("Detalhes - Itens Filhos")
    
    opaTest("Deve filtrar a lista de receitas por Poção de Cura", function (Given, When, Then) {
        Given.iStartMyApp();
        When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_OLHO_DE_ARANHA);
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(QUERY_POCAO_DE_CURA);
        
        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarOItemEsperado(QUERY_POCAO_DE_CURA);
    });

    opaTest("Deve filtrar a lista de pocoes por Poção de Força", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(VALOR_VAZIO);
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(TITULO_POCOES);
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(QUERY_POCAO_DE_FORCA);
        
        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarOItemEsperado(QUERY_POCAO_DE_FORCA);
    });

    opaTest("Deve abrir o modal esperado.", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(VALOR_VAZIO);
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(TITULO_RECEITAS);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoAdicionar();
       
        Then.naPaginaDeDetalhesDoIngrediente.deveEstarNoModalEsperado(MODAL_RECEITAS);
    });

    opaTest("Deve criar um receita com o nome Poção Teste", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, VALOR_POCAO_TESTE, INPUT_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, VALOR_12, INPUT_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, VALOR_50, INPUT_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_DESCRICAO, VALOR_DESCRICAO_TESTE, INPUT_DESCRICAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_TABELA_PEROLA_DO_END, ID_TABELA_INGREDIENTE_DIALOGO_RECEITA);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeSucessoEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com nome", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoAdicionar();
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, VALOR_POCAO_TESTE, INPUT_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com validade", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, VALOR_VAZIO, INPUT_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, VALOR_12, INPUT_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com valor", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, VALOR_VAZIO, INPUT_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, VALOR_50, INPUT_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com descrição", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, VALOR_VAZIO, INPUT_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_DESCRICAO, VALOR_DESCRICAO_TESTE, INPUT_DESCRICAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve tentar criar uma receita sem o ingrediente detalhado.", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, VALOR_POCAO_TESTE, INPUT_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, VALOR_12, INPUT_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, VALOR_50, INPUT_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoDesmacarItemDaTabela(ID_TABELA_INGREDIENTE_DIALOGO_RECEITA);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarDialogoDeErroEsperado(NOME_ITEM_DA_OLHO_DE_ARANHA);
    });

    opaTest("Deve tentar criar uma poção sem o ingrediente detalhado.", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoCancelar();
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(TITULO_POCOES);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoAdicionar();
        When.naPaginaDeDetalhesDoIngrediente.aoDesmacarItemDaTabela(ID_TABELA_INGREDIENTE_DIALOGO_POCAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarDialogoDeErroEsperado(NOME_ITEM_DA_OLHO_DE_ARANHA);
    });
    
    opaTest("Deve criar uma poção com nome igual a Poção Teste", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_OLHO_DE_ARANHA, ID_TABELA_INGREDIENTE_DIALOGO_POCAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabela(NOME_ITEM_DA_TABELA_PEROLA_DO_END, ID_TABELA_INGREDIENTE_DIALOGO_POCAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeSucessoEsperada();
    });
    
    opaTest("Deve abrir o modal de cadastro para a edição de um item", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(TITULO_RECEITAS);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabelaFilho(VALOR_POCAO_TESTE);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoEditarItemFilho();
        
        Then.naPaginaDeDetalhesDoIngrediente.deveEstarNoModalEsperado(MODAL_RECEITAS);
    });
    
    opaTest("Deve editar o nome de uma receita de 'Poção Teste' para 'Poção Teste de Edição'", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, VALOR_POCAO_TESTE_DE_EDICAO, INPUT_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, VALOR_50, INPUT_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeSucessoEsperada();
        Then.iTeardownMyApp();
    });
});