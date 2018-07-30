using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Reportes
{
    public partial class ClientesReportViewer : Form
    {
        private List<Cliente> ListaCliente;
        public ClientesReportViewer(List<Cliente>clientes)
        {
            this.ListaCliente = clientes;
            InitializeComponent();
        }

        private void ClientesReportViewer_Load(object sender, EventArgs e)
        {
            ClienteCrystalReport listado = new ClienteCrystalReport();
            listado.SetDataSource(ListaCliente);

            MycrystalReportViewer.ReportSource = listado;
            MycrystalReportViewer.Refresh();

        }
    }
}
