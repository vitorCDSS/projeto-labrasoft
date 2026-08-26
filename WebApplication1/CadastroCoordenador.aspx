<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCoordenador.aspx.cs" Inherits="WebApplication1.CadastroCoordenador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-5">


    <div class="card shadow-lg border-0 rounded-4">

        <div class="card-header bg-primary text-white rounded-top-4">
            <h3 class="mb-0">
                <i class="bi bi-person-badge"></i>
                Cadastro de Coordenadores
            </h3>
        </div>


        <div class="card-body bg-light">

            <h5 class="card-title text-muted mb-3">
                Informações do coordenador:
            </h5>

            <hr />


            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    Nome
                </label>

                <asp:TextBox 
                    ID="txtnome" 
                    runat="server"
                    CssClass="form-control"
                    placeholder="Digite seu nome">
                </asp:TextBox>

            </div>


            <div class="form-group mb-3">

                <label class="form-label font-weight-bold">
                    CPF
                </label>

                <asp:TextBox
                    ID="txtcpf"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Digite seu CPF">
                </asp:TextBox>

            </div>



            <div class="form-group mb-3">

                <label class="form-label font-weight-bold">
                    Titulação
                </label>


                <asp:DropDownList
                    ID="ddltitulacao"
                    runat="server"
                    CssClass="form-control">

                    <asp:ListItem Text="Selecione sua titulação" Value="" />
                    <asp:ListItem Text="Graduação" Value="Graduação" />
                    <asp:ListItem Text="Especialização" Value="Especialização" />
                    <asp:ListItem Text="Mestrado" Value="Mestrado" />
                    <asp:ListItem Text="Doutorado" Value="Doutorado" />
                    <asp:ListItem Text="Pós-Doutorado" Value="Pós-Doutorado" />

                </asp:DropDownList>

            </div>



            <div class="form-group mb-3">

                <label class="form-label font-weight-bold">
                    Área de atuação
                </label>


                <asp:TextBox
                    ID="txtareadeatuacao"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Sua área de atuação">
                </asp:TextBox>

            </div>



            <div class="form-group mb-3">

                <label class="form-label font-weight-bold">
                    Email
                </label>


                <asp:TextBox
                    ID="txtemail"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Seu email">
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
                        Buscar por nome ou titulação
                    </label>


                    <asp:TextBox
                        ID="txtFiltro"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Ex.: João, Mestrado...">
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
                Text="Ordem alfabética" />



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
            ID="gvcoordenador"
            runat="server"
            AutoGenerateColumns="false"
            OnRowCommand="gvcoordenador_RowCommand"
            CssClass="table table-hover align-middle mt-3 shadow-sm"
            HeaderStyle-CssClass="table-primary">

                <Columns>

                    <asp:BoundField DataField="Nome" HeaderText="Nome" />
                    <asp:BoundField DataField="CPF" HeaderText="CPF" />
                    <asp:BoundField DataField="Titulacao" HeaderText="Titulacao" />
                    <asp:BoundField DataField="AreaAtuacao" HeaderText="AreaAtuacao" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />

                    <asp:TemplateField HeaderText="editar coordenador">
                        <ItemTemplate>
                            <asp:Button 
                                ID="btnEditar"
                                runat="server"
                                Text="Editar"
                                CommandName="Editar"
                                CommandArgument="<%# Container.DataItemIndex %>"
                                CssClass="btn btn-primary btn-sm rounded-pill px-3" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

        </asp:GridView>

                        <asp:Panel ID="pnlEditar" runat="server" Visible="false" CssClass="card mt-3 p-3">

            <asp:HiddenField ID="hfCpfOriginal" runat="server" />

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">Nome</label>
                <asp:TextBox ID="txtEditNome" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">CPF</label>
                <asp:TextBox ID="txtEditCpf" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">Titulação</label>
                <asp:DropDownList ID="ddlEditTitulacao" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Graduação" Value="Graduação" />
                    <asp:ListItem Text="Especialização" Value="Especialização" />
                    <asp:ListItem Text="Mestrado" Value="Mestrado" />
                    <asp:ListItem Text="Doutorado" Value="Doutorado" />
                    <asp:ListItem Text="Pós-Doutorado" Value="Pós-Doutorado" />
                </asp:DropDownList>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">Área de atuação</label>
                <asp:TextBox ID="txtEditArea" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">Email</label>
                <asp:TextBox ID="txtEditEmail" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <asp:Button
                ID="btnFinalizarEdicao"
                runat="server"
                Text="Finalizar edição"
                OnClick="btnFinalizarEdicao_Click"
                CssClass="btn btn-outline-secondary rounded-pill px-4 mb-3" />

            <asp:Button
                ID="btnDesfazerEdicao"
                runat="server"
                Text="Desfazer edição"
                OnClick="btnDesfazerEdicao_Click"
                CssClass="btn btn-outline-danger rounded-pill px-4" />
        </asp:Panel>

    </div>


</div>

</asp:Content>