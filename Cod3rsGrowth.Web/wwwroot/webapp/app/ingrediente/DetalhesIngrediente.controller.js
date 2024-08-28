sap.ui.define([
    "coders-growth/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/app/model/Formatter",
    "sap/m/MessageBox",
    "coders-growth/app/model/Validators"
], function(BaseController, JSONModel, Formatter, MessageBox, Validators) {
    'use strict';

    const URL_API_INGREDIENTE = "https://localhost:7224/api/Ingredientes";
    const URL_API_POCAO = "https://localhost:7224/api/Pocoes";
    const URL_API_RECEITA = "https://localhost:7224/api/Receitas";
    const NOME_DO_MODELO_INGREDIENTE = "ingrediente";
    const NOME_DO_MODELO_INGREDIENTES = "ingredientes";
    const NOME_DO_MODELO_RECEITA = "receita";
    const NOME_DO_MODELO_POCAO = "pocao";
    const ROTA_DETALHES = "appDetalhesIngrediente";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const ARGUMENTOS_DE_PARAMETRO = "arguments";
    const CHAVE_DA_VIEW_HOME = "appListagem";
    const ID_SELECT_FILHOS = "selectItensFilho";
    const ID_TABELA_INGREDIENTE_DIALOGO_POCAO = "tabelaIngrediente1";
    const ID_TABELA_INGREDIENTE_DIALOGO_RECEITA = "tabelaIngrediente2";
    const ID_MENSSAGE_STRIP_SUCESSO = "successMessageStrip";
    const METODO_DE_REQUISICAO_DELETE = "DELETE";
    const REQUISICAO_PATCH = "PATCH";
    const REQUISICAO_POST = "POST";
    const SIM = true;
    const NAO = false;

    var MENSSAGEM_ERRO_CADASTRO_FILHO;
    var RECEITAS_ASSOCIADAS = [];
    var ID_INGREDIENTE_EDITADO;
    var ID_RECEITA_EDITADA;
    var BOTAO_PRECIONADO;
    var DIALOGO;

    return BaseController.extend("coders-growth.app.ingrediente.DetalhesIngrediente", {
        formatter: Formatter,
        
        onInit(){
            this._aoCoincidirRota();
        },

        aoClicarIrParaEditar(oEvent) {
            this._processarAcao(() => {
                const oItem = oEvent.getSource();
                this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {
                    id: oItem._getPropertiesToPropagate().oModels.ingrediente.oData.id
                }, true);
            })
        },

        aoClicarRemover(){
            MessageBox.warning("Deseja remover esse item?\nVocê não poderá retomar essa ação.", {
                actions: [ 
                    sap.m.MessageBox.Action.NO,
                    sap.m.MessageBox.Action.YES 
                ],
                onClose: (sAction) => {
                    if (sAction === "YES") {
                        const query = `${URL_API_INGREDIENTE}/${ID_INGREDIENTE_EDITADO}`;

                        this._removerItem(query, NAO);
                    }
                },
                dependentOn: this.getView()
            });
        },

        aoClicarApresentarListagemFilhoRequerido(){
            this._processarAcao(() => {
                const itemFilho = this.oView.byId(ID_SELECT_FILHOS).getSelectedItem().getText();
                const itemDoSelect = "Poções";
    
                itemFilho === itemDoSelect ?
                    (
                        this.getView().byId("VBoxTabelaPocao").setVisible(SIM),
                        this.getView().byId("VBoxTabelaReceita").setVisible(NAO),
                        this.getView().byId("botaoEditarFilho").setVisible(NAO)
                    )
                    : (
                        this.getView().byId("VBoxTabelaPocao").setVisible(NAO),
                        this.getView().byId("VBoxTabelaReceita").setVisible(SIM), 
                        this.getView().byId("botaoEditarFilho").setVisible(SIM)
                    );
            });
        },

        aoProcurarFiltrarTabela(oEvent) {
            this._processarAcao(() => {
                const query = URL_API_RECEITA + "?Nome=" + oEvent.mParameters.query;
    
                this._carregarDadosFilho(query, NOME_DO_MODELO_RECEITA);
            });
        },

        async aoClicarAbrirModalCadastroFilho(oEvent) {
            const itemFilho = this.getView().byId("selectItensFilho").getSelectedItem().getText();

            let tabelaIngrediente;

            BOTAO_PRECIONADO = oEvent.getSource().mProperties.text;
            DIALOGO = this.oDialog;

            if (itemFilho === "Receitas") {
                DIALOGO ??= await this.loadFragment({
                    type: "XML",
                    name: "coders-growth.app.ingrediente.fragments.DialogoCadastroReceita"
                });

                tabelaIngrediente = DIALOGO.getContent()[1].getItems()[1];
                
                if (BOTAO_PRECIONADO === "Editar") {
                    const tabelaReceita = this.getView().byId("tabelaReceita");
                    const itens = tabelaReceita.getSelectedItems();
                    
                    if (itens.length >= 1) {
                        const primeiroItem = 0;
                        const receita = itens[primeiroItem].getBindingContext(NOME_DO_MODELO_RECEITA); 
    
                        this._inserirValoresReceitaEditada(receita, tabelaIngrediente);

                        DIALOGO.open();
                    } else {
                        MessageBox.error("Deve haver uma receita selecionada.");
                        DIALOGO.destroy();
                    }
                } else 
                    DIALOGO.open();

            } else {
                DIALOGO ??= await this.loadFragment({
                    type: "XML",
                    name: "coders-growth.app.ingrediente.fragments.DialogoCadastroPocao"
                });

                tabelaIngrediente = DIALOGO.getContent()[1].getItems()[0];

                DIALOGO.open();
            }

            MENSSAGEM_ERRO_CADASTRO_FILHO = DIALOGO.getContent()[0];
            this._selecionarItemDetalhadoNaTabela(tabelaIngrediente);
        },

        aoClicarFecharDialogo() {  
            this._processarAcao(() => {
                DIALOGO.close();
                DIALOGO.destroy();
            });
        },

        aoProcurarFiltrarTabelaDialogo(oEvent) {
            this._processarAcao(() => {
                const query = URL_API_INGREDIENTE + "?Nome=" + oEvent.mParameters.query;

                this._carregarIngredientes(query, NOME_DO_MODELO_INGREDIENTES, this.getView());
            })
        },

        aoAlterarValidarNome() {
            this._processarAcao(() => {
                const inputNome = this.getView().byId("inputNomeReceita");

                Validators.ValidarNome(inputNome);
            })
        },

        aoAlterarValidarValidade() {
            this._processarAcao(() => {
                const inputValidade = this.getView().byId("inputValidadeReceita");
                const label = "Validade";

                Validators.ValidarNumeros(inputValidade, label);
            })
        },

        aoAlterarValidarValor() {
            this._processarAcao(() => {
                const inputValor = this.getView().byId("inputValorReceita");
                const label = "Valor";

                Validators.ValidarNumeros(inputValor, label);
            })
        },

        aoAlterarValidarDescricao() {
            this._processarAcao(() => {
                const inputDescricao = this.getView().byId("inputDescricaoReceita");

                Validators.ValidarDescricao(inputDescricao);
            })
        },

        aoClicarSalvarAlteracoes() {
            this._processarAcao(() => {
                const itemFilho = this.oView.byId(ID_SELECT_FILHOS).getSelectedItem().getText();
                const inputNome = this.getView().byId("inputNomeReceita");
                const inputValidade = this.getView().byId("inputValidadeReceita");
                const inputValor = this.getView().byId("inputValorReceita");
                const inputDescricao = this.getView().byId("inputDescricaoReceita");
                
                if (itemFilho === "Receitas") {
                    const ehValido = Validators.ValidarReceita(inputNome, inputValidade, inputValor, inputDescricao);

                    ehValido ? (
                        this._cadastrarReceita(inputNome.getValue(), inputValidade.getValue(), inputValor.getValue(), inputDescricao.getValue()),   
                        MENSSAGEM_ERRO_CADASTRO_FILHO.setVisible(NAO)
                    )
                    : MENSSAGEM_ERRO_CADASTRO_FILHO.setVisible(SIM);
                }
                else 
                    this._cadastrarPocao();
            })
        },

        aoClicarExcluirItemFilho() {
            this._processarAcao(() => {
                const itemFilho = this.getView().byId("selectItensFilho").getSelectedItem().getText();
            
                MessageBox.warning("Deseja remover esse(s) item(ns)?\nVocê não poderá retomar essa ação.", {
                    actions: [sap.m.MessageBox.Action.NO, sap.m.MessageBox.Action.YES],
                    onClose: sAction => {
                        if (sAction === "YES") {
                            itemFilho === "Receitas" ?
                                this._removerReceita()
                                : this._removerPocao();
    
                        }
                    },
                    dependentOn: this.getView()
                });
            })
        },

        _toggleMessageStrips(erroVisivel, sucessoVisivel) {
            this._processarAcao(() => {
                MENSSAGEM_ERRO_CADASTRO_FILHO.setVisible(erroVisivel);
                this.getView().byId(ID_MENSSAGE_STRIP_SUCESSO).setVisible(sucessoVisivel);
            })
        },

        _inserirValoresReceitaEditada(receita, tabelaIngrediente){
            this._processarAcao(() => {
                const listaIdIngrediente = receita.getProperty("listaIdIngrediente");

                ID_RECEITA_EDITADA = receita.getProperty("id");

                this.getView().byId("inputNomeReceita").setValue(receita.getProperty("nome"));
                this.getView().byId("inputValidadeReceita").setValue(receita.getProperty("validadeEmMeses"));
                this.getView().byId("inputValorReceita").setValue(receita.getProperty("valor"));
                this.getView().byId("inputDescricaoReceita").setValue(receita.getProperty("descricao"));
                this._selecionarIngredientesNaTabela(tabelaIngrediente, listaIdIngrediente);
            })
        },

        _removerReceita() {
            this._processarAcao(() => {
                const tabelaReceita = this.getView().byId("tabelaReceita");
                const itens = tabelaReceita.getSelectedItems();
                const tamanhoMinimo = 1;

                itens.length >= tamanhoMinimo ?
                    itens.forEach(item => {
                        const id = item.getBindingContext(NOME_DO_MODELO_RECEITA).getProperty("id");
                        const query = `${URL_API_RECEITA}/${id}`;
    
                        this._removerItem(query, SIM);
                    })
                    : MessageBox.error("Deve haver pelo menos uma receita selecionada.");
            })
        },

        _removerPocao() {
            this._processarAcao(() => {
                const tabelaPocao = this.getView().byId("tabelaPocao");
                const itens = tabelaPocao.getSelectedItems();
                const tamanhoMinimo = 1;

                if (itens.length >= tamanhoMinimo) {
                    itens.forEach(item => {
                        const id = item.getBindingContext(NOME_DO_MODELO_POCAO).getProperty("id");
                        const query = `${URL_API_POCAO}/${id}`;
    
                        this._removerItem(query, SIM);
                    });
                } else {
                    MessageBox.error("Deve haver pelo menos uma poção selecionada.");
                }
            })
        },

        _removerItem(query, ehItemFilho) {
            this._showBusyIndicator();

            fetch(query , {
                method: METODO_DE_REQUISICAO_DELETE,
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
            .then(resp => {
                if (resp.ok) {
                    sap.m.MessageToast.show("Item removido com sucesso.");
                    if (!ehItemFilho) this.getRouter().navTo(CHAVE_DA_VIEW_HOME, {}, true);    
                }
            })
            .catch(err => MessageBox.error(err.message))
            .finally(() => {
                this._hideBusyIndicator();
                this._carregarDadosFilho(URL_API_RECEITA, NOME_DO_MODELO_RECEITA);
                this._carregarDadosFilho(URL_API_POCAO, NOME_DO_MODELO_POCAO);
            });
        },

        _selecionarItemDetalhadoNaTabela(tabela) {
            this._processarAcao(() => {
                const items = tabela.getItems();
    
                items.map((item) => {
                    let id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty("id");
    
                    if (id === parseInt(ID_INGREDIENTE_EDITADO))
                        tabela.setSelectedItem(item);
                });
            });
        },

        _cadastrarReceita(nome, validade, valor, descricao) {
            this._processarAcao(() => {
                const nomeIngredienteDetalhado = this.getView().getModel(NOME_DO_MODELO_INGREDIENTE).getData().nome;
                const itensSelecionados = this.getView().byId(ID_TABELA_INGREDIENTE_DIALOGO_RECEITA).getSelectedItems();
                const requisicao = BOTAO_PRECIONADO === "Adicionar" ? REQUISICAO_POST : REQUISICAO_PATCH;

                const receita = {
                    nome: nome,
                    descricao: descricao,
                    valor: valor,
                    validadeEmMeses: validade,
                    imagem: "string",
                };

                let ingredientesSelecionados = [];
                let possuiItemDetalhado = false;
            
                itensSelecionados.forEach(item => {
                    const id = item.getBindingContext("ingredientes").getProperty("id");
    
                    if (id === parseInt(ID_INGREDIENTE_EDITADO))
                        possuiItemDetalhado = true;
    
                    ingredientesSelecionados.push(id);
                });
                
                receita.listaIdIngrediente = ingredientesSelecionados;

                if (requisicao === REQUISICAO_PATCH) receita.id = ID_RECEITA_EDITADA;

                possuiItemDetalhado ? 
                    this._requisitarApi(URL_API_RECEITA, receita, requisicao)
                    : MessageBox.error(`O cadastro deve possuir o ingrediente "${nomeIngredienteDetalhado}"`);
            });
        },

        _cadastrarPocao() {
            this._processarAcao(() => {
                const itensSelecionados = this.getView().byId(ID_TABELA_INGREDIENTE_DIALOGO_POCAO).getSelectedItems();
                const nomeIngredienteDetalhado = this.getView().getModel(NOME_DO_MODELO_INGREDIENTE).getData().nome;
                const listaIngredientes = this.getView().getModel("ingredientes").getData();
                const ingredientesSelecionados = [];

                let possuiItemDetalhado = false;

                itensSelecionados.map(item => {
                    const id = item.getBindingContext("ingredientes").getProperty("id");
                    
                    if (id === parseInt(ID_INGREDIENTE_EDITADO))
                        possuiItemDetalhado = true;

                    listaIngredientes.map((ingrediente) => {
                        if (ingrediente.id === id)
                            ingredientesSelecionados.push(ingrediente);
                    })
                });       

                possuiItemDetalhado ?
                    this._requisitarApi(URL_API_POCAO, ingredientesSelecionados, REQUISICAO_POST)
                    : MessageBox.error(`O cadastro deve possuir o ingrediente "${nomeIngredienteDetalhado}"`);
            });
        },

        _requisitarApi(url, item, requisicao) {
            this._showBusyIndicator();
            
            fetch(url, {
                method: requisicao,
                body: JSON.stringify(item),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
            .then(response => response.json())
            .then(data => {
                !data.Detail ? (
                    this._toggleMessageStrips(NAO, SIM),

                    url.includes("Receitas") ? 
                        this._carregarDadosFilho(url, NOME_DO_MODELO_RECEITA) 
                        : this._carregarDadosFilho(url, NOME_DO_MODELO_POCAO),

                    this.aoClicarFecharDialogo()

                ) : this._erroNaRequisicaoDaApi(data);
            })
            .catch(err => MessageBox.error(err.message))
            .finally(() => this._hideBusyIndicator());
        },

        _aoCoincidirRota() {
            this._processarAcao(() => {
                this.getRouter().getRoute(ROTA_DETALHES).attachPatternMatched((oEvent) => {
                    this._limparResquicios();
                    this._obterParametro(oEvent);
                    this._obterPorId(ID_INGREDIENTE_EDITADO);
                    this._carregarDadosFilho(URL_API_RECEITA, NOME_DO_MODELO_RECEITA);
                    this._carregarIngredientes(URL_API_INGREDIENTE, NOME_DO_MODELO_INGREDIENTES, this.getView());
                }, this);
            });
        },

        _selecionarIngredientesNaTabela(tabela, listaIdIngrediente) {
            const itens = tabela.getItems();

            itens.map((item) => {
                const id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty("id");

                listaIdIngrediente.map((idIngrediente) => {
                    if (id === idIngrediente)
                        tabela.setSelectedItem(item);
                })
            });
        },

        _limparResquicios(){
            this.getView().byId("filtroNome").setValue("");
            this.getView().byId("selectItensFilho").setSelectedKey("Receitas");
            this.getView().byId(ID_MENSSAGE_STRIP_SUCESSO).setVisible(NAO);
            this.aoClicarApresentarListagemFilhoRequerido();
        },

        _obterParametro(oEvent) {
            ID_INGREDIENTE_EDITADO = oEvent.getParameter(ARGUMENTOS_DE_PARAMETRO).id;
        },
 
        _obterPorId(id) {
            this._showBusyIndicator();
            const query = `${URL_API_INGREDIENTE}/${id}`;

            fetch(query)
                .then(resp => resp.json())
                .then(data => {
                    !data.Detail ? this.getView().setModel(new JSONModel(data), NOME_DO_MODELO_INGREDIENTE)
                    : this._erroNaRequisicaoDaApi(data);
                })
                .catch((err) => MessageBox.error(err.message))
                .finally(() => this._hideBusyIndicator());
        },

        _carregarDadosFilho(urlApi, nomeDoModelo) {
            this._showBusyIndicator();

            fetch(urlApi)
                .then((res) => res.json())
                .then((data) => {
                    if (!data.Detail){
                        if (urlApi.includes("Receitas")){
                            RECEITAS_ASSOCIADAS = this._obterReceitasAssociadas(data);

                            this.getView().setModel(new JSONModel(RECEITAS_ASSOCIADAS), nomeDoModelo)
                            this._carregarDadosFilho(URL_API_POCAO, NOME_DO_MODELO_POCAO);
                        }
                        else {
                            const pocoesAssociadas = this._obterPocoesAssociadas(data, RECEITAS_ASSOCIADAS);

                            this.getView().setModel(new JSONModel(pocoesAssociadas), nomeDoModelo)
                        }
                    } else {
                        this._erroNaRequisicaoDaApi(data);
                    }
                })
                .catch((err) => MessageBox.error(err.message))
                .finally(() => this._hideBusyIndicator());
        },

        _obterReceitasAssociadas(receitas) {
            let receitasAssociadas = [];
            receitas.filter((receita) => {
                if (receita.listaIdIngrediente.includes(parseInt(ID_INGREDIENTE_EDITADO)))
                    receitasAssociadas.push(receita);
            });

            return receitasAssociadas;
        },

        _obterPocoesAssociadas(pocoes, receitasAssociadas) {
            let pocoesAssociadas = [];
            
            pocoes.map((pocao) => {
                receitasAssociadas.map(receita => {
                    if (pocao.idReceita === receita.id) 
                        pocoesAssociadas.push(pocao);
                });
            });

            return pocoesAssociadas;
        },
    })
});