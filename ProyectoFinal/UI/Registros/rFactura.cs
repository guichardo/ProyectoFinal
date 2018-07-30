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
    public partial class FacturaDetalleForm : Form
    {

        public FacturaDetalleForm()
        {
            InitializeComponent();
            LlenarComboBox();
        }

        decimal total = 0;
        decimal importe = 0;

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;
        }

        public bool Validar()
        {
            bool paso = false;
            if (string.IsNullOrEmpty(ClienteComboBox.Text))
            {
                MyerrorProvider.SetError(ClienteComboBox, "Seleccione un cliente.");
                paso = true;
            }

            if (string.IsNullOrEmpty(PeliculaComboBox.Text))
            {
                MyerrorProvider.SetError(PeliculaComboBox, "Seleccione una pelicula.");
                paso = true;
            }

            if (string.IsNullOrEmpty(ObservacionesTextBox.Text))
            {
                MyerrorProvider.SetError(ObservacionesTextBox, "Llene el campo observaciones.");
                paso = true;
            }

            if (PrecioNumericUpDown.Value == 0)
            {
                MyerrorProvider.SetError(PrecioNumericUpDown, "Llene el campo cantidad.");
                paso = true;
            }

            return paso;
        }

        public void LlenarComboBox()
        {
            Repositorio<Cliente> cliente = new Repositorio<Cliente>(new Contexto());
            ClienteComboBox.DataSource = cliente.GetList(c => true);
            ClienteComboBox.ValueMember = "ClienteId";
            ClienteComboBox.DisplayMember = "Nombres";

            Repositorio<Peliculas> peliculas = new Repositorio<Peliculas>(new Contexto());
            PeliculaComboBox.DataSource = peliculas.GetList(c => true);
            PeliculaComboBox.ValueMember = "PeliculaId";
            PeliculaComboBox.DisplayMember = "Nombre";
        }

        public void Limpiar()
        {
            total = 0;
            importe = 0;
            FactIdNumericUpDown.Value = 0;
            ClienteComboBox.SelectedIndex = -1;
            PeliculaComboBox.SelectedIndex = -1;
            FDetalleDataGridView.DataSource = null;
            ObservacionesTextBox.Clear();
            PrecioNumericUpDown.Value = 0;
            TotaltextBox.Clear();
        }

        public Facturas LlenarClase()
        {
            Facturas facturas = new Facturas();

            facturas.FacturaId = Convert.ToInt32(FactIdNumericUpDown.Value);
            facturas.ClienteId = Convert.ToInt32(ClienteComboBox.SelectedValue);
            facturas.Fecha = FechaDateTimePicker.Value;
            facturas.Total = Convert.ToInt32(TotaltextBox.Text);

            foreach (DataGridViewRow item in FDetalleDataGridView.Rows)
            {
                facturas.AgregarDetalle(ToInt(item.Cells["FactDetalleId"].Value),
                    facturas.FacturaId, ToInt(item.Cells["ClienteId"].Value),
                    ToInt(item.Cells["PeliculaId"].Value),
                    Convert.ToString(item.Cells["Pelicula"].Value),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value));
            }
            return facturas;
        }

        public void LlenarCampos(Facturas facturas)
        {
            Limpiar();
            ObservacionesTextBox.Text = facturas.Observaciones;
            FechaDateTimePicker.Value = facturas.Fecha;
            FDetalleDataGridView.DataSource = null;
            TotaltextBox.Text = Convert.ToInt32(facturas.Total).ToString();

            FDetalleDataGridView.DataSource = facturas.Detalle;
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Facturas facturas = LlenarClase();
            bool Paso = false;

            if (FactIdNumericUpDown.Value == 0)
            {
                Paso = BLL.FacturaBLL.Guardar(facturas);
            }
            else
            {
                Paso = BLL.FacturaBLL.Modificar(facturas);
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

            int id = Convert.ToInt32(FactIdNumericUpDown.Value);
            if (BLL.FacturaBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(FactIdNumericUpDown.Value);
            Facturas facturas = BLL.FacturaBLL.Buscar(id);

            if (facturas != null)
            {
                LlenarCampos(facturas);
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<FactDetalle> detalle = new List<FactDetalle>();
            Facturas facturas = new Facturas();


            if (FDetalleDataGridView.DataSource != null)
            {
                facturas.Detalle = (List<FactDetalle>)FDetalleDataGridView.DataSource;
            }

            foreach (var item in BLL.PeliculasBLL.GetList(x => x.Inventario < CantidadnumericUpDown.Value))
            {
                MessageBox.Show("No hay existencia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (ImportenumericUpDown.Value == 0)
            {
                MessageBox.Show("Favor digitar una cantidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                facturas.Detalle.Add(
                    new FactDetalle(FactDetalleId: 0,
                    FacturaId: (int)Convert.ToInt32(FactIdNumericUpDown.Value),
                    ClienteId: (int)ClienteComboBox.SelectedValue,
                    PeliculaId: (int)PeliculaComboBox.SelectedValue,
                    Pelicula: (string)BLL.PeliculasBLL.MostrarDescripcion(PeliculaComboBox.Text),
                    Cantidad: (int)Convert.ToInt32(CantidadnumericUpDown.Value),
                    Precio: (int)Convert.ToInt32(PrecioNumericUpDown.Value),
                    Importe: (int)Convert.ToInt32(ImportenumericUpDown.Value)));


                FDetalleDataGridView.DataSource = null;
                FDetalleDataGridView.DataSource = facturas.Detalle;

                FDetalleDataGridView.Columns["FactDetalleId"].Visible = false;
                FDetalleDataGridView.Columns["ClienteId"].Visible = false;
                FDetalleDataGridView.Columns["PeliculaId"].Visible = false;
            }

            importe += BLL.FacturaBLL.CalcularImporte(PrecioNumericUpDown.Value, Convert.ToInt32(CantidadnumericUpDown.Value));

            if (FactIdNumericUpDown.Value != 0)
            {

                total += importe;
                TotaltextBox.Text = Convert.ToInt32(total).ToString();
            }
            else
            {
                total = importe;
                TotaltextBox.Text = Convert.ToInt32(total).ToString();
            }
        }

        private void PeliculaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in BLL.PeliculasBLL.GetList(x => x.Nombre == PeliculaComboBox.Text))
            {
                PrecioNumericUpDown.Value = item.Precio;
            }
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ImportenumericUpDown.Value = BLL.FacturaBLL.CalcularImporte(PrecioNumericUpDown.Value, Convert.ToInt32(CantidadnumericUpDown.Value));
        }

        private void Removerbutton_Click(object sender, EventArgs e)
        {
            if (FDetalleDataGridView.Rows.Count > 0
                && FDetalleDataGridView.CurrentRow != null)
            {

                List<FactDetalle> detalle = (List<FactDetalle>)FDetalleDataGridView.DataSource;
                detalle.RemoveAt(FDetalleDataGridView.CurrentRow.Index);
                Peliculas peliculas = (Peliculas)PeliculaComboBox.SelectedItem;

                int x = (Convert.ToInt32(CantidadnumericUpDown.Value));
                peliculas.Inventario += x;

                decimal total = 0;

                foreach (var item in detalle)
                {
                    total -= item.Importe;
                }
                total *= (-1);

                TotaltextBox.Text = Convert.ToInt32(total).ToString();


                FDetalleDataGridView.DataSource = null;
                FDetalleDataGridView.DataSource = detalle;


                FDetalleDataGridView.Columns["FactDetalleId"].Visible = false;
                FDetalleDataGridView.Columns["ClienteId"].Visible = false;
                FDetalleDataGridView.Columns["PeliculaId"].Visible = false;
            }
        }
    }
}
