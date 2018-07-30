using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using ProyectoFinal.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consultas
{
    public partial class cClientes : Form
    {
        private List<Cliente> ListaCliente = new List<Cliente>();
        public cClientes()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Cliente>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (filtrarcomboBox.SelectedIndex)
                {
                    case 0://id
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = ClientesBLL.GetList(g => g.ClienteId == id);
                        break;
                    case 1://nombres
                        listado = ClientesBLL.GetList(g => g.Nombres.Contains(CriteriotextBox.Text));
                        break;
                    case 2://apellidos
                        listado = ClientesBLL.GetList(g => g.Apellidos.Contains(CriteriotextBox.Text));
                        break;
                    case 3://Direccion
                        listado = ClientesBLL.GetList(g => g.Direccion.Contains(CriteriotextBox.Text));
                        break;
                    case 4://Telefono
                        listado = ClientesBLL.GetList(g => g.Telefono.Contains(CriteriotextBox.Text));
                        break;
                    case 5://Celular
                        listado = ClientesBLL.GetList(g => g.Celular.Contains(CriteriotextBox.Text));
                        break;
                    case 6://Email
                        listado = ClientesBLL.GetList(g => g.Email.Contains(CriteriotextBox.Text));
                        break;
                }
            }
            else
            {
                ListaCliente = ClientesBLL.GetList();
            }

  //          ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = ListaCliente;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if(ListaCliente.Count == 0)
            {

                MessageBox.Show("No hay datos para imprimir");
                return;
            }

            ClientesReportViewer viewer = new ClientesReportViewer(ListaCliente);
            viewer.ShowDialog();
        }
    }
}