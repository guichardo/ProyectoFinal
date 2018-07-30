using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinal.Registros
{
    public partial class RegGenerosForm : Form
    {

        public RegGenerosForm()
        {
            InitializeComponent();
        }

        private void RegGenerosForm_Load(object sender, EventArgs e)
        {

        }

        public bool Validar(int validar)
        {

            bool paso = false;

            if (validar == 1 && string.IsNullOrEmpty(NombreTextBox.Text))
            {
                MyerrorProvider.SetError(NombreTextBox, "Llene el campo Nombre.");
                paso = true;
            }

            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                MyerrorProvider.SetError(NombreTextBox, "Llene el campo nombre.");
                paso = true;
            }

            return paso;
        }

        public Generos LlenarClase()
        {
            Generos genero = new Generos();

            genero.GeneroId = (int)GeneroIdNumericUpDown.Value;
            genero.Fecha = DateTime.Now;
            genero.Descripcion = NombreTextBox.Text;

            return genero;
        }

        public void Limpiar()
        {
            GeneroIdNumericUpDown.Value = 0;
            NombreTextBox.Clear();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            if (Validar(2))
            {

                MessageBox.Show("Llenar todos los campos marcados");
                return;
            }

            MyerrorProvider.Clear();


            if (GeneroIdNumericUpDown.Value == 0)
                paso = BLL.GenerosBLL.Guardar(LlenarClase());
            else
                paso = BLL.GenerosBLL.Modificar(LlenarClase());


            if (paso)

                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Limpiar();
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(GeneroIdNumericUpDown.Value);

            if (BLL.GenerosBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            MyerrorProvider.Clear();

            if (Validar(1))
            {
                MessageBox.Show("Ingrese un ID");
                return;
            }

            int id = Convert.ToInt32(GeneroIdNumericUpDown.Value);
            Generos generos = BLL.GenerosBLL.Buscar(id);

            if (generos != null)
            {
                NombreTextBox.Text = generos.Descripcion;

            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
