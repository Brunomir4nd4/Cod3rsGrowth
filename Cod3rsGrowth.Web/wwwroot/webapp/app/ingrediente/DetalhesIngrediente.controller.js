sap.ui.define([
    "coders-growth/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/app/model/Formatter",
    "sap/m/MessageBox"
], function(BaseController, JSONModel, Formatter, MessageBox) {
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
    const PROPRIEDADE_ID = "id";
    const ARGUMENTOS_DE_PARAMETRO = "arguments";
    const METODO_DE_REQUISICAO_DELETE = "DELETE";
    const CHAVE_DA_VIEW_HOME = "appListagem";
    const ID_SELECT_FILHOS = "selectItensFilho";
    var PARAMETRO_ID;
    var RECEITAS_ASSOCIADAS = [];

    return BaseController.extend("coders-growth.app.ingrediente.DetalhesIngrediente", {
        formatter: Formatter,
        
        onInit(){
            this._aoCoincidirRota();
        },

        aoClicarIrParaCadastro() {
            this._processarAcao(() => {
                this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {}, true);
            })
        },

        aoClicarIrParaEditar(oEvent) {
            this._processarAcao(() => {
                const oItem = oEvent.getSource();
                this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {
                    id: window.encodeURIComponent(oItem.getBindingContext(NOME_DO_MODELO_INGREDIENTES).getProperty(PROPRIEDADE_ID))
                }, true);
            })
        },

        aoClicarremover(){
            const oRouter = this.getOwnerComponent().getRouter();
            MessageBox.warning("Deseja remover esse item?\nVocê não poderá retomar essa ação.", {
                actions: [ sap.m.MessageBox.Action.NO,
                    sap.m.MessageBox.Action.YES ],
                onClose: function (sAction) {
                    if (sAction === "YES") {
                        fetch(URL_API_INGREDIENTE, {
                            method: METODO_DE_REQUISICAO_DELETE,
                            body: JSON.stringify(PARAMETRO_ID),
                            headers: { "Content-type": "application/json; charset=UTF-8" }
                        })
                        .then(response => {
                            if (response.ok) {
                                sap.m.MessageToast.show("Ingrediente removido com sucesso.");
                                oRouter.navTo(CHAVE_DA_VIEW_HOME, {}, true);    
                            }
                        })
                        .catch(err => MessageBox.error(err.message));
                    }
                },
                dependentOn: this.getView()
            });
        },

        aoClicarApresentarListagemFilhoRequerido(){
            const itemFilho = this.oView.byId(ID_SELECT_FILHOS).getSelectedItem().getText();
            const itemDoSelect = "Poções";
            if (itemFilho === itemDoSelect) {
                this.getView().byId("VBoxTabelaPocao").setVisible(true);
                this.getView().byId("VBoxTabelaReceita").setVisible(false);
            } else {
                this.getView().byId("VBoxTabelaPocao").setVisible(false);
                this.getView().byId("VBoxTabelaReceita").setVisible(true);   
            }
        },

        aoProcurarFiltrarTabela(oEvent) {
            const query = URL_API_RECEITA + "?Nome=" + oEvent.mParameters.query;
            this._carregarDadosFilho(query, NOME_DO_MODELO_RECEITA);
        },

        async aoClicarAbrirModalCadastroFilho() {
            const itemFilho = this.getView().byId("selectItensFilho").getSelectedItem().getText();

            itemFilho === "Receitas" ? (
                this.oDialog ??= await this.loadFragment({
                    name: "coders-growth.app.ingrediente.fragments.DialogoCadastroReceita"
                })
            ) : (
                this.oDialog ??= await this.loadFragment({
                    name: "coders-growth.app.ingrediente.fragments.DialogoCadastroPocao"
                })
            )
        
            this.oDialog.open();
        },

        aoClicarFecharDialogo() {
            this.oDialog.close();
        },

        aoClicarSalvarAlteracoes() {
            const itemFilho = this.getView().byId("selectItensFilho").getSelectedItem().getText();

            itemFilho === "Receitas" ? this._definirReceita() : this._definirPocao(); 
        },

        _definirPocao() {
            const table = this.getView().byId("tabelaIngrediente1");
            const selectedItems = table.getSelectedItems();
            const ingredientesSelecionados = [];
        
            selectedItems.forEach(item => {
                const cells = item.getCells();
                const ingrediente = {
                    nome: cells[0].getTitle(),
                    naturalidade: cells[1].getText(),
                    quantidade: parseInt(cells[2].getNumber())
                };
                ingredientesSelecionados.push(ingrediente);
            });            
            console.log(ingredientesSelecionados)
            this._cadastrarItemFilho(URL_API_POCAO, ingredientesSelecionados);
        },

        _definirReceita() {
            const nome = this.getView().byId("inputNomeReceita").getValue();
            const descricao = this.getView().byId("inputDescricaoReceita").getValue();
            const valor =  parseFloat(this.getView().byId("inputValorReceita").getValue());
            const validade = parseInt(this.getView().byId("inputValidadeReceita").getValue());

            const table = this.getView().byId("tabelaIngrediente2");
            const selectedItems = table.getSelectedItems();
            const ingredientesSelecionados = [];
        
            selectedItems.forEach(item => {
                const id = item.getBindingContext("ingredientes").getProperty("id");
                ingredientesSelecionados.push(id);
            });  
        
            const receita = {
                nome: nome,
                descricao: descricao,
                valor: valor,
                validadeEmMeses: validade,
                listaIdIngrediente: ingredientesSelecionados,
                imagem: "string",
            }
            
            this._cadastrarItemFilho(URL_API_RECEITA, receita);
        },

        _cadastrarItemFilho(url, item) {
            this._showBusyIndicator();
            let sucesso = true;
            const visivel = true;
            const naoVisivel = false;
            fetch(url, {
                method: "POST",
                body: JSON.stringify(item),
                headers: { "Content-type": "application/json; charset=UTF-8" }
            })
            .then(response => {
                if (!response.ok) 
                    sucesso = false;
                return response.json();
            })
            .then(json => {
                console.log(json);
                sucesso ? (
                    // this.getView().byId(ID_MENSSAGE_STRIP_SECESSO).setVisible(visivel),
                    // this.getView().byId(ID_MENSSAGE_STRIP_ERRO).setVisible(naoVisivel),
                    this.oDialog.close()
                ) : this._erroNaRequisicaoDaApi(json);
            })
            .catch(err => MessageBox.error(err.message))
            .finally(() => this._hideBusyIndicator());
            
        },

        _aoCoincidirRota() {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_DETALHES).attachPatternMatched((oEvent) => {
                    this._limparResquicios();
                    this._obterPorId(oEvent);
                    this._carregarDadosFilho(URL_API_RECEITA, NOME_DO_MODELO_RECEITA);
                    this._carregarDadosIngrediente(URL_API_INGREDIENTE, NOME_DO_MODELO_INGREDIENTES, this.getView());
                }, this);
            });
        },

        _limparResquicios(){
            this.getView().byId("filtroNome").setValue("");
            this.getView().byId("selectItensFilho").setSelectedKey("Receitas");
            this.aoClicarApresentarListagemFilhoRequerido();
        },
 
        _obterPorId(oEvent) {
            this._processarAcao(() => {
                this._showBusyIndicator();
                PARAMETRO_ID = oEvent.getParameter(ARGUMENTOS_DE_PARAMETRO).id;
                const barraInvertida = "/";
                const query = URL_API_INGREDIENTE + barraInvertida + PARAMETRO_ID;
                let sucesso = true;
                fetch(query)
                .then(resp => {
                    if (!resp.ok) 
                        sucesso = false;
                    return resp.json();
                })
                .then(data => {
                    sucesso ? this.getView().setModel(new JSONModel(data), NOME_DO_MODELO_INGREDIENTE) 
                    : this._erroNaRequisicaoDaApi(data);
                })
                .catch((err) => MessageBox.error(err.message))
                .finally(() => this._hideBusyIndicator());
            })
        },

        _carregarDadosFilho(urlApi, nomeDoModelo) {
            this._showBusyIndicator();
            let sucesso = true;

            fetch(urlApi)
            .then((res) => {
                if (!res.ok)   
                    sucesso = false;
                return res.json();
            })
            .then((data) => {
                if (sucesso){
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
                if (receita.listaIdIngrediente.includes(parseInt(PARAMETRO_ID)))
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