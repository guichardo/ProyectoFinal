using ProyectoFinal.BLL;
using ProyectoFinal.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace ProyectoFinal.Login
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        public bool Validar()
        {
            bool paso = false;
            if(string.IsNullOrWhiteSpace(NombreUsuarioTextBox.Text))
            {
                MyerrorProvider.SetError(NombreUsuarioTextBox, "Llene el campo Nombre de usuario.");
                paso = true;
            }
            
            if (string.IsNullOrWhiteSpace(PassTextBox.Text))
            {
                MyerrorProvider.SetError(PassTextBox, "Llene el campo contraseña.");
                paso = true;
            }

            return paso;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            foreach (Usuarios user in UsuariosBLL.GetListTodo())
            {
                if (user.NombreUsuario.Equals(NombreUsuarioTextBox.Text) &&
                    user.Pass.Equals(PassTextBox.Text))
                {
                    this.Close();
                    new MainForm().Show();
                    return;
                }
            }

            MessageBox.Show("Este usuario no existe");

        }
    }
}
