sap.ui.define([
    "sap/ui/test/opaQunit",
    "coders-growth/tests/integrations/pages/ingrediente/IngredientsList",
    "coders-growth/tests/integrations/pages/ingrediente/IngredientDetails"
], function(opaTest) {
    'use strict';
    
    const NAME_SPACE = "coders-growth";
    const HASH_DE_DETALHES = "DetalhesIngrediente/4";
    const ITEM_MELANCIA_RELUZENTE = "Melancia Reluzente";
    const ITEM_OLHO_DE_ARANHA = "Olho de Aranha";
    const QUERY_POCAO_DE_CURA = "Poção de Cura";
    const QUERY_POCAO_DE_FORCA = "Poção de Força";
    const STRING_VAZIA = "";
    const ID_INPUT_NOME = "inputNomeReceita";
    const ID_INPUT_VALIDADE = "inputValidadeReceita";
    const ID_INPUT_VALOR = "inputValorReceita";
    const ID_INPUT_DESCRICAO = "inputDescricaoReceita";
    const ID_TABELA_INGREDIENTE_DIALOGO_RECEITA = "tabelaIngrediente2";
    const ID_TABELA_INGREDIENTE_DIALOGO_POCAO = "tabelaIngrediente1";
    const ID_TABELA_RECEITA = "tabelaReceita";
    const ID_TABELA_POCAO = "tabelaPocao";
    const LABEL_NOME = "Nome";
    const LABEL_VALIDADE = "Validade";
    const LABEL_VALOR = "Valor";
    const LABEL_DESCRICAO = "Descrição";
    const NOME_DO_PRODUTO = "Poção Teste";
    const DESCRICAO_DO_PRODUTO = "Descrição Teste";
    const NOME_DO_PRODUTO_PARA_O_TESTE_DE_EDICAO = "Poção Teste de Edição";
    const NOME_DA_TABELA_POCOES = "Poções";
    const NOME_DA_TABELA_RECEITAS = "Receitas";
    const TITULO_DO_MODAL_DE_CADASTRO_RECEITA = "Cadastar Receita";
    const NOME_DO_ITEM_DA_TABELA = "Pérola do End";
    const QUANTIDADE_MESES_VALIDADE = 12;
    const VALOR_DO_PRODUTO = 50;
    const JSON_MODEL_RECEITA = "receita";
    const JSON_MODEL_POCAO = "pocao";

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
        When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(ITEM_MELANCIA_RELUZENTE, ID_TABELA_INGREDIENTE_DIALOGO_RECEITA);
    
        Then.naPaginaDeDetalhesDoIngrediente.deveSerOIngredienteEsperado(ITEM_MELANCIA_RELUZENTE);
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

    //     Then.naPaginaDeListagemDosIngredientes.verificaSeOIngredienteFoiRemovido(S_MELANCIA_RELUZENTE);
    // });

    QUnit.module("Detalhes - Itens Filhos")
    
    opaTest("Deve filtrar a lista de receitas por Poção de Cura", function (Given, When, Then) {
        Given.iStartMyApp();
        When.naPaginaDeListagemDosIngredientes.aoClicarEmUmItemDaTabela(ITEM_OLHO_DE_ARANHA);
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(QUERY_POCAO_DE_CURA);
        
        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarOItemEsperado(QUERY_POCAO_DE_CURA);
    });

    opaTest("Deve filtrar a lista de pocoes por Poção de Força", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(STRING_VAZIA);
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(NOME_DA_TABELA_POCOES);
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(QUERY_POCAO_DE_FORCA);
        
        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarOItemEsperado(QUERY_POCAO_DE_FORCA);
    });

    opaTest("Deve abrir o modal esperado.", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoFiltrarTabelaFilha(STRING_VAZIA);
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(NOME_DA_TABELA_RECEITAS);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoAdicionar();
       
        Then.naPaginaDeDetalhesDoIngrediente.deveEstarNoModalEsperado(TITULO_DO_MODAL_DE_CADASTRO_RECEITA);
    });

    opaTest("Deve criar um receita com o nome Poção Teste", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, NOME_DO_PRODUTO, LABEL_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, QUANTIDADE_MESES_VALIDADE, LABEL_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, VALOR_DO_PRODUTO, LABEL_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_DESCRICAO, DESCRICAO_DO_PRODUTO, LABEL_DESCRICAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabela(NOME_DO_ITEM_DA_TABELA, ID_TABELA_INGREDIENTE_DIALOGO_RECEITA);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeSucessoEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com nome", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoAdicionar();
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, NOME_DO_PRODUTO, LABEL_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com validade", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, STRING_VAZIA, LABEL_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, QUANTIDADE_MESES_VALIDADE, LABEL_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com valor", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, STRING_VAZIA, LABEL_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, VALOR_DO_PRODUTO, LABEL_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve apresentar a mensagem de erro ao tentar criar receita somente com descrição", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, STRING_VAZIA, LABEL_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_DESCRICAO, DESCRICAO_DO_PRODUTO, LABEL_DESCRICAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeErroEsperada();
    });

    opaTest("Deve tentar criar uma receita sem o ingrediente detalhado.", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, NOME_DO_PRODUTO, LABEL_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, QUANTIDADE_MESES_VALIDADE, LABEL_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALOR, VALOR_DO_PRODUTO, LABEL_VALOR);
        When.naPaginaDeDetalhesDoIngrediente.aoDesmacarItemDaTabela(ID_TABELA_INGREDIENTE_DIALOGO_RECEITA);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarDialogoDeErroEsperado(ITEM_OLHO_DE_ARANHA);
    });

    opaTest("Deve tentar criar uma poção sem o ingrediente detalhado.", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoCancelar();
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(NOME_DA_TABELA_POCOES);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoAdicionar();
        When.naPaginaDeDetalhesDoIngrediente.aoDesmacarItemDaTabela(ID_TABELA_INGREDIENTE_DIALOGO_POCAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarDialogoDeErroEsperado(ITEM_OLHO_DE_ARANHA);
    });
    
    opaTest("Deve criar uma poção com nome igual a Poção Teste", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabela(ITEM_OLHO_DE_ARANHA, ID_TABELA_INGREDIENTE_DIALOGO_POCAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabela(NOME_DO_ITEM_DA_TABELA, ID_TABELA_INGREDIENTE_DIALOGO_POCAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeSucessoEsperada();
    });
    
    opaTest("Deve abrir o modal de cadastro para a edição de um item", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(NOME_DA_TABELA_RECEITAS);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabelaFilho(NOME_DO_PRODUTO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoEditarItemFilho();
        
        Then.naPaginaDeDetalhesDoIngrediente.deveEstarNoModalEsperado(TITULO_DO_MODAL_DE_CADASTRO_RECEITA);
    });
    
    opaTest("Deve editar o nome de uma receita de 'Poção Teste' para 'Poção Teste de Edição'", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_NOME, NOME_DO_PRODUTO_PARA_O_TESTE_DE_EDICAO, LABEL_NOME);
        When.naPaginaDeDetalhesDoIngrediente.aoInserirValorAoInput(ID_INPUT_VALIDADE, VALOR_DO_PRODUTO, LABEL_VALIDADE);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoSalvar();

        Then.naPaginaDeDetalhesDoIngrediente.deveApresentarMensagemDeSucessoEsperada();
    });
    
    opaTest("Deve remover a poção com o nome de 'Poção Teste de Edição'", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(NOME_DA_TABELA_POCOES);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabelaFilho(NOME_DO_PRODUTO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoRemoverFilho();
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoYesDoMessageBox();

        Then.naPaginaDeDetalhesDoIngrediente.deveRemoverOItemEsperado(NOME_DO_PRODUTO, ID_TABELA_POCAO, JSON_MODEL_POCAO);
    });

    opaTest("Deve remover a receita com o nome de 'Poção Teste de Edição'", function (Given, When, Then) {
        When.naPaginaDeDetalhesDoIngrediente.aoSelecionarATabelaFilho(NOME_DA_TABELA_RECEITAS);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarEmUmItemDaTabelaFilho(NOME_DO_PRODUTO_PARA_O_TESTE_DE_EDICAO);
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoRemoverFilho();
        When.naPaginaDeDetalhesDoIngrediente.aoClicarNoBotaoYesDoMessageBox();

        Then.naPaginaDeDetalhesDoIngrediente.deveRemoverOItemEsperado(NOME_DO_PRODUTO_PARA_O_TESTE_DE_EDICAO, ID_TABELA_RECEITA, JSON_MODEL_RECEITA);
        Then.iTeardownMyApp();
    });
});