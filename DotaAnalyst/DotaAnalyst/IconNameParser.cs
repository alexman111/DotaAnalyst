using System;
using System.Collections.Generic;
using System.Text;

namespace DotaAnalyst
{
    class IconNameParser
    {
        public static string Parse(string HeroName)
        {
            if (HeroName.Length >= 4)
            {
                if (HeroName.Substring(0, 4) == "User")
                {
                    return UserHeroes.getImageByName(HeroName);
                }
            }
            if (HeroName == "Anti-Mage") return "AntiMage_icon.png";
            if (HeroName == "Nature's Prophet") return "Natures_Prophet_icon.png";
           
            string newHero = HeroName.Replace(' ', '_');

            return newHero + "_icon.png";
        }
    }
}
