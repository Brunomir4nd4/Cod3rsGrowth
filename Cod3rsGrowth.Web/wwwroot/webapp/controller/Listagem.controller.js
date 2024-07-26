sap.ui.define([
    "coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/model/Formatter"
 ], function (BaseController, JSONModel, Formatter) {
    "use strict";

    const URL_DA_API = "https://localhost:7224/api/Ingredientes";
    const NOME_DO_MODELO = 'ingrediente';
    const ID_INPUT_NOME = "filtroNome";
    const ID_INPUT_QUANTIDADE = "filtroQuantidade";
    const ID_INPUT_NATURALIDADE = "filtroNaturalidade";
    const FLAG_PARA_FILTROAGEM_NULA = "Todos";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastrarIngrediente";
    
    return BaseController.extend("coders-growth.controller.Listagem", {
        formatter: Formatter,
        onInit(){
            fetch(URL_DA_API)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), NOME_DO_MODELO))
                .catch((err) => console.error(err));
        },

        aoAlterarFiltrar(){
            let urlComFiltros = "https://localhost:7224/api/Ingredientes?";
            const filtroNome = this.oView.byId(ID_INPUT_NOME).getValue();
            const filtroQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();
            const filtroNaturalidade = this.oView.byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();

            if (filtroNome)
                urlComFiltros += "Nome="+filtroNome+"&";
            
            if (filtroQuantidade)
                urlComFiltros += "Quantidade="+filtroQuantidade+"&";

            if (filtroNaturalidade != FLAG_PARA_FILTROAGEM_NULA)
                urlComFiltros += "Naturalidade="+filtroNaturalidade;

            fetch(urlComFiltros)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), NOME_DO_MODELO))
                .catch((err) => console.error(err));
        },

        aoClicarIrParaCadastro() {
            this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {}, true);
        }
    });
});