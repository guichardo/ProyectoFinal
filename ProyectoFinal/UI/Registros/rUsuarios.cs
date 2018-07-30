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
    public partial class RegUsuariosForm : Form
    {
        public RegUsuariosForm()
        {
            InitializeComponent();
        }

        private void RegUsuariosForm_Load(object sender, EventArgs e)
        {

        }

        public bool Validar(int validar)
        {
            bool paso = false;
            if (string.IsNullOrEmpty(NombreTextBox.Text))
            {
                MyerrorProvider.SetError(NombreTextBox, "Llene el campo Nombre.");
                paso = true;
            }

            if (string.IsNullOrEmpty(PasswordTextBox.Text))
            {
                MyerrorProvider.SetError(NombreTextBox, "Llene el campo Contraseña.");
                paso = true;
            }

            if (string.IsNullOrEmpty(TelefonomaskedTextBox.Text))
            {
                MyerrorProvider.SetError(NombreTextBox, "Llene el campo telefono.");
                paso = true;
            }

            if (string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                MyerrorProvider.SetError(NombreTextBox, "Llene el campo Direccion.");
                paso = true;
            }

            return paso;
        }

        public void Limpiar()
        {
            NombreTextBox.Clear();
            NombreUsTextBox.Clear();
            PasswordTextBox.Clear();
            TelefonomaskedTextBox.Clear();
            DireccionTextBox.Clear();
            UsuarioIdNumericUpDown.Value = 0;
        }

        public Usuarios LlenarClase()
        {
            Usuarios us = new Usuarios();

            us.UsuarioId = (int)UsuarioIdNumericUpDown.Value;
            us.Nombre = NombreTextBox.Text;
            us.NombreUsuario = NombreUsTextBox.Text;
            us.Pass = PasswordTextBox.Text;
            us.Fecha = DateTime.Now;
            us.Telefono = TelefonomaskedTextBox.Text;
            us.Direccion = DireccionTextBox.Text;

            return us;
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


            if (UsuarioIdNumericUpDown.Value == 0)
                paso = BLL.UsuariosBLL.Guardar(LlenarClase());
            else
                paso = BLL.UsuariosBLL.Modificar(LlenarClase());


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

            int id = Convert.ToInt32(UsuarioIdNumericUpDown.Value);

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

            int id = Convert.ToInt32(UsuarioIdNumericUpDown.Value);
            Usuarios usuarios = BLL.UsuariosBLL.Buscar(id);

            if (usuarios != null)
            {
                NombreTextBox.Text = usuarios.Nombre;
                NombreUsTextBox.Text = usuarios.NombreUsuario;
                PasswordTextBox.Text = usuarios.Pass;
                TelefonomaskedTextBox.Text = usuarios.Telefono;
                DireccionTextBox.Text = usuarios.Direccion;

            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
