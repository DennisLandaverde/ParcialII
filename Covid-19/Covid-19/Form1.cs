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
    
    public partial class Form1 : Form
    {
        Beneficiados ben = new Beneficiados();

        public Form1()
        {
            InitializeComponent();
        }


        private void btnConsultar_Click(object sender, EventArgs e)
        {
            
            using (COVID19Entities db = new COVID19Entities())
            {

                var Lista = from Beneficiado in db.Beneficiados
                            where Beneficiado.DUI == txtDui.Text
                            select Beneficiado;
                

                if (Lista.Count() > 0)
                {
                    lblNombrePersona.Visible = true;
                    lblMensaje.Visible = true;
                    lblNombrePersona.Text = ben.NombrePers;
                    
                }



                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "No Eres Beneficiario";
                }




            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            InicioSesion administrador = new InicioSesion();
            administrador.Show();
            this.Hide();
        }
    }
}
