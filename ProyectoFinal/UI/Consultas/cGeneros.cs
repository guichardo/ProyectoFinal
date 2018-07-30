using ProyectoFinal.BLL;
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

namespace ProyectoFinal.UI.Consultas
{
    public partial class cGeneros : Form
    {
        public cGeneros()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Generos>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (filtrarcomboBox.SelectedIndex)
                {
                    case 0://id
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = GenerosBLL.GetList(g => g.GeneroId == id);
                        break;
                    case 1://Descripcion
                        listado = GenerosBLL.GetList(g => g.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                }
            }
            else
            {
                listado = GenerosBLL.GetList();
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}
