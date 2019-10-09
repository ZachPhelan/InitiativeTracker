namespace InitiativeTracker
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.enterButtonPC = new System.Windows.Forms.Button();
            this.itemViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCharacterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeInitativeModifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView = new System.Windows.Forms.ListView();
            this.characterHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.initativeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enterCharacterTemp = new System.Windows.Forms.Button();
            this.EndCombatButton = new System.Windows.Forms.Button();
            this.initativeButton = new System.Windows.Forms.Button();
            this.checkBoxRollNonPc = new System.Windows.Forms.CheckBox();
            this.initiativeModifierUpDown = new System.Windows.Forms.NumericUpDown();
            this.checkboxModForPCs = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.itemViewContext.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initiativeModifierUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
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
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(383, 40);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(280, 26);
            this.nameTextBox.TabIndex = 2;
            // 
            // enterButtonPC
            // 
            this.enterButtonPC.Location = new System.Drawing.Point(383, 72);
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
            this.deleteCharacterToolStripMenuItem,
            this.changeInitativeModifierToolStripMenuItem});
            this.itemViewContext.Name = "itemBoxContext";
            this.itemViewContext.Size = new System.Drawing.Size(209, 70);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.testToolStripMenuItem.Text = "Change Initative";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.ChangeInitative_Click);
            // 
            // deleteCharacterToolStripMenuItem
            // 
            this.deleteCharacterToolStripMenuItem.Name = "deleteCharacterToolStripMenuItem";
            this.deleteCharacterToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.deleteCharacterToolStripMenuItem.Text = "Delete Character";
            this.deleteCharacterToolStripMenuItem.Click += new System.EventHandler(this.DeleteCharacterToolStripMenuItem_Click);
            // 
            // changeInitativeModifierToolStripMenuItem
            // 
            this.changeInitativeModifierToolStripMenuItem.Name = "changeInitativeModifierToolStripMenuItem";
            this.changeInitativeModifierToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.changeInitativeModifierToolStripMenuItem.Text = "Change Initative Modifier";
            this.changeInitativeModifierToolStripMenuItem.Click += new System.EventHandler(this.ChangeInitativeModifierToolStripMenuItem_Click);
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
            this.listView.Location = new System.Drawing.Point(53, 131);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(444, 307);
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
            this.enterCharacterTemp.Location = new System.Drawing.Point(530, 72);
            this.enterCharacterTemp.Name = "enterCharacterTemp";
            this.enterCharacterTemp.Size = new System.Drawing.Size(123, 23);
            this.enterCharacterTemp.TabIndex = 7;
            this.enterCharacterTemp.Text = "Enter NPC";
            this.enterCharacterTemp.UseVisualStyleBackColor = true;
            this.enterCharacterTemp.Click += new System.EventHandler(this.EnterCharacterTemp_Click);
            // 
            // EndCombatButton
            // 
            this.EndCombatButton.Location = new System.Drawing.Point(691, 415);
            this.EndCombatButton.Name = "EndCombatButton";
            this.EndCombatButton.Size = new System.Drawing.Size(75, 23);
            this.EndCombatButton.TabIndex = 8;
            this.EndCombatButton.Text = "End Combat";
            this.EndCombatButton.UseVisualStyleBackColor = true;
            this.EndCombatButton.Click += new System.EventHandler(this.EndCombatButton_Click);
            // 
            // initativeButton
            // 
            this.initativeButton.Location = new System.Drawing.Point(513, 415);
            this.initativeButton.Name = "initativeButton";
            this.initativeButton.Size = new System.Drawing.Size(89, 23);
            this.initativeButton.TabIndex = 9;
            this.initativeButton.Text = "Roll Initative!";
            this.initativeButton.UseVisualStyleBackColor = true;
            this.initativeButton.Click += new System.EventHandler(this.InitativeButton_Click);
            // 
            // checkBoxRollNonPc
            // 
            this.checkBoxRollNonPc.AutoSize = true;
            this.checkBoxRollNonPc.Location = new System.Drawing.Point(513, 131);
            this.checkBoxRollNonPc.Name = "checkBoxRollNonPc";
            this.checkBoxRollNonPc.Size = new System.Drawing.Size(160, 17);
            this.checkBoxRollNonPc.TabIndex = 10;
            this.checkBoxRollNonPc.Text = "Automatically Roll for NPCs?";
            this.checkBoxRollNonPc.UseVisualStyleBackColor = true;
            // 
            // initiativeModifierUpDown
            // 
            this.initiativeModifierUpDown.Location = new System.Drawing.Point(513, 389);
            this.initiativeModifierUpDown.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.initiativeModifierUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.initiativeModifierUpDown.Name = "initiativeModifierUpDown";
            this.initiativeModifierUpDown.Size = new System.Drawing.Size(120, 20);
            this.initiativeModifierUpDown.TabIndex = 11;
            this.initiativeModifierUpDown.ValueChanged += new System.EventHandler(this.InitiativeModifierUpDown_ValueChanged);
            // 
            // checkboxModForPCs
            // 
            this.checkboxModForPCs.AutoSize = true;
            this.checkboxModForPCs.Location = new System.Drawing.Point(513, 154);
            this.checkboxModForPCs.Name = "checkboxModForPCs";
            this.checkboxModForPCs.Size = new System.Drawing.Size(170, 17);
            this.checkboxModForPCs.TabIndex = 12;
            this.checkboxModForPCs.Text = "Add Initiative Modifier for PCs?";
            this.checkboxModForPCs.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // initativeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkboxModForPCs);
            this.Controls.Add(this.initiativeModifierUpDown);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.checkBoxRollNonPc);
            this.Controls.Add(this.initativeButton);
            this.Controls.Add(this.EndCombatButton);
            this.Controls.Add(this.enterCharacterTemp);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.enterButtonPC);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.enterNameText);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "initativeForm";
            this.Text = "Initative Tracker";
            this.itemViewContext.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.initiativeModifierUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enterNameText;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Button enterButtonPC;
        private System.Windows.Forms.ContextMenuStrip itemViewContext;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCharacterToolStripMenuItem;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader characterHeader;
        private System.Windows.Forms.ColumnHeader initativeHeader;
        private System.Windows.Forms.Button enterCharacterTemp;
        private System.Windows.Forms.Button EndCombatButton;
        private System.Windows.Forms.Button initativeButton;
        private System.Windows.Forms.CheckBox checkBoxRollNonPc;
        private System.Windows.Forms.ToolStripMenuItem changeInitativeModifierToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown initiativeModifierUpDown;
        private System.Windows.Forms.CheckBox checkboxModForPCs;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

