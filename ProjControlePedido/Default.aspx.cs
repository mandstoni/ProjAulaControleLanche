using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ProjControlePedido
{
    public partial class Listar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarLista();
        }

        private void CarregarLista()
        {
            PedidoLancheEntities context = new PedidoLancheEntities();
            List<tbPedidoLanche> lstPedido = context.tbPedidoLanche.ToList<tbPedidoLanche>();

            GVPedido.DataSource = lstPedido;
            GVPedido.DataBind();
        }

        protected void GVPedido_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idItem = Convert.ToInt32(e.CommandArgument.ToString());
            PedidoLancheEntities contextViagem = new PedidoLancheEntities();
            tbPedidoLanche viagem = new tbPedidoLanche();

            viagem = contextViagem.tbPedidoLanche.First(c => c.ID == idItem);

            if (e.CommandName == "ALTERAR")
            {
                Response.Redirect("Lanche.aspx?idItem=" + idItem);
            }
            else if (e.CommandName == "EXCLUIR")
            {
                contextViagem.tbPedidoLanche.Remove(viagem);
                contextViagem.SaveChanges();
                string msg = "Pedido excluído com sucesso !";
                string titulo = "Informação";
                CarregarLista();
                DisplayAlert(titulo, msg, this);
            }
        }

        public void DisplayAlert(string titulo, string mensagem, System.Web.UI.Page page)
        {
            h1.InnerText = titulo;
            lblMsgPopup.InnerText = mensagem;
            ClientScript.RegisterStartupScript(typeof(Page), Guid.NewGuid().ToString(),
                "MostrarPopupMensagem();", true);
        }
    }
}