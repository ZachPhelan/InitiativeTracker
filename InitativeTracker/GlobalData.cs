using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitativeTracker
{
    public class GlobalData
    {
        public static List<Character> characterList;

        public static int currentCharacterForStatusEffects;

        public static Character currentCombatCharacter;

        public static int combatIndex;

        public static bool combatOn;

        public static int roundNum;
    }
}
