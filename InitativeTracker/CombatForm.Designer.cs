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
            this.button1.Location = new System.Drawing.Point(510, 295);
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
            this.label2.Location = new System.Drawing.Point(13, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status Effects:";
            // 
            // endCombatButton
            // 
            this.endCombatButton.Location = new System.Drawing.Point(613, 295);
            this.endCombatButton.Name = "endCombatButton";
            this.endCombatButton.Size = new System.Drawing.Size(75, 23);
            this.endCombatButton.TabIndex = 5;
            this.endCombatButton.Text = "End Combat";
            this.endCombatButton.UseVisualStyleBackColor = true;
            this.endCombatButton.Click += new System.EventHandler(this.EndCombatButton_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.statuses});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(136, 78);
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
            // CombatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 374);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.endCombatButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.currentCharacterLabel);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CombatForm";
            this.Text = "Combat Info";
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
    }
}