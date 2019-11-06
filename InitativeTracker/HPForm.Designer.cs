namespace InitativeTracker
{
    partial class HPForm
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
            this.currentHPUpDown = new System.Windows.Forms.NumericUpDown();
            this.maxHPUpDown = new System.Windows.Forms.NumericUpDown();
            this.currentHPLabel = new System.Windows.Forms.Label();
            this.maxHPLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currentHPUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // currentHPUpDown
            // 
            this.currentHPUpDown.Location = new System.Drawing.Point(131, 70);
            this.currentHPUpDown.Name = "currentHPUpDown";
            this.currentHPUpDown.Size = new System.Drawing.Size(120, 20);
            this.currentHPUpDown.TabIndex = 0;
            this.currentHPUpDown.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // maxHPUpDown
            // 
            this.maxHPUpDown.Location = new System.Drawing.Point(131, 119);
            this.maxHPUpDown.Name = "maxHPUpDown";
            this.maxHPUpDown.Size = new System.Drawing.Size(120, 20);
            this.maxHPUpDown.TabIndex = 1;
            this.maxHPUpDown.ValueChanged += new System.EventHandler(this.MaxHPUpDown_ValueChanged);
            // 
            // currentHPLabel
            // 
            this.currentHPLabel.AutoSize = true;
            this.currentHPLabel.Location = new System.Drawing.Point(32, 70);
            this.currentHPLabel.Name = "currentHPLabel";
            this.currentHPLabel.Size = new System.Drawing.Size(59, 13);
            this.currentHPLabel.TabIndex = 2;
            this.currentHPLabel.Text = "Current HP";
            this.currentHPLabel.Visible = false;
            // 
            // maxHPLabel
            // 
            this.maxHPLabel.AutoSize = true;
            this.maxHPLabel.Location = new System.Drawing.Point(35, 125);
            this.maxHPLabel.Name = "maxHPLabel";
            this.maxHPLabel.Size = new System.Drawing.Size(45, 13);
            this.maxHPLabel.TabIndex = 3;
            this.maxHPLabel.Text = "Max HP";
            // 
            // HPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.maxHPLabel);
            this.Controls.Add(this.currentHPLabel);
            this.Controls.Add(this.maxHPUpDown);
            this.Controls.Add(this.currentHPUpDown);
            this.Name = "HPForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.HPForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentHPUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown currentHPUpDown;
        private System.Windows.Forms.NumericUpDown maxHPUpDown;
        private System.Windows.Forms.Label currentHPLabel;
        private System.Windows.Forms.Label maxHPLabel;
    }
}