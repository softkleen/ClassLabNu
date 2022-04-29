using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLabNu;

namespace ComercialSys91
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente(txtNome.Text, txtCpf.Text, txtEmail.Text);
            c.Inserir();
            if (c.Id > 0)
            {
                txtId.Text = c.Id.ToString();
                MessageBox.Show("Cliente gravado com sucesso!");
            }
            else
            {
                MessageBox.Show("Falha ao inserir cliente.");
            }


        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            dgvClientes.Rows.Clear();
            List<Cliente> listaDeClientes = Cliente.Listar();
            int cont = 0;
            foreach (Cliente cliente in listaDeClientes)
            {
                dgvClientes.Rows.Add();
                dgvClientes.Rows[cont].Cells[0].Value = cliente.Id.ToString();
                dgvClientes.Rows[cont].Cells[1].Value = cliente.Nome.ToString();
                dgvClientes.Rows[cont].Cells[2].Value = cliente.Cpf.ToString();
                dgvClientes.Rows[cont].Cells[3].Value = cliente.Email.ToString();
                dgvClientes.Rows[cont].Cells[4].Value = cliente.Ativo;
                cont++;
            }
            listaDeClientes.ForEach(x =>
            {

            });

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (btnBuscar.Text == "...")
            {
                txtId.ReadOnly = false;
                txtId.Focus();
                btnBuscar.Text = "Buscar";
                txtCpf.Enabled = false;
            }
            else
            {
                Cliente cliente = Cliente.ConsultarPorId(int.Parse(txtId.Text));
                if (cliente.Id > 0)
                {

                    txtNome.Text = cliente.Nome.ToString();
                    txtCpf.Text = cliente.Cpf.ToString();
                    txtEmail.Text = cliente.Email.ToString();
                    dtpDataCad.Value = cliente.DataCad.Date;
                    chkAtivo.Checked = cliente.Ativo;

                    btnBuscar.Text = "...";
                    txtId.ReadOnly = true;
                    btnAlterar.Enabled = true;
                    txtCpf.ReadOnly = true;

                }
                else
                {
                    MessageBox.Show("Esse código de cliente não existe!");
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            if (cliente.Alterar(int.Parse(txtId.Text), txtNome.Text, txtEmail.Text))
            {
                MessageBox.Show("Cliente alterado com Sucesso!");
            }
            else
            {
                MessageBox.Show("Falha na alteração do Cliente!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void mskCep_TextChanged(object sender, EventArgs e)
        {

        }

        private void mskCep_Leave(object sender, EventArgs e)
        {
            mskCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            if (mskCep.TextLength == 9)
            {
                Cep cep = new Cep(mskCep.Text);
                txtLogradouro.Text = cep.Lagradouro;
                txtBairro.Text = cep.Bairro;
                txtCidade.Text = cep.Cidade;
                txtUf.Text = cep.UF;

            }
        }

        private void txtUf_TextChanged(object sender, EventArgs e)
        {
            var indice = cmbUf.FindString(txtUf.Text);
            cmbEstado.SelectedIndex = indice;
            cmbUf.SelectedIndex = indice;
            txtNumero.Focus();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dgvClientes.Rows[dgvClientes.CurrentRow.Index].Cells[0].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string caminho = arquivoXLS.Text;
            var cmd = Banco.Abrir();
            cmd.CommandText = "select * from produtos";
            var dr = cmd.ExecuteReader();
            using (StreamWriter sw = File.CreateText(caminho))
            {
                while (dr.Read())
                    sw.WriteLine(dr["descricao"].ToString() + "\t" + dr["valor"].ToString() + "\t" + dr["codbar"].ToString());
            };
            MessageBox.Show("Arquivo " + caminho + " gerado com sucesso.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //openFileDialog1.ShowDialog(this);
            //saveFileDialog1 = new SaveFileDialog();
           DialogResult local =  saveFileDialog1.ShowDialog();
            if (local == DialogResult.OK)
            {
                arquivoXLS.Text = saveFileDialog1.FileName;
                MessageBox.Show("caminho salvo" + saveFileDialog1.FileName);
            }
        }
    }
}
