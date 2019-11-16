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

namespace InitiativeTracker
{
    public partial class CombatForm : Form
    {

        Action<bool> ShowAllMain;

        Character currentCharacter;

        int roundNum;

        public CombatForm(Action<bool> Show)
        {
            InitializeComponent();

            currentCharacter = GlobalData.characterList[GlobalData.combatIndex];

            //GlobalData.combatIndex = 1;

            currentCharacterLabel.Text = currentCharacter.Name;
            UpdateList(currentCharacter);

            currentHealthLabel.Text = currentCharacter.currentHP.ToString();
            maxHealthLabel.Text = currentCharacter.maxHP.ToString();
            tempHealthLabelVal.Text = currentCharacter.tempHP.ToString();

            ShowAllMain = Show;

            VerticalScroll.Enabled = false;
            VerticalScroll.Visible = false;
            HorizontalScroll.Enabled = false;

            roundNum = GlobalData.roundNum;

            roundNumberLabel.Text = roundNum.ToString();

            if (GlobalData.characterList.Count > 2)
            {
                nextCharacterLabel.Text = GlobalData.characterList[1].Name;
            }

            else
            {
                nextCharacterLabel.Text = "None";
            }
            
        }

        private void endTurnButton_Click(object sender, EventArgs e)
        {
            GlobalData.combatIndex++;

            if (GlobalData.combatIndex >= GlobalData.characterList.Count)
            {
                GlobalData.combatIndex = 0;

                GlobalData.roundNum++;
                roundNum++;
                roundNumberLabel.Text = roundNum.ToString();
            }

            if (GlobalData.combatIndex + 1 >= GlobalData.characterList.Count)
            {
                nextCharacterLabel.Text = GlobalData.characterList[0].Name;
            }

            else
                nextCharacterLabel.Text = GlobalData.characterList[GlobalData.combatIndex + 1].Name;


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

        private void changeHPButton_Click(object sender, EventArgs e)
        {
            int value = (int)changeHPUpDown.Value;
            damageOrHeal(value);
        }

        private void hurtButton_Click(object sender, EventArgs e)
        {
            int value = (int)changeHPUpDown.Value * -1;
            damageOrHeal(value);
        }

        private void damageOrHeal(int val)
        {
            if (val > 0)
            {
                currentCharacter.currentHP += val;
            }

            else
            {
                int change = currentCharacter.tempHP + val;

                if (change < 0)
                {
                    currentCharacter.currentHP += change;
                    currentCharacter.tempHP = 0;
                }

                else
                {
                    currentCharacter.tempHP = change;
                }
            }


            if (currentCharacter.currentHP > currentCharacter.maxHP)
                currentCharacter.currentHP = currentCharacter.maxHP;

            if (currentCharacter.currentHP < 0)
            {
                currentCharacter.currentHP = 0;
            }

            currentHealthLabel.Text = currentCharacter.currentHP.ToString();
            tempHealthLabelVal.Text = currentCharacter.tempHP.ToString();

            changeHPUpDown.Value = 0;
        }

        private void UpdateStatusButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            GlobalData.currentCharacterForStatusEffects = GlobalData.combatIndex;

            Character currentCharacter = GlobalData.characterList[GlobalData.combatIndex];

            using (StatusEffectForm form = new StatusEffectForm())
            {
                form.ShowDialog();

                this.Enabled = true;

                UpdateList(currentCharacter);
            }

        }

    }
}
