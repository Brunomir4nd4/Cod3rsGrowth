sap.ui.define([
    "coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/model/Formatter"
 ], function (BaseController,JSONModel, Formatter) {
    "use strict";

    const URL_API = "https://localhost:7224/api/Ingredientes";
    const NOME_DO_MODELO = 'ingrediente';
    const ID_INPUT_NOME = "filtroNome";
    const ID_INPUT_QUANTIDADE = "filtroQuantidade";
    const ID_INPUT_NATURALIDADE = "filtroNaturalidade";
    const FLAG_PARA_FILTROAGEM_NULA = "Todos";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    
    return BaseController.extend("coders-growth.controller.Listagem", {
        formatter: Formatter,
        onInit(){
            this._carregarDadosDaTabela(URL_API, NOME_DO_MODELO);
        },

        aoAlterarFiltrar(){
            let query = URL_API + "?";
            const filtroNome = this.oView.byId(ID_INPUT_NOME).getValue();
            const filtroQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();
            const filtroNaturalidade = this.oView.byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();

            if (filtroNome)
                query += "Nome="+filtroNome+"&";
            
            if (filtroQuantidade)
                query += "Quantidade="+filtroQuantidade+"&";

            if (filtroNaturalidade != FLAG_PARA_FILTROAGEM_NULA)
                query += "Naturalidade="+filtroNaturalidade;

            this._carregarDadosDaTabela(query, NOME_DO_MODELO);
        },

        aoClicarIrParaCadastro() {
            this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {}, true);
        },

        _carregarDadosDaTabela(query, nomeDoModelo){
            this._configurarModelo(query, nomeDoModelo);
        },

		_configurarModelo(query, nomeDoModelo){
            fetch(query)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), nomeDoModelo))
                .catch((err) => console.error(err));
        },

    });
});