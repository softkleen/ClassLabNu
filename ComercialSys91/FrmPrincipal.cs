using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComercialSys91
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
           InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // criar instância do Formulário Cliente
            FrmCliente frmCliente = new FrmCliente();
            // tornando frmCliente filho do Container FrmPrincipal (this)
            frmCliente.MdiParent = this;
            // exibe o formulário de cliente no formprincipal
            frmCliente.Show();
        }
        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPedidos frmPedidos = new FrmPedidos();
            frmPedidos.MdiParent = this;
            frmPedidos.Show();
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog();
            if (Program.usuario!=null)
            {
                usuarioLogadotoolStripStatus.Text = 
                Program.usuario.Nome + " - " + Program.usuario.Nivel.Nome;
                switch (Program.usuario.Nivel.Sigla)
                {
                    case "gr":
                        this.statusStripPrincipal.BackColor = Color.LightGreen;
                        break;
                    case "at":
                        this.statusStripPrincipal.BackColor = Color.LightYellow;
                        break;
                    case "cx":
                        this.statusStripPrincipal.BackColor = Color.LightBlue;
                        break;
                    default:
                        break;
                }
            }

        }
        private void alterarUsuárioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.FrmPrincipal_Load(sender, e);
        }
        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUsuario frmusuario = new FrmUsuario();
            frmusuario.MdiParent = this;   
            frmusuario.Show();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProduto produto = new FrmProduto();
            produto.MdiParent = this;
            produto.Show();
        }
    }
}
