namespace InitiativeTracker
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
            this.endTurnButton = new System.Windows.Forms.Button();
            this.endCombatButton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.statuses = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.healthLabel = new System.Windows.Forms.Label();
            this.currentHealthLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.maxHealthLabel = new System.Windows.Forms.Label();
            this.changeHPUpDown = new System.Windows.Forms.NumericUpDown();
            this.changeHPButton = new System.Windows.Forms.Button();
            this.tempHealthLabel = new System.Windows.Forms.Label();
            this.tempHealthLabelVal = new System.Windows.Forms.Label();
            this.roundLabel = new System.Windows.Forms.Label();
            this.roundNumberLabel = new System.Windows.Forms.Label();
            this.textNextCharacter = new System.Windows.Forms.Label();
            this.nextCharacterLabel = new System.Windows.Forms.Label();
            this.hurtButton = new System.Windows.Forms.Button();
            this.updateStatusButton = new System.Windows.Forms.Button();
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
            this.currentCharacterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCharacterLabel.Location = new System.Drawing.Point(158, 9);
            this.currentCharacterLabel.Name = "currentCharacterLabel";
            this.currentCharacterLabel.Size = new System.Drawing.Size(51, 20);
            this.currentCharacterLabel.TabIndex = 1;
            this.currentCharacterLabel.Text = "label2";
            // 
            // endTurnButton
            // 
            this.endTurnButton.Location = new System.Drawing.Point(679, 367);
            this.endTurnButton.Name = "endTurnButton";
            this.endTurnButton.Size = new System.Drawing.Size(89, 44);
            this.endTurnButton.TabIndex = 2;
            this.endTurnButton.Text = "End Turn";
            this.endTurnButton.UseVisualStyleBackColor = true;
            this.endTurnButton.Click += new System.EventHandler(this.endTurnButton_Click);
            // 
            // endCombatButton
            // 
            this.endCombatButton.Location = new System.Drawing.Point(554, 367);
            this.endCombatButton.Name = "endCombatButton";
            this.endCombatButton.Size = new System.Drawing.Size(102, 44);
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
            this.listView1.Location = new System.Drawing.Point(32, 254);
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
            this.healthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthLabel.Location = new System.Drawing.Point(27, 65);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(80, 25);
            this.healthLabel.TabIndex = 7;
            this.healthLabel.Text = "Health:";
            // 
            // currentHealthLabel
            // 
            this.currentHealthLabel.AutoSize = true;
            this.currentHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentHealthLabel.Location = new System.Drawing.Point(126, 62);
            this.currentHealthLabel.Name = "currentHealthLabel";
            this.currentHealthLabel.Size = new System.Drawing.Size(26, 29);
            this.currentHealthLabel.TabIndex = 8;
            this.currentHealthLabel.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(158, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 39);
            this.label3.TabIndex = 9;
            this.label3.Text = "/";
            // 
            // maxHealthLabel
            // 
            this.maxHealthLabel.AutoSize = true;
            this.maxHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxHealthLabel.Location = new System.Drawing.Point(191, 62);
            this.maxHealthLabel.Name = "maxHealthLabel";
            this.maxHealthLabel.Size = new System.Drawing.Size(39, 29);
            this.maxHealthLabel.TabIndex = 10;
            this.maxHealthLabel.Text = "50";
            // 
            // changeHPUpDown
            // 
            this.changeHPUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeHPUpDown.Location = new System.Drawing.Point(564, 67);
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
            this.changeHPUpDown.Size = new System.Drawing.Size(83, 31);
            this.changeHPUpDown.TabIndex = 11;
            this.changeHPUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // changeHPButton
            // 
            this.changeHPButton.BackColor = System.Drawing.Color.White;
            this.changeHPButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeHPButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.changeHPButton.Location = new System.Drawing.Point(564, 30);
            this.changeHPButton.Name = "changeHPButton";
            this.changeHPButton.Size = new System.Drawing.Size(83, 31);
            this.changeHPButton.TabIndex = 12;
            this.changeHPButton.Text = "Heal";
            this.changeHPButton.UseVisualStyleBackColor = false;
            this.changeHPButton.Click += new System.EventHandler(this.changeHPButton_Click);
            // 
            // tempHealthLabel
            // 
            this.tempHealthLabel.AutoSize = true;
            this.tempHealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempHealthLabel.Location = new System.Drawing.Point(263, 71);
            this.tempHealthLabel.Name = "tempHealthLabel";
            this.tempHealthLabel.Size = new System.Drawing.Size(53, 20);
            this.tempHealthLabel.TabIndex = 13;
            this.tempHealthLabel.Text = "Temp:";
            // 
            // tempHealthLabelVal
            // 
            this.tempHealthLabelVal.AutoSize = true;
            this.tempHealthLabelVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempHealthLabelVal.Location = new System.Drawing.Point(328, 71);
            this.tempHealthLabelVal.Name = "tempHealthLabelVal";
            this.tempHealthLabelVal.Size = new System.Drawing.Size(51, 20);
            this.tempHealthLabelVal.TabIndex = 14;
            this.tempHealthLabelVal.Text = "label4";
            // 
            // roundLabel
            // 
            this.roundLabel.AutoSize = true;
            this.roundLabel.Location = new System.Drawing.Point(328, 6);
            this.roundLabel.Name = "roundLabel";
            this.roundLabel.Size = new System.Drawing.Size(82, 13);
            this.roundLabel.TabIndex = 15;
            this.roundLabel.Text = "Round Number:";
            // 
            // roundNumberLabel
            // 
            this.roundNumberLabel.AutoSize = true;
            this.roundNumberLabel.Location = new System.Drawing.Point(416, 6);
            this.roundNumberLabel.Name = "roundNumberLabel";
            this.roundNumberLabel.Size = new System.Drawing.Size(35, 13);
            this.roundNumberLabel.TabIndex = 16;
            this.roundNumberLabel.Text = "label4";
            // 
            // textNextCharacter
            // 
            this.textNextCharacter.AutoSize = true;
            this.textNextCharacter.Location = new System.Drawing.Point(329, 30);
            this.textNextCharacter.Name = "textNextCharacter";
            this.textNextCharacter.Size = new System.Drawing.Size(81, 13);
            this.textNextCharacter.TabIndex = 17;
            this.textNextCharacter.Text = "Next Character:";
            // 
            // nextCharacterLabel
            // 
            this.nextCharacterLabel.AutoSize = true;
            this.nextCharacterLabel.Location = new System.Drawing.Point(416, 30);
            this.nextCharacterLabel.Name = "nextCharacterLabel";
            this.nextCharacterLabel.Size = new System.Drawing.Size(35, 13);
            this.nextCharacterLabel.TabIndex = 18;
            this.nextCharacterLabel.Text = "label4";
            // 
            // hurtButton
            // 
            this.hurtButton.BackColor = System.Drawing.Color.White;
            this.hurtButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hurtButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.hurtButton.Location = new System.Drawing.Point(564, 104);
            this.hurtButton.Name = "hurtButton";
            this.hurtButton.Size = new System.Drawing.Size(83, 31);
            this.hurtButton.TabIndex = 19;
            this.hurtButton.Text = "Hurt";
            this.hurtButton.UseVisualStyleBackColor = false;
            this.hurtButton.Click += new System.EventHandler(this.hurtButton_Click);
            // 
            // updateStatusButton
            // 
            this.updateStatusButton.Location = new System.Drawing.Point(217, 365);
            this.updateStatusButton.Name = "updateStatusButton";
            this.updateStatusButton.Size = new System.Drawing.Size(98, 46);
            this.updateStatusButton.TabIndex = 20;
            this.updateStatusButton.Text = "Update Status Effect";
            this.updateStatusButton.UseVisualStyleBackColor = true;
            this.updateStatusButton.Click += new System.EventHandler(this.UpdateStatusButton_Click);
            // 
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(780, 423);
            this.ControlBox = false;
            this.Controls.Add(this.updateStatusButton);
            this.Controls.Add(this.hurtButton);
            this.Controls.Add(this.nextCharacterLabel);
            this.Controls.Add(this.textNextCharacter);
            this.Controls.Add(this.roundNumberLabel);
            this.Controls.Add(this.roundLabel);
            this.Controls.Add(this.tempHealthLabelVal);
            this.Controls.Add(this.tempHealthLabel);
            this.Controls.Add(this.changeHPButton);
            this.Controls.Add(this.changeHPUpDown);
            this.Controls.Add(this.maxHealthLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentHealthLabel);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.endCombatButton);
            this.Controls.Add(this.endTurnButton);
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
        private System.Windows.Forms.Button endTurnButton;
        private System.Windows.Forms.Button endCombatButton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader statuses;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.Label currentHealthLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label maxHealthLabel;
        private System.Windows.Forms.NumericUpDown changeHPUpDown;
        private System.Windows.Forms.Button changeHPButton;
        private System.Windows.Forms.Label tempHealthLabel;
        private System.Windows.Forms.Label tempHealthLabelVal;
        private System.Windows.Forms.Label roundLabel;
        private System.Windows.Forms.Label roundNumberLabel;
        private System.Windows.Forms.Label textNextCharacter;
        private System.Windows.Forms.Label nextCharacterLabel;
        private System.Windows.Forms.Button hurtButton;
        private System.Windows.Forms.Button updateStatusButton;
    }
}