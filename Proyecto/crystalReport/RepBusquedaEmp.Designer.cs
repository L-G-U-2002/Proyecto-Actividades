namespace Proyecto.crystalReport
{
    partial class RepBusquedaEmp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.crystalReportEmpleado = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportEmpleado
            // 
            this.crystalReportEmpleado.ActiveViewIndex = -1;
            this.crystalReportEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportEmpleado.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportEmpleado.Location = new System.Drawing.Point(0, 0);
            this.crystalReportEmpleado.Name = "crystalReportEmpleado";
            this.crystalReportEmpleado.Size = new System.Drawing.Size(800, 450);
            this.crystalReportEmpleado.TabIndex = 0;
            this.crystalReportEmpleado.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RepBusquedaEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportEmpleado);
            this.Name = "RepBusquedaEmp";
            this.Text = "RepBusquedaEmp";
            this.Load += new System.EventHandler(this.RepBusquedaEmp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportEmpleado;
    }
}