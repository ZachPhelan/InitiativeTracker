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
    public partial class HPForm : Form
    {
        Character character;

        public HPForm(Character _character)
        {
            InitializeComponent();

            character = _character;

            currentHPUpDown.Value = character.currentHP;

            maxHPUpDown.Value = character.maxHP;

            TempHPUpDown.Value = character.tempHP;
        }

        private void CurrentHPUpDown_ValueChanged(object sender, EventArgs e)
        {
            int currentNum = Int32.Parse(currentHPUpDown.Value.ToString());
            int maxNum = Int32.Parse(maxHPUpDown.Value.ToString());

            if (currentNum > maxNum)
            {
                character.maxHP = currentNum;
                maxHPUpDown.Value = currentNum;
            }


            character.currentHP = currentNum;
        }

        private void MaxHPUpDown_ValueChanged(object sender, EventArgs e)
        {
            int currentNum = Int32.Parse(currentHPUpDown.Value.ToString());
            int maxNum = Int32.Parse(maxHPUpDown.Value.ToString());

            if (currentNum > maxNum)
            {
                character.currentHP = maxNum;
                currentHPUpDown.Value = maxNum;
            }


            character.maxHP = maxNum;
        }

        private void TempHPUpDown_ValueChanged(object sender, EventArgs e)
        {
            int tempNum = Int32.Parse(TempHPUpDown.Value.ToString());

            if (tempNum < 0)
                tempNum = 0;

            character.tempHP = tempNum;

        }
    }
}
