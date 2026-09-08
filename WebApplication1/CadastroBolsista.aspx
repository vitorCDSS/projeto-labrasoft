<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroBolsista.aspx.cs" Inherits="WebApplication1.CadastroBolsista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-5">


    <!-- CARD CADASTRO -->
    <div class="card shadow-lg border-0 rounded-4">

        <div class="card-header bg-primary text-white rounded-top-4">
            <h3 class="mb-0">
                <i class="bi bi-person-plus"></i>
                Cadastro de Bolsista
            </h3>
        </div>


        <div class="card-body bg-light">

            <h5 class="card-title text-muted mb-3">
                Informações do bolsista:
            </h5>

            <hr />


            <div class="form-group mb-3">
                <label class="form-label fw-bold">
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

                <label class="form-label fw-bold">
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

                <label class="form-label fw-bold">
                    Matrícula
                </label>

                <asp:TextBox 
                    ID="txtmatricula"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Digite sua matrícula">
                </asp:TextBox>

            </div>



            <div class="form-group mb-3">

                <label class="form-label fw-bold">
                    Data de nascimento
                </label>

                <asp:TextBox
                    ID="txtdata"
                    runat="server"
                    TextMode="Date"
                    CssClass="form-control">
                </asp:TextBox>

            </div>



            <div class="form-group mb-3">

                <label class="form-label fw-bold">
                    Sexo
                </label>

                <asp:DropDownList 
                    ID="ddlSexo"
                    runat="server"
                    CssClass="form-control">

                    <asp:ListItem Text="Selecione seu gênero" Value=""></asp:ListItem>

                    <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>

                    <asp:ListItem Text="Feminino" Value="F"></asp:ListItem>

                    <asp:ListItem Text="Outro" Value="O"></asp:ListItem>

                </asp:DropDownList>

            </div>



            <hr />


            <div class="mb-3 d-grid gap-2">

                <asp:Button 
                    ID="btn_salvar"
                    runat="server"
                    CssClass="btn btn-success btn-lg rounded-3 shadow-sm"
                    Text="Concluir cadastro"
                    OnClick="Btn_salvar" />


                <asp:Button
                    ID="btn_limpar"
                    runat="server"
                    CssClass="btn btn-danger btn-lg rounded-3 shadow-sm"
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



    <!-- ÁREA DA LISTA -->

    <div class="mt-5">


        <asp:Panel 
            ID="botoes"
            runat="server">


            <div class="card shadow-sm border-0 rounded-4">


                <div class="card-body bg-light">


                    <h3 class="text-dark mb-4">
                        Bolsistas cadastrados
                    </h3>



                    <!-- PESQUISA -->

                    <div class="row align-items-end g-2 mb-3">


                        <div class="col-md-9">

                            <label class="form-label fw-bold">
                                Buscar por nome ou matrícula
                            </label>


                            <asp:TextBox
                                ID="txtFiltro"
                                runat="server"
                                CssClass="form-control"
                                placeholder="Ex.: João, 2024001...">
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
                        CssClass="btn btn-outline-primary btn-lg w-100 mt-2"
                        Text="Ordem alfabética"
                        OnClick="Btn_Ordenar" />



                    <asp:Button
                        ID="btn_desfazer_alteracoes"
                        runat="server"
                        CssClass="btn btn-danger btn-lg w-100 mt-3"
                        Text="Desfazer alterações"
                        OnClick="Btn_Desfazer_Alteracoes" />



                </div>


            </div>


        </asp:Panel>



        <hr />



        <!-- TABELA -->

        <div class="table-responsive shadow rounded">


            <asp:GridView 
                ID="gvAlunos"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-hover align-middle mt-3 shadow-sm"
                HeaderStyle-CssClass="table-primary">

            <Columns>
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                <asp:BoundField DataField="DataNascimento" HeaderText="Data de Nascimento" />
                <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
            </Columns>
                
            </asp:GridView>


        </div>



    </div>


</div>

</asp:Content>