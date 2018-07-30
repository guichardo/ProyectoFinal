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
    public partial class PeliculasReportViewer : Form
    {
        List<Peliculas> ListaPeliculas;
        public PeliculasReportViewer(List<Peliculas> peliculas)
        {
            ListaPeliculas = peliculas;
            InitializeComponent();
        }

        private void PeliculasReportViewer_Load(object sender, EventArgs e)
        {
            PeliculaCrystalReport listado = new PeliculaCrystalReport();
            listado.SetDataSource(ListaPeliculas);

            MycrystalReportViewer.ReportSource = listado;
            MycrystalReportViewer.Refresh();
        }
    }
}
