<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroCoordenador.aspx.cs" Inherits="WebApplication1.CadastroCoordenador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container mt-5">
    
    <div class="card shadow-sm border-2">
        <div class="card-header border-3 bg-primary text-white">
            <h3 class="mb-3">Cadastro coordenador (Semana 1)</h3>
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
                    titulação
                </label>
                <asp:DropDownList ID="ddltitulacao" runat="server" CssClass="form-control">
     <asp:ListItem Text="selecione sua titulção" Value="">

     </asp:ListItem>

    <asp:ListItem Text="Graduação" Value="Graduação">

    </asp:ListItem>

    <asp:ListItem Text="Especialização" Value="Especialização">

    </asp:ListItem>

    <asp:ListItem Text="Mestrado" Value="Mestrado">

    </asp:ListItem>

    <asp:ListItem Text="Doutorado" Value="Doutorado">

    </asp:ListItem>

    <asp:ListItem Text="Pós-Doutorado" Value="Pós-Doutorado">

    </asp:ListItem>
                    
</asp:DropDownList>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    area de atuação
                </label>
                <asp:TextBox ID="txtareadeatuacao" runat="server" CssClass="form-control" placeholder="sua area de atuação">
                </asp:TextBox>
            </div>
               
            <div class="form-group mb-3">
                <label class="form-group font-weight-bold">
                    Email
                </label>
                <asp:TextBox ID="txtemail" runat="server" CssClass="form-control" placeholder="seu Email">
</asp:TextBox>
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
            <asp:Panel ID="botoes" runat="server">
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
               placeholder="Ex.: João, Mestrado, Doutorado...">
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
                 </div>
            </asp:Panel>
             
                  <asp:Button ID="btn_ordenar" runat="server" CssClass="btn btn_ligth btn-lg w-100 border border-secondary border-2 mt-3" Text="ordem alfabetica" />
                  <asp:Button ID="btn_desfazer_alteracoes" runat="server" CssClass="btn btn-secondary btn-lg w-100 mt-3" Style="background-color:#cc6666; border-color:#cc6666; color:white" Text="desfazer alterações"/>

              
              
              <hr />
    <div class="table-responsive shadow rounded">
        <asp:GridView ID="gvcoordenador" runat="server"
            AutoGenerateColumns="true"
            CssClass="table table-striped table-hover table-bordered mb-0 align-middle">
        </asp:GridView>
    </div>
    
</div>
</div>
</asp:Content>
