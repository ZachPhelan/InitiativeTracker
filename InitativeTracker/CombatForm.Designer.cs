namespace InitativeTracker
{
    partial class CombatForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.currentCharacterLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.endCombatButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.statuses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.healthLabel = new System.Windows.Forms.Label();
            this.currentHealthLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxHealthLabel = new System.Windows.Forms.Label();
            this.changeHPUpDown = new System.Windows.Forms.NumericUpDown();
            this.changeHPButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.changeHPUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Character:";
            // 
            // currentCharacterLabel
            // 
            this.currentCharacterLabel.AutoSize = true;
            this.currentCharacterLabel.Location = new System.Drawing.Point(177, 13);
            this.currentCharacterLabel.Name = "currentCharacterLabel";
            this.currentCharacterLabel.Size = new System.Drawing.Size(35, 13);
            this.currentCharacterLabel.TabIndex = 1;
            this.currentCharacterLabel.Text = "label2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 295);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "End Tiurn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status Effects:";
            // 
            // endCombatButton
            // 
            this.endCombatButton.Location = new System.Drawing.Point(579, 295);
            this.endCombatButton.Name = "endCombatButton";
            this.endCombatButton.Size = new System.Drawing.Size(104, 23);
            this.endCombatButton.TabIndex = 5;
            this.endCombatButton.Text = "Switch To Main";
            this.endCombatButton.UseVisualStyleBackColor = true;
            this.endCombatButton.Click += new System.EventHandler(this.EndCombatButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.statuses});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(123, 161);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(179, 157);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // statuses
            // 
            this.statuses.Text = "Status Effect";
            this.statuses.Width = 174;
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Location = new System.Drawing.Point(64, 65);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(41, 13);
            this.healthLabel.TabIndex = 7;
            this.healthLabel.Text = "Health:";
            // 
            // currentHealthLabel
            // 
            this.currentHealthLabel.AutoSize = true;
            this.currentHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentHealthLabel.Location = new System.Drawing.Point(175, 53);
            this.currentHealthLabel.Name = "currentHealthLabel";
            this.currentHealthLabel.Size = new System.Drawing.Size(26, 29);
            this.currentHealthLabel.TabIndex = 8;
            this.currentHealthLabel.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(207, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 42);
            this.label3.TabIndex = 9;
            this.label3.Text = "/";
            // 
            // maxHealthLabel
            // 
            this.maxHealthLabel.AutoSize = true;
            this.maxHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHealthLabel.Location = new System.Drawing.Point(241, 66);
            this.maxHealthLabel.Name = "maxHealthLabel";
            this.maxHealthLabel.Size = new System.Drawing.Size(39, 29);
            this.maxHealthLabel.TabIndex = 10;
            this.maxHealthLabel.Text = "50";
            // 
            // changeHPUpDown
            // 
            this.changeHPUpDown.Location = new System.Drawing.Point(498, 66);
            this.changeHPUpDown.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.changeHPUpDown.Minimum = new decimal(new int[] {
            9999,
            0,
            0,
            -2147483648});
            this.changeHPUpDown.Name = "changeHPUpDown";
            this.changeHPUpDown.Size = new System.Drawing.Size(48, 20);
            this.changeHPUpDown.TabIndex = 11;
            // 
            // changeHPButton
            // 
            this.changeHPButton.Location = new System.Drawing.Point(579, 66);
            this.changeHPButton.Name = "changeHPButton";
            this.changeHPButton.Size = new System.Drawing.Size(75, 23);
            this.changeHPButton.TabIndex = 12;
            this.changeHPButton.Text = "Change HP";
            this.changeHPButton.UseVisualStyleBackColor = true;
            this.changeHPButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(728, 378);
            this.ControlBox = false;
            this.Controls.Add(this.changeHPButton);
            this.Controls.Add(this.changeHPUpDown);
            this.Controls.Add(this.maxHealthLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentHealthLabel);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.endCombatButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentCharacterLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CombatForm";
            this.Text = "Combat Info";
            ((System.ComponentModel.ISupportInitialize)(this.changeHPUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentCharacterLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button endCombatButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader statuses;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label currentHealthLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label maxHealthLabel;
        private System.Windows.Forms.NumericUpDown changeHPUpDown;
        private System.Windows.Forms.Button changeHPButton;
    }
}