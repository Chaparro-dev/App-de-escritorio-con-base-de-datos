using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renting
{
    public partial class CrearCuenta : Form
    {
        public CrearCuenta()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtContrasena.Text == txtConfContrasena.Text)
            {
                int result = Conexion.CrearCuenta(txtNombre.Text, txtContrasena.Text);
                if (result > 0)
                {
                    MessageBox.Show("Cuenta creada con éxito");
                }
                else
                    MessageBox.Show("La cuenta no pudo ser creada");
            }
            else
                MessageBox.Show("Las contraseñas no coinciden");

        }

        private void txtConfContrasena_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
