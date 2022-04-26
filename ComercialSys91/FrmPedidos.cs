using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLabNu;

namespace ComercialSys91
{
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            txtDataPed.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            cmbCliente.DataSource = Cliente.Listar().ToArray();
            cmbCliente.DisplayMember = "Nome";
            cmbCliente.ValueMember = "Id";
            //var lista = Usuario.Listar().ToArray();
            cmbUsuario.DataSource = Usuario.Listar().ToArray();
            cmbUsuario.DisplayMember = "Nome";
            cmbUsuario.ValueMember = "Id";
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            Pedido pedido = new Pedido();
            pedido.Cliente = new Cliente(Convert.ToInt32(cmbCliente.SelectedValue));
            pedido.Usuario = new Usuario(Convert.ToInt32(cmbUsuario.SelectedValue));
            pedido.Inserir();
            txtIdPedido.Text = pedido.Id.ToString();
            lblStatus.Text = pedido.Status == "A" ? "ABERTO" : "Indefinido"; 
            grbDados.Enabled = false;
            grbItens.Enabled = true;

        }
    }
}
