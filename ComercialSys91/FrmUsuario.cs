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
    public partial class FrmUsuario : Form
    {
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            //string usuario = System.Environment.UserName;
            //Text += " - " + usuario;
            try
            {
                cmbNivel.DataSource = Nivel.Listar().ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            cmbNivel.DisplayMember = "Nome";
            cmbNivel.ValueMember = "Id";
        }
    }
}
