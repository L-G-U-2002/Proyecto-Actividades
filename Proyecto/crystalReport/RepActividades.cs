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

        private void RepActividades_Load(object sender, EventArgs e)
        {
            CrystalReport1 = new CrystalReport1();
            crystalReporActividades.ReportSource = reportes;
            reportes.SetDatabaseLogon("sa", "71551457");
            reportes.Refresh();
        }
    }
}
