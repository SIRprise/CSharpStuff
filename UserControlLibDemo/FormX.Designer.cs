namespace UserControlLibDemo
{
    partial class FormX
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
            this.spBlockDiagram1 = new SIRpriseUserControls.SpBlockDiagram();
            this.SuspendLayout();
            // 
            // spBlockDiagram1
            // 
            this.spBlockDiagram1.Location = new System.Drawing.Point(95, 76);
            this.spBlockDiagram1.Name = "spBlockDiagram1";
            this.spBlockDiagram1.Size = new System.Drawing.Size(150, 150);
            this.spBlockDiagram1.TabIndex = 0;
            // 
            // FormX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 333);
            this.ControlBox = true;
            this.Controls.Add(this.spBlockDiagram1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormX";
            this.Text = "SpForm(modified)";
            this.ResumeLayout(false);

        }

        #endregion

        private SIRpriseUserControls.SpBlockDiagram spBlockDiagram1;
    }
}