using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto.crystalReport
{
    public partial class RepActividades : Form
    {
        public RepActividades()
        {
            InitializeComponent();
        }
        public string actividad { get; set; }
        private void RepActividades_Load(object sender, EventArgs e)
        {
            CrystalReport1 actividades = new CrystalReport1();
            crystalReporActividades.ReportSource = actividades;
            actividades.SetParameterValue("@actividad", actividad);
            actividades.SetDatabaseLogon("sa", "71551457");
            actividades.Refresh();
        }
    }
}
