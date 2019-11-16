namespace InitiativeTracker
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
            this.maxHPLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tempHPLabel = new System.Windows.Forms.Label();
            this.TempHPUpDown = new System.Windows.Forms.NumericUpDown();
            this.escButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.currentHPUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempHPUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // currentHPUpDown
            // 
            this.currentHPUpDown.Location = new System.Drawing.Point(108, 44);
            this.currentHPUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.currentHPUpDown.Name = "currentHPUpDown";
            this.currentHPUpDown.Size = new System.Drawing.Size(120, 20);
            this.currentHPUpDown.TabIndex = 0;
            this.currentHPUpDown.ValueChanged += new System.EventHandler(this.CurrentHPUpDown_ValueChanged);
            // 
            // maxHPUpDown
            // 
            this.maxHPUpDown.Location = new System.Drawing.Point(108, 93);
            this.maxHPUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.maxHPUpDown.Name = "maxHPUpDown";
            this.maxHPUpDown.Size = new System.Drawing.Size(120, 20);
            this.maxHPUpDown.TabIndex = 1;
            this.maxHPUpDown.ValueChanged += new System.EventHandler(this.MaxHPUpDown_ValueChanged);
            // 
            // maxHPLabel
            // 
            this.maxHPLabel.AutoSize = true;
            this.maxHPLabel.Location = new System.Drawing.Point(12, 99);
            this.maxHPLabel.Name = "maxHPLabel";
            this.maxHPLabel.Size = new System.Drawing.Size(45, 13);
            this.maxHPLabel.TabIndex = 3;
            this.maxHPLabel.Text = "Max HP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current HP";
            // 
            // tempHPLabel
            // 
            this.tempHPLabel.AutoSize = true;
            this.tempHPLabel.Location = new System.Drawing.Point(12, 141);
            this.tempHPLabel.Name = "tempHPLabel";
            this.tempHPLabel.Size = new System.Drawing.Size(52, 13);
            this.tempHPLabel.TabIndex = 6;
            this.tempHPLabel.Text = "Temp HP";
            // 
            // TempHPUpDown
            // 
            this.TempHPUpDown.Location = new System.Drawing.Point(108, 135);
            this.TempHPUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.TempHPUpDown.Name = "TempHPUpDown";
            this.TempHPUpDown.Size = new System.Drawing.Size(120, 20);
            this.TempHPUpDown.TabIndex = 5;
            this.TempHPUpDown.ValueChanged += new System.EventHandler(this.TempHPUpDown_ValueChanged);
            // 
            // escButton
            // 
            this.escButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.escButton.Location = new System.Drawing.Point(194, 179);
            this.escButton.Name = "escButton";
            this.escButton.Size = new System.Drawing.Size(75, 23);
            this.escButton.TabIndex = 7;
            this.escButton.Text = "escButton";
            this.escButton.UseVisualStyleBackColor = true;
            this.escButton.Visible = false;
            this.escButton.Click += new System.EventHandler(this.EscButton_Click);
            // 
            // HPForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.escButton;
            this.ClientSize = new System.Drawing.Size(293, 217);
            this.Controls.Add(this.escButton);
            this.Controls.Add(this.tempHPLabel);
            this.Controls.Add(this.TempHPUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maxHPLabel);
            this.Controls.Add(this.maxHPUpDown);
            this.Controls.Add(this.currentHPUpDown);
            this.Name = "HPForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.currentHPUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxHPUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempHPUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown currentHPUpDown;
        private System.Windows.Forms.NumericUpDown maxHPUpDown;
        private System.Windows.Forms.Label maxHPLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tempHPLabel;
        private System.Windows.Forms.NumericUpDown TempHPUpDown;
        private System.Windows.Forms.Button escButton;
    }
}