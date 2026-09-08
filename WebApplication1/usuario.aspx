<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="usuario1.aspx.cs" Inherits="WebApplication1.usuario1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-5">

```
<div class="card shadow-lg border-0 rounded-4">

    <!-- CABEÇALHO -->
    <div class="card-header bg-primary text-white rounded-top-4">

        <h3 class="mb-0">
            <i class="bi bi-person-circle"></i>
            Conta de usuário
        </h3>

    </div>


    <!-- CORPO -->
    <div class="card-body bg-light">

        <!-- BOTÕES PARA TROCAR ENTRE LOGIN E CADASTRO -->

        <div class="d-grid gap-2 d-md-flex mb-4">

            <asp:Button
                ID="btnLogin"
                runat="server"
                CssClass="btn btn-primary flex-fill"
                Text="Entrar"
                OnClick="btnLogin_Click" />

            <asp:Button
                ID="btnCadastro"
                runat="server"
                CssClass="btn btn-outline-primary flex-fill"
                Text="Criar conta"
                OnClick="btnCadastro_Click" />

        </div>


        <asp:MultiView
            ID="mvLoginCadastro"
            runat="server"
            ActiveViewIndex="0">


            <!-- ========================= -->
            <!-- LOGIN -->
            <!-- ========================= -->

            <asp:View
                ID="viewLogin"
                runat="server">

                <h5 class="card-title text-muted mb-3">
                    Entre na sua conta
                </h5>

                <hr />


                <!-- EMAIL -->

                <div class="form-group mb-3">

                    <label class="form-label fw-bold">
                        E-mail
                    </label>

                    <asp:TextBox
                        ID="txtEmailLogin"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Digite seu e-mail">
                    </asp:TextBox>

                </div>


                <!-- SENHA -->

                <div class="form-group mb-3">

                    <label class="form-label fw-bold">
                        Senha
                    </label>

                    <asp:TextBox
                        ID="txtSenhaLogin"
                        runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        placeholder="Digite sua senha">
                    </asp:TextBox>

                </div>


                <hr />


                <!-- BOTÃO ENTRAR -->

                <div class="d-grid">

                    <asp:Button
                        ID="btnEntrar"
                        runat="server"
                        CssClass="btn btn-success btn-lg rounded-3 shadow-sm"
                        Text="Entrar"
                        OnClick="Btn_Entrar" />

                </div>

            </asp:View>



            <!-- ========================= -->
            <!-- CADASTRO -->
            <!-- ========================= -->

            <asp:View
                ID="viewCadastro"
                runat="server">

                <h5 class="card-title text-muted mb-3">
                    Crie sua conta
                </h5>

                <hr />


                <!-- NOME -->

                <div class="form-group mb-3">

                    <label class="form-label fw-bold">
                        Nome
                    </label>

                    <asp:TextBox
                        ID="txtnomeusuario"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Digite seu nome">
                    </asp:TextBox>

                </div>


                <!-- EMAIL -->

                <div class="form-group mb-3">

                    <label class="form-label fw-bold">
                        E-mail
                    </label>

                    <asp:TextBox
                        ID="txtemail"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Digite seu e-mail">
                    </asp:TextBox>

                </div>


                <!-- SENHA -->

                <div class="form-group mb-3">

                    <label class="form-label fw-bold">
                        Senha
                    </label>

                    <asp:TextBox
                        ID="txtsenha"
                        runat="server"
                        TextMode="Password"
                        CssClass="form-control"
                        placeholder="Digite sua senha">
                    </asp:TextBox>

                </div>


                <hr />


                <!-- BOTÃO CADASTRAR -->

                <div class="mb-3 d-grid">

                    <asp:Button
                        ID="btn_salvar"
                        runat="server"
                        CssClass="btn btn-success btn-lg rounded-3 shadow-sm"
                        Text="Concluir cadastro"
                        OnClick="Btn_salvar" />

                </div>

            </asp:View>

        </asp:MultiView>


    </div>

</div>


<!-- MENSAGEM -->

<div class="mt-3">

    <asp:Label
        ID="lblMensagem"
        runat="server"
        CssClass="h6">
    </asp:Label>

</div>
```

</div>

</asp:Content>
