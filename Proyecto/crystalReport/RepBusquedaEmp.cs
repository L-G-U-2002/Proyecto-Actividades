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
    public partial class RepBusquedaEmp : Form
    {
        public RepBusquedaEmp()
        {
            InitializeComponent();
        }

        private void RepBusquedaEmp_Load(object sender, EventArgs e)
        {
            ReporteEmpleado reportes = new ReporteEmpleado();
            crystalReportEmpleado.ReportSource = reportes;
            reportes.SetDatabaseLogon("sa", "020902");
            reportes.Refresh();
        }
    }
}
