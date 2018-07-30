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
    public partial class cUsuarios : Form
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var listado = new List<Usuarios>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (filtrarcomboBox.SelectedIndex)
                {
                    case 0://id
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = UsuariosBLL.GetList(g => g.UsuarioId == id);
                        break;
                    case 1://nombres
                        listado = UsuariosBLL.GetList(g => g.Nombre.Contains(CriteriotextBox.Text));
                        break;
                    case 2://nombre de usuario
                        listado = UsuariosBLL.GetList(g => g.NombreUsuario.Contains(CriteriotextBox.Text));
                        break;
                    case 3://password
                        listado = UsuariosBLL.GetList(g => g.Pass.Contains(CriteriotextBox.Text));
                        break;
                    case 4://Telefono
                        listado = UsuariosBLL.GetList(g => g.Telefono.Contains(CriteriotextBox.Text));
                        break;
                    case 5://Cantidad
                        listado = UsuariosBLL.GetList(g => g.Direccion.Contains(CriteriotextBox.Text));
                        break;
                }
            }
            else
            {
                listado = UsuariosBLL.GetListTodo();
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
}
