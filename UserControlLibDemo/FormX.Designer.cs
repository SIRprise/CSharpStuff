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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormX));
            this.spBlockDiagram1 = new SIRpriseUserControls.SpBlockDiagram();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spBlockDiagram1
            // 
            this.spBlockDiagram1.AutoScroll = true;
            this.spBlockDiagram1.BlockColors = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("spBlockDiagram1.BlockColors")));
            this.spBlockDiagram1.BlockSize = 4;
            this.spBlockDiagram1.Location = new System.Drawing.Point(95, 76);
            this.spBlockDiagram1.Name = "spBlockDiagram1";
            this.spBlockDiagram1.Size = new System.Drawing.Size(299, 157);
            this.spBlockDiagram1.TabIndex = 0;
            this.spBlockDiagram1.BlockClick += new System.EventHandler(this.spBlockDiagram1_BlockClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 333);
            this.ControlBox = true;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spBlockDiagram1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormX";
            this.Text = "SpForm(modified)";
            this.ResumeLayout(false);

        }

        #endregion

        private SIRpriseUserControls.SpBlockDiagram spBlockDiagram1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}