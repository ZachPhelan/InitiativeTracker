using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitativeTracker
{
    public class Character : IComparable
    {
        int initative;
        int initiativeModifier;
        string name;
        bool playerCharacter;
        Dictionary<string, int> statusEffects;

        public Character(int _initative, string _name)
        {
            initative = _initative;
            name = _name;
            playerCharacter = false;
            initiativeModifier = 0;
            initializeStatusEffects();
        }

        public Character(int _initative, string _name, bool isPC)
        {
            initative = _initative;
            name = _name;
            playerCharacter = isPC;
            initiativeModifier = 0;
            initializeStatusEffects();
        }

        public Character(int _initative, int _modifier, string _name, bool isPC)
        {
            initative = _initative;
            name = _name;
            playerCharacter = isPC;
            initiativeModifier = _modifier;
            initializeStatusEffects();
        }

        private void initializeStatusEffects()
        {
            statusEffects = new Dictionary<string, int>();
            statusEffects.Add("Blinded", 0);
            statusEffects.Add("Charmed", 0);
            statusEffects.Add("Deafened", 0);
            statusEffects.Add("Frightened", 0);
            statusEffects.Add("Grappled", 0);
            statusEffects.Add("Incapacitated", 0);
            statusEffects.Add("Invisible", 0);
            statusEffects.Add("Paralyzed", 0);
            statusEffects.Add("Petrified", 0);
            statusEffects.Add("Poisoned", 0);
            statusEffects.Add("Prone", 0);
            statusEffects.Add("Restrained", 0);
            statusEffects.Add("Stunned", 0);
            statusEffects.Add("Unconcious", 0);
            statusEffects.Add("Exhaustion", 0);
            statusEffects.Add("Other", 0);

        }

        public Dictionary<string, int> StatusEffects
        {
            get { return statusEffects; }
            protected set { statusEffects = value; }
        }

        public void changeStatusEffect(string statusToChange, int value)
        {
            statusEffects[statusToChange] = value;
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
}
