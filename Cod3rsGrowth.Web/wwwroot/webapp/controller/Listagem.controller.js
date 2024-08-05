sap.ui.define([
    "coders-growth/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "coders-growth/model/Formatter",
    "sap/m/MessageBox"
 ], function (BaseController,JSONModel, Formatter, MessageBox) {
    "use strict";

    const URL_API = "https://localhost:7224/api/Ingredientes";
    const NOME_DO_MODELO = "ingrediente";
    const NOME_DO_MODELO_IMG = "img";
    const ID_INPUT_NOME = "filtroNome";
    const ID_INPUT_QUANTIDADE = "filtroQuantidade";
    const ID_INPUT_NATURALIDADE = "filtroNaturalidade";
    const FLAG_PARA_FILTROAGEM_NULA = "Todos";
    const CHAVE_VIEW_CADASTRAR_INGREDIENTE = "appCadastroIngrediente";
    const CHAVE_VIEW_DETALHES_INGREDIENTE = "appDetalhesIngrediente";
    const ROTA_LISTAGEM = "appListagem";
    const PROPERTY_ID = "id";
    
    return BaseController.extend("coders-growth.controller.Listagem", {
        formatter: Formatter,

        onInit(){
            this._aoCoincidirRota();
        },

        aoAlterarFiltrar(){
            let query = URL_API + "?";

            this._processarAcao(() => {
                const filtroNome = this.oView.byId(ID_INPUT_NOME).getValue();
                const filtroQuantidade = this.oView.byId(ID_INPUT_QUANTIDADE).getValue();
                const filtroNaturalidade = this.oView.byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();
    
                if (filtroNome)
                    query += "Nome="+filtroNome+"&";
                
                if (filtroQuantidade)
                    query += "Quantidade="+filtroQuantidade+"&";
    
                if (filtroNaturalidade != FLAG_PARA_FILTROAGEM_NULA)
                    query += "Naturalidade="+filtroNaturalidade;
            });
            this._carregarDados(query, NOME_DO_MODELO);
        },

        aoClicarIrParaCadastro() {
            this.getRouter().navTo(CHAVE_VIEW_CADASTRAR_INGREDIENTE, {}, true);
        },

        aoClicarIrParaDetalhes(oEvent) {
            const oItem = oEvent.getSource();
            const oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo(CHAVE_VIEW_DETALHES_INGREDIENTE, {
                id: window.encodeURIComponent(oItem.getBindingContext(NOME_DO_MODELO).getProperty(PROPERTY_ID))
            });
        },

        _aoCoincidirRota: function () {
            this._processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_LISTAGEM).attachPatternMatched(() => {
                    this._carregarDados(URL_API, NOME_DO_MODELO);
                    this._carregarImagens(NOME_DO_MODELO_IMG);
                }, this);
            });
        },

        _carregarDados(query, nomeDoModelo){
            let sucesso = true;
            fetch(query)
                .then(response => {
                    if (!response.ok) 
                        sucesso = false;
                    
                    return response.json();
                })
                .then((data) => {
                    if  (!sucesso) {
                        throw {
                            rfc: data,
                            error: new Error()
                        }
                    }
                        
                    this.getView().setModel(new JSONModel(data), nomeDoModelo)   
                })
                .catch((err) => {
                    // Em andamento....
                    console.log(err.rfc)
                    const mensagemErroPrincipal = err.rfc.Extensions.Erros.join(', ');
                    const mensagemErroCompleta = `${err.rfc.Title}\nStatus: ${err.rfc.Status}\n${err.rfc.Detail}\nErros: `;
                    console.log(mensagemErroCompleta)
                    MessageBox.error(mensagemErroPrincipal, {
                        actions: [MessageBox.Action.OK, MessageBox.Action.CLOSE, MessageBox.Action.DETAILS],
                        onClose: function(sAction) {
                            if (sAction === MessageBox.Action.DETAILS) {
                                const dialog = new Dialog({
                                    title: 'Detalhes do Erro',
                                    content: new Text({ text: mensagemErroCompleta }),
                                    beginButton: new Button({
                                        text: 'Fechar',
                                        press: function () {
                                            dialog.close();
                                        }
                                    }),
                                    afterClose: function() {
                                        dialog.destroy();
                                    }
                                });
                                dialog.open();
                            }
                        }
                    });
                });
        },

        _carregarImagens(nomeDoModelo) {
            const caminhoDoDiretorioImagems = "coders-growth/images/overworld_block.png";
            const imgSrc = sap.ui.require.toUrl(caminhoDoDiretorioImagems);
        
            const oImgModel = new sap.ui.model.json.JSONModel({
                imageSrc: imgSrc
            });

            this.getView().setModel(oImgModel, nomeDoModelo);
        }
    });
});