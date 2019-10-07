namespace InitativeTracker
{
    partial class initativeForm
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
            this.components = new System.ComponentModel.Container();
            this.enterNameText = new System.Windows.Forms.Label();
            this.initativeText = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.initativeTextBox = new System.Windows.Forms.TextBox();
            this.enterButtonPC = new System.Windows.Forms.Button();
            this.itemViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.characterHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.initativeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enterCharacterTemp = new System.Windows.Forms.Button();
            this.EndCombatButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.itemViewContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // enterNameText
            // 
            this.enterNameText.AutoSize = true;
            this.enterNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterNameText.Location = new System.Drawing.Point(49, 40);
            this.enterNameText.Name = "enterNameText";
            this.enterNameText.Size = new System.Drawing.Size(222, 24);
            this.enterNameText.TabIndex = 0;
            this.enterNameText.Text = "Enter Name of Character:";
            // 
            // initativeText
            // 
            this.initativeText.AutoSize = true;
            this.initativeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initativeText.Location = new System.Drawing.Point(49, 92);
            this.initativeText.Name = "initativeText";
            this.initativeText.Size = new System.Drawing.Size(232, 24);
            this.initativeText.TabIndex = 1;
            this.initativeText.Text = "Enter Initative of Character:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(383, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(280, 26);
            this.nameTextBox.TabIndex = 2;
            // 
            // initativeTextBox
            // 
            this.initativeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initativeTextBox.Location = new System.Drawing.Point(383, 92);
            this.initativeTextBox.Name = "initativeTextBox";
            this.initativeTextBox.Size = new System.Drawing.Size(280, 26);
            this.initativeTextBox.TabIndex = 3;
            this.initativeTextBox.TextChanged += new System.EventHandler(this.InitativeTextBox_TextChanged);
            // 
            // enterButtonPC
            // 
            this.enterButtonPC.Enabled = false;
            this.enterButtonPC.Location = new System.Drawing.Point(108, 153);
            this.enterButtonPC.Name = "enterButtonPC";
            this.enterButtonPC.Size = new System.Drawing.Size(129, 23);
            this.enterButtonPC.TabIndex = 5;
            this.enterButtonPC.Text = "Enter Player Character";
            this.enterButtonPC.UseVisualStyleBackColor = true;
            this.enterButtonPC.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // itemViewContext
            // 
            this.itemViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.deleteCharacterToolStripMenuItem});
            this.itemViewContext.Name = "itemBoxContext";
            this.itemViewContext.Size = new System.Drawing.Size(162, 48);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.testToolStripMenuItem.Text = "Change Initative";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.ChangeInitative_Click);
            // 
            // deleteCharacterToolStripMenuItem
            // 
            this.deleteCharacterToolStripMenuItem.Name = "deleteCharacterToolStripMenuItem";
            this.deleteCharacterToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.deleteCharacterToolStripMenuItem.Text = "Delete Character";
            this.deleteCharacterToolStripMenuItem.Click += new System.EventHandler(this.DeleteCharacterToolStripMenuItem_Click);
            // 
            // listView
            // 
            this.listView.AllowColumnReorder = true;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.characterHeader,
            this.initativeHeader});
            this.listView.ContextMenuStrip = this.itemViewContext;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(108, 198);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(300, 200);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.ListView_ColumnWidthChanging);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.ListView_SelectedIndexChanged);
            // 
            // characterHeader
            // 
            this.characterHeader.Text = "Character";
            this.characterHeader.Width = 240;
            // 
            // initativeHeader
            // 
            this.initativeHeader.Text = "Initative";
            this.initativeHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.initativeHeader.Width = 55;
            // 
            // enterCharacterTemp
            // 
            this.enterCharacterTemp.Enabled = false;
            this.enterCharacterTemp.Location = new System.Drawing.Point(285, 153);
            this.enterCharacterTemp.Name = "enterCharacterTemp";
            this.enterCharacterTemp.Size = new System.Drawing.Size(123, 23);
            this.enterCharacterTemp.TabIndex = 7;
            this.enterCharacterTemp.Text = "Enter Temp. Character";
            this.enterCharacterTemp.UseVisualStyleBackColor = true;
            this.enterCharacterTemp.Click += new System.EventHandler(this.EnterCharacterTemp_Click);
            // 
            // EndCombatButton
            // 
            this.EndCombatButton.Location = new System.Drawing.Point(503, 375);
            this.EndCombatButton.Name = "EndCombatButton";
            this.EndCombatButton.Size = new System.Drawing.Size(75, 23);
            this.EndCombatButton.TabIndex = 8;
            this.EndCombatButton.Text = "End Combat";
            this.EndCombatButton.UseVisualStyleBackColor = true;
            this.EndCombatButton.Click += new System.EventHandler(this.EndCombatButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Roll Initative!";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(630, 203);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // initativeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EndCombatButton);
            this.Controls.Add(this.enterCharacterTemp);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.enterButtonPC);
            this.Controls.Add(this.initativeTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.initativeText);
            this.Controls.Add(this.enterNameText);
            this.Name = "initativeForm";
            this.Text = "Initative Tracker";
            this.itemViewContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterNameText;
        private System.Windows.Forms.Label initativeText;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox initativeTextBox;
        private System.Windows.Forms.Button enterButtonPC;
        private System.Windows.Forms.ContextMenuStrip itemViewContext;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCharacterToolStripMenuItem;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader characterHeader;
        private System.Windows.Forms.ColumnHeader initativeHeader;
        private System.Windows.Forms.Button enterCharacterTemp;
        private System.Windows.Forms.Button EndCombatButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

