<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Lanche.aspx.cs" Inherits="ProjControlePedido.Lanche" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
        <head runat="server">
            <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
            <title></title>
        </head>
    <body>
        <link rel="stylesheet" href="http://code.jquery.com/ui/1.9.0/themes/base/jquery-ui.css" />
        <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
        <script src="http://code.jquery.com/ui/1.9.0/jquery-ui.js"></script>
        <script> $(function () { $("#<%= txtdata.ClientID %>").datepicker({ dateFormat: 'dd/mm/yy', dayNames: ['Domingo', 'Segunda', 'Terça', 'Quarta', 'Quinta', 'Sexta', 'Sábado', 'Domingo'], dayNamesMin: ['D', 'S', 'T', 'Q', 'Q', 'S', 'S', 'D'], dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sáb', 'Dom'], monthNames: ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'], monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'] }); }); </script>
        <form id="form1" runat="server">
            <article class="kanban-entry grab" id="item1" draggable="true">
                <div class="kanban-entry-inner">
                    <div class="kanban-label">
                        <h2><a href="#">Controle de Lanche</a> <span></span></h2>
                          <p></p>
                    </div>
                </div>
            </article>
            <div class="form-group">
                <label for="Nome">Nome:</label>
                <asp:TextBox class="form-control" name="txtNome" ID="txtNome" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="descricao">Descrição:</label>
                <asp:TextBox class="form-control" name="txtDescricao" ID="txtDescricao" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="Data">Data:</label>
                <asp:TextBox class="form-control" name="txtdata" ID="txtdata" runat="server"></asp:TextBox>
            </div>
            <asp:Button class="btn btn-success" ID="btnCadastrar" runat="server" Text="Salvar" OnClick="btnCadastrar_Click" />
        </form>
        <br />
        <% if (!String.IsNullOrEmpty(lblmsg.Text))
            {%>
        <div class="alert alert-success"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a> <strong>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label></strong> </div>
        <%} %>
     </body>
    </html>
</asp:Content>
