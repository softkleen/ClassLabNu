﻿using System;
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
    }
}
