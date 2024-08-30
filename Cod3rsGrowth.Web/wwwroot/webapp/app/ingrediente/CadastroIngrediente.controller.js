sap.ui.define([
    "coders-growth/app/common/BaseController",
    "coders-growth/app/model/Formatter",
    "coders-growth/app/model/Validators",
    "sap/m/MessageBox",
    "sap/ui/model/json/JSONModel",
], function (BaseController, Formatter, Validators, MessageBox, JSONModel) {
    "use strict";

    const URL_API = "https://localhost:7224/api/Ingredientes";    
    const ID_INPUT_NOME = "inputNome";
    const ID_INPUT_QUANTIDADE = "inputQuantidade";
    const ID_INPUT_NATURALIDADE = "inputNaturalidade";
    const ROTA_CADASTRO = "appCadastroIngrediente";
    const REQUISICAO_POST = "POST";
    const REQUISICAO_PATCH = "PATCH";
    const ID_MENSSAGE_STRIP_SUCESSO = "successMessageStrip";
    const ID_MENSSAGE_STRIP_ERRO = "errorMessageStrip";
    const ID_BOTAO_SALVAR = "saveButton";
    const NOME_DO_MODELO_ENUM = "enum";
    const STRING_VAZIA = "";
    const VISIVEL = true;
    const NAO_VISIVEL = false;    

    var ID_INGREDIENTE_EDITADO;

    return BaseController.extend("coders-growth.app.ingrediente.CadastroIngrediente", {
        onInit(){
            this._aoCoincidirRota();
        },

        aoAlterarNome(){
            this._processarAcao(() =>{
                const inputNome = this.getView().byId(ID_INPUT_NOME);       

                Validators.ValidarNome(inputNome);
            });
        },
        
        aoAlterarQuantidade(){
            this._processarAcao(() => {
                const inputQuantidade = this.getView().byId(ID_INPUT_QUANTIDADE);
                const label = "Quantidade";

                Validators.ValidarNumeros(inputQuantidade, label);
            });
        },

        aoClicarCadastrarIngrediente(){
            this._processarAcao(() => {
                const inputNome = this.getView().byId(ID_INPUT_NOME);
                const inputQuantidade = this.getView().byId(ID_INPUT_QUANTIDADE);
                const naturalidade = this.getView().byId(ID_INPUT_NATURALIDADE).getSelectedItem().getText();
                const nome = inputNome.getValue();
                const quantidade = inputQuantidade.getValue();
                const ehValido = Validators.ValidarIngrediente(inputNome, inputQuantidade);

                if (ehValido) {
                    const oIngrediente = {
                        Nome: nome,
                        Quantidade: quantidade,
                        Naturalidade: Formatter.formatarNaturalidadeParaInteiro(naturalidade)
                    };
                
                    const requisicao = ID_INGREDIENTE_EDITADO ? REQUISICAO_PATCH : REQUISICAO_POST;
                    
                    if (ID_INGREDIENTE_EDITADO !== undefined) {
                        oIngrediente.Id = ID_INGREDIENTE_EDITADO;
                    }
                
                    this._requistarApi(URL_API, oIngrediente, requisicao);
                } else {
                    this._toggleMessageStrips(VISIVEL, NAO_VISIVEL);
                }
            });
        },

        _toggleMessageStrips(erroVisivel, sucessoVisivel) {
            this.getView().byId(ID_MENSSAGE_STRIP_ERRO).setVisible(erroVisivel);
            this.getView().byId(ID_MENSSAGE_STRIP_SUCESSO).setVisible(sucessoVisivel);
        },

        _aoCoincidirRota() {
            this._processarAcao(() => {
                const nao = false;

                this.getRouter().getRoute(ROTA_CADASTRO).attachPatternMatched((oEvent) => {
                    this._limparResquisiosDeCadastro();
                    this._regatarIdPelaUrl(oEvent);
                    this._carregarEnumNaturalidade(URL_API, NOME_DO_MODELO_ENUM, nao);
                    this._obterPorId(URL_API);
                }, this);
            });
        },

        _limparResquisiosDeCadastro() {
            this._processarAcao(() => {
                const inputNome = this.getView().byId(ID_INPUT_NOME);
                const inputQuantidade = this.getView().byId(ID_INPUT_QUANTIDADE);
                const selectNaturalidade = this.getView().byId(ID_INPUT_NATURALIDADE);
                
                const iconeSalvo = "sap-icon://save";
                const chaveOverWorld = "OverWorld";
        
                this._toggleMessageStrips(NAO_VISIVEL, NAO_VISIVEL);
                this.getView().byId(ID_BOTAO_SALVAR).setIcon(iconeSalvo);
                inputNome.setValueState(sap.ui.core.ValueState.None);
                inputQuantidade.setValueState(sap.ui.core.ValueState.None);
                inputNome.setValue(STRING_VAZIA);
                inputQuantidade.setValue(STRING_VAZIA);
        
                selectNaturalidade.getItems().forEach(item => {
                    if (item.getKey() === chaveOverWorld) {
                        selectNaturalidade.setSelectedItem(item);
                    }
                });
            });
        },

        _regatarIdPelaUrl(oEvent){
            this._processarAcao(() => {
                ID_INGREDIENTE_EDITADO = oEvent.getParameter("arguments").id;
            })
        },

        _obterPorId(urlApi) {
            this._processarAcao(() => {
                this._showBusyIndicator();

                if (ID_INGREDIENTE_EDITADO){
                    const query = `${urlApi}/${ID_INGREDIENTE_EDITADO}`;

                    fetch(query)
                        .then(resp => resp.json())
                        .then(data => {
                            data.Detail ? 
                                this._erroNaRequisicaoDaApi(data)
                                : this._inserirDadosDeEdicao(data)
                        })
                        .catch((err) => MessageBox.error(err.message))
                        .finally(() => this._hideBusyIndicator());
                }
            })
        },

        _inserirDadosDeEdicao(ingrediente){
            this._processarAcao(() => {
                const oSelect = this.getView().byId(ID_INPUT_NATURALIDADE);

                this.getView().byId(ID_INPUT_NOME).setValue(ingrediente.nome);
                this.getView().byId(ID_INPUT_QUANTIDADE).setValue(ingrediente.quantidade);

                oSelect.getItems().map((item) => {
                    if (item.getKey() == Formatter.formatarNaturalidadeParaString(ingrediente.naturalidade)){
                        oSelect.setSelectedItem(item);
                    }
                });
            })
        },
        
        _requistarApi(urlApi, ingrediente, requisicao){
            this._processarAcao(() => {
                this._showBusyIndicator();
                const iconeCompleto = "sap-icon://complete";

                fetch(urlApi, {
                    method: requisicao,
                    body: JSON.stringify(ingrediente),
                    headers: { "Content-type": "application/json; charset=UTF-8" }
                })
                .then(resp => resp.json())
                .then(data => {
                    data.Detail ? 
                        this._erroNaRequisicaoDaApi(data)
                        : (
                            this.getView().byId(ID_BOTAO_SALVAR).setIcon(iconeCompleto),
                            this._toggleMessageStrips(NAO_VISIVEL, VISIVEL)
                        ) 
                })
                .catch(err => MessageBox.error(err.message))
                .finally(() => this._hideBusyIndicator());
            })
        },
    }) 
});