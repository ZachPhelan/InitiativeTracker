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

            
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            character.currentHP = Int32.Parse(currentHPUpDown.Value.ToString());
        }

        private void MaxHPUpDown_ValueChanged(object sender, EventArgs e)
        {
            character.maxHP = Int32.Parse(maxHPUpDown.Value.ToString());
        }

        private void HPForm_Load(object sender, EventArgs e)
        {

        }
    }
}
