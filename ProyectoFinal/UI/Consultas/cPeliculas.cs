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
    public partial class cPeliculas : Form
    {
        private List<Peliculas> ListaPeliculas = new List<Peliculas>();
        public cPeliculas()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Peliculas>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (filtrarcomboBox.SelectedIndex)
                {
                    case 0://id
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = PeliculasBLL.GetList(g => g.PeliculaId == id);
                        break;
                    case 1://Nombre
                        listado = PeliculasBLL.GetList(g => g.Nombre.Contains(CriteriotextBox.Text));
                        break;
                    case 2://Precio
                        decimal precio = Convert.ToDecimal(CriteriotextBox.Text);
                        listado = PeliculasBLL.GetList(g => g.Precio == precio);
                        break;
                    case 3://Inventario
                        int inv = Convert.ToInt32(CriteriotextBox.Text);
                        listado = PeliculasBLL.GetList(g => g.Inventario == inv);
                        break;
                    case 4://Sipnosis
                        listado = PeliculasBLL.GetList(g => g.Sipnosis.Contains(CriteriotextBox.Text));
                        break;
                }
            }
            else
            {
                ListaPeliculas = PeliculasBLL.GetList();
            }

            //ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = ListaPeliculas;
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            if (ListaPeliculas.Count == 0)
            {

                MessageBox.Show("No hay datos para imprimir");
                return;
            }

            PeliculasReportViewer viewer = new PeliculasReportViewer(ListaPeliculas);
            viewer.ShowDialog();
        }
    }
}
