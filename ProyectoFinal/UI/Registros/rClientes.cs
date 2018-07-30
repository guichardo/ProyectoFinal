using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinal
{
    public partial class RegClientesForm : Form
    {
        ErrorProvider errorProvider1 = new ErrorProvider();
        public RegClientesForm()
        {
            InitializeComponent();
        }

        private void RegClientesForm_Load(object sender, EventArgs e)
        {

        }

        public bool Validar(int validar)
        {

            bool paso = false;
            if (validar == 1 && string.IsNullOrEmpty(NombresTextBox.Text))
            {
                errorProvider1.SetError(NombresTextBox, "Llene el campo Nombre.");
                paso = true;
            }

            if (validar == 1 && string.IsNullOrEmpty(DireccionTextBox.Text))
            {
                errorProvider1.SetError(DireccionTextBox, "Llene el campo direccion.");
                paso = true;
            }
            return paso;

        }

        public Cliente LlenarClase()
        {
            Cliente cliente = new Cliente();

            cliente.ClienteId = (int)ClienteIdNumericUpDown.Value;
            cliente.Nombres = NombresTextBox.Text;
            cliente.Apellidos = ApellidosTextBox.Text;
            cliente.Direccion = DireccionTextBox.Text;
            cliente.FechaNacimiento = NacimientoDateTimePicker.Value;
            cliente.Telefono = TelefonomaskedTextBox.Text;
            cliente.Celular = CelularmaskedTextBox.Text;
            cliente.Email = EmailTextBox.Text;

            return cliente;
        }

        public void Limpiar()
        {
            ClienteIdNumericUpDown.Value = 0;
            NombresTextBox.Clear();
            ApellidosTextBox.Clear();
            NacimientoDateTimePicker.Value = DateTime.Now;
            DireccionTextBox.Clear();
            TelefonomaskedTextBox.Clear();
            CelularmaskedTextBox.Clear();
            EmailTextBox.Clear();
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


            if (ClienteIdNumericUpDown.Value == 0)
                paso = BLL.ClientesBLL.Guardar(LlenarClase());
            else
                paso = BLL.ClientesBLL.Modificar(LlenarClase());


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

            int id = Convert.ToInt32(ClienteIdNumericUpDown.Value);

            if (BLL.UsuariosBLL.Eliminar(id))
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

            int id = Convert.ToInt32(ClienteIdNumericUpDown.Value);
            Cliente cliente = BLL.ClientesBLL.Buscar(id);

            if (cliente != null)
            {
                NombresTextBox.Text = cliente.Nombres;
                ApellidosTextBox.Text = cliente.Apellidos;
                NacimientoDateTimePicker.Text = Convert.ToString(cliente.FechaNacimiento);
                TelefonomaskedTextBox.Text = cliente.Telefono;
                CelularmaskedTextBox.Text = cliente.Celular;
                EmailTextBox.Text = cliente.Email;
                DireccionTextBox.Text = cliente.Direccion;
            }
            else
                MessageBox.Show("No se encontro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}