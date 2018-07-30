using ProyectoFinal.DAL;
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

namespace ProyectoFinal.UI.Registros
{
    public partial class rEntradaPeli : Form
    {
        public rEntradaPeli()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        private void Vaciar()
        {
            IdnumericUpDown.Value = 0;
            CantidadnumericUpDown.Value = 0;

        }

        private EntradaPeli LlenarClase()
        {

            EntradaPeli entrada = new EntradaPeli();

            entrada.EntradaPeliId = Convert.ToInt32(IdnumericUpDown.Value);
            entrada.PeliculaId = (int)PeliculacomboBox.SelectedValue;
            entrada.Fecha = FechadateTimePicker.Value;
            entrada.Cantidad = Convert.ToInt32(CantidadnumericUpDown.Value);

            return entrada;
        }

        private void LlenarComboBox()
        {
            Repositorio<Peliculas> repositorio = new Repositorio<Peliculas>(new Contexto());
            PeliculacomboBox.DataSource = repositorio.GetList(c => true);
            PeliculacomboBox.ValueMember = "PeliculaId";
            PeliculacomboBox.DisplayMember = "Nombre";
        }

        private bool Validar(int validar)
        {

            bool paso = false;

            if (validar == 1 && IdnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(IdnumericUpDown, "Ingrese un ID");
                paso = true;

            }

            if (validar == 1 && CantidadnumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(CantidadnumericUpDown, "Ingrese una cantidad");
                paso = true;

            }
            return paso;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if(IdnumericUpDown.Value == 0)
            {

                MessageBox.Show("Digite un ID");

            }
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            EntradaPeli entrada = BLL.EntradaPeliculaBLL.Buscar(id);

            if (entrada != null)
            {
                FechadateTimePicker.Value = Convert.ToDateTime(entrada.Fecha);
                PeliculacomboBox.SelectedValue = entrada.PeliculaId;
                CantidadnumericUpDown.Value = Convert.ToDecimal(entrada.Cantidad);
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Vaciar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            int id = (int)IdnumericUpDown.Value;
            EntradaPeli entrada = BLL.EntradaPeliculaBLL.Buscar(id);
            EntradaPeli entrada_guardar = LlenarClase();
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            if (entrada == null)
            {
                if (IdnumericUpDown.Value == 0)
                {
                    if (BLL.EntradaPeliculaBLL.Guardar(entrada_guardar))
                        MessageBox.Show("Entrada Articulo guardado");
                    else
                        MessageBox.Show("Entrada Articulo no guardado");
                }
                else
                {
                    if (BLL.EntradaPeliculaBLL.Modificar(entrada_guardar, entrada))
                        MessageBox.Show("Entrada de articulo modificada");
                    else
                        MessageBox.Show("Entrada de articulo no modificada");
                } 
            }

            MyerrorProvider.Clear();


            if (IdnumericUpDown.Value == 0)
                paso = BLL.EntradaPeliculaBLL.Guardar(LlenarClase());
            else
                paso = BLL.EntradaPeliculaBLL.Modificar(entrada_guardar, entrada);


            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Vaciar();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(IdnumericUpDown.Value);

            if (BLL.EntradaPeliculaBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
