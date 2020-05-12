using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Covid_19.Modelo;

namespace Covid_19
{
    public partial class InicioSesion : Form
    {
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            using (COVID19Entities db = new COVID19Entities())
            {
                var Lista = from Admini in db.Administrador
                            where Admini.NombreAdmin == txtUsuario.Text
                            && Admini.Contraseña == txtContraseña.Text
                            select Admini;

                if (Lista.Count() > 0)
                {
                    MessageBox.Show("Haz iniciado sesion ");
                    Administrador menu = new Administrador();
                    menu.Show();
                    this.Hide();
                }



                else
                {
                    MessageBox.Show("El Usuario no existe en el sistema");
                }

            }
        }
    }
}

