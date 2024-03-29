﻿using InitiativeTracker;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.ListView;

namespace InitiativeTracker
{

    public partial class initiativeForm : Form
    {

        //CombatForm combatForm;

        public initiativeForm()
        {
            InitializeComponent();

            GlobalData.characterList = new List<Character>();
            GlobalData.roundNum = 1;
            

            GlobalData.characterList.Add(new Character(10, "Galadan", true));
            GlobalData.characterList.Add(new Character(5, "NPC"));

            GlobalData.characterList.Add(new Character(15, "Rosi", true));

            GlobalData.characterList.Add(new Character(20, "Onru", true));

            //CombatForm combatForm = new CombatForm(ShowAllOnMain);

            //combatForm.Show();
            
            RedrawItemBox();
        }

        


        private void EnterButton_Click(object sender, EventArgs e)
        {
            AddCharacterToList(nameTextBox.Text.Trim(), true);

            nameTextBox.Text = "";

            nameTextBox.Focus();

            RedrawItemBox();
        }

        public void AddCharacterToList(string characterName, bool isPC)
        {

            int modifier = ParseNameForModifier(characterName);

            if (modifier != 0)
                characterName = characterName.Substring(0, characterName.Length - 3);

            Character newChar = new Character(0, modifier, characterName, isPC);



            GlobalData.characterList.Add(newChar);
        }

        public void AddCharacterToList(string characterName, int initiative, int modifier, bool isPC)
        {
            if (modifier == 0)
            {
                modifier = ParseNameForModifier(characterName);
                characterName = characterName.Substring(0, characterName.Length - 3);
            }
               
            Character newChar = new Character(0, modifier, characterName, isPC);

            GlobalData.characterList.Add(newChar);
        }

        private void ChangeInitative_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;

            foreach (ListViewItem character in characters)
            {
                string promptValue = Prompt.ShowDialog("Changing " + character.Text + "'s initative.", "Change Initative");

                bool didParse = Int32.TryParse(promptValue, out int parsed);

                if (!didParse)
                {
                    if (promptValue == "")
                    {
                        continue;
                    }

                    MessageBox.Show("Entered initiatve must be an integer.");
                    continue;
                }

                DeleteCharacterWithGivenName(character.Text);

                Character newChar = new Character(parsed, character.Text);

                GlobalData.characterList.Add(newChar);

            }
            RedrawItemBox();
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private void DeleteCharacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;
            StringBuilder sb = new StringBuilder();
            sb.Append("Are you sure you want to delete the selected character(s)? \n \n");

            foreach (ListViewItem character in characters)
            {
                sb.Append(character.Text + "\n");
            }
            string message = sb.ToString();
            string caption = "Character deletion";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;



            result = MessageBox.Show(this, message, caption, buttons,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            else
            {
                foreach (ListViewItem character in characters)
                {
                    DeleteCharacterWithGivenName(character.Text);


                    // changes the combat index if a character is deleted mid-battle.
                    GlobalData.combatIndex--;

                    if (GlobalData.combatIndex < 0)
                        GlobalData.combatIndex = GlobalData.characterList.Count - 1;
                }

                RedrawItemBox();
            }

        }


        private void RedrawItemBox()
        {
            GlobalData.characterList.Sort();
            listView.Items.Clear();

            foreach (Character character in GlobalData.characterList)
            {
                string[] items = new string[] { character.Name.ToString(), character.Initiative.ToString() };
                ListViewItem item = new ListViewItem(items);
                listView.Items.Add(item);
                
            }
        }

        public int FindCharacterByName(string characterName)
        {
            foreach (Character character in GlobalData.characterList)
            {
                if (character.Name == characterName)
                {
                    return GlobalData.characterList.IndexOf(character);
                }
            }

            return -1;
        }

        public void DeleteCharacterWithGivenName(string characterName)
        {
            int index = FindCharacterByName(characterName);

            if (index == -1)
                throw new IndexOutOfRangeException();

            GlobalData.characterList.RemoveAt(index);
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }

        private void EnterCharacterTemp_Click(object sender, EventArgs e)
        {
            AddCharacterToList(nameTextBox.Text.Trim(), false);

            nameTextBox.Text = "";

            nameTextBox.Focus();

            RedrawItemBox();
        }

        private void EndCombatButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, "Are you sure you want to end combat?", "Ending Combat", buttons,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                return;
            }

            else
            {
                initiativeButton.Text = "Roll Initative!";

                ArrayList removeList = new ArrayList();

                foreach (Character character in GlobalData.characterList)
                {
                    if (character.IsPlayerCharacter)
                    {
                        character.Initiative = 0;
                    }
                    else
                    {
                        removeList.Add(character);
                    }
                }

                foreach (Character character in removeList)
                {
                    GlobalData.characterList.Remove(character);
                }

                GlobalData.combatIndex = 0;
                GlobalData.roundNum = 1;
                GlobalData.combatOn = false;

                RedrawItemBox();
                initiativeButton.Enabled = true;
            }

           
        }

        private void InitativeButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();

            CombatForm combatForm;

            if (GlobalData.combatOn)
            {
                HideAllOnMain();

                this.IsMdiContainer = true;

                //combatForm.TopLevel = false;

                combatForm = new CombatForm(ShowAllOnMain);

                combatForm.MdiParent = this;

                combatForm.Show();

                return;
            }

            if (checkBoxRollNonPc.Checked)
            {
                foreach (Character character in GlobalData.characterList)
                {
                    if (character.IsPlayerCharacter) // Manually enter PC's initative
                    {
                        string promptValue = Prompt.ShowDialog("Changing " + character.Name + "'s initative.", "Change Initative");

                        bool didParse = Int32.TryParse(promptValue, out int parsed);

                        if (!didParse)
                        {
                            if (promptValue == "")
                            {
                                continue;
                            }

                            MessageBox.Show("Entered initiatve must be an integer."); // should change this to not allow non-ints, rather than returning
                            return;
                        }

                        int index = GlobalData.characterList.IndexOf(character);
                        int initiativeModifier = GlobalData.characterList[index].InitiativeModifier;

                        if (checkboxModForPCs.Checked)
                            parsed += initiativeModifier;

                        GlobalData.characterList[index].Initiative = parsed;

                    }

                    else // roll for NPCS
                    {
                        int num = rnd.Next(1, 21) + character.InitiativeModifier; // Rolls a d20 for npc.

                        int index = GlobalData.characterList.IndexOf(character);

                        GlobalData.characterList[index].Initiative = num;

                    }
                }

            }

            else
            {
                foreach (Character character in GlobalData.characterList)
                {
                    string promptValue = Prompt.ShowDialog("Changing " + character.Name + "'s initative.", "Change Initative");

                    bool didParse = Int32.TryParse(promptValue, out int parsed);

                    if (!didParse)
                    {
                        if (promptValue == "")
                        {
                            continue;
                        }

                        MessageBox.Show("Entered initiatve must be an integer."); // should change this to not allow non-ints, rather than returning
                        return;
                    }

                    int index = GlobalData.characterList.IndexOf(character);
                    int initiativeModifier = GlobalData.characterList[index].InitiativeModifier;

                    if (character.IsPlayerCharacter)
                    {
                        if (checkboxModForPCs.Checked)
                        {
                            parsed += initiativeModifier;
                        }
                    }
                    else
                        parsed += initiativeModifier;

                    GlobalData.characterList[index].Initiative = parsed;

                }
            }

            initiativeButton.Text = "Resume combat";
            GlobalData.combatOn = true;

            RedrawItemBox();

            HideAllOnMain();

            this.IsMdiContainer = true;


            //combatForm.TopLevel = false;
            combatForm = new CombatForm(ShowAllOnMain);

            combatForm.MdiParent = this;

            combatForm.Show();
        }

        //public static class CombatPrompt
        //{
        //    public static string ShowDialog(string text, string caption)
        //    {
        //        Form prompt = new Form()
        //        {
        //            Width = 500,
        //            Height = 150,
        //            FormBorderStyle = FormBorderStyle.FixedDialog,
        //            Text = caption,
        //            StartPosition = FormStartPosition.CenterScreen
        //        };
        //        Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
        //        TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200 };
        //        Button confirmation = new Button() { Text = "Next", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
        //        confirmation.Click += (sender, e) => { prompt.Close(); };
        //        prompt.Controls.Add(textBox);
        //        prompt.Controls.Add(confirmation);
        //        prompt.Controls.Add(textLabel);
        //        prompt.AcceptButton = confirmation;

        //        return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        //    }
        //}

        private int ParseNameForModifier(string characterName)
        {
            int num;

            if (characterName.Length < 4)
                return 0;

            if (Regex.IsMatch(characterName, "('+')[0-5]$"))
            {
                num = Int32.Parse(characterName[characterName.Length - 1].ToString());

                return num;
            }

            else if (Regex.IsMatch(characterName, "(-)[0-5]$"))
            {
                num = Int32.Parse(characterName[characterName.Length - 1].ToString()) * -1;

                return num;
            }

            else if (Regex.IsMatch(characterName, "[0-5]$"))
            {
                num = Int32.Parse((characterName[characterName.Length - 1].ToString()));

                return num;
            }

            else
            {
                return 0;
            }
        }

        private void ChangeInitativeModifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;

            foreach (ListViewItem character in characters)
            {
                string promptValue = Prompt.ShowDialog("Changing " + character.Text + "'s initative modifier.", "Change Initative Modifier");

                int newVal = ParseNameForModifier(promptValue);

                    if (promptValue == "")
                    {
                        continue;
                    }
                

                int index = FindCharacterByName(character.Text);

                if (index == -1)
                    throw new IndexOutOfRangeException();

                GlobalData.characterList[index].InitiativeModifier = newVal;
            }
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;

            String s = "";

            foreach (ListViewItem character in characters)
            {
                s = character.Text;
            }

            if (s == "")
                return;

            int index = FindCharacterByName(s);
            int initiativeMod = GlobalData.characterList[index].InitiativeModifier;
            initiativeModifierUpDown.Value = initiativeMod;
        }

        private void InitiativeModifierUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;

            foreach (ListViewItem character in characters)
            {
                
                int index = FindCharacterByName(character.Text);

                GlobalData.characterList[index].InitiativeModifier = Int32.Parse(initiativeModifierUpDown.Value.ToString());
            }
        }

        private void ListView_ItemMouseHover(object sender, ListViewItemMouseHoverEventArgs e)
        {
            ListViewItemCollection characters = listView.Items;

            foreach (ListViewItem character in characters)
            {
                Character characterInList = GlobalData.characterList[FindCharacterByName(character.Text)];

                StringBuilder sb = new StringBuilder();

                sb.Append("Status effects: ");
                bool changed = false;

                foreach (KeyValuePair<string, int> status in characterInList.StatusEffects)
                {
                    if (status.Value > 0)
                    {
                        if (status.Key == "Exhaustion")
                        {
                            sb.Append(status.Key + " = " + status.Value + " ");
                        }
                        else
                        {
                            sb.Append(status.Key + ", ");
                        }
                        
                        changed = true;
                    }
                }

                if (changed)
                {
                    sb.Remove(sb.Length - 2, 2);
                    sb.Append(".");
                }

                if (!changed)
                    sb.Append("None");

                character.ToolTipText = sb.ToString().Trim();
            }

           listView.ShowItemToolTips = true;

        }
    
        private void HideAllOnMain()
        {
            listView.Hide();
            enterButtonPC.Hide();
            enterCharacterTemp.Hide();
            nameTextBox.Hide();
            enterNameText.Hide();
            checkBoxRollNonPc.Hide();
            checkboxModForPCs.Hide();
            initiativeModText.Hide();
            initiativeModifierUpDown.Hide();
            initiativeButton.Hide();
            EndCombatButton.Hide();
        }

        public void ShowAllOnMain(bool doesntMatter)
        {
            listView.Show();
            enterButtonPC.Show();
            enterCharacterTemp.Show();
            nameTextBox.Show();
            enterNameText.Show();
            checkBoxRollNonPc.Show();
            checkboxModForPCs.Show();
            initiativeModText.Show();
            initiativeModifierUpDown.Show();
            initiativeButton.Show();
            EndCombatButton.Show();

            if (GlobalData.combatOn)
                EndCombatButton.Enabled = true;

            else
                EndCombatButton.Enabled = false;

            this.IsMdiContainer = false;
        }


        // Saving and loading

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "\t",
                NewLineOnAttributes = true
            };

            saveFileDialog.Filter = "Initiative Tracker|*.tra";
            saveFileDialog.ShowDialog();

            string filename = saveFileDialog.FileName;


            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("initiative-tracker");

                writer.WriteStartElement("characters");
                foreach (Character c in GlobalData.characterList)
                {
                    writer.WriteStartElement("character");

                    writer.WriteElementString("name", c.Name);
                    writer.WriteElementString("initiative", c.Initiative.ToString());
                    writer.WriteElementString("initiative-modifier", c.InitiativeModifier.ToString());
                    writer.WriteElementString("player-character", c.IsPlayerCharacter.ToString());
                    writer.WriteElementString("current-HP", c.currentHP.ToString());
                    writer.WriteElementString("max-HP", c.maxHP.ToString());
                    writer.WriteElementString("temp-HP", c.tempHP.ToString());

                    bool changed = false;
                    Dictionary<string, int> tempDict = new Dictionary<string, int>();

                    foreach (KeyValuePair<string, int> status in c.StatusEffects)
                    {

                        if (status.Value > 0)
                        {
                            tempDict.Add(status.Key, status.Value);
                            
                            changed = true;
                        }
                          
                    }

                    if (changed)
                    {
                        writer.WriteStartElement("statuse-effects");
                        StringBuilder sb = new StringBuilder();

                        foreach (KeyValuePair<string, int> status in tempDict)
                        {
                            sb.Append(status.Key + " = " + status.Value + ", ");
                        }

                        //sb.Remove(sb.Length - 2, 2);

                        string stringBuilder = sb.ToString();

                        if (stringBuilder.Length > 0)
                            writer.WriteString(stringBuilder);

                        else
                            writer.WriteString("none");


                        writer.WriteEndElement();

                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();

                writer.WriteEndElement();
                writer.WriteEndDocument();

            }

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            GlobalData.characterList.Clear();

            if (openFileDialog.FileName != "")
            {

                using (XmlReader reader = XmlReader.Create(openFileDialog.FileName))
                {
                    string name = "";
                    int initiative = 0;
                    int initiativeModifier = 0;
                    bool PC = false;
                    int currentHP = 0;
                    int maxHP = 0;
                    int tempHP = 0;
                    Dictionary<string, int> statusEffects = new Dictionary<string, int>();

                    bool firstCharacter = true;


                    while (reader.Read())
                    {

                        if (reader.IsStartElement())
                        {
                            switch (reader.Name)
                            {

                                case "name":
                                    reader.Read();
                                    name = reader.Value;
                                    break;

                                case "initiative":
                                    reader.Read();
                                    initiative = Int32.Parse(reader.Value);
                                    break;

                                case "initiative-modifier":
                                    reader.Read();
                                    initiativeModifier = Int32.Parse(reader.Value);
                                    break;

                                case "player-character":
                                    reader.Read();
                                    PC = bool.Parse(reader.Value);
                                    break;

                                case "current-HP":
                                    reader.Read();
                                    currentHP = Int32.Parse(reader.Value);
                                    break;

                                case "max-HP":
                                    reader.Read();
                                    maxHP = Int32.Parse(reader.Value);
                                    break;

                                case "temp-HP":
                                    reader.Read();
                                    tempHP = Int32.Parse(reader.Value);
                                    break;


                                case "status-effects":
                                    reader.Read();
                                    string s = reader.Value;

                                    statusEffects = ParseStatusEffectForLoading(s);
                                    break;

                            }
                        }
                        else
                        {
                            if (reader.Name == "character")
                            {
                                Character character = new Character(initiative, initiativeModifier, name, PC, currentHP, maxHP, tempHP, statusEffects);
                                GlobalData.characterList.Add(character);

                            }

                        }


                    }
                }

                RedrawItemBox();
            }
        }

        private Dictionary<string, int> ParseStatusEffectForLoading(string s)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();


            if (s == "empty")
                return null;

            return dict;
        }



        private void StatusEffectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;

            foreach (ListViewItem character in characters)
            {
                int currentCharacter = FindCharacterByName(character.Text);
                GlobalData.currentCharacterForStatusEffects = currentCharacter;

                StatusEffectForm statusForm = new StatusEffectForm();
                statusForm.Show();
            }
        }

        private void SetHPToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SelectedListViewItemCollection characters = listView.SelectedItems;

            this.Enabled = false;

            foreach (ListViewItem character in characters)
            {
                Character characterInList = GlobalData.characterList[FindCharacterByName(character.Text)];

                //HPForm hpform = new HPForm(characterInList);

                

                using (HPForm hpForm = new HPForm(characterInList))
                {
                    hpForm.ShowDialog();
                }
                
            }

            this.Enabled = true;
            
        }

        private void InitiativeForm_Load(object sender, EventArgs e)
        {
            
        }


    }
}
