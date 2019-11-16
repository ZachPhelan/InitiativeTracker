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
using static InitiativeTracker.initiativeForm;

namespace InitiativeTracker
{
    public partial class StatusEffectForm : Form
    {
        Character currentCharacter;
        public StatusEffectForm()
        {
            InitializeComponent();

            currentCharacter = GlobalData.characterList[GlobalData.currentCharacterForStatusEffects];

            this.Text = currentCharacter.Name + "'s Status Effects";

            characterLabel.Text = currentCharacter.Name;

            List<string> checkBoxesToUpdate = new List<string>();
            int exhaustionValue = 0;

            foreach (KeyValuePair<string, int> status in currentCharacter.StatusEffects)
            {
                if (status.Value > 0)
                {
                    checkBoxesToUpdate.Add(status.Key);
                    if (status.Key == "Exhaustion")
                        exhaustionValue = status.Value;
                }
            }

            foreach (string item in checkBoxesToUpdate)
            {
                switch (item)
                {
                    case "Blinded":
                        blindedCheckBox.Checked = true;
                        break;

                    case "Charmed":
                        charmedCheckBox.Checked = true;
                        break;

                    case "Deafened":
                        deafenedCheckBox.Checked = true;
                        break;

                    case "Frightened":
                        frightenedCheckBox.Checked = true;
                        break;

                    case "Grappled":
                        grappledCheckBox.Checked = true;
                        break;

                    case "Incapacitated":
                        incapcitatedCheckBox.Checked = true;
                        break;

                    case "Invisible":
                        invisibleCheckBox.Checked = true;
                        break;

                    case "Paralyzed":
                        paralyzedCheckBox.Checked = true;
                        break;

                    case "Petrified":
                        petrifiedCheckBox.Checked = true;
                        break;

                    case "Poisoned":
                        poisonedCheckBox.Checked = true;
                        break;

                    case "Prone":
                        proneCheckBox.Checked = true;
                        break;

                    case "Restrained":
                        restrainedCheckBox.Checked = true;
                        break;

                    case "Stunned":
                        stunnedCheckBox.Checked = true;
                        break;

                    case "Unconscious":
                        unconsciousCheckBox.Checked = true;
                        break;
                    //.....

                    case "Exhaustion":
                        CheckMultipleBoxes(exhaustionValue);
                        break;
                }
            }


            // Tooltips for Status Effects

            //toolTip1.SetToolTip(Control blindedLabel, "hey");
            //toolTip2.t


            
        }

        private void BlindedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (blindedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Blinded", newValue);
        }

        private void ExhaustionCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            int exhaustionLevel = currentCharacter.StatusEffects["Exhaustion"];
            if (exhaustionLevel == 0)
            {
                currentCharacter.changeStatusEffect("Exhaustion", 1);
            }

            else
            {
                currentCharacter.changeStatusEffect("Exhaustion", 1);
            }

            if (exhaustionCheckBox1.Checked)
            {

            }

            else
            {
                UncheckHigherBoxes(1);
            }

        }

        private void ExhaustionCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (exhaustionCheckBox2.Checked)
            {
                currentCharacter.changeStatusEffect("Exhaustion", 2);
                CheckMultipleBoxes(2);

                currentCharacter.StatusEffects["Exhaustion"] = 2;
            }

            else
            {
                UncheckHigherBoxes(2);
                currentCharacter.StatusEffects["Exhaustion"] = 1;
            }

        }

        private void ExhaustionCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (exhaustionCheckBox3.Checked)
            {
                currentCharacter.changeStatusEffect("Exhaustion", 3);

                CheckMultipleBoxes(3);

                currentCharacter.StatusEffects["Exhaustion"] = 3;
            }

            else
            {
                UncheckHigherBoxes(3);

                currentCharacter.StatusEffects["Exhaustion"] = 2;
            }

        }

        private void ExhaustionCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (exhaustionCheckBox4.Checked)
            {
                currentCharacter.changeStatusEffect("Exhaustion", 4);

                CheckMultipleBoxes(4);

                currentCharacter.StatusEffects["Exhaustion"] = 4;
            }

            else
            {
                UncheckHigherBoxes(4);

                currentCharacter.StatusEffects["Exhaustion"] = 3;
            }

        }

        private void ExhaustionCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (exhaustionCheckBox5.Checked)
            {
                currentCharacter.changeStatusEffect("Exhaustion", 5);

                CheckMultipleBoxes(5);

                currentCharacter.StatusEffects["Exhaustion"] = 5;
            }

            else
            {
                UncheckHigherBoxes(5);
                currentCharacter.StatusEffects["Exhaustion"] = 4;
            }

        }

        private void ExhaustionCheckBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (exhaustionCheckBox6.Checked)
            {
                currentCharacter.changeStatusEffect("Exhaustion", 6);

                CheckMultipleBoxes(6);

                currentCharacter.StatusEffects["Exhaustion"] = 6;
            }

            else
            {
                UncheckHigherBoxes(6);

                currentCharacter.StatusEffects["Exhaustion"] = 5;
            }

        }


        private void CheckMultipleBoxes(int num)
        {
            while (num > 0)
            {
                if (num == 1)
                {
                    exhaustionCheckBox1.Checked = true;
                    num--;
                }
                    

                else if (num == 2)
                {
                    exhaustionCheckBox2.Checked = true;
                    num--;
                }
                    

                else if (num == 3)
                {
                    exhaustionCheckBox3.Checked = true;
                    num--;
                }
                    

                else if (num == 4)
                {
                    exhaustionCheckBox4.Checked = true;
                    num--;
                }
                    

                else if (num == 5)
                {
                    exhaustionCheckBox5.Checked = true;
                    num--;
                }
                    

                else
                {
                    exhaustionCheckBox6.Checked = true;
                    num--;
                }
            }
            
        }

        private void UncheckHigherBoxes(int num)
        {
            while (num < 7)
            {
                if (num == 1)
                {
                    exhaustionCheckBox1.Checked = false;
                    num++;
                }


                else if (num == 2)
                {
                    exhaustionCheckBox2.Checked = false;
                    num++;
                }


                else if (num == 3)
                {
                    exhaustionCheckBox3.Checked = false;
                    num++;
                }


                else if (num == 4)
                {
                    exhaustionCheckBox4.Checked = false;
                    num++;
                }


                else if (num == 5)
                {
                    exhaustionCheckBox5.Checked = false;
                    num++;
                }


                else
                {
                    exhaustionCheckBox6.Checked = false;
                    num++;
                }
            }

        }

        private void CharmedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (charmedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Charmed", newValue);
        }

        private void DeafenedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (deafenedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Deafened", newValue);
        }

        private void FrightenedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (frightenedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Frightened", newValue);
        }

        private void GrappledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (grappledCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Grappled", newValue);
        }

        private void IncapcitatedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (incapcitatedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Incapacitated", newValue);
        }

        private void InvisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (invisibleCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Invisible", newValue);
        }

        private void ParalyzedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (paralyzedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Paralyzed", newValue);
        }

        private void PetrifiedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (petrifiedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Petrified", newValue);
        }

        private void PoisonedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (poisonedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Poisoned", newValue);
        }

        private void ProneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (proneCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Prone", newValue);
        }

        private void RestrainedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (restrainedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Restrained", newValue);
        }

        private void StunnedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (stunnedCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Stunned", newValue);
        }

        private void UnconsciousCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            if (unconsciousCheckBox.Checked)
                newValue = 1;

            currentCharacter.changeStatusEffect("Unconscious", newValue);
        }

    }
}
