using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InitiativeTracker;

namespace InitativeTracker
{
    public partial class CombatForm : Form
    {

        Action<bool> ShowAllMain;

        Character currentCharacter;

        //public CombatForm()
        //{
        //    InitializeComponent();

        //    GlobalData.currentCombatCharacter = GlobalData.characterList[0];

        //    //GlobalData.combatIndex = 1;

        //    currentCharacterLabel.Text = GlobalData.currentCombatCharacter.Name;

        //    UpdateList();
        //}
        public CombatForm(Action<bool> Show)
        {
            InitializeComponent();

            currentCharacter = GlobalData.characterList[GlobalData.combatIndex];

            //GlobalData.combatIndex = 1;

            currentCharacterLabel.Text = currentCharacter.Name;
            UpdateList(currentCharacter);

            currentHealthLabel.Text = currentCharacter.currentHP.ToString();
            maxHealthLabel.Text = currentCharacter.maxHP.ToString();

            ShowAllMain = Show;

            VerticalScroll.Enabled = false;
            VerticalScroll.Visible = false;
            HorizontalScroll.Enabled = false;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GlobalData.combatIndex++;

            if (GlobalData.combatIndex >= GlobalData.characterList.Count)
            {
                GlobalData.combatIndex = 0;
            }

            currentCharacter = GlobalData.characterList[GlobalData.combatIndex];

            currentCharacterLabel.Text = currentCharacter.Name;
            currentHealthLabel.Text = currentCharacter.currentHP.ToString();
            maxHealthLabel.Text = currentCharacter.maxHP.ToString();

            UpdateList(currentCharacter);
        }

        private void EndCombatButton_Click(object sender, EventArgs e)
        {

            if (ShowAllMain != null)
                ShowAllMain.Invoke(true);

            this.Close();
        }

        private void UpdateList(Character currentCharacter)
        {
            listView1.Items.Clear();

            List<string> tempList = new List<string>();

            foreach (KeyValuePair<string, int> status in currentCharacter.StatusEffects)
            {
                if (status.Value > 0)
                {
                    listView1.Items.Add(status.Key);
                }
            }

            

        }
    }
}
