using ProyectoFinal.Registros;
using ProyectoFinal.UI.Consultas;
using ProyectoFinal.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegClientesForm registro = new RegClientesForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void PeliculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegPeliculasForm registro = new RegPeliculasForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void EntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradaPeli registro = new rEntradaPeli();
            registro.MdiParent = this;
            registro.Show();
        }

        private void GeneroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegGenerosForm registro = new RegGenerosForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegUsuariosForm registro = new RegUsuariosForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FacturaDetalleForm registro = new FacturaDetalleForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void ClienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cClientes cons = new cClientes();
            cons.MdiParent = this;
            cons.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cPeliculas cons = new cPeliculas();
            cons.MdiParent = this;
            cons.Show();
        }

        private void generoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cGeneros cons = new cGeneros();
            cons.MdiParent = this;
            cons.Show();
        }

        private void usuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuarios cons = new cUsuarios();
            cons.MdiParent = this;
            cons.Show();
        }
    }
}
