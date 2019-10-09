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
    public partial class initativeForm : Form
    {

        List<Character> characterList;
  
        bool initativeOn = false;

        public initativeForm()
        {
            InitializeComponent();

            characterList = new List<Character>();

            

            characterList.Add(new Character(10, "Galadan", true));
            characterList.Add(new Character(5, "NPC"));

            characterList.Add(new Character(15, "Rosi", true));

            characterList.Add(new Character(20, "Onru", true));

            RedrawItemBox();

        }


        private void EnterButton_Click(object sender, EventArgs e)
        {
            AddCharacterToList(nameTextBox.Text.Trim(), true);

            nameTextBox.Text = "";
            //initativeTextBox.Text = "";

            nameTextBox.Focus();

            RedrawItemBox();

        }

        public void AddCharacterToList(string characterName, bool isPC)
        {
            Character newChar = new Character(0, characterName, isPC);

            characterList.Add(newChar);
        }

        public void AddCharacterToList(string characterName, int initi, int modifier, bool isPC)
        {
            Character newChar = new Character(initi, characterName, isPC);
            newChar.InitiativeModifier = modifier;
            characterList.Add(newChar);
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

                characterList.Add(newChar);

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
            
            foreach (ListViewItem character in characters)
            {
                DeleteCharacterWithGivenName(character.Text);
            }

            RedrawItemBox();
        }


        private void RedrawItemBox()
        {
            characterList.Sort();
            listView.Items.Clear();

            

            foreach (Character character in characterList)
            {
                string[] items = new string[] { character.Name.ToString(), character.Initiative.ToString() };
                ListViewItem item = new ListViewItem(items);
                listView.Items.Add(item);
                
            }
        }


        public class Character : IComparable
        {
            int initative;
            int initiativeModifier;
            string name;
            bool playerCharacter;

            public Character(int _initative, string _name)
            {
                initative = _initative;
                name = _name;
                playerCharacter = false;
                initiativeModifier = 0;
            }

            public Character(int _initative, string _name, bool isPC)
            {
                initative = _initative;
                name = _name;
                playerCharacter = isPC;
                initiativeModifier = 0;
            }


            public int Initiative
            {
                get
                {
                    return initative;
                }

                set
                {
                    initative = value;
                }
            }

            public int InitiativeModifier
            {
                get { return initiativeModifier; }
                set { initiativeModifier = value; }
            }

            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    name = value;
                }
            }

            public bool IsPlayerCharacter
            {
                get { return playerCharacter; }
                protected set { playerCharacter = value; }
            }

            public int CompareTo(object obj)
            {
                Character other = (Character)obj;

                if (this.initative < other.initative)
                    return 1;

                else if (this.initative == other.initative)
                    return 0;

                else
                    return -1;
            }

        }


        public int FindCharacterByName(string characterName)
        {
            foreach (Character character in characterList)
            {
                if (character.Name == characterName)
                {
                    return characterList.IndexOf(character);
                }
            }

            return -1;
        }

        public void DeleteCharacterWithGivenName(string characterName)
        {
            int index = FindCharacterByName(characterName);

            if (index == -1)
                throw new IndexOutOfRangeException();

            characterList.RemoveAt(index);
        }

        private void ListView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }

        //private void InitativeTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    bool didParse = Int32.TryParse(initativeTextBox.Text, out int parsed);

        //    if (!didParse)
        //    {
        //        enterButtonPC.Enabled = false;
        //        enterCharacterTemp.Enabled = false;
        //    }

        //    else
        //    {
        //        enterButtonPC.Enabled = true;
        //        enterCharacterTemp.Enabled = true;
        //    }
                
        //}

        private void EnterCharacterTemp_Click(object sender, EventArgs e)
        {
            
            Character newChar = new Character(0, nameTextBox.Text.Trim());

            characterList.Add(newChar);

            nameTextBox.Text = "";
            //initativeTextBox.Text = "";

            nameTextBox.Focus();

            RedrawItemBox();
        }

        private void EndCombatButton_Click(object sender, EventArgs e)
        {
            ArrayList removeList = new ArrayList();

            foreach (Character character in characterList)
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
                characterList.Remove(character);
            }

            RedrawItemBox();
        }

        private void InitativeButton_Click(object sender, EventArgs e)
        {
            //ArrayList removeList = new ArrayList();
            //ArrayList addList = new ArrayList();
            Random rnd = new Random();
            if (checkBoxRollNonPc.Checked)
            {
                foreach (Character character in characterList)
                {
                    if (character.IsPlayerCharacter)
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

                        int index = characterList.IndexOf(character);
                        int initiativeModifier = characterList[index].InitiativeModifier;

                        if (checkboxModForPCs.Checked)
                            parsed += initiativeModifier;

                        characterList[index].Initiative = parsed;

                    }

                    else
                    {
                        //removeList.Add(character);

                        
                        int num = rnd.Next(1, 21) + character.InitiativeModifier; // Rolls a d20 for npc.

                        int index = characterList.IndexOf(character);

                        ((Character)characterList[index]).Initiative = num;

                        //addList.Add(new Character(num, character.Name));
                    }
                }


            }

            else
            {
                foreach (Character character in characterList)
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

                    int index = characterList.IndexOf(character);
                    int initiativeModifier = characterList[index].InitiativeModifier;

                    if (character.IsPlayerCharacter)
                    {
                        if (checkboxModForPCs.Checked)
                        {
                            parsed += initiativeModifier;
                        }
                    }
                    else
                        parsed += initiativeModifier;

                    ((Character)characterList[index]).Initiative = parsed;

                }
            }

            RedrawItemBox();
        }

        private int ParseNameForModifier(string characterName)
        {
            if (Regex.IsMatch(characterName, "('+')[0-9]$"))
            {
                return Int32.Parse(characterName[characterName.Length - 1].ToString());
            }

            else if (Regex.IsMatch(characterName, "(-)[0-9]$"))
            {
                return Int32.Parse(characterName[characterName.Length - 1].ToString()) * -1;
            }

            else if (Regex.IsMatch(characterName, "[0-9]$"))
            {
                return Int32.Parse((characterName[characterName.Length - 1].ToString()));
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

                characterList[index].InitiativeModifier = newVal;
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
            int initiativeMod = characterList[index].InitiativeModifier;
            initiativeModifierUpDown.Value = initiativeMod;
        }

        private void InitiativeModifierUpDown_ValueChanged(object sender, EventArgs e)
        {
            SelectedListViewItemCollection characters = listView.SelectedItems;

            foreach (ListViewItem character in characters)
            {
                int index = FindCharacterByName(character.Text);

                characterList[index].InitiativeModifier = Int32.Parse(initiativeModifierUpDown.Value.ToString());
            }
        }

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

            //try
            //{
                using (XmlWriter writer = XmlWriter.Create(filename, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("initiative-tracker");
                    // Write the version attribute.
                    //writer.WriteAttributeString("version", Version);

                    // write the cells themselves
                    foreach (Character c in characterList)
                    {
                        writer.WriteStartElement("character");
                        writer.WriteAttributeString("name", c.Name);

                    //writer.WriteStartElement("initiative");
                    //writer.WriteString(c.Initiative.ToString());
                    //writer.WriteEndElement();

                    writer.WriteAttributeString("initiative", c.Initiative.ToString());

                    //writer.WriteStartElement("initiative-modifier");
                    //writer.WriteString(c.InitiativeModifier.ToString());
                    //writer.WriteEndElement();

                    writer.WriteAttributeString("initiative-modifier", c.InitiativeModifier.ToString());

                    //writer.WriteStartElement("player-characer");
                    //writer.WriteString(c.IsPlayerCharacter.ToString());
                    //writer.WriteEndElement();

                    writer.WriteAttributeString("player-character", c.IsPlayerCharacter.ToString());

                        writer.WriteEndElement();

                    }
                        

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }

                //Changed = false;

            //}
            //catch (ArgumentNullException)
            //{
            //    throw new ReadWriteException("The file name, and the version, must not be null.");
            //}
            //catch (Exception)
            //{
            //    throw new SpreadsheetReadWriteException("There was an error when saving the file.");
            //}
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();

            characterList.Clear();

            if (openFileDialog.FileName != "")
            {

                XmlReader reader = XmlReader.Create(openFileDialog.FileName);
                string characterName = "";
                int initiative = 0;
                int initiativeModifier = 0;
                bool isPC = false;
                int fieldsChanged = 0;

                while (reader.Read())
                {
                    //characterName = "";
                    //isPC = false;
                    //initiative = 0;
                    //initiativeModifier = 0;

                    if (reader.IsStartElement())
                    {
                        //switch (reader.Name)
                        //{
                        //case "character":
                        //    characterName = reader["name"];
                        //    fieldsChanged++;
                        //    break;

                        //case "initiative":
                        //    //reader.Read();
                        //    //reader.Read();
                        //    //reader.Read();

                        //    initiative = Int32.Parse(reader["initiative"]);
                        //    fieldsChanged++;
                        //    break;

                        //case "initiative-modifier":
                        //    //reader.Read();
                        //    //reader.Read();
                        //    //reader.Read();

                        //    initiativeModifier = Int32.Parse(reader["initiative-modifier"]);
                        //    fieldsChanged++;
                        //    break;

                        //case "player-character":
                        //    //reader.Read();

                        //    if (reader["player-character"] == "True")
                        //        isPC = true;

                        //    else
                        //        isPC = false;

                        //    fieldsChanged++;
                        //    break;

                        //}

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
                        

                        //if (fieldsChanged == 4)
                        //{
                        //    AddCharacterToList(characterName, initiative, initiativeModifier, isPC);
                        //    fieldsChanged = 0;
                        //}
                            
                    }
                }

                RedrawItemBox();
            }
        }
    }
}
