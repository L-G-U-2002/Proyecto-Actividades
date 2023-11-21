namespace Proyecto.crystalReport
{
    partial class RepActividades
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
            this.crystalReporActividades = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReporActividades
            // 
            this.crystalReporActividades.ActiveViewIndex = -1;
            this.crystalReporActividades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReporActividades.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReporActividades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReporActividades.Location = new System.Drawing.Point(0, 0);
            this.crystalReporActividades.Name = "crystalReporActividades";
            this.crystalReporActividades.Size = new System.Drawing.Size(800, 450);
            this.crystalReporActividades.TabIndex = 0;
            this.crystalReporActividades.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // RepActividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReporActividades);
            this.Name = "RepActividades";
            this.Text = "RepActividades";
            this.Load += new System.EventHandler(this.RepActividades_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReporActividades;
    }
}