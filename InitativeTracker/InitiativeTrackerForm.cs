using InitativeTracker;
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

        //List<Character> characterList;

        bool initativeOn = false;

        public initiativeForm()
        {
            InitializeComponent();

            GlobalData.characterList = new List<Character>();

            

            GlobalData.characterList.Add(new Character(10, "Galadan", true));
            GlobalData.characterList.Add(new Character(5, "NPC"));

            GlobalData.characterList.Add(new Character(15, "Rosi", true));

            GlobalData.characterList.Add(new Character(20, "Onru", true));

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

        public void AddCharacterToList(string characterName, int initi, int modifier, bool isPC)
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
            GlobalData.combatOn = false;

            RedrawItemBox();
            initiativeButton.Enabled = true;
        }

        private void InitativeButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            initiativeButton.Text = "Resume combat";

            if (GlobalData.combatOn)
            {
                HideAllOnMain();

                this.IsMdiContainer = true;

                CombatForm form = new CombatForm(ShowAllOnMain);

                //combatForm.TopLevel = false;

                form.MdiParent = this;

                form.Show();

                return;
            }

            GlobalData.combatOn = true;



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



            RedrawItemBox();

            HideAllOnMain();

            this.IsMdiContainer = true;

            CombatForm combatForm = new CombatForm(ShowAllOnMain);

            //combatForm.TopLevel = false;

            combatForm.MdiParent = this;

            combatForm.Show();
        }


        /// <summary>
        /// Should track who is next in combat. Will open a dialog box showing status effects and other information on each turn. 
        /// </summary>
        //private void CombatTracker()
        //{
        //    GlobalData.combatIndex = 0;
        //    GlobalData.combatOn = true;

        //    initiativeButton.Enabled = false;

        //    while (GlobalData.combatOn)
        //    {
        //        Character currentCharacter = GlobalData.characterList[GlobalData.combatIndex];

        //        listView.Items[GlobalData.combatIndex].Selected = true;

        //        List<string> tempList = new List<string>();
        //        StringBuilder sb = new StringBuilder();

        //        foreach (KeyValuePair<string, int> status in currentCharacter.StatusEffects)
        //        {
        //            if (status.Value > 0)
        //            {
        //                tempList.Add(status.Key);
        //            }
        //        }

        //        GlobalData.currentCombatCharacter = GlobalData.characterList[GlobalData.combatIndex];


        //        CombatForm combatForm = new CombatForm();

        //    }

        //    initiativeButton.Enabled = true;
        //}

        public static class CombatPrompt
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
                Button confirmation = new Button() { Text = "Next", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        private int ParseNameForModifier(string characterName)
        {
            int num;
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

            this.IsMdiContainer = false;
        }


        // Saving and loading

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                //NewLineOnAttributes = true
            };

            saveFileDialog.Filter = "Initiative Tracker|*.tra";
            saveFileDialog.ShowDialog();

            string filename = saveFileDialog.FileName;


            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("initiative-tracker");

                foreach (Character c in GlobalData.characterList)
                {
                    writer.WriteStartElement("character");
                    writer.WriteAttributeString("name", c.Name);
                    writer.WriteAttributeString("initiative", c.Initiative.ToString());
                    writer.WriteAttributeString("initiative-modifier", c.InitiativeModifier.ToString());
                    writer.WriteAttributeString("player-character", c.IsPlayerCharacter.ToString());
                    writer.WriteEndElement();
                }


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

                XmlReader reader = XmlReader.Create(openFileDialog.FileName);
                string characterName = "";
                int initiative = 0;
                int initiativeModifier = 0;
                bool isPC = false;

                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {

                        if (reader.Name == "character")

                        {
                            characterName = reader["name"];
                            initiative = Int32.Parse(reader["initiative"]);
                            initiativeModifier = Int32.Parse(reader["initiative-modifier"]);
                            if (reader["player-character"] == "True")
                                isPC = true;

                            else
                                isPC = false;

                            AddCharacterToList(characterName, initiative, initiativeModifier, isPC);
                        }
                            
                    }
                }

                RedrawItemBox();
            }
        }

        private void StatusEffectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;

            String s = "";

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

            foreach (ListViewItem character in characters)
            {
                Character characterInList = GlobalData.characterList[FindCharacterByName(character.Text)];

                HPForm hpform = new HPForm(characterInList);

                hpform.Show();
            }
            
        }
    }
}
