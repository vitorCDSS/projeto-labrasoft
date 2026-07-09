<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroBolsista.aspx.cs" Inherits="WebApplication1.CadastroBolsista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    
    <div class="card shadow-sm border-2">
        <div class="card-header border-3 bg-primary text-white">
            <h3 class="mb-3">Cadastro bolsista (Semana 1)</h3>
        </div>
        
        <div class="card-body bg-light">
            <h5 class="card-title text-muted mb-3">Preencha suas informações:</h5>
            <hr />
            
            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    nome
                </label>
                <asp:TextBox ID="txtnome" runat="server" CssClass="form-control" placeholder="digite seu nome">
                </asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    cpf
                </label>
                <asp:TextBox ID="txtcpf" runat="server" CssClass="form-control" placeholder="digite seu cpf">
                </asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    matrícula
                </label>
                <asp:TextBox ID="txtmatricula" runat="server" CssClass="form-control" placeholder="sua matrícula">
                </asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    data de nascimento
                </label>
                <asp:TextBox ID="txtdata" runat="server" TextMode="Date" CssClass="form-control" placeholder="data de nascimento">
                </asp:TextBox>
            </div>
               
            <div class="form-group mb-3">
                <label class="form-group font-weight-bold">
                    sexo
                </label>
                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                     <asp:ListItem Text="selecione seu genero" Value="">

                     </asp:ListItem>

                    <asp:ListItem Text="masculino" Value="Masculino">

                    </asp:ListItem>

                    <asp:ListItem Text="feminino" Value="Feminino">

                    </asp:ListItem>

                    <asp:ListItem Text="outro" Value="Outro">

                    </asp:ListItem>
                </asp:DropDownList>
            </div>
            <hr />
            <div class="mb-3 d-grid gap-2">
                <asp:Button ID="btn_salvar" runat="server" CssClass="btn btn-success btn-lg w-100" Text="concluir" OnClick="Btn_salvar" />
                <asp:Button ID="btn_limpar" runat="server" CssClass="btn btn-lg w-100" Style="background-color:#cc6666; border-color:#cc6666; color:white;" Text="desfazer formulário" OnClick="Btn_Limpar" />
            </div>
            
            
        </div>
     
    </div>   
                        <asp:Label ID="lblMensagem" runat="server" CssClass="h6">
</asp:Label>
          <div class="mt-5">
                
    <div class="card-body bg-ligth mb-3 d-grid gap-2">
    <h3 class="card-title text-dark mb-3">bolsistas já cadastrados:</h3>
    </div>
    <hr />
    <div class="table-responsive shadow rounded">
        <asp:GridView ID="gvAlunos" runat="server"
            AutoGenerateColumns="true"
            CssClass="table table-striped table-hover table-bordered mb-0 align-middle">
        </asp:GridView>
    </div>
    
</div>
</div>
</asp:Content>
