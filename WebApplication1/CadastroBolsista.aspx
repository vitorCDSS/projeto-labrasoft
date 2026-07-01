<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroBolsista.aspx.cs" Inherits="WebApplication1.CadastroBolsista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
    
    <div class="card shadow-sm">
        <div class="card-header bg-primary text-white">
            <h3 class="mb-0">Cadastro bolsista (Semana 1)</h3>
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

                    <asp:ListItem Text="masculino" Value="M">

                    </asp:ListItem>

                    <asp:ListItem Text="feminino" Value="F">

                    </asp:ListItem>

                    <asp:ListItem Text="outro" Value="O">

                    </asp:ListItem>
                </asp:DropDownList>
            </div>
            <hr />
            <asp:Button ID="btn_salvar" runat="server" CssClass="btn btn-success btn-lg w-100" Text="concluir" OnClick="Btn_salvar" />
            <asp:Label ID="lblMensagem" runat="server" CssClass="h6">

            </asp:Label>


        </div>
  
    </div>        
</div>
</asp:Content>
