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
    const CHAVE_VIEW_DETALHES_INGREDIENTE = "appDetalhesIngrediente";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const CHAVE_DA_VIEW_LISTAGEM_INGREDIENTE = "appListagem";
    const ID_SELECT_FILHOS = "selectItensFilho";
    const ID_TABELA_INGREDIENTE_DIALOGO_POCAO = "tabelaIngrediente1";
    const ID_TABELA_INGREDIENTE_DIALOGO_RECEITA = "tabelaIngrediente2";
    const ID_MENSSAGE_STRIP_SUCESSO = "successMessageStrip";
    const ID_TABELA_RECEITA = "tabelaReceita";
    const ID_TABELA_POCAO = "tabelaPocao";
    const ID_INPUT_NOME_RECEITA = "inputNomeReceita";
    const ID_INPUT_VALIDADE_RECEITA = "inputValidadeReceita";
    const ID_INPUT_VALOR_RECEITA = "inputValorReceita";
    const ID_INPUT_DESCRICAO_RECEITA = "inputDescricaoReceita";
    const METODO_DE_REQUISICAO_DELETE = "DELETE";
    const REQUISICAO_PATCH = "PATCH";
    const REQUISICAO_POST = "POST";
    const PROPRIEDADE_ARGUMENTOS = "arguments";
    const ITEM_DO_SELECT_RECEITAS = "Receitas";
    const ITEM_DO_SELECT_POCOES = "Poções";
    const PROPRIEDADE_EDITAR = "Editar";
    const PROPRIEDADE_ADICIONAR = "Adicionar";
    const PROPRIEDADE_ID = "id";
    const STRING_VAZIA = "";
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
            const acaoSim = "YES";

            MessageBox.warning("Deseja remover esse item?\nVocê não poderá retomar essa ação.", {
                actions: [ 
                    sap.m.MessageBox.Action.NO,
                    sap.m.MessageBox.Action.YES 
                ],
                onClose: (sAction) => {
                    if (sAction === acaoSim) {
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
                const idVBoxTabelaReceita = "VBoxTabelaReceita";
                const idVBoxTabelaPocao = "VBoxTabelaPocao";
                const idBotaoEditarFilho = "botaoEditarFilho";
    
                itemFilho === ITEM_DO_SELECT_POCOES ?
                    (
                        this.getView().byId(idVBoxTabelaPocao).setVisible(SIM),
                        this.getView().byId(idVBoxTabelaReceita).setVisible(NAO),
                        this.getView().byId(idBotaoEditarFilho).setVisible(NAO)
                    )
                    : (
                        this.getView().byId(idVBoxTabelaPocao).setVisible(NAO),
                        this.getView().byId(idVBoxTabelaReceita).setVisible(SIM), 
                        this.getView().byId(idBotaoEditarFilho).setVisible(SIM)
                    );
            });
        },

        aoProcurarFiltrarTabela(oEvent) {
            this._processarAcao(() => {
                const query = `${URL_API_RECEITA}?Nome=${oEvent.mParameters.query}`;
    
                this._carregarDadosFilho(query, NOME_DO_MODELO_RECEITA);
            });
        },

        async aoClicarAbrirModalCadastroFilho(oEvent) {
            const itemFilho = this.getView().byId(ID_SELECT_FILHOS).getSelectedItem().getText();
            const primeiroIdex = 0;
            const segundoIndex = 1;
            const tamanhoMinimo = 1;

            let tabelaIngrediente;

            BOTAO_PRECIONADO = oEvent.getSource().mProperties.text;
            DIALOGO = this.oDialog;

            if (itemFilho === ITEM_DO_SELECT_RECEITAS) {
                DIALOGO ??= await this.loadFragment({
                    type: "XML",
                    name: "coders-growth.app.ingrediente.fragments.DialogoCadastroReceita"
                });

                tabelaIngrediente = DIALOGO.getContent()[segundoIndex].getItems()[segundoIndex];
                
                if (BOTAO_PRECIONADO === PROPRIEDADE_EDITAR) {
                    const tabelaReceita = this.getView().byId(ID_TABELA_RECEITA);
                    const itens = tabelaReceita.getSelectedItems();
                    
                    if (itens.length >= tamanhoMinimo) {
                        const receita = itens[primeiroIdex].getBindingContext(NOME_DO_MODELO_RECEITA); 
    
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

                tabelaIngrediente = DIALOGO.getContent()[segundoIndex].getItems()[primeiroIdex];

                DIALOGO.open();
            }

            MENSSAGEM_ERRO_CADASTRO_FILHO = DIALOGO.getContent()[primeiroIdex];
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
                const query = `${URL_API_INGREDIENTE}?Nome=${oEvent.mParameters.query}`;

                this._carregarIngredientes(query, NOME_DO_MODELO_INGREDIENTES, this.getView());
            })
        },

        aoAlterarValidarNome() {
            this._processarAcao(() => {
                const inputNome = this.getView().byId(ID_INPUT_NOME_RECEITA);

                Validators.ValidarNome(inputNome);
            })
        },

        aoAlterarValidarValidade() {
            this._processarAcao(() => {
                const inputValidade = this.getView().byId(ID_INPUT_VALIDADE_RECEITA);
                const label = "Validade";

                Validators.ValidarNumeros(inputValidade, label);
            })
        },

        aoAlterarValidarValor() {
            this._processarAcao(() => {
                const inputValor = this.getView().byId(ID_INPUT_VALOR_RECEITA);
                const label = "Valor";

                Validators.ValidarNumeros(inputValor, label);
            })
        },

        aoAlterarValidarDescricao() {
            this._processarAcao(() => {
                const inputDescricao = this.getView().byId(ID_INPUT_DESCRICAO_RECEITA);

                Validators.ValidarDescricao(inputDescricao);
            })
        },

        aoClicarSalvarAlteracoes() {
            this._processarAcao(() => {
                const itemFilho = this.oView.byId(ID_SELECT_FILHOS).getSelectedItem().getText();
                const inputNome = this.getView().byId(ID_INPUT_NOME_RECEITA);
                const inputValidade = this.getView().byId(ID_INPUT_VALIDADE_RECEITA);
                const inputValor = this.getView().byId(ID_INPUT_VALOR_RECEITA);
                const inputDescricao = this.getView().byId(ID_INPUT_DESCRICAO_RECEITA);
                
                if (itemFilho === ITEM_DO_SELECT_RECEITAS) {
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
                const itemFilho = this.getView().byId(ID_SELECT_FILHOS).getSelectedItem().getText();
                const acaoSim = "YES";
            
                MessageBox.warning("Deseja remover esse(s) item(ns)?\nVocê não poderá retomar essa ação.", {
                    actions: [sap.m.MessageBox.Action.NO, sap.m.MessageBox.Action.YES],
                    onClose: sAction => {
                        if (sAction === acaoSim) {
                            itemFilho === ITEM_DO_SELECT_RECEITAS ?
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
                const sListaIdIngrediente = "listaIdIngrediente";
                const sValidadeEmMeses = "validadeEmMeses";
                const sDescricao = "descricao";         
                const sValor = "valor";
                const sNome = "nome";

                const listaIdIngrediente = receita.getProperty(sListaIdIngrediente);

                ID_RECEITA_EDITADA = receita.getProperty(PROPRIEDADE_ID);

                this.getView().byId(ID_INPUT_NOME_RECEITA).setValue(receita.getProperty(sNome));
                this.getView().byId(ID_INPUT_VALIDADE_RECEITA).setValue(receita.getProperty(sValidadeEmMeses));
                this.getView().byId(ID_INPUT_VALOR_RECEITA).setValue(receita.getProperty(sValor));
                this.getView().byId(ID_INPUT_DESCRICAO_RECEITA).setValue(receita.getProperty(sDescricao));
                this._selecionarIngredientesNaTabela(tabelaIngrediente, listaIdIngrediente);
            })
        },

        _removerReceita() {
            this._processarAcao(() => {
                const tabelaReceita = this.getView().byId(ID_TABELA_RECEITA);
                const itens = tabelaReceita.getSelectedItems();

                const tamanhoMinimo = 1;

                itens.length >= tamanhoMinimo ?
                    itens.forEach(item => {
                        const id = item.getBindingContext(NOME_DO_MODELO_RECEITA).getProperty(PROPRIEDADE_ID);
                        const query = `${URL_API_RECEITA}/${id}`;
    
                        this._removerItem(query, SIM);
                    })
                    : MessageBox.error("Deve haver pelo menos uma receita selecionada.");
            })
        },

        _removerPocao() {
            this._processarAcao(() => {
                const tabelaPocao = this.getView().byId(ID_TABELA_POCAO);
                const itens = tabelaPocao.getSelectedItems();
                
                const tamanhoMinimo = 1;

                if (itens.length >= tamanhoMinimo) {
                    itens.forEach(item => {
                        const id = item.getBindingContext(NOME_DO_MODELO_POCAO).getProperty(PROPRIEDADE_ID);
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
                    if (!ehItemFilho) this.getRouter().navTo(CHAVE_DA_VIEW_LISTAGEM_INGREDIENTE, {}, true);    
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
                    let id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty(PROPRIEDADE_ID);
    
                    if (id === parseInt(ID_INGREDIENTE_EDITADO))
                        tabela.setSelectedItem(item);
                });
            });
        },

        _cadastrarReceita(nome, validade, valor, descricao) {
            this._processarAcao(() => {
                const nomeIngredienteDetalhado = this.getView().getModel(NOME_DO_MODELO_INGREDIENTE).getData().nome;
                const itensSelecionados = this.getView().byId(ID_TABELA_INGREDIENTE_DIALOGO_RECEITA).getSelectedItems();
                const requisicao = BOTAO_PRECIONADO === PROPRIEDADE_ADICIONAR ? REQUISICAO_POST : REQUISICAO_PATCH;

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
                    const id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty(PROPRIEDADE_ID);
    
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
                const listaIngredientes = this.getView().getModel(NOME_DO_MODELO_INGREDIENTES).getData();
                const ingredientesSelecionados = [];

                let possuiItemDetalhado = false;

                itensSelecionados.map(item => {
                    const id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty(PROPRIEDADE_ID);
                    
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

                    url.includes(ITEM_DO_SELECT_RECEITAS) ? 
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
                this.getRouter().getRoute(CHAVE_VIEW_DETALHES_INGREDIENTE).attachPatternMatched((oEvent) => {
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
                const id = item.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty(PROPRIEDADE_ID);

                listaIdIngrediente.map((idIngrediente) => {
                    if (id === idIngrediente)
                        tabela.setSelectedItem(item);
                })
            });
        },

        _limparResquicios(){
            const idFiltroNome = "filtroNome";
            this.getView().byId(idFiltroNome).setValue(STRING_VAZIA);
            this.getView().byId(ID_SELECT_FILHOS).setSelectedKey(ITEM_DO_SELECT_RECEITAS);
            this.getView().byId(ID_MENSSAGE_STRIP_SUCESSO).setVisible(NAO);
            this.aoClicarApresentarListagemFilhoRequerido();
        },

        _obterParametro(oEvent) {
            ID_INGREDIENTE_EDITADO = oEvent.getParameter(PROPRIEDADE_ARGUMENTOS).id;
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
                        if (urlApi.includes(ITEM_DO_SELECT_RECEITAS)){
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