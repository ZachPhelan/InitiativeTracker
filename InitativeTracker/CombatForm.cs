using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InitativeTracker
{
    public partial class CombatForm : Form
    {
        public CombatForm()
        {
            InitializeComponent();

            GlobalData.currentCombatCharacter = GlobalData.characterList[0];

            //GlobalData.combatIndex = 1;

            currentCharacterLabel.Text = GlobalData.currentCombatCharacter.Name;

            UpdateList();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GlobalData.combatIndex++;

            if (GlobalData.combatIndex >= GlobalData.characterList.Count)
            {
                GlobalData.combatIndex = 0;
            }

            GlobalData.currentCombatCharacter = GlobalData.characterList[GlobalData.combatIndex];

            currentCharacterLabel.Text = GlobalData.currentCombatCharacter.Name;

            UpdateList();
        }

        private void EndCombatButton_Click(object sender, EventArgs e)
        {
            GlobalData.combatOn = false;



            this.Close();
        }

        private void UpdateList()
        {
            listView1.Items.Clear();

            List<string> tempList = new List<string>();
            StringBuilder sb = new StringBuilder();

            foreach (KeyValuePair<string, int> status in GlobalData.currentCombatCharacter.StatusEffects)
            {
                if (status.Value > 0)
                {
                    listView1.Items.Add(status.Key);
                }
            }

            

        }
    }
}
