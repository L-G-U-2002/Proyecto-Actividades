using Proyecto.capadatos;
using Proyecto.capalogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Proyecto.formularios
{
    public partial class Actividades : Form
    {
        public Actividades()
        {
            InitializeComponent();
        }

        void nuevo()
        {
            cbremitente.Text= "Seleccionar";
            cbdestinatario.Text = "Seleccionar";
            cbproyecto.Text = "Seleccionar";
            cbtarea.Text = "Seleccionar";
            txtdescripcion.Clear();
            dtpFechaIn.Value= DateTime.Now;
            dtpFechaFin.Value = DateTime.Now;
        }

        private void LLenarcomboboxES()
        {
            ClsActividades.LLenarcomboboxES();
            cbestado.DataSource = ClsActividades.dt;
            cbestado.DisplayMember = "nom_estado";
            cbestado.ValueMember = "id_estado";
            cbestado.Text = "Activado";
        }

        private void LLenarcomboboxAd()
        {
            ClsEmpleado.LLenarcomboboxAd();
            cbremitente.DataSource = ClsEmpleado.dt;
            cbremitente.DisplayMember = "nombre_apellido";
            cbremitente.ValueMember = "id_empleado";
            cbremitente.Text = "Seleccionar";
        }
        private void LLenarcomboboxEm()
        {
            ClsEmpleado.LLenarcomboboxEm();
            cbdestinatario.DataSource = ClsEmpleado.dt;
            cbdestinatario.DisplayMember = "nombre_apellido";
            cbdestinatario.ValueMember = "id_empleado";
            cbdestinatario.Text = "Seleccionar";
        }

        private void LLenarcomboboxP()
        {
            ClsProyecto.LLenarcomboboxP();
            cbproyecto.DataSource = ClsProyecto.dt;
            cbproyecto.DisplayMember = "nom_proyecto";
            cbproyecto.ValueMember = "id_proyecto";
            cbproyecto.Text = "Seleccionar";
        }
        private void LLenarcomboboxT()
        {
            ClsTarea.LLenarcomboboxT();
            cbtarea.DataSource = ClsTarea.dt;
            cbtarea.DisplayMember = "nom_tarea";
            cbtarea.ValueMember = "id_tarea";
            cbtarea.Text = "Seleccionar";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaAdmin devolver = new VistaAdmin();
            // Mostrar el formulario y ocultar el primero{
            Close();
            devolver.Show();
            
        }

        private void Actividades_Load(object sender, EventArgs e)
        {
            LLenarcomboboxAd();
            LLenarcomboboxEm();
            LLenarcomboboxP();
            LLenarcomboboxT();
            LLenarcomboboxES();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult Rpt;

            Rpt = MessageBox.Show("¿Deseas enviar esta actividad a un empleado?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Rpt == DialogResult.Yes)
            {
                int estado = Convert.ToInt32(cbestado.SelectedValue.ToString());
                MetodoActividades Gl = new MetodoActividades();
                Gl.remitente = cbremitente.Text;
                Gl.id_empleado = cbdestinatario.SelectedValue.ToString();
                Gl.id_proyecto = cbproyecto.SelectedValue.ToString();
                Gl.id_tarea = cbtarea.SelectedValue.ToString();
                Gl.estado = estado;
                Gl.descripcion = txtdescripcion.Text;
                Gl.fecha_inicio = DateTime.Parse(dtpFechaIn.Text);
                Gl.fecha_fin = DateTime.Parse(dtpFechaFin.Text);
              //  Gl.estado =Convert.ToInt32(cbdestinatario.SelectedValue.ToString());
                
                ClsActividades.InsertarActividades(Gl);

                MessageBox.Show("Se envio el trabajo correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            nuevo();
        }
    }
}
