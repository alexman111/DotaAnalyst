using System;
using System.Collections.Generic;
using System.Text;

namespace DotaAnalyst
{
    class BannedHeroes
    {
        private static List<DotaHero> banned = new List<DotaHero>();

        public static bool canDraw = false;
        public static void Clear()
        {
            banned.Clear();
        }
        public static void Add(DotaHero Hero)
        {
            banned.Add(Hero);
        }
        public static int Size()
        {
            return banned.Count;
        }
        public static bool Contains(DotaHero Hero)
        {
            for (int i = 0; i < banned.Count; ++i) if (banned[i].Name == Hero.Name) return true;
            return false;
        }
        public static DotaHero LastElement()
        {
            return banned[banned.Count - 1];
        }
    }
}
