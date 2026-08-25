<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroDespesa.aspx.cs" Inherits="WebApplication1.CadastroDespesa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-5">

    <div class="card shadow-lg border-0 rounded-4">

        <div class="card-header bg-primary text-white rounded-top-4">
            <h3 class="mb-0">
                <i class="bi bi-cash-coin"></i>
                Cadastro de Despesas
            </h3>
        </div>

        <div class="card-body bg-light">

            <h5 class="card-title text-muted mb-3">
                Informações da despesa:
            </h5>

            <hr />

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    Descrição
                </label>

                <asp:TextBox 
                    ID="txtdescricao" 
                    runat="server"
                    CssClass="form-control"
                    placeholder="Descreva a despesa">
                </asp:TextBox>

            </div>

            <div class="form-group mb-3">

                <label class="form-label font-weight-bold">
                    Valor
                </label>

                <asp:TextBox
                    ID="txtvalor"
                    runat="server"
                    CssClass="form-control"
                    TextMode="Number"
                    placeholder="0,00">
                </asp:TextBox>

            </div>

            <div class="form-group mb-3">

                <label class="form-label font-weight-bold">
                    Categoria
                </label>

                <asp:DropDownList
                    ID="ddlcategoria"
                    runat="server"
                    CssClass="form-control">

                    <asp:ListItem Text="Selecione a categoria" Value="" />
                    <asp:ListItem Text="Material" Value="Material" />
                    <asp:ListItem Text="Transporte" Value="Transporte" />
                    <asp:ListItem Text="Serviços" Value="Serviços" />
                    <asp:ListItem Text="Equipamento" Value="Equipamento" />
                    <asp:ListItem Text="Outros" Value="Outros" />

                </asp:DropDownList>

            </div>

            <div class="form-group mb-3">

                <label class="form-label font-weight-bold">
                    Projeto (ID)
                </label>

                <asp:TextBox
                    ID="txtprojetoid"
                    runat="server"
                    CssClass="form-control"
                    TextMode="Number"
                    placeholder="ID do projeto">
                </asp:TextBox>

            </div>

            <hr />

            <div class="mb-3 d-grid gap-2">

                <asp:Button
                    ID="btn_salvar"
                    runat="server"
                    CssClass="btn btn-success btn-lg w-100 rounded-3 shadow-sm"
                    Text="Concluir"
                    OnClick="Btn_salvar" />

                <asp:Button
                    ID="btn_limpar"
                    runat="server"
                    CssClass="btn btn-danger btn-lg w-100 rounded-3 shadow-sm"
                    Text="Desfazer formulário"
                    OnClick="Btn_Limpar" />

            </div>

        </div>

    </div>

    <asp:Label 
        ID="lblMensagem"
        runat="server"
        CssClass="h6">
    </asp:Label>

    <asp:Panel 
        ID="botoes"
        runat="server">

        <hr />

        <div class="mt-5">

            <div class="row align-items-end g-2 mb-3">

                <div class="col-md-9">

                    <label class="form-label fw-bold">
                        Buscar por descrição ou categoria
                    </label>

                    <asp:TextBox
                        ID="txtFiltro"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Ex.: transporte, material...">
                    </asp:TextBox>

                </div>

                <div class="col-md-3 d-grid">

                    <asp:Button
                        ID="btn_filtrar"
                        runat="server"
                        CssClass="btn btn-primary"
                        Text="🔍 Filtrar"
                        OnClick="Btn_Filtrar" />

                </div>

            </div>

            <asp:Button
                ID="btn_ordenar"
                runat="server"
                CssClass="btn btn-outline-primary btn-lg w-100 mt-3"
                Text="Ordenar por valor" />

            <asp:Button
                ID="btn_desfazer_alteracoes"
                runat="server"
                CssClass="btn btn-danger btn-lg w-100 mt-3"
                Text="Desfazer alterações" />

            <hr />

        </div>

    </asp:Panel>

    <div class="table-responsive shadow rounded">

        <asp:GridView
            ID="gvdespesas"
            runat="server"
            AutoGenerateColumns="true"
            CssClass="table table-hover align-middle mt-3 shadow-sm"
            HeaderStyle-CssClass="table-primary">

        </asp:GridView>

    </div>

</div>

</asp:Content>
