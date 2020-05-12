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
    public partial class Administrador : Form
    {
        public Administrador()
        {
            InitializeComponent();
        }
        void CargarDatos()
        {
            using (COVID19Entities db = new COVID19Entities())
            {


                var Jointablas = from Beneficiados in db.Beneficiados                              
                                 
                                 select new
                                 {

                                     Nombre = Beneficiados.NombrePers,
                                     Dui = Beneficiados.DUI
                                     




                                 };

                dtvBenefiarios.DataSource = Jointablas.ToList();



            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Beneficiados beneficiados = new Beneficiados();
            using (COVID19Entities db = new COVID19Entities())
            {
                String Id = dtvBenefiarios.CurrentRow.Cells[0].Value.ToString();
                int Idc = int.Parse(Id);
                beneficiados = db.Beneficiados.Where(VerificarId => VerificarId.IdPer == Idc).First();               
                beneficiados.NombrePers = txtNombre.Text;
                beneficiados.DUI = txtDui.Text;
                db.Entry(beneficiados).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


            }
        }

        private void Administrador_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
    }
}
