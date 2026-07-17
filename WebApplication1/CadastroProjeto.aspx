<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroProjeto.aspx.cs" Inherits="WebApplication1.CadastroProjeto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container mt-5">
               
    
    <div class="card shadow-sm border-2">
        <div class="card-header border-3 bg-primary text-white">
            <h3 class="mb-3">Criação de projetos</h3>
        </div>
        
        <div class="card-body bg-light">
            <h5 class="card-title text-muted mb-3">Informações do projeto:</h5>
            <hr />
            
            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    titulo
                </label>
                <asp:TextBox ID="txttitulo" runat="server" CssClass="form-control" placeholder="nome do projeto">
                </asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    verba aprovada
                </label>
                <asp:TextBox ID="txtverba" runat="server" CssClass="form-control" placeholder="verba do projeto">
                </asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    valor da bolsa
                </label>
                <asp:TextBox ID="txtvalor" runat="server" CssClass="form-control" placeholder="valor da bolsa">
                </asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label class="form-label font-weight-bold">
                    area de conhecimento
                </label>
                <asp:TextBox ID="txtarea" runat="server" CssClass="form-control" placeholder="area de comhacimento">
                </asp:TextBox>
            </div>
               
            <div class="form-group mb-3">
                <label class="form-group font-weight-bold">
                    coordenador
                </label>
                <asp:DropDownList ID="ddlcoordenador" runat="server" CssClass="form-control">
                     
                </asp:DropDownList>
            </div>
            <div class="form-group mb-3">
                <label class="form-group font-weight-bold">
                    bolsistas
                </label>
               <asp:ListBox
                    ID="lstBolsistas"
                    runat="server"
                    CssClass="form-control"
                    SelectionMode="Multiple">
                </asp:ListBox>
                <div class="form-group mb-3">
    <small class="form-text text-muted">
        Segure <strong>Ctrl</strong> para selecionar mais de um bolsista.
    </small>
</div>
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
                
   
              <asp:Panel runat="server" ID="botoes">
                  <hr />
                   <div class="card-body bg-ligth mb-3 d-grid gap-2">

 </div>
                   <h3 class="card-title text-dark mb-3">Projetos criados:</h3>
                  <div class="d-flex gap-2">
                      <asp:Button ID="btn_filtrar" runat="server" CssClass="btn btn-ligth btn-lg w-100 border border-secondary border-2" Text="filtrar" OnClick="Btn_Filtrar" />
                      <asp:Button ID="btn_ordenar" runat="server" CssClass="btn btn_ligth btn-lg w-100 border border-secondary border-2" Text="ordem alfabetica" OnClick="Btn_Ordenar" />
                  </div>
                  
                  <asp:Button ID="btn_desfazer_alteracoes" runat="server" CssClass="btn btn-secondary btn-lg w-100 mt-3" Style="background-color:#cc6666; border-color:#cc6666; color:white" Text="desfazer alterações" OnClick="Btn_Desfazer_Alteracoes" />

              </asp:Panel>
              
              
    <div class="table-responsive shadow rounded">
        <asp:GridView ID="gvProjetos" runat="server"
            AutoGenerateColumns="true"
            CssClass="table table-striped table-hover table-bordered mb-0 align-middle">
        </asp:GridView>
    </div>
    
</div>
</div>
</asp:Content>
