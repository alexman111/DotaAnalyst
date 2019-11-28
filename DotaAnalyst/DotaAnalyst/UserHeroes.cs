using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace DotaAnalyst
{
    class UserHeroes
    {
        private static List<Tuple<string, string, string> > heroes = new List<Tuple<string, string, string> >();

        public static void Add(string img, string name, int attributeNumber)
        {
            string attr;
            if (attributeNumber == 0) attr = "agi";
            else if (attributeNumber == 1) attr = "str";
            else attr = "int";
            heroes.Add(new Tuple<string, string, string>(img, "User" + name, attr));
        }

        public static void Clear()
        {
            heroes.Clear();
        }
       
        public static int Size()
        {
            return heroes.Count;
        } 
        public static string getName(int index)
        {
            return heroes[index].Item2;
        }
        public static string getAttribute(int index)
        {
            return heroes[index].Item3;
        }
        public static string getImage(int index)
        {
            return heroes[index].Item1;
        }
        public static string getImageByName(string name)
        {
            for (int i = 0; i < heroes.Count; ++i) if (heroes[i].Item2 == name) return heroes[i].Item1;
            return heroes[0].Item1;
        }
        public static bool Contains(string name)
        {
            for (int i = 0; i < Size(); ++i) if (getName(i) == "User" + name) return true;
            return false;
        }
    }
}
