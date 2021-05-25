using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjControlePedido
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDadosPagina();
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            DateTime data = Convert.ToDateTime(txtData.Text);
            tbPedidoLanche p = new tbPedidoLanche() { Nome= nome, Descricao = descricao, Data = data };
            PedidoLancheEntities contextPedido = new PedidoLancheEntities();

            string valor = Request.QueryString["idItem"];

            if (String.IsNullOrEmpty(valor))
            {
                contextPedido.tbPedidoLanche.Add(p);
                lblmsg.Text = "Registro Inserido!";
                Clear();
            }
            else
            {
                int id = Convert.ToInt32(valor);
                tbPedidoLanche pedido = contextPedido.tbPedidoLanche.First(c => c.ID == id);
                pedido.Descricao = p.Descricao;
                pedido.Data = p.Data;
                lblmsg.Text = "Registro Alterado";
                contextPedido.SaveChanges();
            }

            private void Clear()
            {
                txtData.Text = "";
                txtDescricao.Text = "";
                txtNome.Text = "";
                txtNome.Focus();
            }

            private void CarregarDadosPagina()
            {
                string valor = Request.QueryString["idItem"];
                int idItem = 0;
                tbPedidoLanche pedido = new tbPedidoLanche();
                PedidoLancheEntities contexPedido = new PedidoLancheEntities();

                if (!String.IsNullOrEmpty(valor))
                {
                    idItem = Convert.ToInt32(valor);
                    pedido = contexPedido.tbPedidoLanche.First(contexPedido => contexPedido.ID == idItem);

                    txtNome.Text = pedido.Nome;
                    txtDescricao.Text = pedido.Descricao;
                    txtdata.Text = pedido.Data.ToString();
                }
            }
        }
    }
}