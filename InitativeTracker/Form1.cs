using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListView;

namespace InitativeTracker
{
    public partial class initativeForm : Form
    {

        ArrayList characterList;
  
        bool initativeOn = false;

        public initativeForm()
        {
            InitializeComponent();

            characterList = new ArrayList();

            

            characterList.Add(new Character(10, "Galadan", true));
            characterList.Add(new Character(5, "NPC"));

            characterList.Add(new Character(15, "Rosi", true));

            characterList.Add(new Character(20, "Onru", true));

            RedrawItemBox();

        }


        private void EnterButton_Click(object sender, EventArgs e)
        {
            //bool didParse = Int32.TryParse(initativeTextBox.Text, out int parsed);
            
            //if (!didParse)
            //{
            //    MessageBox.Show("Entered initiatve must be an integer.");
            //    return;
            //}

            Character newChar = new Character(0, nameTextBox.Text.Trim(), true);

            characterList.Add(newChar);

            nameTextBox.Text = "";
            //initativeTextBox.Text = "";

            nameTextBox.Focus();

            RedrawItemBox();

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
                        return;
                    }

                    MessageBox.Show("Entered initiatve must be an integer.");
                    return;
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

        /// <summary>
        ///  
        /// </summary>
        /// <returns>An ArrayList if iniativeOn is set to true. Otherwise, return null. This should allow me to easily update the item box when
        /// changing intiative.</returns>
        private void RedrawItemBox()
        {
            characterList.Sort();
            listView.Items.Clear();

            

            foreach (Character character in characterList)
            {
                string[] items = new string[] { character.Name.ToString(), character.Initative.ToString() };
                ListViewItem item = new ListViewItem(items);
                listView.Items.Add(item);
                
            }
        }


        public class Character : IComparable
        {
            int initative;
            int initativeModifier;
            string name;
            bool playerCharacter;

            public Character(int _initative, string _name)
            {
                initative = _initative;
                name = _name;
                playerCharacter = false;
                initativeModifier = 0;
            }

            public Character(int _initative, string _name, bool isPC)
            {
                initative = _initative;
                name = _name;
                playerCharacter = isPC;
                initativeModifier = 0;
            }


            public int Initative
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

            public int InitativeModifier
            {
                get { return initativeModifier; }
                set { initativeModifier = value; }
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
                    character.Initative = 0;
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
                        int initativeModifier = ((Character)characterList[index]).InitativeModifier;

                        ((Character)characterList[index]).Initative = parsed + initativeModifier;

                    }

                    else
                    {
                        //removeList.Add(character);

                        
                        int num = rnd.Next(1, 21) + character.InitativeModifier; // Rolls a d20 for npc.

                        int index = characterList.IndexOf(character);

                        ((Character)characterList[index]).Initative = num;

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
                    int initativeModifier = ((Character)characterList[index]).InitativeModifier;

                    ((Character)characterList[index]).Initative = parsed + initativeModifier;

                }
            }

            //foreach (Character character in removeList)
            //{
            //    characterList.Remove(character);
            //}

            //foreach (Character character in addList)
            //{
            //    characterList.Add(character);
            //}

            RedrawItemBox();
        }
    }
}
