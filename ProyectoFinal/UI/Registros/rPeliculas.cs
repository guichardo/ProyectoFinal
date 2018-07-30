using ProyectoFinal.DAL;
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
    public partial class RegPeliculasForm : Form
    {

        public RegPeliculasForm()
        {
            InitializeComponent();
            LlenarCombo();
        }

        private void RegPeliculasForm_Load(object sender, EventArgs e)
        {
            LlenarCombo();
        }

        public bool Validar(int validar)
        {
            bool paso = false;
            if (validar == 1 && string.IsNullOrEmpty(NombreTextBox.Text))
            {
                MyerrorProvider.SetError(NombreTextBox, "Llene el campo Nombre.");
                paso = true;
            }

            if (validar == 1 && PrecioNumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(PrecioNumericUpDown, "Llene el campo Precio.");
                paso = true;
            }

            if (validar == 1 && string.IsNullOrEmpty(SipnosisTextBox.Text))
            {
                MyerrorProvider.SetError(SipnosisTextBox, "Llene el campo sipnosis.");
                paso = true;
            }

            return paso;
        }

        public Peliculas LlenarClase()
        {
            Peliculas peli = new Peliculas();

            peli.PeliculaId = (int)IdNumericUpDown.Value;
            peli.Nombre = NombreTextBox.Text;
            peli.Precio = PrecioNumericUpDown.Value;
            peli.FechaSalida = FechaDateTimePicker.Value;
            peli.Sipnosis = SipnosisTextBox.Text;
            peli.Inventario = 0;

            return peli;
        }

        public void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            NombreTextBox.Clear();
            PrecioNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            SipnosisTextBox.Clear();
        }

        public void LlenarCombo()
        {
            Repositorio<Generos> generos = new Repositorio<Generos>(new Contexto());
            GenerosComboBox.DataSource = generos.GetList(c => true);
            GenerosComboBox.ValueMember = "GeneroId";
            GenerosComboBox.DisplayMember = "Descripcion";
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Peliculas peliculas = LlenarClase();
            bool Paso = false;

            if (IdNumericUpDown.Value == 0)
            {
                Paso = BLL.PeliculasBLL.Guardar(peliculas);
            }
            else
            {
                Paso = BLL.PeliculasBLL.Modificar(peliculas);
            }

            if (Paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Exito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Por favor llenar los campos!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int id = Convert.ToInt32(IdNumericUpDown.Value);
            if (BLL.PeliculasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {

            MyerrorProvider.Clear();

            if(IdNumericUpDown.Value == 0)
            {

                MessageBox.Show("Ingrese un ID");

            }

            int id = Convert.ToInt32(IdNumericUpDown.Value);
            Peliculas peliculas = BLL.PeliculasBLL.Buscar(id);

            if (peliculas != null)
            {
                IdNumericUpDown.Value = peliculas.PeliculaId;
                NombreTextBox.Text = peliculas.Nombre;
                FechaDateTimePicker.Value = peliculas.FechaSalida;
                PrecioNumericUpDown.Value = peliculas.Precio;
                InventarionumericUpDown.Value = peliculas.Inventario;
                SipnosisTextBox.Text = peliculas.Sipnosis;
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
