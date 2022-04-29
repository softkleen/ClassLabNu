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
    public partial class FrmProduto : Form
    {
        public FrmProduto()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            Produto produto = new Produto();
            var lista = Produto.ListarTodos();
            dgvListaProduto.DataSource = lista;
        }

        private void txtProcurar_TextChanged(object sender, EventArgs e)
        {
            if (txtProcurar.TextLength>=3)
            {
                //btnListar_Click(sender, e);
                Produto produto = new Produto();
                var lista = Produto.ListarTodos(txtProcurar.Text);
                dgvListaProduto.DataSource = lista;
            }
        }
    }
}
