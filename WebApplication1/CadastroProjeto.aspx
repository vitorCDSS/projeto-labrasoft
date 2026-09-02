<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CadastroProjeto.aspx.cs" Inherits="WebApplication1.CadastroProjeto" MaintainScrollPositionOnPostBack="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container mt-5">
               
    
    <div class="card shadow-lg border-0 rounded-4">
        <div class="card-header bg-primary text-white rounded-top-4">
            <h3 class="mb-0">
                <i class="bi bi-folder-plus"></i>
                Cadastro de Projetos
            </h3>
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
                <asp:Button ID="btn_salvar" runat="server" CssClass="btn btn-success btn-lg w-100 rounded-3 shadow-sm" Text="concluir" OnClick="Btn_salvar" />
                <asp:Button ID="btn_limpar" runat="server" CssClass="btn btn-danger btn-lg w-100 rounded-3 shadow-sm" Text="desfazer formulário" OnClick="Btn_Limpar" />
            </div>
            
            
        </div>
     
    </div>   
                        <asp:Label ID="lblMensagem" runat="server" CssClass="h6">
</asp:Label>
          <div class="mt-5">
                
   
              <asp:Panel runat="server" ID="botoes">
                  <hr />
                   <div class="mt-5">

    <div class="row align-items-end g-2 mb-3">

        <div class="col-md-9">
            <label class="form-label fw-bold">
                Buscar por título, área ou coordenador
            </label>

            <asp:TextBox
                ID="txtFiltroProjeto"
                runat="server"
                CssClass="form-control"
                placeholder="Ex.: Sistema, ADS, João...">
            </asp:TextBox>

        </div>


        <div class="col-md-3 d-grid">

            <asp:Button
                ID="btn_filtrarProjeto"
                runat="server"
                CssClass="btn btn-primary"
                Text="🔍 Filtrar"
                OnClick="Btn_FiltrarProjeto" />

        </div>

    </div>


    <asp:Button 
        ID="btn_ordenar"
        runat="server"
        CssClass="btn btn-outline-primary btn-lg w-100 mt-3"
        Text="Ordem alfabética"
        OnClick="Btn_Ordenar" />


    <asp:Button 
        ID="btn_desfazer_alteracoes"
        runat="server"
        CssClass="btn btn-danger btn-lg w-100 mt-3"
        Text="Desfazer alterações"
        OnClick="Btn_Desfazer_Alteracoes" />


    <hr />

</div>
              </asp:Panel>
              
              
<div class="table-responsive shadow rounded">
    <asp:GridView ID="gvProjetos"
    runat="server"
    AutoGenerateColumns="false"
    OnRowCommand="gvProjetos_RowCommand"
    CssClass="table table-hover align-middle mt-3 shadow-sm"
    HeaderStyle-CssClass="table-primary">

    <Columns>

        <asp:BoundField DataField="Titulo" HeaderText="Título" />
        <asp:BoundField DataField="VerbaAprovada" HeaderText="Verba Aprovada" />
        <asp:BoundField DataField="ValorBolsaIndividual" HeaderText="Valor da Bolsa" />
        <asp:BoundField DataField="AreaConhecimento" HeaderText="Área" />

        <asp:TemplateField HeaderText="Mais informações">

    <ItemTemplate>
        <asp:Button 
            ID="btnDetalhar"
            runat="server"
            Text="Detalhar"
            CommandName="Detalhar"
            CommandArgument='<%# Container.DataItemIndex %>'
            CssClass="btn btn-primary btn-sm rounded-pill px-3" />
    </ItemTemplate>

</asp:TemplateField>
                
    </Columns>
</asp:GridView>
</div>
        <asp:Panel ID="pnlDetalhes" runat="server" Visible="false" CssClass="card mt-3 p-3">

    <h4>Detalhes do Projeto</h4>

    <p><strong>Título:</strong> <asp:Label ID="lblTitulo" runat="server" /></p>

    <p><strong>Verba:</strong> <asp:Label ID="lblVerba" runat="server" /></p>

    <p><strong>Valor da Bolsa:</strong> <asp:Label ID="lblBolsa" runat="server" /></p>

    <p><strong>Despesas:</strong></p>

    <asp:BulletedList ID="bltDespesas" runat="server"></asp:BulletedList>

    <p><strong>Área:</strong> <asp:Label ID="lblArea" runat="server" /></p>

    <p><strong>Coordenador:</strong> <asp:Label ID="lblCoordenador" runat="server" /></p>

    <p><strong>Bolsistas:</strong></p>

<asp:BulletedList 
    ID="bltBolsistas" 
    runat="server">
</asp:BulletedList>

<asp:Panel ID="pnlSelecionarBolsistas" runat="server" Visible="false">

    <hr />

    <p>
        <strong>Selecione os bolsistas do projeto:</strong>
    </p>

        <asp:GridView 
    ID="gvBolsistas"
    runat="server"
    AutoGenerateColumns="false"
    DataKeyNames="ID"
    CssClass="table table-hover align-middle mt-3"
    HeaderStyle-CssClass="table-primary"
    OnRowCommand="gvBolsistas_RowCommand">

    <Columns>

        <asp:BoundField 
            DataField="Nome" 
            HeaderText="Bolsista" />

        <asp:TemplateField HeaderText="Ação">

            <ItemTemplate>

                <asp:Button
                    ID="btnAlternar"
                    runat="server"
                    CommandName="Alternar"
                    CommandArgument='<%# Container.DataItemIndex %>'
                    Text='<%# ObterTextoBotao(Container.DataItem) %>'
                    CssClass="btn btn-primary btn-sm rounded-pill px-3" />

            </ItemTemplate>

        </asp:TemplateField>

    </Columns>

</asp:GridView>

    >

    <small class="form-text text-muted">
        Segure <strong>Ctrl</strong> para selecionar mais de um bolsista.
    </small>

    <br />

    <%--<asp:Button
        ID="btnSalvarBolsistas"
        runat="server"
        Text="Salvar bolsistas"
        CssClass="btn btn-success rounded-pill px-4 mb-2"
        OnClick="btnSalvarBolsistas_Click" />--%>

    <asp:Button
        ID="btnCancelarBolsistas"
        runat="server"
        Text="Cancelar"
        CssClass="btn btn-outline-secondary rounded-pill px-4 mb-2"
        OnClick="btnCancelarBolsistas_Click" />

</asp:Panel>

    <asp:Button 
    ID="btnSelecionarBolsistas"
    runat="server"
    Text="Selecionar bolsistas"
    CssClass="btn btn-primary btn-sm rounded-pill px-3 mb-3"
    OnClick="btnSelecionarBolsistas_Click" />

    <asp:Button
        ID="btnFecharDetalhes"
        runat="server"
        Text="Fechar"
        CssClass="btn btn-outline-secondary rounded-pill px-4"
        OnClick="btnFecharDetalhes_Click" />
</asp:Panel>
              <asp:HiddenField ID="hfProjetoID" runat="server" />

</div>
</div>
</asp:Content>
